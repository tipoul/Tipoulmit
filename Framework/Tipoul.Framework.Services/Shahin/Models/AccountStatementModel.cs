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
    public class AccountStatementModel
    {
        public AccountStatementModel(string bank, string nationalCode, string sourceAccount,
            string fromDate, string fromTime, string toDate, string toTime)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
            this.fromDate = fromDate;
            this.fromTime = fromTime;
            this.toDate = toDate;
            this.toTime = toTime;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string fromDate { get; set; }
        public string fromTime { get; set; }
        public string toDate { get; set; }
        public string toTime { get; set; }
    }
    internal class AccountStatementRequestModel
    {
        public AccountStatementRequestModel(AccountStatementModel model)
        {
            Request = model;
        }
        public AccountStatementModel Request { get; set; }
    }
}
