using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Tipoul.Wallet.Switch;
using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Models;
using Tipoul.Wallet.Switch.Services;
using Tipoul.Wallet.Switch.Utilities;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;
using Wallet.Hub.WebApi.Models.Let;
using Wallet.Hub.WebApi.Models.Token;
using Wallet.Hub.WebApi.Models.Verify;
using Wallet.Hub.WebApi.Services;

namespace Wallet.Hub.WebApi.TransactionApis
{

    [Route("/hub")]
    public class PayController : ControllerBase
    {
        private readonly ILogger<PayController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private SwitchWalletContext _switchwalletcontext;

        public PayController(ILogger<PayController> logger, IUnitOfWork unitOfWork, SwitchWalletContext switchwalletcontext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _switchwalletcontext = switchwalletcontext;

        }
        [HttpPost("getToken")]
        public async Task<Response> GetToken([FromBody] Request model)
        {
            GetTokenRequest _gtr = new GetTokenRequest();

            long SourceWalletId = Utility.GetWallet(_switchwalletcontext, model.SourceWalletNo.Value);
            long RequestId = 0;

            _gtr.Id = 0;
            _gtr.IpServer = model.IpServer;
            _gtr.SourceWalletNo = model.SourceWalletNo.Value;
            _gtr.DestinationWalletNo = model.DestinationWalletNo.Value;
            _gtr.FactorNo = model.FactorNo.Value;
            _gtr.Amount = model.Amount.Value;
            _gtr.BalanceEffect = model.BalanceEffect;
            _gtr.CallBackUrl = model.CallBackUrl;
            _gtr.RegisterDate = DateTime.Now;
            var result = _unitOfWork.GetTokenRequestRepo.Insert(_gtr);
            _unitOfWork.Save();



            Response _response = new Response();
            _response.Status = 200;
            _response.StatusCode = 10001;
            _response.IpServer = model.IpServer;

            ResultObject _resobj = new ResultObject();
            _resobj.ResMessage = "Successed";

            string Token = Utilities.Utility.GenerateToken(256);
            _resobj.ResponseToken = Token;
            _resobj.HashedToken = Utilities.Utility.GenerateHash(Token);
            string WTTRN = Utilities.Utility.TrackNumber(SourceWalletId);
            _resobj.WTTRN = WTTRN;
            string WTTN = Utilities.Utility.GetTraceNumber();
            _resobj.WTTN = WTTN;


            _response.resObject = _resobj;
            _response.RegisterDate = DateTime.Now;


            GetTokenResponse _gtres = new GetTokenResponse();

            _gtres.Id = 0;
            _gtres.IpServer = model.IpServer;
            _gtres.WTTN = WTTN;
            _gtres.WTTRN = WTTRN;
            _gtres.Status = 200;
            _gtres.StatusCode = 10001;
            _gtres.ResMessage = "Successed";
            _gtres.ResponseToken = Token;
            _gtres.HashedToken = Utilities.Utility.GenerateHash(Token);
            _gtres.RegisterDate = DateTime.Now;
            _gtres.IdRequest = _gtr.Id;
            var resultres = _unitOfWork.GetTokenResponseRepo.Insert(_gtres);
            _unitOfWork.Save();

            return _response;


        }

