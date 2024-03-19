using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tipoul.Services.OpenBanking.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShahinServicesController : ControllerBase
    {
        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpGet("{Id}")]
        public string GetById(long Id)
        {
            return "mina";
        }
    }


}
