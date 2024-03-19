
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tipoul.Services.Shared.Models.Banking
{
    public class BankingTransferModel
    {
        public string Mobile { get; set; }
        public string WalletCode { get; set; }
        public string NationalCode { get; set; }
        public string OBHAuthCode { get; set; }
        public long Amount { get; set; }
        public string DestIban { get; set; }
        public string DestNationalCode { get; set; }
        public string DestOwnerName { get; set; }
        public string DestBirthDate { get; set; }
        public string DestBank { get; set; }
        public string TransferType { get; set; }
        public string Babat { get; set; }
        public string Sharh { get; set; }
        public string PaymentID { get; set; }
    }
}