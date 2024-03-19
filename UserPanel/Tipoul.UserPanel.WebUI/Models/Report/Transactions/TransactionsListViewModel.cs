using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Report.Transactions
{
    public class TransactionsListViewModel
    {
        public int? GateWayId { get; set; }

        public int? WalletId { get; set; }

        public string CustomerKey { get; set; }

        public string Keyword { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public bool? Success { get; set; }

        public long TotalAmount { get; set; }

        public long TotalPageAmount { get; set; }
        public string PayDateFrom_Year { get; set; }
        public string PayDateFrom_Month { get; set; }
        public string PayDateFrom_Day { get; set; }
        public string PayDateFrom_Hour { get; set; }
        public string PayDateFrom_Min{ get; set; }
        public string PayDateTo_Year { get; set; }
        public string PayDateTo_Month { get; set; }
        public string PayDateTo_Day { get; set; }
        public string PayDateTo_Hour { get; set; }
        public string PayDateTo_Min { get; set; }

        public List<TransactionsListItemViewModel> Items { get; set; }
    }
}
