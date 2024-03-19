using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class CommertialGateWay
    {
        public CommertialGateWay()
        {
            CreateDate = DateTime.Now;
            CommertialGateWayStatuses = new List<CommertialGateWayStatus>();
            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string WebSiteURL { get; set; }

        public string SupportPhoneNumber { get; set; }

        public string? LogoUrl { get; set; }

        public string? Description { get; set; }

        public string Token { get; set; }

        public string? MerchantNumber { get; set; }

        public string? TerminalNumber { get; set; }

        public int? DefaultBankAccountId { get; set; }

        public WagePayerSide WageSide { get; set; }

        public SettlementType Settlement { get; set; }

        public SettlementPeriodType SettlementPeriod { get; set; }

        public int BusinessSubCategoryId { get; set; }

        public int WalletId { get; set; }

        //public bool HasETrust { get; set; }

        //public int? ETrustStarsCount { get; set; }

        public DateTime CreateDate { get; set; }
        public string? RsaPublicKey { get; set; }
        public string? PassPhrase { get; set; }

        public BusinessSubCategory BusinessSubCategory { get; set; }

        public Wallet Wallet { get; set; }

        public BankAccount DefaultBankAccount { get; set; }

        public List<CommertialGateWayStatus> CommertialGateWayStatuses { get; set; }

        public List<Transaction> Transactions { get; set; }

        public enum SettlementType
        {
            Automatic = 1,
            Manual = 2
        }

        public enum SettlementPeriodType
        {
            Daily = 1,
            ThreeDays = 3,
            Weekly = 7,
            FiftheenDays = 15,
            Monthly = 30
        }

        public enum WagePayerSide
        {
            FromMe = 1,
            FromPayer = 2
        }

        public static List<SettlementType> GetAllSettlementTypes()
        {
            return Enum.GetValues<SettlementType>().ToList();
        }

        public static string GetSettlementName(SettlementType settlementType)
        {
            switch (settlementType)
            {
                case SettlementType.Automatic:
                    return "اتوماتیک";
                case SettlementType.Manual:
                    return "دستی";
                default:
                    throw new InvalidEnumArgumentException(nameof(settlementType));
            }
        }

        public static List<SettlementPeriodType> GetAllSettlementPeriodTypes()
        {
            return Enum.GetValues<SettlementPeriodType>().ToList();
        }

        public static string GetSettlementPeriodName(SettlementPeriodType settlementPeriodType)
        {
            switch (settlementPeriodType)
            {
                case SettlementPeriodType.Daily:
                    return "روزانه";
                case SettlementPeriodType.ThreeDays:
                    return "هر 3 روز";
                case SettlementPeriodType.Weekly:
                    return "هفتگی";
                case SettlementPeriodType.FiftheenDays:
                    return "هر 15 روز";
                case SettlementPeriodType.Monthly:
                    return "ماهانه";
                default:
                    return string.Empty;
                    //throw new InvalidEnumArgumentException(nameof(settlementPeriodType));
            }
        }

        public static List<WagePayerSide> GetAllWagePayerSides()
        {
            return Enum.GetValues<WagePayerSide>().ToList();
        }

        public static string GetWagePayerSideName(WagePayerSide wagePayerSide)
        {
            switch (wagePayerSide)
            {
                case WagePayerSide.FromMe:
                    return "از من";
                case WagePayerSide.FromPayer:
                    return "از پرداخت کننده";
                default:
                    throw new InvalidEnumArgumentException(nameof(wagePayerSide));
            }
        }
    }
}
