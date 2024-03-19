using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models
{
    public class CardInfos
    {       
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string cardNumber { get; set; }
        
    }
    public class CardInfoResultObject
    {
        public string ownerName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string iban { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class CardInfoResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public CardInfoResultObject respObject { get; set; }
    }
}
