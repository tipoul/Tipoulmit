using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Notification
    {
        public Notification()
        {
            CreateDate = DateTime.Now;
            NotificationUsers = new List<NotificationUser>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? ImageURL { get; set; }

        public string? FileURL { get; set; }

        public string? Link { get; set; }

        public int UserId { get; set; }

        public PriorityType Priority { get; set; }

        public DateTime? ExpireDate { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public List<NotificationUser> NotificationUsers { get; set; }

        public enum PriorityType
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

        public static List<PriorityType> GetAllPriorityTypes()
        {
            return Enum.GetValues(typeof(PriorityType)).Cast<PriorityType>().ToList();
        }

        public static string GetPriorityTypeName(PriorityType priorityType)
        {
            switch (priorityType)
            {
                case PriorityType.Low:
                    return "کم";
                case PriorityType.Medium:
                    return "متوسط";
                case PriorityType.High:
                    return "زیاد";
                default:
                    throw new InvalidEnumArgumentException(nameof(priorityType));
            }
        }
    }
}
