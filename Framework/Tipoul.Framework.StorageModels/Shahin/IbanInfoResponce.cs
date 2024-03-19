using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class IbanInfoResponce
    {
        public IbanInfoResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string Uuid { get; set; }
        public string? Bank { get; set; }
        public string? AccountNumber { get; set; }
        public string? IbanNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountStatus { get; set; }
        public string? NationalCode { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int IbanInfoId { get; set; }
        public IbanInfo IbanInfo { get; set; }
    }
}
