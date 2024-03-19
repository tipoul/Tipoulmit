using System;
using System.Collections.Generic;

namespace Tipoul.UserPanel.WebUI.Models.Financial
{
    public class FinantialWageHistoryViewModel
    {
        public int Id { get; set; }

        public long Amount { get; set; }

        public DateTime CreateDate { get; set; }

        public string WageType { get; set; }

        public DateTime? SettlementDate { get; set; }

        public List<int> TransactionIds { get; set; }
    }
}
