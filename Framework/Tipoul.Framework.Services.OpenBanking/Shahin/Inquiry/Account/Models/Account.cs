using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models
{
    public class Accounts
    {       
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    public class AccountResultObject
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string accountNumber { get; set; }
        public string branch { get; set; }
        public string accountCreationTime { get; set; }
        public string customerNumber { get; set; }
        public string accountOwnerName { get; set; }
        public string accountStatus { get; set; }
        public string? accountType { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }      
    }
    public class AccountResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountResultObject respObject { get; set; }
    }
}
