using System.Diagnostics.Contracts;

namespace Tipoul.Wallet.WebApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string Iban { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public string Images { get; set; }
        public string CartNo { get; set; }
    }
}
