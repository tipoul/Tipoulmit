using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

namespace Tipoul.AdminPanel.WebUI.Models.Ticket
{
    public class TicketListViewModel : ListViewModel
    {
        public TicketListViewModel(int count, int? pageNumber, List<TicketListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}
