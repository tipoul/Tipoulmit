using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class AccountStatementList
    {
        public AccountStatementList()
        {
        }
        public int Id { get; set; }
        public string? TransactionDate { get; set; }
        public string? TransactionTime { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }
        public string? Description { get; set; }
        public long Balance { get; set; }
        public string? TransactionTrace { get; set; }
        public string? BranchCode { get; set; }
        public string? TransactionIdentity { get; set; }
        public string? StatementStatus { get; set; }
        public string? SourceAccount { get; set; }
        public string? DestinationAccount { get; set; }
        public int AccountStatementResponceId { get; set; }
        public virtual AccountStatementResponce AccountStatementResponce { get; set; }
    }
}
