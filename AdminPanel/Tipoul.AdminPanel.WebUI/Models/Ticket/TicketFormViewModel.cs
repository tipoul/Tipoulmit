using System.Collections.Generic;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.Ticket
{
    [Title("تیکت")]
    public class TicketFormViewModel : FormViewModel
    {
        public TicketFormViewModel(Framework.StorageModels.Ticket model)
        {
            Title = model.Title;
            UserId = model.UserId;
            Priority = (PriorityType)model.Priority;
        }

        public TicketFormViewModel()
        {
        }

        [Label("عنوان")]
        public string Title { get; set; }

        [Label("کاربر")]
        [Partial("formComponents/User")]
        public int UserId { get; set; }

        [Label("اولویت")]
        public PriorityType Priority { get; set; }

        [Label("دپارتمان")]
        public DepartmentType Department { get; set; }

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

        public static Dictionary<int, string> GetPriorityValues()
        {
            return Framework.StorageModels.Ticket.GetAllPriorityTypes().ToDictionary(userType => (int)userType, userType => Framework.StorageModels.Ticket.GetPriorityTypeName(userType));
        }

        public static Dictionary<int, string> GetDepartmentValues()
        {
            return Framework.StorageModels.Ticket.GetAllDepartmentTypes().ToDictionary(departmentType => (int)departmentType, departmentType => Framework.StorageModels.Ticket.GetDepartmentTypeName(departmentType));
        }
    }
}
