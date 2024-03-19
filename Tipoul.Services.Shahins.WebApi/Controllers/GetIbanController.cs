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

using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Tipoul.CoreBanking.Services.KYC.Iban.Inquiry;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.CoreBanking.Switch;
using Tipoul.CoreBanking.Services.KYC.OutModel.Iban;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetIbanController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetIbanController> _logger;
        private readonly IConfiguration configuration;

        private static GetTokenResult? tokenResult;
        private readonly string TokenUrl;
        private readonly string ApiUrl;

        public GetIbanController(ILogger<GetIbanController> logger, IConfiguration iConfig, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            configuration = iConfig;
            _unitOfWork = unitOfWork;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
        }

        [HttpGet("{Account}/bank")]
        public async Task<OutIban.OutModelIban> Get([FromRoute] string Account, string? bank)
        {

            OutIban.OutModelIban om = new OutIban.OutModelIban();
            OutIban.ResultObjectIban rob = new OutIban.ResultObjectIban();

            Tipoul.CoreBanking.Switch.Convert c = new CoreBanking.Switch.Convert();

            UtilitySwitch utility = new UtilitySwitch();
            AccessDB accessdb = utility.FindAccessDatabse(_unitOfWork);
            if (accessdb != null)
            {
                string statecart = c.Accountnumbertype(Account);
                switch (statecart)
                {
                    case "AccountNumber":
                        {
                            if (bank == "")
                            {
                                Random rnd = new Random();
                                int numberrandom = rnd.Next(100000, 999999);
                                rob.ibanNumber = "";
                                om.message = "انتخاب کردن بانک اجباری است";
                                om.messagecode = "10001";
                                om.statuscode = "200";
                                om.resultobject = rob;
                                om.tracenumber = numberrandom;
                                om.trakingnumber = "";

                                return om;
                            }
                            else
                            {
                                Boolean statelimit = c.ShahinGetIbanLimit(bank);
                                if (statelimit)
                                {
                                    c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                                    return await c.ShahinGetIbanOperation(bank, Account, statecart);
                                }
                                else
                                {
                                    Random rnd = new Random();
                                    int numberrandom = rnd.Next(100000, 999999);
                                    rob.ibanNumber = "";
                                    om.message = "امکان خدمات دهی به شماره کارت وجود ندارد";
                                    om.messagecode = "10002";
                                    om.statuscode = "200";
                                    om.resultobject = rob;
                                    om.tracenumber = numberrandom;
                                    om.trakingnumber = "";

                                    return om;
                                }
                            }
                        }
                        break;
                    case "CardNumber":
                    case "Iban":
                        {
                            c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                            return await c.ShahinGetIbanOperation(bank, Account, statecart);
                        }
                        break;                  
                  
                    default:
                        {
                            Random rnd = new Random();
                            int numberrandom = rnd.Next(100000, 999999);
                            rob.ibanNumber = "";
                            om.message = "فرمت داده ورودی اشتباه است";
                            om.messagecode = "10003";
                            om.statuscode = "200";
                            om.resultobject = rob;
                            om.tracenumber = numberrandom;
                            om.trakingnumber = "";

                            return om;
                        }
                        break;
                }

            }
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                rob.ibanNumber = "";
                om.message = "امکان سرویس دهی میسر نیست";
                om.messagecode = "10004";
                om.statuscode = "200";
                om.resultobject = rob;
                om.tracenumber = numberrandom;
                om.trakingnumber = "";

                return om;
            }
           
        }

    }
}
