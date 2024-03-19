using System;

namespace Tipoul.AdminPanel.WebUI.Models.Settlements
{
    public class SettlementsListItemViewModel
    {
        public int Id { get; set; }

        public long Amount { get; set; }
        public long Wage { get; set; }
        public long AmountInTipoulAfterSettlement { get; set; }
        public long AmountInBankAfterSettlement { get; set; }
        public string BankAccount { get; set; }
        public bool QuickSettlement { get; set; }
        public string RequestedUuid { get; set; }
        public string Wallet { get; set; }
        public string LastStatus { get; set; }
        public string UserFullName { get; set; }
        public string DestIban { get; set; }
        public string SelectedDate { get; set; }
        public string CreateDate { get; set; }
        public string OwnerName { get; set; }
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public string NationalCode { get; set; }
        public string Babat { get; set; }
        public string DestnitionBank { get; set; }
        public string Sharh { get; set; }
    }
}
