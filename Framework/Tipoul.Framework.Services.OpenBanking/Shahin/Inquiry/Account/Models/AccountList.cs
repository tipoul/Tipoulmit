using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models
{
    public class AccountList
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    public class AccountObject
    {
        public string? accountType { get; set; }
        public string? accountTypeName { get; set; }
        public string? accountNumber { get; set; }
        public string bank { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class AccountListResultObject
    {
        public List<AccountObject> accounts { get; set; }
     }
    public class AccountListResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountListResultObject respObject { get; set; }
    }
}
