using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.StorageModels
{
    public class AccountBalance
    {
        public AccountBalance()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string AccessToken { get; set; }
        public AccountBalanceResponce AccountBalanceResponce { get; set; }
    }
}
