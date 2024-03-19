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
    public class AccountBalanceModel
    {
        public AccountBalanceModel(string bank, string nationalCode, string sourceAccount)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    internal class AccountBalanceRequestModel
    {
        public AccountBalanceRequestModel(AccountBalanceModel model)
        {
            Request = model;
        }
        public AccountBalanceModel Request { get; set; }
    }
}
