using Microsoft.AspNetCore.Mvc;

using Tipoul.Wallet.WebApi.Models;

namespace Tipoul.Wallet.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class InquiryController : ControllerBase
    {
        private readonly IConfiguration configuration;
       
        [HttpPost("getownercart")]
        public async Task<string> GetOwnercart([FromForm] Ownercart ownercart)
        {
            return null;



        }
    }
}
