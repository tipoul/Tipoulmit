using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Wallet.Hub.Apis.Controllers
{
    [Route("[controller]/v1")]
    public class IncreaseController : ControllerBase
    {
        /*private readonly IUnitOfWork _unitOfWork;

        public PayController(IConfiguration config, Tipoul.Shaparak.Services.Data.Context dbContext)
        {


            _dbContext = dbContext;

        }

        [HttpPost("getToken")]
        public async Task<GetTokenResult> GetToken([FromServices] IConfiguration configuration, [FromBody] GetTokenModel model)
        {


            try
            {
                var traceNumber = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Length - 4);
                traceNumber += rand.Next(1000, 9999);
                traceNumber += new PersianCalendar().GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                traceNumber += rand.Next(1000, 9999);

                Tipoul.Shaparak.Switch.Model.GetToken.InModel modelipg = new Shaparak.Switch.Model.GetToken.InModel();

                modelipg.IPG = model.IPG;
                modelipg.BlankForTransaction = model.BlankForTransaction;
                modelipg.BlankForPayer = model.BlankForPayer;
                modelipg.ValidCardNum = model.ValidCardNum;
                modelipg.Amount = model.Amount;
                modelipg.PayerUserId = model.PayerUserId;
                modelipg.FactorNumber = model.FactorNumber;
                modelipg.PayerName = model.PayerName;
                modelipg.Description = model.Description;
                modelipg.GateToken = model.GateToken;
                modelipg.CallBackUrl = model.CallBackUrl;
                modelipg.PayerMobile = model.PayerMobile;




                HomeController sw = new HomeController(_dbContext);
                Task<string> a = sw.IPGParameter(model.IPG, modelipg, null);

                GetTokenResult gr = new GetTokenResult();
                gr.AccessToken = a.Result;



                return gr;
            }
            catch (Exception ex)
            {
                return null;
                //return new SharedModels.Common.ApiResult<SharedModels.Pay.GetTokenResult>(ex, -1);
            }
        }*/
    }
}
