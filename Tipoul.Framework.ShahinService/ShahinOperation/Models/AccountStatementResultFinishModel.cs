using System;
using System.Collections.Generic;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class AccountStatementResultFinishModel
    {
        public string sourceAccountOwnerName { get; set; }
        public string sourceAccountNumber { get; set; }
        public string sourceAccountNationalCode { get; set; }
        public string sourceAccountIbanNumber { get; set; }
        public long amount { get; set; }
        public string transferType { get; set; }
        public string babat { get; set; }
        public string destnitionBank { get; set; }
        public string sharh { get; set; }
        public string destAccountOwnerName { get; set; }
        public string destAccountNumber { get; set; }
        public string settlementCreateDate { get; set; }
        public string transactionDateTime { get; set; }
        public long amountInTipoulAfterDeposit { get; set; }
    }
}
