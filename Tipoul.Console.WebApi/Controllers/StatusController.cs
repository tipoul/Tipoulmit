using Microsoft.AspNetCore.Mvc;

namespace Tipoul.Services.WebApiii.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public async Task<string> GetAsync()
        {
            //await dbContext.Users.FirstOrDefaultAsync();
            //await requestLogDbContext.ShaparakRequests.FirstOrDefaultAsync();
            //await infrastructureRequestLogDbContext.Requests.FirstOrDefaultAsync();

            return "I`m up and running";
        }
    }
}
