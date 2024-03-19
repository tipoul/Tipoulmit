using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.OutModel.Iban
{
    public class OutIban
    {
        public class OutModelIban
        {
            public string? message { get; set; }
            public string statuscode { get; set; }
            public string? messagecode { get; set; }
            public string trakingnumber { get; set; }
            public long tracenumber { get; set; }
            public ResultObjectIban resultobject { get; set; }
        }
        public class ResultObjectIban
        {
            public string bank { get; set; }
            public string accountNumber { get; set; }
            public string ibanNumber { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string accountStatus { get; set; }            
            public string nationalCode { get; set; }
            
        }
    }
}
