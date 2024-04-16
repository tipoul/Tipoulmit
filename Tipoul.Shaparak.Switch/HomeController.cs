
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
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
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
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
        private readonly Tipoul.Shaparak.Services.Data.Context _dbContext;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };


        public HomeController(Tipoul.Shaparak.Services.Data.Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> IPGParameter(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
            Task<string> a = null;
            if (AdminIPGChoice != null)
            {
                switch (AdminIPGChoice)
                {
                    case "Sepehr":
                        {
                            IPGSepehr(IPG, inmodel, AdminIPGChoice);
                        }
                        break;
                    case "IranKish":
                        {
                            IPGIranKish(IPG, inmodel, AdminIPGChoice);

                        }
                        break;
                    case "BPT":
                        {
                            IPGBPT(IPG, inmodel, AdminIPGChoice);
                        }
                        break;
                }
            }
            else
            {
                switch (IPG)
                {
                    case "Sepehr":
                        {
                            IPGSepehr(IPG, inmodel, AdminIPGChoice);
                        }
                        break;
                    case "IranKish":
                        {
                            IPGIranKish(IPG, inmodel, AdminIPGChoice);

                        }
                        break;
                    case "BPT":
                        {
                            a = IPGBPT(IPG, inmodel, AdminIPGChoice);
                        }
                        break;
                }
            }
            return a.Result;
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
            Tipoul.Shaparak.Services.Data.Context _context = new Tipoul.Shaparak.Services.Data.Context(null);
            //TipoulFrameworkDbContext _context = new TipoulFrameworkDbContext();
            var ObjsSepherSource = _context.SepehrSource.FirstOrDefault();
            if (ObjsSepherSource != null)
                swm.TerminalId = long.Parse(ObjsSepherSource.TerminalId);
            else
                swm.TerminalId = 0;
            swm.Payload = "Sepehr";

        }
        public async void IPGIranKish(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
            /*IranKishGateWayService iks = new IranKishGateWayService(null, null);

            GetTokenModel gtm = new GetTokenModel();

            Tipoul.Shaparak.Services.Data.Context _context = new Tipoul.Shaparak.Services.Data.Context(null);
            var ObjsIrankishSource = _context.IrankishSource.FirstOrDefault();
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

            iks.GetToken(gtm, "");*/


        }

        public async Task<string> IPGBPT(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {

            Services.BehPardakhtGateWay.Services ss = new Services.BehPardakhtGateWay.Services();

            InModel inmpdelpay = new InModel();


            var optionsBuilder = new DbContextOptionsBuilder<TipoulFrameworkDbContext>();
            //optionsBuilder.UseSqlServer(connectionString);


            //TipoulFrameworkDbContext dbContext = new TipoulFrameworkDbContext(optionsBuilder.Options);


            //var Objswallet = dbContext.Wallets.FirstOrDefault();
            //if (Objswallet != null)
            //    inmpdelpay.payerId = Objswallet.Id;
            //else
            inmpdelpay.payerId = 0;

            //int a= _dbContext.BehpardakhtSource.Count();
            // var ObjsBehpardakhtSource = _dbContext.BehpardakhtSource.FirstOrDefault();
            // if (ObjsBehpardakhtSource != null)
            // {
            inmpdelpay.terminalId = 3467423;// long.Parse(ObjsBehpardakhtSource.TerminalId);
            inmpdelpay.userName = "m6094";// ObjsBehpardakhtSource.Username;
            inmpdelpay.userPassword = "68751835";// ObjsBehpardakhtSource.Password;
            //}
            //else
            //{
            //    inmpdelpay.terminalId = 0;
            //    inmpdelpay.userName = "";
            //    inmpdelpay.userPassword = "";
            //}



            inmpdelpay.localDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            inmpdelpay.amount = inmodel.Amount;
            inmpdelpay.callBackUrl = inmodel.CallBackUrl;
            inmpdelpay.localTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            //if (inmodel.FactorNumber != null)
            //    inmpdelpay.orderId = 10000;// long.Parse(inmodel.FactorNumber);
            //else
            //{
            Random rnd = new Random();
            int numberrandom = rnd.Next(100000, 999999);
            inmpdelpay.orderId = numberrandom;
            //}
            var mm = await ss.bpPayRequest(inmpdelpay);
            
            return mm.resultobject.ResCode;

        }
    }
       
}
