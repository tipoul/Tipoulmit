using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using Tipoul.Console.WebApi;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Utilities;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.Console.Payment.Controllers
{
    public class CallbackController : Controller
    {
        private ConsoleContext _consolecontext;
        private TipoulFrameworkDbContext _tipoulframeworkdbcontext;

        public CallbackController(ConsoleContext consolecontext,TipoulFrameworkDbContext tipoulframeworkbbcontext)
        {
            _consolecontext = consolecontext;
            _tipoulframeworkdbcontext = tipoulframeworkbbcontext;
        }
        public IActionResult Index()
        {
            try
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

                long FactorNumber = long.Parse(HttpContext.Request.Form["SaleOrderId"].ToString());

                var Objs = _consolecontext.Request.Where(x => x.FactorNumber == FactorNumber).FirstOrDefault();
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
                return Redirect("https://myremitpay.com/Verify/" + _rcm.GTTN);
            }
            catch(Exception ex) {
                return Redirect("https://myremitpay.com/Verify/NoTransaction");
            }

        }
    }
}
