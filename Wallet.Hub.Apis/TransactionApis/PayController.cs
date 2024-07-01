using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using Wallet.Hub.Apis.Models.Token;

namespace Wallet.Hub.Apis.TransactionApis
{

    [Route("/hub")]
    public class PayController : ControllerBase
    {
        private readonly ILogger<PayController> _logger;
        private readonly IUnitOfWork _unitOfWork;
       
        public PayController(ILogger<PayController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpPost("getToken")]
        public async Task<Response> GetToken([FromBody] Request model)
        {
            GetTokenRequest _gtr = new GetTokenRequest();

            _gtr.Id = 0;
            _gtr.IpServer = model.IpServer;
            _gtr.WalletId = model.WalletId.Value;
            _gtr.FactorNo = model.FactorNo.Value;
            _gtr.Amount = model.Amount.Value;
            _gtr.BalanceEffect = model.BalanceEffect;
            _gtr.CallBackUrl = model.CallBackUrl;
            _gtr.Mobile = model.Mobile;
            _gtr.NationalCode = model.NationalCode;
            _gtr.RegisterDate = DateTime.Now;            
            var result = _unitOfWork.GetTokenRequestRepo.Insert(_gtr);
            _unitOfWork.Save();

            Response _response = new Response();
            _response.Status = 200;
            _response.StatusCode = 10001;
            _response.IpServer= model.IpServer;

            ResultObject _resobj = new ResultObject();
            _resobj.ResMessage = "Successed";
           
            string Token= Utilities.Utility.GenerateToken(256);
            _resobj.ResponseToken = Token;
            _resobj.HashedToken = Utilities.Utility.GenerateHash(Token);
            _resobj.WTTN = Utilities.Utility.TrackNumber(model.FactorNo.Value);
            _resobj.WTTRN = Utilities.Utility.GetTraceNumber();
           
                      
            _response.resObject = _resobj;
            _response.RegisterDate= DateTime.Now;
            

            return _response;

           
        }
        [HttpGet("let")]
        public async Task<int> Get([FromRoute] string Token)
        {

            return 2;

        }
    }
}