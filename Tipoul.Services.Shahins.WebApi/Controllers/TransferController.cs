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
using System.Reflection.Metadata;
using System.Reflection;
using System.Text.RegularExpressions;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans;
using Tipoul.CoreBanking.Switch;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.CoreBanking.Services.KYC.OutModel.Iban;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransferController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private static GetTokenResult? tokenResult;


        public TransferController(ILogger<TransferController> logger, IConfiguration iConfig, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            configuration = iConfig;
            _unitOfWork = unitOfWork;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;

        }

        [HttpGet("{destinationAccountNumber}/{destinationBank}/{amount}/{transferType}/{babat}/{withdrawDescription}/{paymentID}/destinationAccountName/depositDescription")]
        public async Task<OutTransfer.OutModelTransfer> Get([FromRoute] string destinationAccountNumber, string destinationBank, string? destinationAccountName, long amount, long userid, TransferTypeEnum transferType, BabatEnum babat, string withdrawDescription, string paymentID, string? depositDescription)
        {


            Tipoul.CoreBanking.Switch.Convert c = new CoreBanking.Switch.Convert();

            UtilitySwitch utility = new UtilitySwitch();
            AccessDB accessdb = utility.FindAccessDatabse(_unitOfWork);
            if (accessdb != null)
            {
                string statecart = c.Accountnumbertype(destinationAccountNumber);
                if ((statecart == "AccountNumber") || (statecart == "CardNumber") || (statecart == "Iban"))
                {
                    c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                    return await c.ShahinTransfer(destinationAccountNumber,destinationBank,destinationAccountName,amount,0, transferType,babat,withdrawDescription,paymentID,depositDescription, statecart);
                }
                else               
                   return c.ShowResultTransfer("", "", amount, "", "", "", "", "فرمت داده ورودی اشتباه است", "10031", "200", "");
                

            }
            else
               return c.ShowResultTransfer("", "", amount, "", "", "", "", "امکان سرویس دهی میسر نیست", "10031", "200", "");
        }

    }
}
