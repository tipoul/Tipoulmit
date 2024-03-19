using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Account.Models
{
    public class AccountBalance
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    public class AccountBalanceResultObject
    {
        public long availableBalance { get; set; }
        public long effectiveBalance { get; set; }
        public string? accountType { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class AccountBalanceResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountBalanceResultObject respObject { get; set; }
    }
}
