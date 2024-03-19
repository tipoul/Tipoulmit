using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.BankAccount
{
    [Title("حساب های بانکی")]
    public class BankAccountListItemViewModel
    {
        public BankAccountListItemViewModel(Framework.StorageModels.BankAccount model)
        {
            Id = model.Id;
            FullName = model.FullName;
            BankName = model.Bank.Name;
            UserFullName = model.User.FirstName + " " + model.User.LastName;
        }

        public BankAccountListItemViewModel()
        {
        }

        public int Id { get; set; }

        [HeaderTitle("نام مالک حساب")]
        public string FullName { get; set; }

        [HeaderTitle("نام بانک")]
        public string BankName { get; set; }

        [HeaderTitle("نام کاربر")]
        public string UserFullName { get; set; }
    }
}