using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Ticket
    {
        public Ticket()
        {
            CreateDate = DateTime.Now;
            TicketStatusHistories = new List<TicketStatusHistory>();
            TicketMessages = new List<TicketMessage>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public PriorityType Priority { get; set; }

        public DepartmentType Department { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public List<TicketStatusHistory> TicketStatusHistories { get; set; }

        public List<TicketMessage> TicketMessages { get; set; }

        public enum PriorityType
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

        public enum DepartmentType
        {
            Mali = 1,
            MoghayeratTarakonesh_Paygiry = 2,
            PoshtibanyOmoomy = 3,
            Bazaryaby = 4,
            PoshtibanyFanny_Foroosh = 5
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

        public static List<DepartmentType> GetAllDepartmentTypes()
        {
            return Enum.GetValues(typeof(DepartmentType)).Cast<DepartmentType>().ToList();
        }

        public static string GetDepartmentTypeName(DepartmentType departmentType)
        {
            switch (departmentType)
            {
                case DepartmentType.Mali:
                    return "مالی";
                case DepartmentType.MoghayeratTarakonesh_Paygiry:
                    return "مغایرت تراکنش، پیگیری";
                case DepartmentType.PoshtibanyOmoomy:
                    return "پشتیبانی عمومی";
                case DepartmentType.Bazaryaby:
                    return "بازاریابی";
                case DepartmentType.PoshtibanyFanny_Foroosh:
                    return "پشتیبانی فنی، فروش";
                default:
                    throw new InvalidEnumArgumentException(nameof(departmentType));
            }
        }
    }
}
