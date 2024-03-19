using System;

namespace Tipoul.AdminPanel.WebUI.Models.Settlements
{
    public class AccountStatementListViewModel
    {
        public string transactionDate { get; set; }
        public string transactionTime { get; set; }
        public long debit { get; set; }
        public long credit { get; set; }
        public string description { get; set; }
        public long balance { get; set; }
        public string transactionTrace { get; set; }
        public string branchCode { get; set; }
        public string transactionIdentity { get; set; }
        public string statementStatus { get; set; }
        public string sourceAccount { get; set; }
        public string destinationAccount { get; set; }
    }
}
