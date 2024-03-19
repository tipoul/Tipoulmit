using System;
using System.ComponentModel;

namespace Tipoul.Framework.StorageModels
{
    public class WalletDepositRequestStatusHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int WalletDepositRequestId { get; set; }
        public DepositStatus Status { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public enum DepositStatus
        {
            [Description("جدید")]
            Created = 0,
            [Description("تایید شده")]
            Confirm = 1,
            [Description("رد شده")]
            Reject = 2
        }
        public virtual WalletDepositRequest WalletDepositRequest { get; set; }
    }
}
