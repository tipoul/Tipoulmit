using System;
using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class UserVerificationHistory
    {
        public UserVerificationHistory()
        {
            CreateDate = DateTime.Now;
            UserVerificationHistoryErrors = new List<UserVerificationHistoryError>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string ServiceName { get; set; }

        public VerificationType Type { get; set; }

        public DateTime? SeenDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DoneDate { get; set; }

        public User User { get; set; }

        public int? ShaparakRequestId { get; set; }

        public List<UserVerificationHistoryError> UserVerificationHistoryErrors { get; set; }

        public enum VerificationType
        {
            Shaparak = 1
        }
    }

    public class UserTaxRequestHistory
    {
        public UserTaxRequestHistory()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int ShaparakServiceLodId { get; set; }

        public string TrackingNumber { get; set; }

        public bool ShahkarValid { get; set; }

        public string? TprId { get; set; }

        /// <summary>
        /// شماره رهگیری ثبت نام الکترونیک پرونده مالیاتی
        /// </summary>
        public string? FollowCode { get; set; }

        public int? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }
    }
}
