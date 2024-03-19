using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class AccountStatementResponce
    {
        public AccountStatementResponce()
        {
            AccountStatementLists = new HashSet<AccountStatementList>();
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string UUID { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int AccountStatementId { get; set; }
        public AccountStatement AccountStatement { get; set; }
        public virtual ICollection<AccountStatementList> AccountStatementLists { get; set; }
    }
}
