using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Framework.Services.IranKishGateWay.Models;
using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.SepehrGateWay;
using Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest;

namespace Tipoul.Shaparak.Switch
{
    public class Switch
    {
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
            swm.InvoiceId = inmodel.FactorNumber;//Or Random Number
            swm.TerminalId = 0;//Fill With Database Sepehr Source TerminalId
            swm.Payload = "Sepehr";

        }
        public async void IPGIranKish(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {
            IranKishGateWayService iks = new IranKishGateWayService(null, null);

            GetTokenModel gtm = new GetTokenModel();

            gtm.TerminalId = "";//Fill With Database IranKish Source TerminalId

            gtm.AcceptorId = "";//Fill With Database IranKish Source AcceptorId
            gtm.RevertUri = inmodel.CallBackUrl;
            gtm.PassPhrase = "";//Fill With Database IranKish Source PassPhrase
            gtm.Amount = inmodel.Amount;

            gtm.RsaPublicKey = //Fill With Database IranKish Source RsaPublicKey

            gtm.PaymentId = inmodel.FactorNumber;//Or Random Number;
            gtm.RequestId = "";//Insert Recore To Table Log Request

            iks.GetToken(gtm, "");


        }
        public async void IPGBPT(string IPG, Model.GetToken.InModel inmodel, string AdminIPGChoice)
        {

            Services.BehPardakhtGateWay.Services ss = new Services.BehPardakhtGateWay.Services();

            InModel inmpdelpay = new InModel();

            inmpdelpay.payerId = 0;//Wallet Id table CommertialGateWays

            inmpdelpay.terminalId = 0;//Fill With Database
            inmpdelpay.userName = "";//Fill With Database
            inmpdelpay.userPassword = "";//Fill With Database
            inmpdelpay.localDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            inmpdelpay.amount = inmodel.Amount;
            inmpdelpay.callBackUrl = inmodel.CallBackUrl;
            inmpdelpay.localTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            inmpdelpay.orderId = long.Parse(inmodel.FactorNumber);//Or Random Number;

            await ss.bpPayRequest(inmpdelpay);

        }
    }
}


