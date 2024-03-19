using System;

namespace Tipoul.Framework.StorageModels
{
    public class UserCommertialGateWayRegisterRequestLog
    {
        public UserCommertialGateWayRegisterRequestLog()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int CommertialGateWayId { get; set; }

        public int? SepehrLoginId { get; set; }

        public string? SepehrLoginUserName { get; set; }

        public string? Token { get; set; }

        public ServiceType Service { get; set; }

        public int? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public string? TerminalNumber { get; set; }

        public string? MerchantNumber { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public enum ServiceType
        {
            Sepehr = 1,
            IranKish = 2
        }
    }
}
