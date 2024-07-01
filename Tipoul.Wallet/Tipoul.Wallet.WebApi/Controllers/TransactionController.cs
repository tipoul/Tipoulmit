using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Entity;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Wallet.WebApi.Entity;
using Tipoul.Wallet.WebApi.Infrastructure;
using Tipoul.Wallet.WebApi.Models;
using Tipoul.Wallet.WebApi.Utilities;

namespace Tipoul.Wallet.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class TransactionController : ControllerBase
    {
        private readonly IHttpContextAccessor contextAccessor;


        private readonly IConfiguration configuration;

        private static Random rand = new Random((int)DateTime.Now.Ticks);

        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };



        private readonly IUnitOfWorkWallet _unitOfWork;
        private TipoulFrameworkDbContext _tipoulframeworkdbcontext;
        private ConsoleContext _consolecontext;
        private readonly IHttpContextAccessor _contextAccessor;
        public TransactionController(IConfiguration config, IUnitOfWorkWallet unitOfWork, IHttpContextAccessor contextAccessor, TipoulFrameworkDbContext tipoulframeworkbbcontext, ConsoleContext consolecontext)
        {

            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _tipoulframeworkdbcontext = tipoulframeworkbbcontext;
            _consolecontext = consolecontext;
        }

        [HttpPost("getAllTransaction")]
        public async Task<ResponseTransaction> getAllTransaction([FromServices] IConfiguration configuration, [FromForm] int userId)
        {
           
            ResponseTransaction _res = new ResponseTransaction();
            try
            {
                List<Request> _lst = _consolecontext.Request.Where(r => r.PayerUserId == userId).OrderByDescending(r=>r.Id).ToList();
                if (_lst.Count > 0)
                {
                    _res.statuscode = "200";
                    _res.message = "لیست تراکنش ها";
                    _res.messagecode = "10000";

                    List<Payer> _lstpayer = new List<Payer>();
                    foreach (var item in _lst)
                    {
                        Payer _payerObjs = new Payer();
                        var Objs = _tipoulframeworkdbcontext.Transactionv1.FirstOrDefault(r => r.GTTN == item.GTTN);
                        if (Objs != null)
                            _payerObjs.state = "1";
                        else
                            _payerObjs.state = "0";

                        _payerObjs.price = Utilitys.NumberFormat((item.Amount/10).ToString());
                        _payerObjs.name = item.PayerName;
                        _payerObjs.date = Utilitys.PersianDate(item.RegisterDate.Value);
                        _payerObjs.time= item.RegisterDate.Value.Hour+" : "+ item.RegisterDate.Value.Minute;
                        _payerObjs.description = item.Description;

                        _lstpayer.Add(_payerObjs);
                    }
                    _res.payerobject = _lstpayer;

                }
                else
                {
                    _res.statuscode = "400";
                    _res.message = "تراکنشی یافت نشد";
                    _res.messagecode = "10003";
                    _res.payerobject = null;
                }

                

            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";
                _res.payerobject = null;
            }
            return _res;
        }
        [HttpPost("allmoneybag")]
        public async Task<ResponseBag> allmoneybag([FromServices] IConfiguration configuration, [FromForm] int userId)
        {
            ResponseBag _res = new ResponseBag();
            try
            {
                List<Request> _lst = _consolecontext.Request.Where(r => r.PayerUserId == userId).ToList();
                if (_lst.Count > 0)
                {
                    _res.statuscode = "200";
                    _res.message = "موجودی کیف پول";
                    _res.messagecode = "10000";

                    long Pricing = 0;
                    foreach (var item in _lst)
                    {
                        Payer _payerObjs = new Payer();
                        var Objs = _tipoulframeworkdbcontext.Transactionv1.FirstOrDefault(r => r.GTTN == item.GTTN);
                        if (Objs != null)
                            Pricing += (Objs.Amount.Value/10);                        
                    }
                    _res.allprice = Utilitys.NumberFormat(Pricing.ToString());

                }
                else
                {
                    _res.statuscode = "400";
                    _res.message = "تراکنشی یافت نشد";
                    _res.messagecode = "10003";
                    _res.allprice = "0";
                }



            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";
                _res.allprice = "0";
            }
            return _res;
        }
        [HttpPost("checkTransaction")]
        public async Task<ResponseGttnTransaction> checkTransaction([FromServices] IConfiguration configuration, [FromForm] string GTTN)
        {
            ResponseGttnTransaction _res = new ResponseGttnTransaction();
            try
            {
               var Objs = _consolecontext.Request.FirstOrDefault(r => r.GTTN == GTTN);
                if (Objs!=null)
                {
                    _res.statuscode = "200";
                    _res.message = "تراکنش یافت شد";
                    _res.messagecode = "10000";



                    GttnResponse _payerObjs = new GttnResponse();
                    _payerObjs.price = Utilitys.NumberFormat((Objs.Amount/10).ToString());
                    _payerObjs.name = Objs.PayerName;
                    _payerObjs.description = Objs.Description;
                    _payerObjs.date = Utilitys.PersianDate(Objs.RegisterDate.Value);
                    _payerObjs.time = Objs.RegisterDate.Value.Hour + " : " + Objs.RegisterDate.Value.Minute;
                   
                    var Objss = _tipoulframeworkdbcontext.Transactionv1.FirstOrDefault(r => r.GTTN == GTTN);
                    if (Objss != null)
                    {
                        _payerObjs.state = "1";
                        _payerObjs.ipg = Objss.GTRN;
                        _payerObjs.refnumber = Objss.RRN;
                        _payerObjs.cart = Objss.CardNumber;
                    }
                    else
                    {
                        _payerObjs.state = "0";
                        _payerObjs.ipg = "";
                        _payerObjs.refnumber ="";
                        _payerObjs.cart = "";
                    }

                    
                    _res.payerobject = _payerObjs;

                }
                else
                {
                    _res.statuscode = "400";
                    _res.message = "تراکنشی یافت نشد";
                    _res.messagecode = "10003";
                    _res.payerobject = null;
                }



            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";
                _res.payerobject = null;
            }
            return _res;
        }
    }
}
