using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Wallet.WebApi.Entity;
using Tipoul.Wallet.WebApi.Infrastructure;
using Tipoul.Wallet.WebApi.Models;

namespace Tipoul.Wallet.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class UserBankAccountsController : ControllerBase
    {
        private readonly IHttpContextAccessor contextAccessor;


        private readonly IConfiguration configuration;

        private static Random rand = new Random((int)DateTime.Now.Ticks);

        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };



        private readonly IUnitOfWorkWallet _unitOfWork;
        private TipoulFrameworkDbContext _tipoulframeworkdbcontext;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserBankAccountsController(IConfiguration config, IUnitOfWorkWallet unitOfWork, IHttpContextAccessor contextAccessor, TipoulFrameworkDbContext tipoulframeworkbbcontext)
        {

            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _tipoulframeworkdbcontext = tipoulframeworkbbcontext;
        }

        [HttpPost("getbankaccounts")]
        public async Task<ResponseBankAccounts> getbankaccounts([FromServices] IConfiguration configuration, [FromForm] int userId)
        {
            ResponseBankAccounts _res = new ResponseBankAccounts();
            try
            {
                var Objs= _unitOfWork.BankAccountRepo.GetBankAccounts(_tipoulframeworkdbcontext, userId);
                
                if (Objs==null)
                {
                    _res.statuscode = "200";
                    _res.message = "کارتی یافت نشد";
                    _res.messagecode = "10001";
                    _res.cartobject = null;
                }
                else
                {
                    _res.statuscode = "200";
                    _res.message ="عملیات با موفقیت انجام شد";
                    _res.messagecode = "10002";
                    _res.cartobject = Objs;
                }               
                
            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message =ex.Message;
                _res.messagecode = "10003";
                _res.cartobject = null;
            }
            return _res;
        }
        [HttpPost("addbankaccounts")]
        public async Task<ResponseAddBankAccounts> addbankaccounts([FromServices] IConfiguration configuration, [FromForm] CartAccount cartaccount)
        {
            ResponseAddBankAccounts _res = new ResponseAddBankAccounts();
            try
            {
                var Objs = _unitOfWork.BankAccountRepo.Insert(_tipoulframeworkdbcontext, cartaccount);
                
                if (Objs != "Success")
                {
                    _res.statuscode = "200";
                    _res.message = "عدم توانایی در افزودن کارت";
                    _res.messagecode = "10001";
                    _res.anserobject = "Error";
                }
                else
                {
                    _res.statuscode = "200";
                    _res.message = "عملیات با موفقیت انجام شد";
                    _res.messagecode = "10002";
                    _res.anserobject = "Success";
                }
               
            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";
                _res.anserobject = "Error";
            }
            return _res;
        }

    }
}
