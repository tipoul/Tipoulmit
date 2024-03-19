using System.Collections.Generic;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

namespace Tipoul.AdminPanel.WebUI.Models.Verification
{
    public class VerificationListViewModel : ListViewModel
    {
        public VerificationListViewModel(int count, int? pageNumber, List<VerificationListItemViewModel> items) : base(count, pageNumber)
        {
            Items = items;
        }
    }
}
