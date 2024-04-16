
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Framework.Services.IranKishGateWay.Models;
using Tipoul.Framework.Services.SepehrGateWay;
using Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest;
using Tipoul.Shaparak.Services.Data;

namespace Tipoul.Shaparak.Switch
{
    public class Switch
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly string TokenUrl;
        public Switch(IConfiguration config)
        {
            configuration = config;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
        }




        public async void IPGParameter(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
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
                            IPGBPT(IPG, inmodel, AdminIPGChoice);
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
            IranKishGateWayService iks = new IranKishGateWayService(null, null);

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

            iks.GetToken(gtm, "");


        }
        public async void IPGBPT(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {

            Services.BehPardakhtGateWay.Services ss = new Services.BehPardakhtGateWay.Services();

            InModel inmpdelpay = new InModel();
            

            var optionsBuilder = new DbContextOptionsBuilder<TipoulFrameworkDbContext>();
            //optionsBuilder.UseSqlServer(connectionString);


            TipoulFrameworkDbContext dbContext = new TipoulFrameworkDbContext(optionsBuilder.Options);


            var Objswallet = dbContext.Wallets.FirstOrDefault();
            if (Objswallet != null)
                inmpdelpay.payerId = Objswallet.Id;
            else
                inmpdelpay.payerId = 0;

            Tipoul.Shaparak.Services.Data.Context _context = new Tipoul.Shaparak.Services.Data.Context(null);
            var ObjsBehpardakhtSource = _context.BehpardakhtSource.FirstOrDefault();
            if (ObjsBehpardakhtSource != null)
            {
                inmpdelpay.terminalId = long.Parse(ObjsBehpardakhtSource.TerminalId);
                inmpdelpay.userName = ObjsBehpardakhtSource.Username;
                inmpdelpay.userPassword = ObjsBehpardakhtSource.Password;
            }
            else
            {
                inmpdelpay.terminalId = 0;
                inmpdelpay.userName = "";
                inmpdelpay.userPassword = "";
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

            await ss.bpPayRequest(inmpdelpay);

        }
    }
}


