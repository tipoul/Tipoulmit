namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakMerchantIbanModel
    {
        public ShaparakMerchantIbanModel(string merchantIban, string description)
        {
            MerchantIban = merchantIban;
            Description = description;
        }

        public string MerchantIban { get; set; }

        public string Description { get; set; }
    }
}
