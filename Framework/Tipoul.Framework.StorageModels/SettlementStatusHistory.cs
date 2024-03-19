using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Tipoul.Framework.StorageModels
{
    public class SettlementStatusHistory
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public SettlementStatus Status { get; set; }

        public User User { get; set; }

        public DateTime CreateDate { get; set; }
        public enum SettlementStatus
        {
            [Description("در انتظار بررسی")]
            InReview = 0,
            [Description("در انتظار واریز")]
            InDeposit = 1,
            [Description("رد شده")]
            Rejected = 3,
            [Description("انجام شده")]
            Done = 4,
            [Description("نامشخص")]
            UnKnown = 5,
        }
    }
}
