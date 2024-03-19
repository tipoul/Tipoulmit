using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class AccountBalanceResultModelRespObject
    {
        public long availableBalance { get; set; }
        public long effectiveBalance { get; set; }
        public string? accountType { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class AccountBalanceResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public AccountBalanceResultModelRespObject respObject { get; set; }
    }
}
