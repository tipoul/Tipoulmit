using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.NationalCode.Inquiry
{
    public class OutNationalInquiry
    {
        public class OutModelNationalInquiry
        {
            public string? message { get; set; }
            public string statuscode { get; set; }
            public string? messagecode { get; set; }
            public string trakingnumber { get; set; }
            public long tracenumber { get; set; }
            public ResultObjectModelNationalInquiry resultobject { get; set; }
        }
        public class ResultObjectModelNationalInquiry
        {
            public string nationalCode { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string fatherName { get; set; }
            public Boolean alive { get; set; }
            public string Birthdate { get; set; }

        }
    }
}
