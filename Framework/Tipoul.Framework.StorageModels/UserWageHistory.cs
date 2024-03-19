using System;

namespace Tipoul.Framework.StorageModels
{
    public class UserWageHistory
    {
        public UserWageHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int UserWageTypeHistoryId { get; set; }

        public int? SettlementId { get; set; }

        public long Amount { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public UserWageTypeHistory UserWageTypeHistory { get; set; }

        public Settlement? Settlement { get; set; }
    }
}
