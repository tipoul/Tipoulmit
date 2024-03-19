using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Framework.Services.Shaparak.Models.Enums;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakRequestModel
    {
        public ShaparakRequestModel(string trackingNumberPsp, ShaparakMerchantModel merchant, List<ShaparakShopAcceptorModel> pspRequestShopAcceptors)
        {
            TrackingNumberPsp = trackingNumberPsp;
            Merchant = merchant;
            PspRequestShopAcceptors = pspRequestShopAcceptors;
        }

        public string TrackingNumberPsp { get; set; }

        public Enums.ShaparakRequestType RequestType { get; set; }

        public ShaparakMerchantModel Merchant { get; set; }

        public ShaparakMerchantRelatedModel RelatedMerchants { get; set; }

        public ShaparakContractModel Contract { get; } = new ShaparakContractModel();

        public List<ShaparakShopAcceptorModel> PspRequestShopAcceptors { get; set; }

        public string Description { get; set; }

        public class ShaparakContractModel
        {
            internal ShaparakContractModel()
            {
                ContractNumber = "59879";
                ContractDate = ServiceStartDate = DateTime.Now.AddDays(-1).ToTotalMilliseconds();
                ExpiryDate = DateTime.Now.AddYears(3).ToTotalMilliseconds();
            }

            public long ContractDate { get; set; }

            public long ExpiryDate { get; set; }

            public long ServiceStartDate { get; set; }

            public string ContractNumber { get; set; }

            public string Description { get; set; } = " ";

            public int UpdateAction { get; set; } = 0;
        }

        public class ShaparakShopAcceptorModel
        {
            public ShaparakShopAcceptorModel(ShaparakShopAcceptorShopModel shop, List<ShaparakShopAcceptorItemModel> acceptors)
            {
                Shop = shop;
                Acceptors = acceptors;
            }

            public ShaparakShopAcceptorShopModel Shop { get; set; }

            public List<ShaparakShopAcceptorItemModel> Acceptors { get; set; }

            public class ShaparakShopAcceptorShopModel
            {
                public ShaparakShopAcceptorShopModel(string farsiName, string englishName, string telephoneNumber, string postalCode, string businessCategoryCode,
                    string businessSubCategoryCode, string provinceCode, string cityCode, string emailAddress, string websiteAddress, string taxPayerCode, bool hasETrust, int? eTrustStarsCount)
                {
                    FarsiName = farsiName;
                    EnglishName = englishName;
                    TelephoneNumber = telephoneNumber;
                    PostalCode = postalCode;
                    //BusinessCertificateNumber = "59879";
                    CertificateIssueDate = null;
                    CertificateExpiryDate = null;
                    BusinessCategoryCode = businessCategoryCode;
                    BusinessSubCategoryCode = businessSubCategoryCode;
                    OwnershipType = Ownership.Renter;
                    ProvinceCode = provinceCode;
                    CityCode = cityCode;
                    BusinessType = Business.PhysicalAndVirtual;
                    if (hasETrust && eTrustStarsCount.HasValue)
                        EtrustCertificateType = eTrustStarsCount.Value == 2 ? EtrustCertificate.TwoStar : EtrustCertificate.OneStar;
                    EmailAddress = emailAddress;
                    WebsiteAddress = websiteAddress;
                    TaxPayerCode = taxPayerCode;
                    CountryCode = "IR";
                }

                public string FarsiName { get; set; }

                public string EnglishName { get; set; }

                public string TelephoneNumber { get; set; }

                public string PostalCode { get; set; }

                public string BusinessCertificateNumber { get; set; }

                public long? CertificateExpiryDate { get; set; }

                public string Description { get; set; } = null;

                public string BusinessCategoryCode { get; set; }

                public string BusinessSubCategoryCode { get; set; }

                public long? CertificateIssueDate { get; set; }

                public long? RentalExpiryDate { get; set; }

                public string RentalContractNumber { get; set; } = " ";

                public string Address { get; set; } = " ";

                public string CountryCode { get; set; }

                public string ProvinceCode { get; set; }

                public string CityCode { get; set; }

                public Enums.Ownership OwnershipType { get; set; }

                public Enums.Business BusinessType { get; set; }

                public Enums.EtrustCertificate EtrustCertificateType { get; set; }

                public object? EtrustCertificateIssueDate { get; set; } = null;

                public object? EtrustCertificateExpiryDate { get; set; } = null;

                public string EmailAddress { get; set; }

                public string WebsiteAddress { get; set; }

                public string TaxPayerCode { get; set; }
            }

            public class ShaparakShopAcceptorItemModel
            {
                public ShaparakShopAcceptorItemModel(string iin, string acceptorCode, string facilitatorAcceptorCode, List<ShaparakShopAcceptorItemTerminalModel> terminals, List<string> shaparakSettlementIbans)
                {
                    Iin = iin;
                    AcceptorCode = acceptorCode;
                    AcceptorType = Acceptor.Supported;
                    FacilitatorAcceptorCode = facilitatorAcceptorCode;
                    Cancelable = Refundable = Blockable = ChargeBackable = SettledSeparately = false;
                    AllowScatteredSettlement = AllowScatteredSettlementType.NotPermited;
                    AcceptCreditCardTransaction = AllowIranianProductsTrx = AllowKaraCardTrx = AllowGoodsBasketTrx = AllowFoodSecurityTrx = false;
                    AllowJcbCardTrx = AllowUpiCardTrx = AllowVisaCardTrx = AllowMasterCardTrx = AllowAmericanExpressTrx = AllowOtherInternationaCardsTrx = false;
                    Terminals = terminals;
                    ShaparakSettlementIbans = shaparakSettlementIbans;
                }

                public string Iin { get; set; }

                public string AcceptorCode { get; set; }

                public string FacilitatorAcceptorCode { get; set; }

                public Enums.Acceptor AcceptorType { get; set; }

                public bool Cancelable { get; set; }

                public bool Refundable { get; set; }

                public bool Blockable { get; set; }

                public bool ChargeBackable { get; set; }

                public bool SettledSeparately { get; set; }

                public Enums.AllowScatteredSettlementType AllowScatteredSettlement { get; } = Enums.AllowScatteredSettlementType.NotPermited;

                public bool AcceptCreditCardTransaction { get; set; }

                public bool AllowIranianProductsTrx { get; set; }

                public bool AllowKaraCardTrx { get; set; }

                public bool AllowGoodsBasketTrx { get; set; }

                public bool AllowFoodSecurityTrx { get; set; }

                public bool AllowJcbCardTrx { get; set; }

                public bool AllowUpiCardTrx { get; set; }

                public bool AllowVisaCardTrx { get; set; }

                public bool AllowMasterCardTrx { get; set; }

                public bool AllowAmericanExpressTrx { get; set; }

                public bool AllowOtherInternationaCardsTrx { get; set; }

                public string Description { get; set; } = " ";

                public List<string> ShaparakSettlementIbans { get; set; }

                public List<ShaparakShopAcceptorItemTerminalModel> Terminals { get; set; }

                public class ShaparakShopAcceptorItemTerminalModel
                {
                    public ShaparakShopAcceptorItemTerminalModel(string terminalNumber, string accessAddress, string callbackAddress)
                    {
                        TerminalNumber = terminalNumber;
                        SetupDate = DateTime.Now.ToTotalMilliseconds();
                        AccessAddress = accessAddress;
                        AccessPort = accessAddress.StartsWith("https://") ? 443 : 80;
                        CallbackAddress = callbackAddress;
                        CallbackPort = callbackAddress.StartsWith("https://") ? 443 : 80;
                        Description = "Sepehr PSP";
                    }

                    public int? Sequence { get; set; } = null;

                    public string TerminalNumber { get; set; }

                    public string SerialNumber { get; set; } = null;

                    public long? SetupDate { get; set; }

                    public Enums.Terminal TerminalType { get; set; } = Terminal.InternetGateWay;

                    public string HardwareBrand { get; set; } = null;

                    public string HardwareModel { get; set; } = null;

                    public string AccessAddress { get; set; }

                    public int? AccessPort { get; set; }

                    public string CallbackAddress { get; set; }

                    public int? CallbackPort { get; set; }

                    public string Description { get; set; }

                    public int EmvType { get; set; } = 0;
                }
            }
        }
    }
}
