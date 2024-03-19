using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class AccountBalanceResponce
    {
        public AccountBalanceResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string UUID { get; set; }
        public long AvailableBalance { get; set; }
        public long EffectiveBalance { get; set; }
        public string? AccountType { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int AccountBalanceId { get; set; }
        public AccountBalance AccountBalance { get; set; }
    }
}
