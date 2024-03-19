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
using Tipoul.Framework.Services.OpenBanking.Shahin.Public;
using Tipoul.CoreBanking.Switch;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;
using Tipoul.CoreBanking.Services.KYC.OutModel.Iban;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbannationalcodeController : ControllerBase
    {

        private readonly ILogger<IbannationalcodeController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;

        private static GetTokenResult? tokenResult;
        private readonly IUnitOfWork _unitOfWork;

        public IbannationalcodeController(ILogger<IbannationalcodeController> logger, IConfiguration iConfig, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            configuration = iConfig;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("{nationalCode}/{birthDate}/iban/bank")]

        public async Task<OutNationalIdentity.OutModelNationalIdentity> Get([FromRoute] string nationalCode, string birthDate, string iban, string? bank)
        {
            OutNationalIdentity.OutModelNationalIdentity om = new OutNationalIdentity.OutModelNationalIdentity();
            OutNationalIdentity.ResultObjectNationalIdentity rob = new OutNationalIdentity.ResultObjectNationalIdentity();

            Tipoul.CoreBanking.Switch.Convert c = new CoreBanking.Switch.Convert();

            UtilitySwitch utility = new UtilitySwitch();
            AccessDB accessdb = utility.FindAccessDatabse(_unitOfWork);
            if (accessdb != null)
            {
                string statecart = c.Accountnumbertype(iban);
                switch (statecart)
                {
                    case "AccountNumber":
                        {
                            if (bank == "")
                            {
                                Random rnd = new Random();
                                int numberrandom = rnd.Next(100000, 999999);
                                rob.ibanNumber = "";
                                rob.firstName = "";
                                rob.lastName = "";
                                rob.bank = "";
                                rob.ibanCheckResult = "";
                                rob.nationalCode = nationalCode;
                                rob.accountNumber = iban;
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
                                
                                    c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                                    return await c.ShahinGetnationalCode(nationalCode,iban,birthDate, bank, statecart);
                                
                            }
                        }
                        break;
                    case "CardNumber":
                    case "Iban":
                        {
                            c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                            return await c.ShahinGetnationalCode(nationalCode, iban, birthDate, bank, statecart);

                        }
                        break;

                    default:
                        {
                            Random rnd = new Random();
                            int numberrandom = rnd.Next(100000, 999999);
                            rob.ibanNumber = "";
                            rob.firstName = "";
                            rob.lastName = "";
                            rob.bank = "";
                            rob.ibanCheckResult = "";
                            rob.nationalCode = nationalCode;
                            rob.accountNumber = iban;
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
                rob.firstName = "";
                rob.lastName = "";
                rob.bank = "";
                rob.ibanCheckResult = "";
                rob.nationalCode = nationalCode;
                rob.accountNumber = iban;
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
