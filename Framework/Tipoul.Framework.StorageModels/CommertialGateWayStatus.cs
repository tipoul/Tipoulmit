using System;

namespace Tipoul.Framework.StorageModels
{
    public class CommertialGateWayStatus
    {
        public CommertialGateWayStatus()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int CommertialGateWayId { get; set; }

        public string? Description { get; set; }

        public StatusType Status { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public CommertialGateWay CommertialGateWay { get; set; }

        public enum StatusType
        {
            Pending = 1,
            Rejected = 2,
            Accepted = 3
        }
    }
}
