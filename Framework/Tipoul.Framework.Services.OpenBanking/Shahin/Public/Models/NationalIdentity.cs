using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models
{
    public class NationalIdentity
    {
        public string nationalCode { get; set; }       
        public string birthDate { get; set; }
    }
    public class NationalIdentityResultObject
    {
        public string nationalCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public Boolean alive { get; set; }
        public string Birthdate { get; set; }       
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class NationalIdentityResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public NationalIdentityResultObject respObject { get; set; }
    }
}
