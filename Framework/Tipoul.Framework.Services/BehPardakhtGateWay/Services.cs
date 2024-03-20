using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankMellat;

namespace Tipoul.Shaparak.Services.BehPardakhtGateWay
{
    public class Services
    {
        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.OutModel> bpPayRequest(Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.InModel model)
        {

            var pgc = new PaymentGatewayClient();

            var result = await pgc.bpPayRequestAsync(model.terminalId, model.userName, model.userPassword, model.orderId, model.amount, model.localDate, model.localTime, model.additionalData, model.callBackUrl, model.payerId);
            string[] resultArray = result.Body.@return.Split(",");
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.OutModel om = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.OutModel();
            if (resultArray[0] == "0")
            {

                om.messagecode = "10000";
                om.message = "تراکنش با موفقیت انجام شد";
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                om.tracenumber = numberrandom;
                om.statuscode = "200";

                Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.ResultObject ro = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest.ResultObject();
                ro.RefId = resultArray[0];
                ro.ResCode = resultArray[1];

                om.resultobject = ro;
            }
            else
            {

                om.messagecode = "10001";

                switch (resultArray[0])
                {
                    case "11":
                        om.message = "شماره کارت نامعتبر است";
                        break;
                    case "12":
                        om.message = "موجودی کافی نیست";
                        break;
                    case "13":
                        om.message = "رمز نادرست است";
                        break;
                    case "14":
                        om.message = "تعداد دفعات وارد كردن رمز بيش از حد مجاز است";
                        break;
                    case "15":
                        om.message = "کارت نامعتبر است";
                        break;
                    case "16":
                        om.message = "دفعات برداشت وجه بیش از حد مجاز است";
                        break;
                    case "17":
                        om.message = "کاربر از انجام تراکنش منصرف شده است";
                        break;
                    case "18":
                        om.message = "تاریخ انقضای کارت گذشته است";
                        break;
                    case "19":
                        om.message = "مبلغ برداشت وجه بیش از حد مجاز است";
                        break;
                    case "111":
                        om.message = "صادر کننده کارت نامعتبر است";
                        break;
                    case "112":
                        om.message = "خطای سوییچ صادر کننده کارت";
                        break;
                    case "113":
                        om.message = "پاسخی از صادر کننده کارت دریافت نشد";
                        break;
                    case "114":
                        om.message = "دارنده کارت مجاز به انجام این تراکنش نیست";
                        break;
                    case "21":
                        om.message = "پذیرنده نامعتبر است";
                        break;
                    case "23":
                        om.message = "خطای امنیتی رخ داده است";
                        break;
                    case "24":
                        om.message = "اطلاعات کاربری پذیرنده نامعتبر است";
                        break;
                    case "25":
                        om.message = "مبلغ نامعتبر است";
                        break;
                    case "31":
                        om.message = "پاسخ نامعتبر است";
                        break;
                    case "32":
                        om.message = "فرمت اطلاعات وارد شده صحیح نمی باشد";
                        break;
                    case "33":
                        om.message = "حساب نامعتبر است";
                        break;
                    case "34":
                        om.message = "خطای سیستمی";
                        break;
                    case "35":
                        om.message = "تاریخ نامعتبر است";
                        break;
                    case "41":
                        om.message = "شماره درخواست تکراری است";
                        break;
                    case "42":
                        om.message = "تراکش Sale یافت نشد";
                        break;
                    case "43":
                        om.message = "قبلا درخواست Verify داده شده است";
                        break;
                    case "44":
                        om.message = "درخواست Verify یافت نشد";
                        break;
                    case "45":
                        om.message = "تراکنش Settle شده است";
                        break;
                    case "46":
                        om.message = "تراکنش Settle نشده است";
                        break;
                    case "47":
                        om.message = "تراکنش Settle یافت نشد";
                        break;
                    case "48":
                        om.message = "تراکنش Reverse شده است";
                        break;
                    case "49":
                        om.message = "تراکنش Refund یافت نشد";
                        break;
                    case "412":
                        om.message = "شناسه قبض نادرست است";
                        break;
                    case "413":
                        om.message = "شناسه پرداخت نادرست است";
                        break;
                    case "414":
                        om.message = "سازمان صادر کننده قبض نامعتبر است";
                        break;
                    case "415":
                        om.message = "زمان جلسه کاری به پایان رسیده است";
                        break;
                    case "416":
                        om.message = "خطا در ثبت اطلاعات";
                        break;
                    case "417":
                        om.message = "شناسه پرداخت کننده نامعتبر است";
                        break;
                    case "418":
                        om.message = "اشکال در تعریف اطلاعات مشتری";
                        break;
                    case "419":
                        om.message = "تعداد دفعات ورود اطلاعات از حد مجاز گذشته است ";
                        break;
                    case "421":
                        om.message = "IP نامعتبر است";
                        break;
                    case "51":
                        om.message = "تراکنش تکراری است";
                        break;
                    case "54":
                        om.message = "تراکنش مرجع موجود نیست";
                        break;
                    case "55":
                        om.message = "تراکنش نامعتبر است";
                        break;
                    case "61":
                        om.message = "خطا در واریز";
                        break;
                    default:
                        om.message = "";
                        break;
                }
            }

            return om;
        }
        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel> bpVerifyRequest(Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.InModel model)
        {
            var pgc = new PaymentGatewayClient();

            var result = await pgc.bpVerifyRequestAsync(model.terminalId, model.userName, model.userPassword, model.orderId, model.saleOrderId, model.saleReferenceId);
            string resultArray = result.Body.@return;
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel om = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.OutModel();
            if (resultArray == "0")
            {

                om.messagecode = "10000";
                om.message = "تراکنش با موفقیت انجام شد";
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                om.tracenumber = numberrandom;
                om.statuscode = "200";

                Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.ResultObject ro = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpVerifyRequest.ResultObject();

                ro.ResCode = resultArray;

                om.resultobject = ro;
            }
            else
            {
                om.messagecode = "10001";
                om.message = "تراکنش موفقیت آمیز نبود";
            }

            return om;
        }


        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.OutModel> bpSettleRequest(Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.InModel model)
        {
            var pgc = new PaymentGatewayClient();

            var result = await pgc.bpSettleRequestAsync(model.terminalId, model.userName, model.userPassword, model.orderId, model.saleOrderId, model.saleReferenceId);
            string resultArray = result.Body.@return;
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.OutModel om = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.OutModel();
            if (resultArray == "0" || resultArray == "45")
            {

                om.messagecode = "10000";
                om.message = "تراکنش با موفقیت انجام شد";
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                om.tracenumber = numberrandom;
                om.statuscode = "200";

                Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.ResultObject ro = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpSettleRequest.ResultObject();

                ro.ResCode = resultArray;

                om.resultobject = ro;
            }
            else
            {
                om.messagecode = "10001";
                om.message = "تراکنش موفقیت آمیز نبود";
            }

            return om;
        }


        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.OutModel> bpInquiryRequest(Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.InModel model)
        {
            var pgc = new PaymentGatewayClient();

            var result = await pgc.bpInquiryRequestAsync(model.terminalId, model.userName, model.userPassword, model.orderId, model.saleOrderId, model.saleReferenceId);
            string resultArray = result.Body.@return;
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.OutModel om = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.OutModel();
            if (resultArray == "0")
            {

                om.messagecode = "10000";
                om.message = "تراکنش با موفقیت انجام شد";
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                om.tracenumber = numberrandom;
                om.statuscode = "200";

                Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.ResultObject ro = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpInquiryRequest.ResultObject();

                ro.ResCode = resultArray;

                om.resultobject = ro;
            }
            else
            {
                om.messagecode = "10001";
                om.message = "تراکنش موفقیت آمیز نبود";
            }

            return om;
        }


        public async Task<Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.OutModel> bpReversalRequest(Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.InModel model)
        {
            var pgc = new PaymentGatewayClient();

            var result = await pgc.bpReversalRequestAsync(model.terminalId, model.userName, model.userPassword, model.orderId, model.saleOrderId, model.saleReferenceId);
            string resultArray = result.Body.@return;
            Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.OutModel om = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.OutModel();
            if (resultArray == "0")
            {

                om.messagecode = "10000";
                om.message = "تراکنش با موفقیت انجام شد";
                Random rnd = new Random();
                int numberrandom = rnd.Next(100000, 999999);
                om.tracenumber = numberrandom;
                om.statuscode = "200";

                Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.ResultObject ro = new Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpReversalRequest.ResultObject();

                ro.ResCode = resultArray;

                om.resultobject = ro;
            }
            else
            {
                om.messagecode = "10001";
                om.message = "تراکنش موفقیت آمیز نبود";
            }

            return om;
        }


    }
}
