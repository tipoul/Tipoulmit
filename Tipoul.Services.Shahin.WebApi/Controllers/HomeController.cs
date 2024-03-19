using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Tipoul.Services.Shahin.WebApi.Controllers
{
   
    public class HomeController : ApiController
    {
        [AllowAnonymous]        
        [HttpGet("{id}")]
        public async Task<string> GetById(int id)
        {
            return "Mina";
        }
    }
}
