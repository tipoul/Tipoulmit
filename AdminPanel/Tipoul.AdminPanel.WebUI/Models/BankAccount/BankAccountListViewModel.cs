
using System.Collections.Generic;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

namespace Tipoul.AdminPanel.WebUI.Models.BankAccount
{
    public class BankAccountListViewModel : ListViewModel
    {
        public BankAccountListViewModel(int count, int? pageNumber, List<BankAccountListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}