using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class Bank
    {
        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? LogoURL { get; set; }

        public string Code { get; set; }

        public List<BankAccount> BankAccounts { get; set; }
    }
}