        [HttpGet("let/{Token}")]
        public async Task<LetResponse> Get([FromRoute] string Token)
        {
            var result = _unitOfWork.GetTokenResponseRepo.GetByToken(Token);
            if (result != null)
            {
                LetRequestLog _letrequestlog = new LetRequestLog();
                _letrequestlog.RegisterDate = DateTime.Now;
                _letrequestlog.IpServer = "";
                _letrequestlog.HashedToken = Token;

                var resultLet = _unitOfWork.LetRequestLogRepo.Insert(_letrequestlog);
                _unitOfWork.Save();


                LetResponse _response = new LetResponse();
                _response.Status = 200;
                _response.StatusCode = 10001;
                _response.IpServer = result.IpServer;

                LetResultObject _resobj = new LetResultObject();

                var Request = _unitOfWork.GetTokenRequestRepo.GetRequest(result.IdRequest.Value);
                if (Request != null)
                {
                    var SourceUser = Utility.GetSourceUser(_switchwalletcontext, Request.SourceWalletNo.Value);
                    var DestinationUser = Utility.GetSourceUser(_switchwalletcontext, Request.DestinationWalletNo.Value);

                    Switchs _sw = new Switchs();

                   

                    long SourceWalletId = Utility.GetWallet(_switchwalletcontext, Request.SourceWalletNo.Value);
                    long DestinationWalletId = Utility.GetWallet(_switchwalletcontext, Request.DestinationWalletNo.Value);
                    long Amountpayable = 0;

                    TransactionTypeUserRepo _ttur = new TransactionTypeUserRepo(_switchwalletcontext);
                    var ObjsTransactionTypeUser = _ttur.GetByTypeUser(11, DestinationUser.Id);
                    long transactionid = 0;

                    Calculatemodels cm= WageCalculator.WageCal(_switchwalletcontext, ObjsTransactionTypeUser.Id, Request.Amount.Value);

                    if (cm.SourceAmount > 0)
                        Amountpayable=Request.Amount.Value + cm.SourceAmount;
                    else
                        Amountpayable = Request.Amount.Value;

                    Boolean BalanceCheckerStateSource= BalanceChecker.SourceChecker(_switchwalletcontext, SourceWalletId, Amountpayable);

                    if (BalanceCheckerStateSource)
                    {
                        Boolean BalanceCheckerState = BalanceChecker.DestinationChecker(_switchwalletcontext, DestinationWalletId, cm.DestinationAmount);

                        if (BalanceCheckerState)
                        {
                            Transactions _transa = new Transactions();

                            _transa.Id = 0;
                            _transa.WTTN = result.WTTN;
                            _transa.WTTRN = result.WTTRN;
                            _transa.SourceWalletId = SourceWalletId;
                            _transa.DestinationWalletId = DestinationWalletId;
                            _transa.FactorNo = Request.FactorNo;
                            _transa.ResultStatus = null;
                            _transa.TransactionTypeUserId = ObjsTransactionTypeUser.Id;
                            _transa.BlankForOrder = null;
                            _transa.RegisterDate = DateTime.Now;
                            _transa.Amount = Request.Amount;
                            _transa.Amountpayable = Amountpayable;
                            _transa.EndUserWageAmount = cm.SourceAmount;
                            _transa.UserWageAmount = cm.DestinationAmount;
                            _transa.Offer = 0;
                            _transa.IsWage = 0;
                            _transa.WageAmount = cm.WageAmount;

                            var res = _switchwalletcontext.Transactions.Add(_transa);
                            _switchwalletcontext.SaveChanges();
                            if (res.State == EntityState.Added)
                                transactionid = _transa.Id;

                            else transactionid = 0;


                            _resobj.ResMessage = "Successed";

                            _resobj.SourceName = SourceUser.Name;
                            _resobj.SourceLastName = SourceUser.Lastname;
                            _resobj.Sourcenatonalcode = SourceUser.Nationalcode;
                            _resobj.SourceMobile = SourceUser.Mobile;
                            _resobj.SourceWalletNo = Request.SourceWalletNo.Value;
                            _resobj.EndUserWageAmount = cm.SourceAmount;

                            _resobj.CustomerUserId = SourceUser.CustomerUserId != null ? SourceUser.CustomerUserId.Value : 0;

                            _resobj.DestinationName = DestinationUser.Name;
                            _resobj.DestinationLastName = DestinationUser.Lastname;
                            _resobj.Destinationatonalcode = DestinationUser.Nationalcode;
                            _resobj.DestinationeMobile = DestinationUser.Mobile;
                            _resobj.DestinationeWalletNo = Request.DestinationWalletNo.Value;
                            _resobj.UserWageAmount = cm.DestinationAmount;


                            _resobj.FactorNo = Request.FactorNo;
                            _resobj.Amount = Request.Amount.Value;
                            _resobj.BalanceEffect = Request.BalanceEffect;
                            _resobj.AmountPayAble = Amountpayable;


                            _response.resObject = _resobj;
                            _response.RegisterDate = DateTime.Now;

                            return _response;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            else
                return null;


        }
        [HttpPost("Verify")]
        public async void Verify([FromBody] string WTTN)
        {
            TransactionRepo _tr = new TransactionRepo(_switchwalletcontext);
            var ObjsTr = _tr.GetByWTTN(WTTN);
           
            if (ObjsTr != null)
            {
                string WTTRNTransaction = Utilities.Utility.TrackNumber(ObjsTr.SourceWalletId.Value);
                int SourceBalanceManagerno =BalanceManager.SourceBalance(_switchwalletcontext, WTTRNTransaction, ObjsTr);
                int DestinationBalanceManager = BalanceManager.DestinationBalance(_switchwalletcontext, WTTRNTransaction, ObjsTr);


                
            }
            else
            {

            }

        }

    }
}
