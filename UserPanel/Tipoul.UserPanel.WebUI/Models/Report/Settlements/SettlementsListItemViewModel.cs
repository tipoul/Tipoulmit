using System;

namespace Tipoul.UserPanel.WebUI.Models.Report.Settlements
{
    public class SettlementsListItemViewModel
    {
        public int Id { get; set; }

        public long Amount { get; set; }
        public long Wage { get; set; }
        public string BankAccount { get; set; }
        public bool QuickSettlement { get; set; }

        public string Wallet { get; set; }

        public string LastStatus { get; set; }
        public string RequestedUuid { get; set; }
        public string DocumentURL { get; set; }
        public string SelectedDate { get; set; }
        public string CreateDate { get; set; }
    }
}
