using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;
using Tipoul.Console.WebApi;

using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.Services;
using Tipoul.Shaparak.Switch;
using Tipoul.Framework.DataAccessLayer;

using Azure;
using Tipoul.Console.WebApi.Infrastructure;
using Tipoul.Framework.Services.RequestLog.Migrations;
using Tipoul.Console.WebApi.Entity;
using System.Reflection.Metadata;
using Azure.Core;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

using Tipoul.Framework.Services.RequestLog.StorageModels.IranKishGateWay;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Text;
using Tipoul.Framework.DataAccessLayer.Migrations;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tipoul.Console.WebApi.Utilities;
using Tipoul.Shaparak.Switch.Model.GetToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Tipoul.Framework.StorageModels;
using Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest;


//using SharedModels = Tipoul.Services.Shared.Models;

namespace Tipoul.Services.WebApiii.Controllers
{
    [Route("[controller]/v1")]
    public class PayController : ControllerBase
    {
        private readonly IHttpContextAccessor contextAccessor;


        private readonly IConfiguration configuration;

        private static Random rand = new Random((int)DateTime.Now.Ticks);
        protected readonly TipoulFrameworkDbContext _TipouldbContext;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private readonly IUnitOfWork _unitOfWork;
        private ShaparakContext _shaparakcontext;
        private TipoulFrameworkDbContext _tipoulframeworkdbcontext;
        private readonly IHttpContextAccessor _contextAccessor;
        public PayController(IConfiguration config, IUnitOfWork unitOfWork, ShaparakContext shaparakcontext, TipoulFrameworkDbContext tipoulframeworkbbcontext, IHttpContextAccessor contextAccessor)
        {
            _shaparakcontext = shaparakcontext;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _tipoulframeworkdbcontext = tipoulframeworkbbcontext;
        }

