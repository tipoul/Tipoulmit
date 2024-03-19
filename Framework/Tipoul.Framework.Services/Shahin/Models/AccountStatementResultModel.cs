using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class AccountStatementList
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

    public class AccountStatementResultModelRespObject
    {
        public List<AccountStatementList> accountStatementList { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class AccountStatementResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountStatementResultModelRespObject respObject { get; set; }
    }





}
