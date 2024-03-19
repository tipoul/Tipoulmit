using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.BankAccount
{
    public class ListViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string BankName { get; set; }

        public string Iban { get; set; }

        public string BankLogoURL { get; set; }

        public bool IsActive { get; set; }
    }
}
