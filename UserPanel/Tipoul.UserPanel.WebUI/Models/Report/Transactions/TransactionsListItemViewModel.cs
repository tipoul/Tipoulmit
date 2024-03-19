using System;

namespace Tipoul.UserPanel.WebUI.Models.Report.Transactions
{
    public class TransactionsListItemViewModel
    {
        public int Id { get; set; }

        public string GateWayTitle { get; set; }

        public long Amount { get; set; }

        public string PayerName { get; set; }

        public DateTime CreateDate { get; set; }

        public string PayDate { get; set; }

        public bool Success { get; set; }
    }
}
