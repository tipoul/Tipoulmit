using System.Diagnostics.Contracts;

namespace Tipoul.Wallet.WebApi.Models
{
    public class CartAccount
    {
        public int UserId { get; set; }
      
        public string Iban { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public int WalletUserId { get; set; }  
        public string CartNo { get; set; }
        public string BankCode { get; set; }
    }
}
