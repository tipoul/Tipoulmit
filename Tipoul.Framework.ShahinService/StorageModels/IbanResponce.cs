using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.StorageModels
{
    public class IbanResponce
    {
        public IbanResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string Uuid { get; set; }
        public string? AccountNumber { get; set; }
        public string? IbanNumber { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int IbanId { get; set; }
        public Iban Iban { get; set; }
    }
}
