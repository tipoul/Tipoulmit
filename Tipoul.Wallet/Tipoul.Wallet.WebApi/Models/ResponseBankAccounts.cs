namespace Tipoul.Wallet.WebApi.Models
{
    public class ResponseBankAccounts
    {

        public string message { get; set; }
        public string statuscode { get; set; }
        public string messagecode { get; set; }
        public List<BankAccount> ?cartobject { get; set; }
    }

   
}

