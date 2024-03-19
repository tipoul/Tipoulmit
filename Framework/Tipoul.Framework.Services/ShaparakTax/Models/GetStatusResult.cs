namespace Tipoul.Framework.Services.ShaparakTax.Models
{
    public class GetStatusResult
    {
        public string TrackingNumber { get; set; }

        /// <summary>
        /// شماره رهگیری ثبت نام الکترونیک پرونده مالیاتی
        /// </summary>
        public string FollowCode { get; set; }

        public ErrorStatusType ErrorStatus { get; set; }

        public string ErrorMessage { get; set; }

        public string StatusId { get; set; }

        public int ServiceLogId { get; set; }

        public enum ErrorStatusType
        {
            Success = 0,
            Error
        }

        public enum StatusIdType
        {
            DeactiveRegistered = -1,
            NotRegistered = 0,
            ActiveRegistered = 1
        }
    }
}
