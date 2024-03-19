using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Wallet
{
    public class WalletViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public long Amount { get; set; }
        public long AmountWage { get; set; }

        public long AmountInHand { get; set; }

        public long AmountSettlementable { get; set; }
        public long AmountInTipoul { get; set; }
    }
}
