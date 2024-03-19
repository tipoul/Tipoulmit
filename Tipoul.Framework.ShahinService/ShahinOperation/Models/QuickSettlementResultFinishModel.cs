using System;
using System.Collections.Generic;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class QuickSettlementResultFinishModel
    {
        public string ownerName { get; set; }
        public string accountNumber { get; set; }
        public string ibanNumber { get; set; }
        public string cardNumber { get; set; }
        public string nationalCode { get; set; }
        public long amount { get; set; }
        public string babat { get; set; }
        public string sharh { get; set; }
        public string bank { get; set; }
        public string transferType { get; set; }
        public string settlementCreateDate { get; set; }
        public string depositCreateDate { get; set; }
        public long amountInTipoulAfterSettlement { get; set; }
        public string TraceNumber { get; set; }
        public string DocutmentURL { get; set; }
        public string PaymentID { get; set; }
    }
}
