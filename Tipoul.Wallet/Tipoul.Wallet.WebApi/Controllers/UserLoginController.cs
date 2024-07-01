using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tipoul.Console.WebApi.Data;
using Tipoul.CoreBanking.Services.KYC.OutModel.Cart;
using Tipoul.CoreBanking.Switch;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Wallet.WebApi.Entity;
using Tipoul.Wallet.WebApi.Infrastructure;
using Tipoul.Wallet.WebApi.Models;

namespace Tipoul.Wallet.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class UserLoginController : ControllerBase
    {
        private readonly IHttpContextAccessor contextAccessor;


        private readonly IConfiguration configuration;

        private static Random rand = new Random((int)DateTime.Now.Ticks);

        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };



        private readonly IUnitOfWorkWallet _unitOfWork;

        private readonly IHttpContextAccessor _contextAccessor;
        public UserLoginController(IConfiguration config, IUnitOfWorkWallet unitOfWork, IHttpContextAccessor contextAccessor, ConsoleContext consolecontext)
        {

            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;

        }

        [HttpPost("login")]
        public async Task<ResponseLogin> Login([FromServices] IConfiguration configuration, [FromForm] RequestLogin model)
        {
            ResponseLogin _res = new ResponseLogin();
            try
            {
                var Objs= _unitOfWork.UsersRepo.Login(model.Username, model.Password);
                
                if (Objs==null)
                {
                    _res.statuscode = "200";
                    _res.message = "نام کاربری یا کلمه عبور یافت نشد";
                    _res.messagecode = "10001";

                    ResultObjectUser _resobj = new ResultObjectUser();
                    _resobj.FirtName = "";
                    _resobj.LastName = "";
                    _resobj.Token = "";

                    _res.resultobject = _resobj;
                }
                else
                {
                    _res.statuscode = "200";
                    _res.message ="عملیات با موفقیت انجام شد";
                    _res.messagecode = "10002";

                    ResultObjectUser _resobj = new ResultObjectUser();
                    _resobj.FirtName = Objs.FirtName;
                    _resobj.LastName = Objs.LastName;
                    _resobj.Token = Objs.Token;
                    _resobj.UserId = Objs.Id.ToString();
                    _res.resultobject = _resobj;
                }
                
                
            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message =ex.Message;
                _res.messagecode = "10003";

                ResultObjectUser _resobj = new ResultObjectUser();
                _resobj.FirtName = "";
                _resobj.LastName = "";
                _resobj.Token = "";

                _res.resultobject = _resobj;
            }
            return _res;
        }
        [HttpPost("getinfo")]
        public async Task<ResponseInfo> GetInfo([FromServices] IConfiguration configuration, [FromForm] string token)
        {
            ResponseInfo _res = new ResponseInfo();
            try
            {
                var Objs = _unitOfWork.UsersRepo.GetInfo(token);

                if (Objs == null)
                {
                    _res.statuscode = "200";
                    _res.message = "کاربر یافت نشد";
                    _res.messagecode = "10001";

                    ResultObjectDashboard _resobj = new ResultObjectDashboard();
                    _resobj.FirtName = "";
                    _resobj.LastName = "";
                    _resobj.Id = 0;

                    _res.resultobject = _resobj;
                }
                else
                {
                    _res.statuscode = "200";
                    _res.message = "عملیات با موفقیت انجام شد";
                    _res.messagecode = "10002";

                    ResultObjectDashboard _resobj = new ResultObjectDashboard();
                    _resobj.FirtName = Objs.Name;
                    _resobj.LastName = Objs.Lastname;                    
                    _resobj.Id = Objs.Id;
                    _res.resultobject = _resobj;
                }


            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";

                ResultObjectDashboard _resobj = new ResultObjectDashboard();
                _resobj.FirtName = "";
                _resobj.LastName = "";
                _resobj.Id = 0;

                _res.resultobject = _resobj;
            }
            return _res;
        }
        [HttpGet("/{token}/getuserwithtoken")]
        public async Task<ResponseInfo> GetuserWithToken(string token)
        {



           
            ResponseInfo _res = new ResponseInfo();
            try
            {
                var Objs = _unitOfWork.UsersRepo.GetInfo(token);

                if (Objs == null)
                {
                    _res.statuscode = "200";
                    _res.message = "کاربر یافت نشد";
                    _res.messagecode = "10001";

                    ResultObjectDashboard _resobj = new ResultObjectDashboard();
                    _resobj.FirtName = "";
                    _resobj.LastName = "";
                    _resobj.Id = 0;

                    _res.resultobject = _resobj;
                }
                else
                {
                    _res.statuscode = "200";
                    _res.message = "عملیات با موفقیت انجام شد";
                    _res.messagecode = "10002";

                    ResultObjectDashboard _resobj = new ResultObjectDashboard();
                    _resobj.FirtName = Objs.Name;
                    _resobj.LastName = Objs.Lastname;
                    _resobj.Id = Objs.Id;
                    _res.resultobject = _resobj;
                }


            }
            catch (Exception ex)
            {
                _res.statuscode = "400";
                _res.message = ex.Message;
                _res.messagecode = "10003";

                ResultObjectDashboard _resobj = new ResultObjectDashboard();
                _resobj.FirtName = "";
                _resobj.LastName = "";
                _resobj.Id = 0;

                _res.resultobject = _resobj;
            }
            return _res;

        }

    }
}
