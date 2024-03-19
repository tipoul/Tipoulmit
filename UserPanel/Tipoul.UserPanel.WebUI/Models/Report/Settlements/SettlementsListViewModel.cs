using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Report.Settlements
{
    public class SettlementsListViewModel
    {
        public int? SelectedMinAmount { get; set; }

        public int? SelectedMaxAmount { get; set; }

        public long MinAmount { get; set; }

        public long MaxAmount { get; set; }

        public int? WalletId { get; set; }

        public int? BankAccountId { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<SettlementsListItemViewModel> Items { get; set; }
    }
}
