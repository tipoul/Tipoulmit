using System;

namespace Tipoul.Framework.StorageModels
{
    public class NotificationUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int NotificationId { get; set; }

        public DateTime? SeenDate { get; set; }

        public DateTime? LinkClickDate { get; set; }

        public User User { get; set; }

        public Notification Notification { get; set; }
    }
}
