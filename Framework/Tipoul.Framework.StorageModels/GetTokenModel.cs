using System;

namespace Tipoul.Framework.StorageModels
{
    public class GetTokenModel
    {
        public GetTokenModel()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string? GateToken { get; set; }

        public long Amount { get; set; }

        public string? CallBackUrl { get; set; }

        public string? PayerUserId { get; set; }

        public string? PayerName { get; set; }

        public string? PayerMobile { get; set; }

        public string? FactorNumber { get; set; }

        public string? PayerMail { get; set; }

        public string? ValidCardNum { get; set; }

        public string? BlankForPayer { get; set; }

        public string? BlankForTransaction { get; set; }

        public string? Description { get; set; }

        public string? IPG { get; set; }

        public int RequestId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
