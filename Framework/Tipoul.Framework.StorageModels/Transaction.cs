using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Transaction
    {
        public Transaction()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string? InvoiceId { get; set; }

        public int RequestId { get; set; }

        public string TipoulTraceNumber { get; set; }

        public string? ISPAccessToken { get; set; }

        public string? ISPAccessTokenErrorMessage { get; set; }

        public int? GateWayId { get; set; }

        public int? UserWageHistoryId { get; set; }
        public bool InvalidReferer { get; set; }

        public bool InvalidCallbackUrl { get; set; }

        public string? Description { get; set; }

        public PSP SelectedPSP { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? RedirectToGateWay { get; set; }

        public UserWageHistory UserWageHistory { get; set; }

        public CommertialGateWay GateWay { get; set; }

        public GetTokenModel GetTokenModel { get; set; }

        public GetTokenResult GetTokenResult { get; set; }

        public TransactionResponse TransactionResponse { get; set; }

        public TransactionConfirmModel TransactionConfirmModel { get; set; }

        public TransactionConfirmResult TransactionConfirmResult { get; set; }

        public enum PSP
        {
            Sepehr = 1,
            IranKish=2
        }

        public static PSP[] GetAllPSPs()
        {
            return Enum.GetValues<PSP>();
        }

        public static string GetPSPName(PSP psp)
        {
            switch (psp)
            {
                case PSP.Sepehr:
                    return "سپهر";
                default:
                    throw new InvalidEnumArgumentException(psp.ToString());
            }
        }
    }
}
