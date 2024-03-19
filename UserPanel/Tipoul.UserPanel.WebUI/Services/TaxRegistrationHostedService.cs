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
using Tipoul.Framework.Services.ShaparakTax;
using Tipoul.Framework.Services.ShaparakTax.Models;
using Tipoul.Framework.StorageModels;

namespace Tipoul.UserPanel.WebUI.Services
{
    public class TaxRegistrationHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        private static readonly object userIdsListLockObject = new object();

        private static List<int> userIds = new List<int>();

        public TaxRegistrationHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public static void Register(int userId)
        {
            lock (userIdsListLockObject)
            {
                userIds.Add(userId);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            StartRegistering();

            return Task.CompletedTask;
        }

        private async void StartRegistering()
        {
            var localUserIds = new List<int>(userIds);
            foreach (var userId in localUserIds)
            {
                lock (userIdsListLockObject)
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

                        if (await dbContext.UserTaxRequestHistories.AnyAsync(f => f.UserId == userId && !f.Duration.HasValue))
                            return;

                        var taxReuqestHistory = new UserTaxRequestHistory
                        {
                            UserId = userId,
                            TrackingNumber = new Random().Next(1000000, 9999999).ToString()
                        };

                        dbContext.UserTaxRequestHistories.Add(taxReuqestHistory);
                        await dbContext.SaveChangesAsync();

                        var taxService = scope.ServiceProvider.GetService<ShaparakTaxService>();

                        var user = await dbContext.Users.Include(f => f.BusinessSubCategory).FirstOrDefaultAsync(f => f.Id == userId);

                        var registerModel = new RegisterModel
                        {
                            TaxpayerInfo = new RegisterInfoModel(user.BirthDate.Value)
                            {
                                MobileNumber = user.MobileNumber,
                                NationalID = user.NationalCode,
                                PostalCode = user.PostalCode,
                                TaxpayerBusinessName = user.BusinessSubCategory.Title,
                                Tel = user.PhoneNumber.Split("-")[1],
                                TelCode = user.PhoneNumber.Split("-")[0],
                                TrackingNumber = taxReuqestHistory.TrackingNumber
                            }
                        };

                        try
                        {
                            var registerResult = await taxService.RegisterAsync(registerModel, JsonSerializer.Serialize(new { userId, registerModel.TaxpayerInfo.TrackingNumber, userTaxRequestHistoriesId = taxReuqestHistory.Id }), userId);

                            taxReuqestHistory.ShahkarValid = registerResult.ShahkarValid ?? false;
                            taxReuqestHistory.ErrorMessage = registerResult.ErrorMessage;
                            taxReuqestHistory.ErrorCode = (int)registerResult.ErrorStatus;
                            taxReuqestHistory.FollowCode = registerResult.FollowCode;
                            taxReuqestHistory.TprId = registerResult.TprId;
                            taxReuqestHistory.ShaparakServiceLodId = registerResult.ServiceLogId;

                            await dbContext.SaveChangesAsync();

                            if (registerResult.ErrorStatus == Framework.Services.ShaparakTax.Models.RegisterResult.ErrorStatusType.Success)
                                await GetStatusAsync(dbContext, taxService, registerModel, JsonSerializer.Serialize(new { userId, registerModel.TaxpayerInfo.TrackingNumber, userTaxRequestHistoriesId = taxReuqestHistory.Id }), userId);
                        }
                        catch (Exception ex)
                        {
                            taxReuqestHistory.ErrorMessage = ex.Message;
                            taxReuqestHistory.ErrorCode = -1;
                        }
                        finally
                        {
                            taxReuqestHistory.Duration = DateTime.Now - taxReuqestHistory.CreateDate;

                            await dbContext.SaveChangesAsync();
                        }
                    }
                });
            }

            await Task.Delay(TimeSpan.FromMinutes(5));
            StartRegistering();
        }

        private async Task GetStatusAsync(TipoulFrameworkDbContext dbContext, ShaparakTaxService taxService, RegisterModel registerModel, string extraParamForLog, int userId)
        {
            var taxReuqestHistory = new UserTaxRequestHistory
            {
                UserId = userId,
                TrackingNumber = registerModel.TaxpayerInfo.TrackingNumber
            };

            dbContext.UserTaxRequestHistories.Add(taxReuqestHistory);

            await dbContext.SaveChangesAsync();

            var status = await taxService.GetStatusAsync(new Framework.Services.ShaparakTax.Models.GetStatusModel
            {
                NationalId = registerModel.TaxpayerInfo.NationalID,
                PostalCode = registerModel.TaxpayerInfo.PostalCode,
                TrackingNumber = registerModel.TaxpayerInfo.TrackingNumber
            }, extraParamForLog, userId);

            taxReuqestHistory.ErrorMessage = status.ErrorMessage;
            taxReuqestHistory.ErrorCode = (int)status.ErrorStatus;
            taxReuqestHistory.ErrorMessage = status.ErrorMessage;
            taxReuqestHistory.FollowCode = status.FollowCode;
            taxReuqestHistory.Duration = DateTime.Now - taxReuqestHistory.CreateDate;

            if (!string.IsNullOrWhiteSpace(status.FollowCode))
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(f => f.Id == userId);
                user.TaxCode = status.FollowCode;

                await dbContext.SaveChangesAsync();

                VerificationHostedService.Register(user.Id);
            }
            else
                await dbContext.SaveChangesAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
