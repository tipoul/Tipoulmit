using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.Infrastructure.RequestLog.DataAccessLayer;

namespace Tipoul.Athentication.Web.Controllers
{
    public class StatusController : Controller
    {
        public async Task<string> Index([FromServices] TipoulFrameworkDbContext dbContext, [FromServices] RequestLogDbContext requestLogDbContext)
        {
            await dbContext.Users.FirstOrDefaultAsync();
            await requestLogDbContext.Requests.FirstOrDefaultAsync();

            return "I`m up and running";
        }
    }
}
