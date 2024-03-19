using Kavenegar;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Framework.StorageModels;

namespace Tipoul.Athentication.Web.Services
{
    public class KavenegarSMSService
    {
        private readonly KavenegarApi kavenegarApi;

        public KavenegarSMSService(IConfiguration configuration)
        {
            kavenegarApi = new KavenegarApi(configuration["KavenegarApiKey"]);
        }

        public async Task SendVerificationCodeAsync(string phoneNumber, string verificationCode)
        {
            await kavenegarApi.VerifyLookup(phoneNumber, verificationCode, "Token");
        }
    }
}
