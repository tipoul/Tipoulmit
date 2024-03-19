
using System.Collections.Generic;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

namespace Tipoul.AdminPanel.WebUI.Models.CommertialGateWay
{
    public class CommertialGateWayListViewModel : ListViewModel
    {
        public CommertialGateWayListViewModel(int count, int? pageNumber, List<CommertialGateWayListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}
