using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models
{
    public class AccountStatement
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string fromDate { get; set; }
        public string fromTime { get; set; }
        public string toDate { get; set; }
        public string toTime { get; set; }
    }
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
    public class AccountStatementResultObject
    {
        public List<AccountStatementList> accountStatementList { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class AccountStatementResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountStatementResultObject respObject { get; set; }
    }
}
