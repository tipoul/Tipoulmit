using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;
using Tipoul.Framework.Utilities.Enums;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class TransferModel
    {
        public TransferModel(string bank, string nationalCode, string sourceAccount, string destinationAccountNumber,
            string destinationBank, long amount, TransferTypeEnum transferType, BabatEnum babat, string paymentID, string documentID,
            string transferID, string depositDescription, string withdrawDescription, string smsPass)
        {
            this.bank = bank;
            this.nationalCode = nationalCode;
            this.sourceAccount = sourceAccount;
            this.destinationAccountNumber = destinationAccountNumber;
            this.destinationBank = destinationBank; 
            this.amount = amount;
            this.transferType = transferType;
            this.babat = babat;
            this.paymentID = paymentID;
            this.documentID = documentID;
            this.transferID = transferID;   
            this.depositDescription = depositDescription;   
            this.withdrawDescription = withdrawDescription; 
            this.smsPass = smsPass;
        }
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string destinationAccountNumber { get; set; }
        public string destinationBank { get; set; }
        public long amount { get; set; }
        public TransferTypeEnum transferType { get; set; }
        public BabatEnum babat { get; set; }
        public string paymentID { get; set; }
        public string documentID { get; set; }
        public string transferID { get; set; }
        public string depositDescription { get; set; }
        public string withdrawDescription { get; set; }
        public string smsPass { get; set; }
    }
    internal class TransferRequestModel
    {
        public TransferRequestModel(TransferModel model)
        {
            Request = model;
        }
        public TransferModel Request { get; set; }
    }
}
