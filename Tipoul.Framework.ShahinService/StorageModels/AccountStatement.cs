using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.StorageModels
{
    public class AccountStatement
    {
        public AccountStatement()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string FromDate { get; set; }
        public string FromTime { get; set; }
        public string ToDate { get; set; }
        public string ToTime { get; set; }
        public string AccessToken { get; set; }
        public AccountStatementResponce AccountStatementResponce { get; set; }
    }
}
