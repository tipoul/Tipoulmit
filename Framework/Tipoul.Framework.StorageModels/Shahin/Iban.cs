using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class Iban
    {
        public Iban()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string AccType { get; set; }
        public string AccessToken { get; set; }
        public IbanResponce IbanResponce { get; set; }
    }
}
