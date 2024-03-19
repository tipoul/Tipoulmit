namespace Tipoul.Services.Shared.Models.Banking
{
    public class BankingTransferResult
    {
        public string OwnerName { get; set; }
        public string AccountNumber { get; set; }
        public string IbanNumber { get; set; }
        public string CardNumber { get; set; }
        public string NationalCode { get; set; }
        public long Amount { get; set; }
        public string Babat { get; set; }
        public string Sharh { get; set; }
        public string Bank { get; set; }
        public string TransferType { get; set; }
        public string SettlementCreateDate { get; set; }
        public string DepositCreateDate { get; set; }
        public long AmountInTipoulAfterSettlement { get; set; }
        public string TraceNumber { get; set; }
        public string DocutmentURL { get; set; }
    }
}