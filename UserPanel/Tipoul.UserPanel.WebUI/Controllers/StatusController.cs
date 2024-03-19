using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.DataAccessLayer;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class StatusController : Controller
    {
        public async Task<string> Index([FromServices] TipoulFrameworkDbContext dbContext, [FromServices] RequestLogDbContext requestLogDbContext, [FromServices] Infrastructure.RequestLog.DataAccessLayer.RequestLogDbContext infrastructureRequestLogDbContext)
        {
            await dbContext.Users.FirstOrDefaultAsync();
            await requestLogDbContext.ShaparakRequests.FirstOrDefaultAsync();
            await infrastructureRequestLogDbContext.Requests.FirstOrDefaultAsync();

            return "I`m up and running";
        }
    }
}
