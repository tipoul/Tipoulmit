using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.OutModel.Cart
{
    public class Outowner
    {
        public class OutModelCart
        {
            public string? message { get; set; }
            public string statuscode { get; set; }
            public string? messagecode { get; set; }
            public string trakingnumber { get; set; }
            public long tracenumber { get; set; }
            public ResultObjectCart resultobject { get; set; }
        }
        public class ResultObjectCart
        {
            public string ownerName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string iban { get; set; }

        }
    }
}
