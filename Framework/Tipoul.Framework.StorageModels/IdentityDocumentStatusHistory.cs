using System;
using System.ComponentModel;

namespace Tipoul.Framework.StorageModels
{
    public class IdentityDocumentStatusHistory
    {
        public IdentityDocumentStatusHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string? Description { get; set; }

        public int UserId { get; set; }

        public int IdentityDocumentId { get; set; }

        public StatusType Status { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public IdentityDocument IdentityDocument { get; set; }

        public enum StatusType
        {
            Pending = 1,
            Accepted = 2,
            Rejected = 3
        }

        public static string GetStatusTypeName(StatusType statusType)
        {
            switch (statusType)
            {
                case StatusType.Pending:
                    return "در انتظار بررسی";
                case StatusType.Accepted:
                    return "تأیید شده";
                case StatusType.Rejected:
                    return "رد شده";
                default:
                    throw new InvalidEnumArgumentException(nameof(statusType));
            }
        }
    }
}
