using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.Account.MatchNationalCode
{
    public class OutModel
    {
        public string? message { get; set; }
        public string statuscode { get; set; }
        public string? messagecode { get; set; }
        public string trakingnumber { get; set; }
        public long tracenumber { get; set; }
        public ResultObject resultobject { get; set; }
    }
    public class ResultObject
    {
       
        public string nationalCode { get; set; }
       
    }

}
