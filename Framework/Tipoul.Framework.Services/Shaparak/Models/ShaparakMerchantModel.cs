using System;
using System.Collections.Generic;

using Tipoul.Framework.Services.Shaparak.Models.Enums;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakMerchantModel
    {
        public ShaparakMerchantModel(string firstNameFa, string lastNameFa, string fatherNameFa, string firstNameEn, string lastNameEn, string fatherNameEn, Gender gender, long birthDate, string nationalCode,
            string comNameFa, string comNameEn, LegalityType merchantType, string nationalLegalCode, string description, string telephoneNumber, string cellPhoneNumber,
            string emailAddress, string webSite, List<ShaparakMerchantIbanModel> merchantIbans)
        {
            FirstNameFa = firstNameFa;
            LastNameFa = lastNameFa;
            FatherNameFa = fatherNameFa;
            FirstNameEn = firstNameEn;
            LastNameEn = lastNameEn;
            FatherNameEn = fatherNameEn;
            Gender = gender;
            BirthDate = birthDate;
            NationalCode = nationalCode;
            ComNameFa = comNameFa;
            ComNameEn = comNameEn;
            MerchantType = merchantType;
            ResidencyType = Residency.Iranian;
            VitalStatus = Vital.Live;
            NationalLegalCode = nationalLegalCode;
            Description = description;
            TelephoneNumber = telephoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            EmailAddress = emailAddress;
            WebSite = webSite;
            MerchantIbans = merchantIbans;
        }

        public string FirstNameFa { get; set; }

        public string LastNameFa { get; set; }

        public string FatherNameFa { get; set; }

        public string FirstNameEn { get; set; }

        public string LastNameEn { get; set; }

        public string FatherNameEn { get; set; }

        public Enums.Gender Gender { get; set; }

        public long BirthDate { get; set; }

        public long? RegisterDate { get; set; } = null;

        public string NationalCode { get; set; }

        public string RegisterNumber { get; set; }

        public string ComNameFa { get; set; }

        public string ComNameEn { get; set; }

        public Enums.LegalityType MerchantType { get; set; }

        public Enums.Residency ResidencyType { get; set; } = Enums.Residency.Iranian;

        public Enums.Vital VitalStatus { get; set; } = Enums.Vital.Live;

        public int? BirthCrtfctNumber { get; set; } = null;

        public int? BirthCrtfctSerial { get; set; } = null;

        public int? BirthCrtfctSeriesLetter { get; set; } = null;

        public int? BirthCrtfctSeriesNumber { get; set; } = null;

        public string NationalLegalCode { get; set; }

        public string CommercialCode { get; set; } = null;

        public string CountryCode { get; set; } = null;

        public string ForeignPervasiveCode { get; set; } = null;

        public string PassportNumber { get; set; } = null;

        public long? PassportExpireDate { get; set; } = null;

        public string Description { get; set; }

        public string TelephoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string WebSite { get; set; }

        public string Fax { get; set; } = null;

        public List<ShaparakMerchantIbanModel> MerchantIbans { get; set; }

        public List<ShaparakMerchantOfficerModel> MerchantOfficers { get; set; }

        public string UpdateAction { get; set; } = null;

        public class ShaparakMerchantOfficerModel
        {
            public string FirstNameFa { get; set; }

            public string LastNameFa { get; set; }

            public string FatherNameFa { get; set; }

            public string FirstNameEn { get; set; }

            public string LastNameEn { get; set; }

            public string FatherNameEn { get; set; }

            public Enums.Gender Gender { get; set; }

            public long Birthdate { get; set; }

            public string NationalCode { get; set; }

            public Enums.Residency ResidencyType { get; set; }

            public Enums.Vital VitalStatus { get; set; }

            public int BirthCrtfctNumber { get; set; }

            public int BirthCrtfctSerial { get; set; }

            public Enums.CrtfctSeriesLetter BirthCrtfctSeriesLetter { get; set; }

            public int BirthCrtfctSeriesNumber { get; set; }

            public string CountryCode { get; set; }

            public string ForeignPervasiveCode { get; set; }

            public string PassportNumber { get; set; }

            public long PassportExpireDate { get; set; }

            public string Description { get; set; }
        }
    }
}
