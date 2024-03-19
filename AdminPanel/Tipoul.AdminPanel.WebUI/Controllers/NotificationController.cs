using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.Notification;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class NotificationController : TipoulBaseController<Notification, NotificationListViewModel, NotificationFormViewModel>
    {
        public NotificationController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<NotificationFormViewModel> GetItemAsync(int? id)
        {
            if (id.HasValue)
                return new NotificationFormViewModel(await dbContext.Notifications.FirstOrDefaultAsync(f => f.Id == id.Value));
            else
                return new NotificationFormViewModel();
        }

        protected override async Task<NotificationListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.Notifications.OrderByDescending(f => f.Id).AsQueryable();

            var count = await dbContext.Notifications.CountAsync();

            var data = await SkipTake(query, pageNumber).ToListAsync();

            return new NotificationListViewModel(count, pageNumber, data.ConvertAll(item => new NotificationListItemViewModel(item)));
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, NotificationFormViewModel model)
        {
            var dbModel = model.Id == 0 ? new Notification() : await dbContext.Notifications.FirstOrDefaultAsync(f => f.Id == model.Id);

            dbModel.Title = model.Title;
            dbModel.Description = model.Description;
            dbModel.ImageURL = model.ImageURL;
            dbModel.FileURL = model.FileURL;
            dbModel.Link = model.Link;
            dbModel.UserId = model.UserId;
            dbModel.Priority = (Notification.PriorityType)model.Priority;
            dbModel.ExpireDate = model.ExpireDate;

            if (dbModel.Id == 0)
                await dbContext.Notifications.AddAsync(dbModel);

            await dbContext.SaveChangesAsync();
        }
    }
}
