using System;

namespace Tipoul.Framework.StorageModels
{
    public class TransactionConfirmModel
    {
        public TransactionConfirmModel()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string TipoulTraceNumber { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
