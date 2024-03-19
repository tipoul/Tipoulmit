using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.CommertialGateWay;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class CommertialGateWayController : TipoulBaseController<CommertialGateWay, CommertialGateWayListViewModel, CommertialGateWayFormViewModel>
    {
        public CommertialGateWayController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<CommertialGateWayListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.CommertialGateWays.AsQueryable();

            var count = await query.CountAsync();

            var data = await SkipTake(query.OrderByDescending(f => f.Id), pageNumber).ToListAsync();

            return new CommertialGateWayListViewModel(count, pageNumber, data.ConvertAll(item => new CommertialGateWayListItemViewModel(item)));
        }

        protected override async Task<CommertialGateWayFormViewModel> GetItemAsync(int? id)
        {
            if (id.HasValue)
                return new CommertialGateWayFormViewModel(await dbContext.CommertialGateWays.FirstOrDefaultAsync(f => f.Id == id.Value));
            else
                return new CommertialGateWayFormViewModel();
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, CommertialGateWayFormViewModel model)
        {
            var dbModel = model.Id == 0 ? new CommertialGateWay() : await dbContext.CommertialGateWays.FirstOrDefaultAsync(f => f.Id == model.Id);

            dbModel.Title = model.Title;
            dbModel.WebSiteURL = model.WebSiteURL;
            dbModel.SupportPhoneNumber = model.SupportPhoneNumber;
            dbModel.LogoUrl = model.LogoUrl;
            dbModel.Description = model.Description;
            dbModel.WageSide = (CommertialGateWay.WagePayerSide)model.WageSide;
            dbModel.Settlement = (CommertialGateWay.SettlementType)model.Settlement;
            dbModel.BusinessSubCategoryId = model.BusinessSubCategoryId;

            if (dbModel.Id == 0)
                await dbContext.CommertialGateWays.AddAsync(dbModel);

            await dbContext.SaveChangesAsync();
        }
    }
}