        [HttpPost("getToken")]
        public async Task<Tipoul.Shaparak.Switch.Model.GetToken.ResultModelUser> GetToken([FromServices] IConfiguration configuration, [FromForm] Tipoul.Console.WebApi.GetTokenModel model)
        { 
            string GTTN = Utility.GTTN();
            try
            {


                Tipoul.Shaparak.Switch.Model.GetToken.InModel modelipg = new Shaparak.Switch.Model.GetToken.InModel();


                modelipg.TraceNumber = Utility.GTTN();
                modelipg.IPG = model.IPG;
                modelipg.BlankForTransaction = model.BlankForTransaction;
                modelipg.BlankForPayer = model.BlankForPayer;
                //modelipg.ValidCardNum = model.ValidCardNum;
                modelipg.Amount = model.Amount;
                modelipg.PayerUserId = model.PayerUserId;
                modelipg.FactorNumber = model.FactorNumber;
                modelipg.PayerName = model.PayerName;
                modelipg.Description = model.Description;
                modelipg.GateToken = model.GateToken;
                modelipg.CallBackUrl = model.CallBackUrl;
                modelipg.PayerMobile = model.PayerMobile;

                Tipoul.Console.WebApi.Entity.Request _r = new Tipoul.Console.WebApi.Entity.Request();
                _r.IPG = model.IPG;
                _r.PayerMobile = model.PayerMobile;
                _r.PayerUserId = long.Parse(model.PayerUserId);
                _r.BlankForPayer = model.BlankForPayer;
                string ValidCardNum = "";
                //if (model.ValidCardNum != null)
                //{
                //    foreach (var item in model.ValidCardNum)
                //    {
                //        ValidCardNum += item;
                //    }
                //    _r.ValidCardNum = ValidCardNum;
                //}
                //else
                    _r.ValidCardNum = "";
                _r.FactorNumber = long.Parse(model.FactorNumber);
                _r.Amount = model.Amount;
                _r.BlankForTransaction = model.BlankForTransaction;
                _r.CallBackUrl = model.CallBackUrl;
                _r.PayerName = model.PayerName;
                _r.Description = model.Description;
                _r.GateToken = model.GateToken;
                string Token = Utility.GenerateToken(256);
                string HashedToken = Utility.GenerateHash(Token);
                _r.AccessToken = Token;
                _r.HashedToken = HashedToken;

                HomeController sw = new HomeController(_shaparakcontext);

                Task<ResultModel> _res = sw.IPGParameter(model.IPG, modelipg, null);



                _r.IPG = _res.Result.IPG;
                _r.IPGToken = _res.Result.resCode;
                _r.AccessToken = _res.Result.accessToken;
                _r.GTTN = GTTN;
                _r.RegisterDate = DateTime.Now;

                var result = _unitOfWork.RequestRepo.Insert(_r);
                _unitOfWork.Save();

              
                ResultModelUser _resuser = new ResultModelUser();
                _resuser.IPG = _res.Result.IPG;
               
                _resuser.accessToken = HashedToken;
                _resuser.amount = _res.Result.amount;
                _resuser.callbackurl = _res.Result.callbackurl;
                _resuser.orderId = _res.Result.orderId;


                return _resuser;


            }
            catch (Exception ex)
            {
               
                return null;

            }
        }
        [HttpPost("callback")]
        public CallbackModel Callback()
        {
            var SaleReferenceId = HttpContext.Request.Form["SaleReferenceId"].ToString();
            var RefId = HttpContext.Request.Form["RefId"].ToString();
            var ResCode = HttpContext.Request.Form["ResCode"].ToString();
            var FinalAmount = HttpContext.Request.Form["FinalAmount"].ToString();
            var CardHolderInfo = HttpContext.Request.Form["CardHolderInfo"].ToString();
            var CardHolderPan = HttpContext.Request.Form["CardHolderPan"].ToString();
            var SaleOrderId = HttpContext.Request.Form["SaleOrderId"].ToString();

            CallbackModel _rcm = new CallbackModel();
            

            _rcm.CardNumber = CardHolderPan;
            _rcm.FactorNumber = SaleOrderId;
            _rcm.RRN = SaleReferenceId;
            _rcm.Amount = long.Parse(FinalAmount);
            _rcm.RespCode = int.Parse(ResCode);
            _rcm.GTRN = Utility.TrackNumber(long.Parse(SaleOrderId));
            _rcm.DatePaid = Utility.ConvertDate(DateTime.Now);
            _rcm.TraceNumber = null;
            string BankName = Utility.Bankrecogntion(CardHolderPan.Substring(0, 6));
            _rcm.IssuerBank = BankName;
            var Objs = _unitOfWork.RequestRepo.GetByFactorNo(long.Parse(HttpContext.Request.Form["SaleOrderId"].ToString()));
            if (Objs != null)
                _rcm.GTTN = Objs.GTTN;
            else
                _rcm.GTTN = null;

            Transactionv1 _trans = new Transactionv1();

            _trans.IssuerBank = BankName;
            _trans.CardNumber = CardHolderPan;

            _trans.Amount = long.Parse(FinalAmount);
            _trans.TraceNumber = null;
            _trans.FactorNumber = long.Parse(SaleOrderId);
            _trans.DatePaid = DateTime.Now;
            _trans.RRN = SaleReferenceId;
            _trans.RespCode = int.Parse(ResCode);
            _trans.GTRN = _rcm.GTRN;
            _trans.GTTN = _rcm.GTTN;            

            try
            {
                var results = _tipoulframeworkdbcontext.Transactionv1.Add(_trans);
                _tipoulframeworkdbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
           
            return _rcm;

        }


        [HttpPost("confirm")]
        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel> Confirm([FromForm] string GTTN)
        {
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel _modelsOutModel = new Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel();

            var ObjTrans = _tipoulframeworkdbcontext.Transactionv1.FirstOrDefault(r => r.GTTN == GTTN);
            if (ObjTrans != null)
            {
                var ObjsRequest = _unitOfWork.RequestRepo.GetByGTTN(GTTN);
                if (ObjsRequest != null)
                {
                    switch (ObjsRequest.IPG)
                    {
                        case "BPT":
                            {
                                var ObjsBank = _shaparakcontext.BehpardakhtSource.FirstOrDefault();
                                if (ObjsBank != null)
                                {

                                    Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.InModel _models = new Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.InModel();

                                    _models.saleReferenceId = long.Parse(ObjTrans.RRN);
                                    _models.terminalId = long.Parse(ObjsBank.TerminalId);
                                    _models.saleOrderId = ObjTrans.FactorNumber.Value;
                                    _models.userName = ObjsBank.Username;
                                    _models.orderId = ObjTrans.FactorNumber.Value;
                                    _models.userPassword = ObjsBank.Password;


                                    Tipoul.Shaparak.Services.BehPardakhtGateWay.Services _Behver = new Shaparak.Services.BehPardakhtGateWay.Services();


                                    

                                    Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.ResultObject _finalresult = new Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.ResultObject();

                                    ResultObject _robject = new ResultObject();

                                    var ObjsVerify = await _Behver.bpVerifyRequest(_models);
                                    if (ObjsVerify.messagecode == "10000")
                                    {
                                        Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.InModel _modelsSettle = new Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.InModel();

                                        _modelsSettle.saleReferenceId = long.Parse(ObjTrans.RRN);
                                        _modelsSettle.terminalId = long.Parse(ObjsBank.TerminalId);
                                        _modelsSettle.saleOrderId = ObjTrans.FactorNumber.Value;
                                        _modelsSettle.userName = ObjsBank.Username;
                                        _modelsSettle.orderId = ObjTrans.FactorNumber.Value;
                                        _modelsSettle.userPassword = ObjsBank.Password;

                                        var ObjsSettle = await _Behver.bpSettleRequest(_modelsSettle);
                                        if (ObjsSettle.messagecode == "10000")
                                        {
                                            _modelsOutModel.tracenumber = ObjsSettle.tracenumber;
                                            _modelsOutModel.message = ObjsSettle.message;
                                            _modelsOutModel.messagecode = ObjsSettle.messagecode;
                                            _modelsOutModel.statuscode = ObjsSettle.statuscode;
                                            _finalresult.ResCode = ObjsSettle.resultobject.ResCode;
                                            _modelsOutModel.resultobject = _finalresult;
                                        }
                                        else
                                        {
                                            _modelsOutModel.tracenumber = 0;
                                            _modelsOutModel.message = "تراکنش موفقیت آمیز نبود";
                                            _modelsOutModel.messagecode = "2000";
                                            _modelsOutModel.statuscode = "-1";

                                            _modelsOutModel.resultobject = null;
                                        }


                                    }
                                    else
                                    {
                                        _modelsOutModel.tracenumber = 0;
                                        _modelsOutModel.message = "تراکنش موفقیت آمیز نبود";
                                        _modelsOutModel.messagecode = "2000";
                                        _modelsOutModel.statuscode = "-1";

                                        _modelsOutModel.resultobject = null;

                                    }
                                    return _modelsOutModel;
                                }
                                else
                                {
                                    _modelsOutModel.tracenumber = 0;
                                    _modelsOutModel.message = "بانک یافت نشد";
                                    _modelsOutModel.messagecode = "2001";
                                    _modelsOutModel.statuscode = "-1";

                                    _modelsOutModel.resultobject = null;
                                }
                            }
                            break;
                        default:
                            {
                                _modelsOutModel.tracenumber = 0;
                                _modelsOutModel.message = "توکن یافت نشد";
                                _modelsOutModel.messagecode = "2002";
                                _modelsOutModel.statuscode = "-1";

                                _modelsOutModel.resultobject = null;
                            }
                            break;

                    }
                }
                else
                {
                    _modelsOutModel.tracenumber = 0;
                    _modelsOutModel.message = "توکن یافت نشد";
                    _modelsOutModel.messagecode = "2003";
                    _modelsOutModel.statuscode = "-1";

                    _modelsOutModel.resultobject = null;
                }
            }
            else
            {

                _modelsOutModel.tracenumber = 0;
                _modelsOutModel.message = "توکن یافت نشد";
                _modelsOutModel.messagecode = "2004";
                _modelsOutModel.statuscode = "-1";

                _modelsOutModel.resultobject = null;
            }
            return _modelsOutModel;
        }
    }
}
