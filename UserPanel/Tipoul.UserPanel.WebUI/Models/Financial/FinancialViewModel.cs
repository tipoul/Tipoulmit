using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Financial
{
    public class FinancialViewModel
    {
        public int WageType { get; set; }

        public int StaticAmount { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public List<FinantialWageHistoryViewModel> Items { get; set; }
    }
}
