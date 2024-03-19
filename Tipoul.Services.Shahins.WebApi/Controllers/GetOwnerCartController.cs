using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Tipoul.Framework.Services.OpenBanking.Shahin.Cart;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account;
using Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts;
using Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Microsoft.IdentityModel.Tokens;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;
using Tipoul.CoreBanking.Switch;
using Tipoul.CoreBanking.Services.KYC.OutModel.Cart;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetOwnerCartController : ControllerBase
    {

        private readonly ILogger<GetOwnerCartController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;


        private static GetTokenResult? tokenResult;
        private readonly IUnitOfWork _unitOfWork;

        public GetOwnerCartController(ILogger<GetOwnerCartController> logger, IConfiguration iConfig, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            configuration = iConfig;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{cardNumber}")]
        public async Task<Outowner.OutModelCart> Get([FromRoute] string cardNumber)
        {
            UtilitySwitch utility = new UtilitySwitch();
            AccessDB accessdb = utility.FindAccessDatabse(_unitOfWork);
            Tipoul.CoreBanking.Switch.Convert c = new CoreBanking.Switch.Convert();

            c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
            return await c.ShahinGetOwnerCartInfoOperation(cardNumber);

            
        }

    }
}
