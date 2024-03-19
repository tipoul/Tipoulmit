using System;
using System.ComponentModel;

namespace Tipoul.Framework.StorageModels
{
    public class TransactionConfirmResult
    {
        public TransactionConfirmResult()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public ConfirmStatus Status { get; set; }

        public string? ReturnId { get; set; }

        public string? Message { get; set; }

        public string TipoulTrackNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public enum ConfirmStatus
        {
            OK,
            NOK,
            Duplicate,
            False,
            True
        }

        public static string GetConfirmStatusName(ConfirmStatus confirmStatus)
        {
            switch (confirmStatus)
            {
                case ConfirmStatus.OK:
                    return "موفق";
                case ConfirmStatus.NOK:
                    return "ناموفق";
                case ConfirmStatus.Duplicate:
                    return "تکراری";
                default:
                    throw new InvalidEnumArgumentException(nameof(confirmStatus));
            }
        }
    }
}
