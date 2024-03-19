using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.Sepehr;
using Tipoul.Framework.Services.Shaparak.Models;
using Tipoul.Framework.Services.Shaparak.Models.Enums;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.UserPanel.WebUI.Services
{
    public class CommertialGateWayRegistrationHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IConfiguration configuration;

        private static readonly object userIdsLockObject = new object();

        private static readonly List<int> userIds = new List<int>();

        public CommertialGateWayRegistrationHostedService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.configuration = configuration;
        }

        public static void Register(int userId)
        {
            lock (userIdsLockObject)
            {
                userIds.Add(userId);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            RegisterAsync();

            return Task.CompletedTask;
        }

        private async void RegisterAsync()
        {
            var localUserIds = new List<int>(userIds);

            foreach (var userId in localUserIds)
            {
                lock (userIdsLockObject)
                {
                    userIds.Remove(userId);
                }

#if DEBUG
                await
#endif
                Task.Run(async () =>
                {
                    using (var scope = serviceProvider.CreateAsyncScope())
                    {
                        var dbContext = scope.ServiceProvider.GetService<TipoulFrameworkDbContext>();

                        if (await dbContext.UserCommertialGateWayRegisterRequestLogs.AnyAsync(f => f.UserId == userId && !f.Duration.HasValue))
                            return;

                        var commertialGateWay = await dbContext.CommertialGateWays
                            .Include(f => f.BusinessSubCategory).ThenInclude(f => f.BusinessCategory)
                            .Include(f => f.CommertialGateWayStatuses)
                            .FirstOrDefaultAsync(f => f.Wallet.UserId == userId);

                        commertialGateWay.CommertialGateWayStatuses.Add(new Framework.StorageModels.CommertialGateWayStatus
                        {
                            UserId = userId,
                            Status = Framework.StorageModels.CommertialGateWayStatus.StatusType.Pending
                        });

                        var requestLog = new Framework.StorageModels.UserCommertialGateWayRegisterRequestLog
                        {
                            UserId = userId,
                            Service = Framework.StorageModels.UserCommertialGateWayRegisterRequestLog.ServiceType.Sepehr,
                            CommertialGateWayId = commertialGateWay.Id
                        };

                        dbContext.UserCommertialGateWayRegisterRequestLogs.Add(requestLog);

                        await dbContext.SaveChangesAsync();

                        var sepehrResult = /*!string.IsNullOrWhiteSpace(commertialGateWay.TerminalNumber) ||*/ await RegisterInSepehr(userId, scope, dbContext, commertialGateWay, requestLog);

                        if (sepehrResult)
                        {
                            var userVerificationHistory = await AddUserVerificationHistoryAsync(userId, dbContext);

                            try
                            {
                                var shaparak = scope.ServiceProvider.GetService<Tipoul.Framework.Services.Shaparak.ShaparakService>();


                                var trakingNumberPsp = new Random().Next(1000000, 9999999).ToString();

                                var model = await GetShaparakModelAsync(userId, dbContext, trakingNumberPsp, commertialGateWay);

                                var result = await shaparak.RequestNewGateWayAsync(model, JsonSerializer.Serialize(new { userId, trakingNumberPsp, userVerificationHistoryId = userVerificationHistory.Id }), userId);

                                userVerificationHistory.ShaparakRequestId = result.RequestLogId;

                                await dbContext.SaveChangesAsync();

                                if (result.Success)
                                    await GetStatusReport(userId, shaparak, trakingNumberPsp, result, userVerificationHistory, dbContext);
                                else
                                {
                                    userVerificationHistory.UserVerificationHistoryErrors.AddRange(result.RequestRejectionReasons.ConvertAll(f => new Framework.StorageModels.UserVerificationHistoryError
                                    {
                                        ErrorMessage = f.CodeExceptionValue.ToString(),
                                        FieldName = f.FieldName
                                    }));

                                    userVerificationHistory.DoneDate = DateTime.Now;

                                    await dbContext.SaveChangesAsync();
                                }
                            }
                            catch (Exception ex)
                            {
                                userVerificationHistory.UserVerificationHistoryErrors.Add(new Framework.StorageModels.UserVerificationHistoryError
                                {
                                    ErrorMessage = ex.Message,
                                    Description = ex.StackTrace,
                                    FieldName = ex.GetType().Name
                                });

                                userVerificationHistory.DoneDate = DateTime.Now;

                                await dbContext.SaveChangesAsync();
                            }
                        }

                        requestLog.Duration = DateTime.Now - requestLog.CreateDate;

                        await dbContext.SaveChangesAsync();
                    }
                });
            }


            await Task.Delay(TimeSpan.FromMinutes(5));
            RegisterAsync();
        }

        private static async Task GetStatusReport(int userId, Framework.Services.Shaparak.ShaparakService shaparak, string trakingNumberPsp, ShaparakRequestResult result, Framework.StorageModels.UserVerificationHistory userVerificationHistory, TipoulFrameworkDbContext dbContext)
        {
            var status = (await shaparak.GetStatusReportAsync(new ShaparakStatusReportModel { TrackingNumbers = new List<string> { result.TrackingNumber } }, JsonSerializer.Serialize(new { userId, trakingNumberPsp }), userId))
                                        .FirstOrDefault();

            if (status.Status == Status.Pending || status.Status == Status.Delaied || status.Status == Status.Processing)
            {
                await Task.Delay(TimeSpan.FromMinutes(10));

                await GetStatusReport(userId, shaparak, trakingNumberPsp, result, userVerificationHistory, dbContext);
            }
            else if (status.RequestRejectionReasons.Count > 0)
            {
                userVerificationHistory.UserVerificationHistoryErrors.AddRange(status.RequestRejectionReasons.ConvertAll(f => new Framework.StorageModels.UserVerificationHistoryError
                {
                    ErrorMessage = f.CodeExceptionValue.ToString(),
                    FieldName = f.FieldName
                }));

                userVerificationHistory.DoneDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
            }
            else
            {
                userVerificationHistory.DoneDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
            }
        }

        private async Task<ShaparakRequestModel> GetShaparakModelAsync(int userId, TipoulFrameworkDbContext dbContext, string trakingNumberPsp, Framework.StorageModels.CommertialGateWay commertialGateWay)
        {
            var user = await dbContext.Users
                .Include(f => f.LegalProfile)
                .Include(f => f.BusinessSubCategory).ThenInclude(f => f.BusinessCategory)
                .Include(f => f.JobCity).ThenInclude(f => f.State)
                .FirstOrDefaultAsync(f => f.Id == userId);

            var merchantIbans = (await dbContext.BankAccounts.Where(f => f.UserId == userId).ToListAsync()).ConvertAll(f => new ShaparakMerchantIbanModel(f.Iban, "IBAN " + f.Id));

            var merchant = new ShaparakMerchantModel(user.FirstName, user.LastName, user.FatherName, "Tipoul", "Tipoul", "Tipoul", Gender.Mail, user.BirthDate.Value.ToTotalMilliseconds(), user.NationalCode, user.LegalProfile?.CompanyName,
                user.LegalProfile != null ? "Tipoul" : null, user.LegalProfile == null ? LegalityType.Personal : LegalityType.Legal, user.LegalProfile?.NatitonalCode, string.Empty, user.PhoneNumber, user.MobileNumber, user.Email, user.LegalProfile?.WebSiteURL, merchantIbans);


            var shop = new ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorShopModel(commertialGateWay.Title, "Tipoul", commertialGateWay.SupportPhoneNumber, user.JobPostalCode, commertialGateWay.BusinessSubCategory.BusinessCategory.Code,
               commertialGateWay.BusinessSubCategory.Code.Substring(4), user.JobCity.State.Code, user.JobCity.Code, user.Email, commertialGateWay.WebSiteURL, user.TaxCode,false,0);


            //var shop = new ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorShopModel(commertialGateWay.Title, "Tipoul", commertialGateWay.SupportPhoneNumber, user.JobPostalCode, commertialGateWay.BusinessSubCategory.BusinessCategory.Code,
            //    commertialGateWay.BusinessSubCategory.Code.Substring(4), user.JobCity.State.Code, user.JobCity.Code, user.Email, commertialGateWay.WebSiteURL, user.TaxCode, commertialGateWay.HasETrust, commertialGateWay.ETrustStarsCount);

            var terminals = new List<ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorItemModel.ShaparakShopAcceptorItemTerminalModel>
            {
                new ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorItemModel.ShaparakShopAcceptorItemTerminalModel(commertialGateWay.TerminalNumber, commertialGateWay.WebSiteURL, commertialGateWay.WebSiteURL)
            };

            return new ShaparakRequestModel(trakingNumberPsp, merchant, new List<ShaparakRequestModel.ShaparakShopAcceptorModel>
            {
                new ShaparakRequestModel.ShaparakShopAcceptorModel(shop, new List<ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorItemModel>
                {
                    new ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorItemModel("581672121", commertialGateWay.MerchantNumber, "594808737200024", terminals, merchantIbans.Select(f => f.MerchantIban).ToList())
                })
            });
        }


        private static async Task<Framework.StorageModels.UserVerificationHistory> AddUserVerificationHistoryAsync(int userId, TipoulFrameworkDbContext dbContext)
        {
            var userVerificationHistory = new Framework.StorageModels.UserVerificationHistory
            {
                Type = Framework.StorageModels.UserVerificationHistory.VerificationType.Shaparak,
                UserId = userId,
                ServiceName = "RequestNewGateWayAsync"
            };

            dbContext.UserVerificationHistories.Add(userVerificationHistory);

            await dbContext.SaveChangesAsync();
            return userVerificationHistory;
        }

        private async Task<bool> RegisterInSepehr(int userId, AsyncServiceScope scope, TipoulFrameworkDbContext dbContext, Framework.StorageModels.CommertialGateWay commertialGateWay, Framework.StorageModels.UserCommertialGateWayRegisterRequestLog requestLog)
        {
            try
            {
                var sepehr = scope.ServiceProvider.GetService<SepehrService>();

                var sepehrLoginResult = await sepehr.LoginAsync(JsonSerializer.Serialize(new { userId }));

                requestLog.SepehrLoginId = sepehrLoginResult.Id;
                requestLog.SepehrLoginUserName = sepehrLoginResult.UserName;
                requestLog.Token = sepehrLoginResult.JwtToken;

                await dbContext.SaveChangesAsync();

                var sepehrRegisterModel = new Framework.Services.Sepehr.Models.RequestModel
                {
                    IsAllow = true,
                    PayType = Framework.Services.Sepehr.Models.RequestModel.PaymentType.Web,
                    MerchantNumber = configuration["sepehr:MerchantNumber"],
                    FetchPanEnable = true,
                    SubBusinessCategoryCode = commertialGateWay.BusinessSubCategory.BusinessCategory.Code,
                    WebSiteName = commertialGateWay.Title,
                    WebSiteUrl = commertialGateWay.WebSiteURL,
                    Base64Img = string.IsNullOrWhiteSpace(commertialGateWay.LogoUrl) ? null : Convert.ToBase64String(File.ReadAllBytes(configuration["FileManagerPath"] + commertialGateWay.LogoUrl)),
                    Ips = new List<string> { configuration["Tipoul:ServerIp"] }
                };

                var sepehrRegisterResult = await sepehr.RegisterAsync(sepehrRegisterModel, JsonSerializer.Serialize(new { userId }), sepehrLoginResult.JwtToken);

                if (!sepehrRegisterResult.IsSuccess)
                {
                    requestLog.ErrorCode = sepehrRegisterResult.ErrorCode;
                    requestLog.ErrorMessage = sepehrRegisterResult.Message;

                    commertialGateWay.CommertialGateWayStatuses.Add(new Framework.StorageModels.CommertialGateWayStatus
                    {
                        Status = Framework.StorageModels.CommertialGateWayStatus.StatusType.Rejected,
                        UserId = userId,
                        Description = $"{sepehrRegisterResult.ErrorCode} => {sepehrRegisterResult.Message}"
                    });
                }
                else
                {
                    requestLog.TerminalNumber = sepehrRegisterResult.Data.TerminalNumber;
                    requestLog.MerchantNumber = sepehrRegisterResult.Data.MerchantNumber;
                    commertialGateWay.TerminalNumber = sepehrRegisterResult.Data.TerminalNumber;
                    commertialGateWay.MerchantNumber = sepehrRegisterResult.Data.MerchantNumber;

                    commertialGateWay.CommertialGateWayStatuses.Add(new Framework.StorageModels.CommertialGateWayStatus
                    {
                        Status = Framework.StorageModels.CommertialGateWayStatus.StatusType.Accepted,
                        UserId = userId
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                requestLog.ErrorCode = -1;
                requestLog.ErrorMessage = ex.Message;

                return false;
            }
            finally
            {
                requestLog.Duration = DateTime.Now - requestLog.CreateDate;

                await dbContext.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
