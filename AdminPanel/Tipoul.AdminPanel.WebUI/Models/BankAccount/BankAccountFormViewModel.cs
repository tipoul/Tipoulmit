using System;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.BankAccount
{
    [Title("حساب بانکی")]
    public class BankAccountFormViewModel : FormViewModel
    {
        public BankAccountFormViewModel(Framework.StorageModels.BankAccount model)
        {
            Id = model.Id;
            FullName = model.FullName;
            NationalCode = model.NationalCode;
            BankId = model.BankId;
            Iban = model.Iban;
            UserId = model.UserId;
            BirthDate = model.BirthDate;
        }

        public BankAccountFormViewModel()
        {
        }

        [Label("نام مالک حساب")]
        public string FullName { get; set; }

        [Label("کد ملی")]
        [Numeric]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [Label("بانک")]
        [Partial("formComponents/bank")]
        public int BankId { get; set; }

        [Label("شماره شبا")]
        public string Iban { get; set; }

        [Label("کاربر")]
        [Partial("formComponents/user")]
        public int UserId { get; set; }

        [Label("تاریخ تولد")]
        public DateTime BirthDate { get; set; }
    }
}