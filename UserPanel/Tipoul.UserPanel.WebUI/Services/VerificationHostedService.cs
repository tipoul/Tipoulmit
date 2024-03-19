using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Framework.Services.Shaparak.Models;
using Tipoul.UserPanel.WebUI.Services.Models.VerificationService;
using Tipoul.Framework.Services.Shaparak.Models.Enums;

namespace Tipoul.UserPanel.WebUI.Services
{
    public class VerificationHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        private static readonly object verificationModelsLockObject = new object();

        private static readonly List<VerificationModel> verificationModels = new List<VerificationModel>();

        public VerificationHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public static void Register(int userId)
        {
            lock (verificationModelsLockObject)
            {
                verificationModels.Add(new VerificationModel { UserId = userId });
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Verify();

            return Task.CompletedTask;
        }

        private async void Verify()
        {
            var localUserIds = new List<int>(verificationModels.Select(f => f.UserId));
            foreach (var userId in localUserIds)
            {
#if DEBUG
                await
#endif
                Task.Run(async () =>
                {
                    lock (verificationModelsLockObject)
                    {
                        verificationModels.Remove(verificationModels.FirstOrDefault(f => f.UserId == userId));
                    }

                    using (var scope = serviceProvider.CreateAsyncScope())
                    {
                        var dbContext = scope.ServiceProvider.GetService<TipoulFrameworkDbContext>();

                        if (await dbContext.UserVerificationHistories.AnyAsync(f => f.UserId == userId && !f.DoneDate.HasValue))
                            return;

                        var userVerificationHistory = await AddUserVerificationHistoryAsync(userId, dbContext);

                        try
                        {
                            var shaparak = scope.ServiceProvider.GetService<Tipoul.Framework.Services.Shaparak.ShaparakService>();


                            var trakingNumberPsp = new Random().Next(1000000, 9999999).ToString();

                            var model = await GetShaparakModelAsync(userId, dbContext, trakingNumberPsp);

                            var result = await shaparak.CreateCustomerAndShopAsync(model, JsonSerializer.Serialize(new { userId, trakingNumberPsp, userVerificationHistoryId = userVerificationHistory.Id }), userId);

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
                });
            }


            await Task.Delay(TimeSpan.FromMinutes(5));
            Verify();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
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

        private static async Task<ShaparakRequestModel> GetShaparakModelAsync(int userId, TipoulFrameworkDbContext dbContext, string trakingNumberPsp)
        {
            var user = await dbContext.Users
                .Include(f => f.LegalProfile)
                .Include(f => f.BusinessSubCategory).ThenInclude(f => f.BusinessCategory)
                .Include(f => f.JobCity).ThenInclude(f => f.State)
                .FirstOrDefaultAsync(f => f.Id == userId);

            var merchantIbans = (await dbContext.BankAccounts.Where(f => f.UserId == userId).ToListAsync()).ConvertAll(f => new ShaparakMerchantIbanModel(f.Iban, "IBAN " + f.Id));

            var merchant = new ShaparakMerchantModel(user.FirstName, user.LastName, user.FatherName, "Tipoul", "Tipoul", "Tipoul", Gender.Mail, user.BirthDate.Value.ToTotalMilliseconds(), user.NationalCode, user.LegalProfile?.CompanyName,
                user.LegalProfile != null ? "Tipoul" : null, user.LegalProfile == null ? LegalityType.Personal : LegalityType.Legal, user.LegalProfile?.NatitonalCode, string.Empty, user.PhoneNumber, user.MobileNumber, user.Email, user.LegalProfile?.WebSiteURL, merchantIbans);

            var shop = new ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorShopModel("تیپول", "Tipoul", user.JobPhoneNumber, user.JobPostalCode, user.BusinessSubCategory.BusinessCategory.Code, user.BusinessSubCategory.Code.Substring(4),
                user.City.State.Code, user.City.Code, user.Email, "https://tipoul.com", user.TaxCode, true, 1);

            return new ShaparakRequestModel(trakingNumberPsp, merchant, new List<ShaparakRequestModel.ShaparakShopAcceptorModel>
            {
                new ShaparakRequestModel.ShaparakShopAcceptorModel(shop, new List<ShaparakRequestModel.ShaparakShopAcceptorModel.ShaparakShopAcceptorItemModel>())
            });
        }

        private static async Task<Framework.StorageModels.UserVerificationHistory> AddUserVerificationHistoryAsync(int userId, TipoulFrameworkDbContext dbContext)
        {
            var userVerificationHistory = new Framework.StorageModels.UserVerificationHistory
            {
                Type = Framework.StorageModels.UserVerificationHistory.VerificationType.Shaparak,
                UserId = userId,
                ServiceName = "CreateCustomerAndShopAsync"
            };

            dbContext.UserVerificationHistories.Add(userVerificationHistory);

            await dbContext.SaveChangesAsync();
            return userVerificationHistory;
        }
    }
}
