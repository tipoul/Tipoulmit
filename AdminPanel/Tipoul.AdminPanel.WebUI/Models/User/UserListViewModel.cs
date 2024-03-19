using System.Collections.Generic;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

namespace Tipoul.AdminPanel.WebUI.Models.User
{
    public class UserListViewModel : ListViewModel
    {
        public UserListViewModel(int count, int? pageNumber, List<UserListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}