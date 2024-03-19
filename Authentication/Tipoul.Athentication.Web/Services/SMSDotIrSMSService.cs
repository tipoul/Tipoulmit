
using Microsoft.Extensions.Configuration;

using SmsIrRestfulNetCore;

using System;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;

namespace Tipoul.Athentication.Web.Services
{
    public class SMSDotIrSMSService
    {
        private readonly IConfiguration configuration;

        private readonly TipoulFrameworkDbContext dbContext;

        public SMSDotIrSMSService(IConfiguration configuration, TipoulFrameworkDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        public async Task SendVerificationCodeAsync(string phoneNumber, string verificationCode)
        {
            var smsLog = new Framework.StorageModels.SMSLog { PhoneNumber = phoneNumber, VerificationCode = verificationCode };

            dbContext.SMSLogs.Add(smsLog);
            await dbContext.SaveChangesAsync();

            try
            {
                var token = new Token().GetToken(configuration["sms.ir:ApiKey"], configuration["sms.ir:SecurityCode"]);

                smsLog.Token = token;
                await dbContext.SaveChangesAsync();

                var sendResult = new UltraFast().Send(token, new UltraFastSend
                {
                    Mobile = long.Parse(phoneNumber),
                    TemplateId = int.Parse(configuration["sms.ir:TemplateId"]),
                    ParameterArray = new[] { new UltraFastParameters { Parameter = "VerificationCode", ParameterValue = verificationCode } }
                });

                smsLog.IsSuccess = sendResult.IsSuccessful;
                smsLog.Message = sendResult.Message;
                smsLog.MessageId = sendResult.VerificationCodeId;
            }
            catch (Exception ex)
            {
                smsLog.ExceptionMessage = ex.Message;
            }
            finally
            {


                smsLog.Duration = DateTime.Now - smsLog.CreateDate;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
