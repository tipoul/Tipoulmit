using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.Ticket;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class TicketController : TipoulBaseController<Ticket, TicketListViewModel, TicketFormViewModel>
    {
        public TicketController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<TicketFormViewModel> GetItemAsync(int? id)
        {
            if (id.HasValue)
                return new TicketFormViewModel(await dbContext.Tickets.FirstOrDefaultAsync(f => f.Id == id.Value));
            else
                return new TicketFormViewModel();
        }

        protected override async Task<TicketListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.Tickets.OrderByDescending(f => f.Id).AsQueryable();

            var count = await query.CountAsync();

            var data = await SkipTake(query, pageNumber).ToListAsync();

            return new TicketListViewModel(count, pageNumber, data.ConvertAll(item => new TicketListItemViewModel(item)));
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, TicketFormViewModel model)
        {
            var dbModel = model.Id == 0 ? new Ticket() : await dbContext.Tickets.FirstOrDefaultAsync(f => f.Id == model.Id);

            dbModel.Title = model.Title;
            dbModel.UserId = model.UserId;
            dbModel.Priority = (Ticket.PriorityType)model.Priority;

            if (dbModel.Id == 0)
                dbContext.Tickets.Add(dbModel);

            await dbContext.SaveChangesAsync();
        }
    }
}
