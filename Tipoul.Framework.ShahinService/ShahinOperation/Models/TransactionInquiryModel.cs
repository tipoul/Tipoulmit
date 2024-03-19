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
    public class TransactionInquiryModel
    {
        public TransactionInquiryModel(string bank, string nationalCode, string sourceAccount, string requestedUuid)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
            this.requestedUuid = requestedUuid;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string requestedUuid { get; set; }
    }
    internal class TransactionInquiryRequestModel
    {
        public TransactionInquiryRequestModel(TransactionInquiryModel model)
        {
            Request = model;
        }
        public TransactionInquiryModel Request { get; set; }
    }
}
