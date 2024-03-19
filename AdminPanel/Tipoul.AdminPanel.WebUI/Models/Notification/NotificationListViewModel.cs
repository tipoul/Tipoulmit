using System.Collections.Generic;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.Notification
{
    [Title("پیام ها و اطلاعیه عا")]
    public class NotificationListViewModel : ListViewModel
    {
        public NotificationListViewModel(int count, int? pageNumber, List<NotificationListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}
