using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.BankAccount
{
    public class FormViewModel
    {
        public int Id { get; set; }

        public int BankId { get; set; }

        public string Iban { get; set; }

        public string FullName { get; set; }

        public string NationalCode { get; set; }

        public string BirthDate { get; set; }

        public bool IsActive { get; set; }
    }
}
