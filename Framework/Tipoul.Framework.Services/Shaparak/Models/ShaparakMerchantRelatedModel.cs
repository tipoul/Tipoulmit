using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakMerchantRelatedModel
    {
        public string FirstNameFa { get; set; }

        public string LastNameFa { get; set; }

        public string FatherNameFa { get; set; }

        public string FirstNameEn { get; set; }

        public string LastNameEn { get; set; }

        public string FatherNameEn { get; set; }

        public Enums.Gender Gender { get; set; }

        public long Birthdate { get; set; }

        public long RegisterDate { get; set; }

        public string NationalCode { get; set; }

        public string RegisterNumber { get; set; }

        public string ComNameFa { get; set; }

        public string ComNameEn { get; set; }

        public Enums.LegalityType MerchantType { get; set; }

        public Enums.Residency ResidencyType { get; set; }

        public Enums.Vital VitalStatus { get; set; }

        public int BirthCrtfctNumber { get; set; }

        public int BirthCrtfctSerial { get; set; }

        public Enums.CrtfctSeriesLetter BirthCrtfctSeriesLetter { get; set; }

        public int BirthCrtfctSeriesNumber { get; set; }

        public string NationalLegalCode { get; set; }

        public string CommercialCode { get; set; }

        public string CountryCode { get; set; }

        public string ForeignPervasiveCode { get; set; }

        public string PassportNumber { get; set; }

        public long PassportExpireDate { get; set; }

        public string Description { get; set; }

        public string TelephoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string WebSite { get; set; }

        public string Fax { get; set; }

        public List<ShaparakMerchantIbanModel> MerchantIbans { get; set; }

        public List<ShaparakMerchantRelatedModel> MerchantOfficers { get; set; }

        public Enums.Relation RelationType { get; set; }
    }
}
