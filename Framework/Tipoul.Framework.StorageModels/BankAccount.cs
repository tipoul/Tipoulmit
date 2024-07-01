using System;
using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class BankAccount
    {
        public BankAccount()
        {
            Settlements = new List<Settlement>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int BankId { get; set; }

        public string Iban { get; set; }

        public string FullName { get; set; }

        public string NationalCode { get; set; }

        public bool IsActive { get; set; }

        public bool Trashed { get; set; }

        public DateTime BirthDate { get; set; }
        public long WalletUserId { get; set; }
        public string CartNo { get; set; }

        public Bank Bank { get; set; }

        public User User { get; set; }

        public List<Settlement> Settlements { get; set; }
    }
}
