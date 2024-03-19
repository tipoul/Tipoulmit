using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.OutModel.Iban
{
    public class OutTransfer
    {
        public class OutModelTransfer
        {
            public string? message { get; set; }
            public string statuscode { get; set; }
            public string? messagecode { get; set; }
            public string trakingnumber { get; set; }
            public long tracenumber { get; set; }
            public ResultObjectTransfer resultobject { get; set; }
        }
        public class ResultObjectTransfer
        {
            public string sourceAccountNumber { get; set; }
            public string destinationAccountNumber { get; set; }
            public long amount { get; set; }
            public string sourceBank { get; set; }
            public string destinationBank { get; set; }
            public string transferType { get; set; }
            public string traceNumber { get; set; }

        }
    }
}
