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
    public class IbanInfoModel
    {
        public IbanInfoModel(string bank, string nationalCode, string sourceAccount)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    internal class IbanInfoRequestModel
    {
        public IbanInfoRequestModel(IbanInfoModel model)
        {
            Request = model;
        }
        public IbanInfoModel Request { get; set; }
    }
}
