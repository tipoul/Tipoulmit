
using System.Collections.Generic;

namespace Tipoul.Services.Shared.Models.Pay
{
    public class GetTokenModel
    {
        public string GateToken { get; set; }

        public long Amount { get; set; }

        public string CallBackUrl { get; set; }

        public string? PayerUserId { get; set; }

        public string? PayerName { get; set; }

        public string? PayerMobile { get; set; }

        public string? FactorNumber { get; set; }

        public string? PayerMail { get; set; }

        public List<string>? ValidCardNum { get; set; }

        public string? BlankForPayer { get; set; }

        public string? BlankForTransaction { get; set; }

        public string? Description { get; set; }

        public string? IPG { get; set; }
    }
}