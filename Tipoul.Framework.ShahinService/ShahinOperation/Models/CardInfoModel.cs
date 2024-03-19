using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class CardInfoModel
    {
        public CardInfoModel(string bank, string nationalCode, string sourceAccount,string cardNumber)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
            this.cardNumber = cardNumber;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string cardNumber { get; set; }
    }
    internal class CardInfoRequestModel
    {
        public CardInfoRequestModel(CardInfoModel model)
        {
            Request = model;
        }
        public CardInfoModel Request { get; set; }
    }
}
