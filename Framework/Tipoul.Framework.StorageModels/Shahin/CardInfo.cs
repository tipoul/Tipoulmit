using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class CardInfo
    {
        public CardInfo()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string CardNumber { get; set; }
        public string AccessToken { get; set; }
        public CardInfoResponce CardInfoResponce { get; set; }
    }
}
