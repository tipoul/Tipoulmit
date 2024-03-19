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
using Tipoul.CoreBanking.Services.KYC.OutModel.Iban;
using Tipoul.CoreBanking.Switch;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.CoreBanking.Services.KYC.NationalCode.Inquiry;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;

namespace Tipoul.Services.Shahins.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class nationalIdentityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<nationalIdentityController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private static GetTokenResult? tokenResult ;

        public nationalIdentityController(ILogger<nationalIdentityController> logger, IConfiguration iConfig, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            configuration = iConfig;
            _unitOfWork = unitOfWork;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
        }
       
        [HttpGet("{nationalCode}/{bankcode}/birthDate")]
        public async Task<OutNationalInquiry.OutModelNationalInquiry> Get([FromRoute] string nationalCode, string birthDate,string bankcode)
        {         
            
            OutNationalInquiry.OutModelNationalInquiry om = new OutNationalInquiry.OutModelNationalInquiry();
            OutNationalInquiry.ResultObjectModelNationalInquiry rob = new OutNationalInquiry.ResultObjectModelNationalInquiry();

            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);

            Tipoul.CoreBanking.Switch.Convert c = new CoreBanking.Switch.Convert();

            UtilitySwitch utility = new UtilitySwitch();
            AccessDB accessdb = utility.FindAccessDatabse(_unitOfWork);
            if (accessdb != null)
            {
                
                   
                            c.UtilityConvert(TokenUrl, ApiUrl, accessdb.UserName, accessdb.Password, _unitOfWork);
                            return await c.ShahinGetNationalInfoOperation(nationalCode, birthDate, bankcode);
                

            }
            else
            {
                om.message = "امکان سرویس دهی میسر نیست";

                rob.fatherName = "";
                rob.lastName = "";
                rob.Birthdate = "";
                rob.alive = false;
                rob.nationalCode = "";

                om.messagecode = "10007";
                om.statuscode = "200";
                om.resultobject = rob;
                om.tracenumber = numberrandom;
                om.trakingnumber = "";

                return om;
            }

        }

    }
}
