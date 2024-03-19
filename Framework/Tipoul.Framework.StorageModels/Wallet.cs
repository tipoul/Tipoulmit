using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Wallet
    {
        public Wallet()
        {
            CommertialGateWays = new List<CommertialGateWay>();
            Settlements = new List<Settlement>();
            WalletDepositRequests = new List<WalletDepositRequest>();
        }

        public int Id {  get; set; }

        public string Title { get; set; }

        public string? WalletCode { get; set; }

        public long Amount { get; set; }

        /// <summary>
        /// موجودی قابل برداشت
        /// </summary>
        public long AmountInHand { get; set; }

        public long AmountSettlementable { get; set; }
        public long AmountInTipoul { get; set; }

        public int UserId { get; set; }

        public int? LegalProfileId { get; set; }

        public User User { get; set; }

        public LegalProfile LegalProfile { get; set; }

        public List<CommertialGateWay> CommertialGateWays { get; set; }

        public List<Settlement> Settlements { get; set; }
        public List<WalletDepositRequest> WalletDepositRequests { get; set; }
    }
}
