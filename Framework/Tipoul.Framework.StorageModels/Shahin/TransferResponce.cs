﻿using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class TransferResponce
    {
        public TransferResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string UUID { get; set; }
        public string? SourceAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public long Amount { get; set; }
        public string? SourceBank { get; set; }
        public string? DestinationBank { get; set; }
        public string? TransferType { get; set; }
        public string? TraceNumber { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
    }
}
