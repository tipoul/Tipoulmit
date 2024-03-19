using System;

namespace Tipoul.UserPanel.WebUI.Models.Report.Customers
{
    public class CustomersListItemViewModel
    {
        public string PayerName { get; set; }

        public string PayerMobile { get; set; }

        public int TotalTransactions { get; set; }

        public int SuccessTransactions { get; set; }

        public long Amount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
