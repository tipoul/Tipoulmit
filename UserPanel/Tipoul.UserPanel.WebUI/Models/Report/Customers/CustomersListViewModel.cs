using System.Collections.Generic;

namespace Tipoul.UserPanel.WebUI.Models.Report.Customers
{
    public class CustomersListViewModel
    {
        public int? GateWayId { get; set; }

        public int? WalletId { get; set; }

        public string Keyword { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<CustomersListItemViewModel> Items { get; set; }
    }
}
