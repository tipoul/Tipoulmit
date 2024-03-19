using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account;
//using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models;

namespace Tipoul.Services.OpenBankings.WebApi.Controllers
{
    public class ShahinServicesController : ControllerBase
    {
        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpGet("{Id}")]
        public string GetAccountBalance(string Id)
        {
            //GetaccountBalance m=new GetaccountBalance(AccountBalance)
            //    m.GetAccountBalances();
            return "1111";
        }
    }
}
