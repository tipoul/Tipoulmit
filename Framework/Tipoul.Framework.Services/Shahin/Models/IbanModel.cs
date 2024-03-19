using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class IbanModel
    {
        public IbanModel(string bank, string nationalCode, string sourceAccount, AccTypeEnum? accType)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
            this.accType = accType;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public AccTypeEnum? accType { get; set; }
    }
    internal class IbanRequestModel
    {
        public IbanRequestModel(IbanModel model)
        {
            Request = model;
        }
        public IbanModel Request { get; set; }
    }
}
