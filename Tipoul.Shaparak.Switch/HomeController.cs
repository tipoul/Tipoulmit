
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Framework.Services.IranKishGateWay.Models;

using Tipoul.Framework.Services.RequestLog.StorageModels.IranKishGateWay;
using Tipoul.Framework.Services.SepehrGateWay;
using Tipoul.Framework.Services.SepehrGateWay.Models;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest;
using Tipoul.Shaparak.Services.Data;



namespace Tipoul.Shaparak.Switch
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private ShaparakContext _shaparakcontext;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };


        public HomeController(ShaparakContext shaparakcontext)
        {
            _shaparakcontext = shaparakcontext;
        }

        public async Task<Tipoul.Shaparak.Switch.Model.GetToken.ResultModel> IPGParameter(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {


            if (AdminIPGChoice != null)
            {
                switch (AdminIPGChoice)
                {
                    case "Sepehr":
                        {
                            IPGSepehr(IPG, inmodel, AdminIPGChoice);
                            return null;
                        }
                        break;
                    case "IranKish":
                        {
                            IPGIranKish(IPG, inmodel, AdminIPGChoice);
                            return null;
                        }
                        break;
                    case "BPT":
                        {
                            IPGBPT(IPG, inmodel, AdminIPGChoice);
                            return null;
                        }
                        break;
                    default:
                        return null;
                }
            }
            else
            {
                switch (IPG)
                {
                    case "Sepehr":
                        {
                            IPGSepehr(IPG, inmodel, AdminIPGChoice);
                            return null;
                        }
                        break;
                    case "IranKish":
                        {
                            IPGIranKish(IPG, inmodel, AdminIPGChoice);
                            return null;
                        }
                        break;
                    case "BPT":
                        {
                            return await IPGBPT(IPG, inmodel, AdminIPGChoice);

                        }
                        break;
                    default:
                        {
                            return await IPGBPT(IPG, inmodel, AdminIPGChoice);

                        }
                        break;
                }
            }

        }
        public async void IPGSepehr(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
            SepehrGateWayService sgs = new SepehrGateWayService(null);

            Tipoul.Framework.Services.SepehrGateWay.Models.GetTokenModel swm = new Tipoul.Framework.Services.SepehrGateWay.Models.GetTokenModel();

            swm.Amount = inmodel.Amount;
            swm.CallbackURL = inmodel.CallBackUrl;
            if (inmodel.CallBackUrl != null)
                swm.InvoiceId = inmodel.FactorNumber;
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                swm.InvoiceId = numberrandom.ToString();
            }

            var ObjsSepherSource = _shaparakcontext.SepehrSource.FirstOrDefault();
            if (ObjsSepherSource != null)
                swm.TerminalId = long.Parse(ObjsSepherSource.TerminalId);
            else
                swm.TerminalId = 0;
            swm.Payload = "Sepehr";

        }
        public async void IPGIranKish(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
            IranKishGateWayService iks = new IranKishGateWayService(null, null);

            Tipoul.Framework.Services.IranKishGateWay.Models.GetTokenModel gtm = new Tipoul.Framework.Services.IranKishGateWay.Models.GetTokenModel();

            var ObjsIrankishSource = _shaparakcontext.IrankishSource.FirstOrDefault();
            if (ObjsIrankishSource != null)
            {
                gtm.TerminalId = ObjsIrankishSource.TerminalId;
                gtm.AcceptorId = ObjsIrankishSource.AcceptorId;
                gtm.PassPhrase = ObjsIrankishSource.PassPhrase;
                gtm.RsaPublicKey = ObjsIrankishSource.RsaPublicKey;
            }
            else
            {
                gtm.TerminalId = "";
                gtm.AcceptorId = "";
                gtm.PassPhrase = "";
                gtm.RsaPublicKey = "";
            }

            gtm.RevertUri = inmodel.CallBackUrl;
            gtm.Amount = inmodel.Amount;

            if (inmodel.FactorNumber != null)
                gtm.PaymentId = inmodel.FactorNumber;
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                gtm.PaymentId = numberrandom.ToString();
            }

            gtm.RequestId = "";//Insert Recore To Table Log Request

            iks.GetToken(gtm, "");


        }

        public async Task<Tipoul.Shaparak.Switch.Model.GetToken.ResultModel> IPGBPT(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {


            Services.BehPardakhtGateWay.Services ss = new Services.BehPardakhtGateWay.Services();

            InModel inmpdelpay = new InModel();

            inmpdelpay.payerId = inmodel.PayerUserId != "" ? long.Parse(inmodel.PayerUserId) : null;

            long terminalId = 0; string TerminaluserName = "", userPassword = "";
            try
            {


                var ObjsBehpardakhtSource = _shaparakcontext.BehpardakhtSource.FirstOrDefault();

                if (ObjsBehpardakhtSource != null)
                {
                    inmpdelpay.terminalId = long.Parse(ObjsBehpardakhtSource.TerminalId);
                    inmpdelpay.userName = ObjsBehpardakhtSource.Username;
                    inmpdelpay.userPassword = ObjsBehpardakhtSource.Password;
                    terminalId = long.Parse(ObjsBehpardakhtSource.TerminalId);
                    TerminaluserName = ObjsBehpardakhtSource.Username;
                    userPassword = ObjsBehpardakhtSource.Password;


                }
                else
                {
                    inmpdelpay.terminalId = 0;
                    inmpdelpay.userName = "";
                    inmpdelpay.userPassword = "";



                }

            }
            catch (Exception ex)
            {


            }



            inmpdelpay.localDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            inmpdelpay.amount = inmodel.Amount;
            inmpdelpay.callBackUrl = inmodel.CallBackUrl;
            inmpdelpay.localTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            if (inmodel.FactorNumber != null)
                inmpdelpay.orderId = long.Parse(inmodel.FactorNumber);
            else
            {
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                inmpdelpay.orderId = numberrandom;
            }
            var result = await ss.bpPayRequest(inmpdelpay);
            Tipoul.Shaparak.Switch.Model.GetToken.ResultModel _result = new Model.GetToken.ResultModel();
            if (result != null)
            {
                _result.orderId = inmodel.FactorNumber != "" ? long.Parse(inmodel.FactorNumber) : 0;
                _result.amount = inmodel.Amount;
                _result.saleReferenceId = 0;
                _result.accessToken = "";
                _result.saleOrderId = inmodel.PayerUserId != "" ? long.Parse(inmodel.PayerUserId) : 0;
                _result.callbackurl = inmodel.CallBackUrl;
                _result.terminalId = terminalId;
                _result.userName = TerminaluserName;
                _result.userPassword = userPassword;
                _result.resCode = result.resultobject.ResCode;
                _result.IPG = "BPT";

                return _result; ;

            }
            else
                return null;

        }

    }
}
