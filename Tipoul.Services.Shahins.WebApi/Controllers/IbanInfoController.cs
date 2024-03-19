using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbanInfoController : ControllerBase
    {
       
        private readonly ILogger<IbanInfoController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private static GetTokenResult? tokenResult ;
        
        public IbanInfoController(ILogger<IbanInfoController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
            UserName = configuration.GetSection("shahin").GetSection("UserName").Value;
            Password = configuration.GetSection("shahin").GetSection("Password").Value;

        }
      
        [HttpGet("{bank}/sourceAccount")]
        public async Task<IbanInfoResult?> GetInanInfo([FromRoute] string bank, string sourceAccount)
        {
            GetToken gt = new GetToken();
            Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

            IbanInfo _i = new IbanInfo();
            _i.bank = tokenResult.bank;
            _i.nationalCode = tokenResult.user_name;
            _i.sourceAccount = sourceAccount;

            GetIbanInfo m = new GetIbanInfo();
            Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models.IbanInfoResult ibanInfoResult = await m.GetIbanInfos(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");
                        
            return ibanInfoResult;
        }       

    }
}
