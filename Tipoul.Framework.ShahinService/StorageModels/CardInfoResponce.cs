using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.StorageModels
{
    public class CardInfoResponce
    {
        public CardInfoResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string UUID { get; set; }
        public string? OwnerName { get; set; }
        public string? AccountNumber { get; set; }
        public string? Bank { get; set; }
        public string? Iban { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int CardInfoId { get; set; }
        public CardInfo CardInfo { get; set; }
    }
}
