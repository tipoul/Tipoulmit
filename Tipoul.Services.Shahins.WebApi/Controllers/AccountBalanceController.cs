using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models;


namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountBalanceController : ControllerBase
    {
       
        private readonly ILogger<AccountBalanceController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private static GetTokenResult? tokenResult ;
        
        public AccountBalanceController(ILogger<AccountBalanceController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
            UserName = configuration.GetSection("shahin").GetSection("UserName").Value;
            Password = configuration.GetSection("shahin").GetSection("Password").Value;

        }

        [HttpGet()]
        public async Task<AccountBalanceResult?> Get()
        {
            GetToken gt = new GetToken();
            Framework.Services.OpenBanking.Shahin.Token.Models.GetTokenResult tokenResult = await gt.GetTokens(TokenUrl, UserName, Password);

            AccountBalance _i = new AccountBalance();
            _i.bank = tokenResult.bank;
            _i.nationalCode = tokenResult.user_name;
            _i.sourceAccount = tokenResult.accounts[0];

            GetaccountBalance a = new GetaccountBalance();
            Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models.AccountBalanceResult accountResult = await a.GetAccountBalances(_i, ApiUrl, UserName, Password, tokenResult.access_token, "");


          return  accountResult;
        }

    }
}
