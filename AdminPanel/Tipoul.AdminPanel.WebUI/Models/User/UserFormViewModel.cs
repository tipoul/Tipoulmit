
using Microsoft.AspNetCore.Mvc;

using NPOI.HSSF.Record.Chart;

using System;
using System.Collections.Generic;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

using static Tipoul.Framework.StorageModels.User;

namespace Tipoul.AdminPanel.WebUI.Models.User
{
    [Title("کاربر")]
    public class UserFormViewModel : FormViewModel
    {
        public UserFormViewModel(Framework.StorageModels.User model)
        {
            Id = model.Id;

            PersonalInfo = new PersonalInfoViewModel
            {
                AvatarURL = model.AvatarURL,
                BirthDate = model.BirthDate,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
                FatherName = model.FatherName,
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                MobileNumberConfirmed = model.MobileNumberConfirmed,
                NationalCode = model.NationalCode,
                TaxCode = model.TaxCode,
                QuickSettlement = model.QuickSettlement,
            };
            Files = new FilesViewModel
            {
                BirthCertificatePicture = model.IdentityDocuments.Where(f => f.Type == Framework.StorageModels.IdentityDocument.IdentityDocumentType.BirthCertificate).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault(),
                NationalCardPicture = model.IdentityDocuments.Where(f => f.Type == Framework.StorageModels.IdentityDocument.IdentityDocumentType.NationalCard).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault(),
                ApprovalPicture = model.IdentityDocuments.Where(f => f.Type == Framework.StorageModels.IdentityDocument.IdentityDocumentType.Verification).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault()
            };
            AddressInfo = new AddressInfoViewModel
            {
                Address = model.Address,
                CityId = model.CityId,
                PhoneNumber = model.PhoneNumber,
                PostalCode = model.PostalCode
            };
            BusinessInfo = new BusinessInfoViewModel
            {
                BusinessAddress = model.JobAddress,
                BusinessCityId = model.JobCityId,
                BusinessPhoneNumber = model.JobPhoneNumber,
                BusinessSubCategoryId = model.BusinessSubCategoryId,
                BusinessPostalCode = model.JobPostalCode
            };
            LegalInfo = new LegalInfoViewModel
            {
                CommertialName = model.LegalProfile?.CommertialName,
                CompanyName = model.LegalProfile?.CompanyName,
                LegalInfoPhoneNumber = model.LegalProfile?.PhoneNumber,
                NatitonalCode = model.LegalProfile?.NatitonalCode,
                RegisterDate = (model.LegalProfile != null && model.LegalProfile.RegisterDate != null) ? model.LegalProfile.RegisterDate.Value : DateTime.Now,
                RegisterNumber = model.LegalProfile?.RegisterNumber,
                WebSiteURL = model.LegalProfile?.WebSiteURL,
                LogoURL = model.LegalProfile?.CommertialName,
                Description = model.LegalProfile?.Description,
                Id = model.LegalProfileId ?? 0,
                QuickSettlement = model.QuickSettlement,
            };
            LegalBusinessAddressInfo = new LegalBusinessAddressInfoViewModel
            {
                LegalBusinessAddressCityId = model.LegalProfile?.CityId,
                LegalBusinessAddressAddress = model.LegalProfile?.CompanyAddress
            };
            LegalFiles = new LegalFilesViewModel
            {
                NewsLetterPicture = model.LegalProfile?.IdentityDocuments.Where(f => f.Type == Framework.StorageModels.IdentityDocument.IdentityDocumentType.Newsletter)
                    .OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault()
            };
            LegalBusinessInfo = new LegalBusinessInfoViewModel
            {
                LegalBusinessPhoneNumber = model.LegalProfile?.PhoneNumber,
                LegalBusinessBusinessSubCategoryId = model.LegalProfile?.BusinessSubCategoryId
            };
        }

        public UserFormViewModel()
        {
            PersonalInfo = new PersonalInfoViewModel();
            Files = new FilesViewModel();
            AddressInfo = new AddressInfoViewModel();
            BusinessInfo = new BusinessInfoViewModel();
            LegalInfo = new LegalInfoViewModel();
            LegalBusinessAddressInfo = new LegalBusinessAddressInfoViewModel();
            LegalFiles = new LegalFilesViewModel();
            LegalBusinessInfo = new LegalBusinessInfoViewModel();
        }

        #region form parts

        [Ignore]
        public PersonalInfoViewModel PersonalInfo { get; set; }

        [Ignore]
        public FilesViewModel Files { get; set; }

        [Ignore]
        public AddressInfoViewModel AddressInfo { get; set; }

        [Ignore]
        public BusinessInfoViewModel BusinessInfo { get; set; }

        [Ignore]
        public LegalInfoViewModel LegalInfo { get; set; }

        [Ignore]
        public LegalBusinessAddressInfoViewModel LegalBusinessAddressInfo { get; set; }

        [Ignore]
        public LegalFilesViewModel LegalFiles { get; set; }

        [Ignore]
        public LegalBusinessInfoViewModel LegalBusinessInfo { get; set; }

        #endregion

        #region parsonal info

        [Ignore]
        public string? FirstName { get; set; }

        [Ignore]
        public string? LastName { get; set; }

        [Ignore]
        public string? FatherName { get; set; }

        [Ignore]
        public string? AvatarURL { get; set; }

        [Ignore]
        public string? NationalCode { get; set; }

        [Ignore]
        public DateTime? BirthDate { get; set; }

        [Ignore]
        public string? MobileNumber { get; set; }

        [Ignore]
        public bool MobileNumberConfirmed { get; set; }

        [Ignore]
        public string? Email { get; set; }

        [Ignore]
        public bool EmailConfirmed { get; set; }

        [Ignore]
        public string? TaxCode { get; set; }
        [Ignore]
        public bool QuickSettlement { get; set; }
        [Ignore]
        public double QuickSettlementWagePercent { get; set; }
        #endregion

        [FormPart]
        [Title("اطلاعات فردی")]
        public class PersonalInfoViewModel : FormViewModel
        {
            [Label("نام")]
            public string? FirstName { get; set; }

            [Label("نام خانوادگی")]
            public string? LastName { get; set; }

            [Label("نام پدر")]
            public string? FatherName { get; set; }

            [Label("تصویر پروفایل")]
            [File]
            public string? AvatarURL { get; set; }

            [Label("کد ملی")]
            [MaxLength(10)]
            [Numeric]
            public string? NationalCode { get; set; }

            [Label("تاریخ تولد")]
            public DateTime? BirthDate { get; set; }

            [Label("شماره موبایل")]
            [MaxLength(11)]
            [Numeric]
            public string? MobileNumber { get; set; }

            [Label("تأیید شماره موبایل")]
            public bool MobileNumberConfirmed { get; set; }

            [Label("ایمیل")]
            public string? Email { get; set; }

            [Label("تأیید ایمیل")]
            public bool EmailConfirmed { get; set; }

            [Label("کد مالیاتی")]
            public string? TaxCode { get; set; }
            [Label("تسویه سریع")]
            public bool QuickSettlement { get; set; }
            [Label("درصد کارمزد تسویه سریع")]
            public double QuickSettlementWagePercent { get; set; }
        }

        #region files

        [Ignore]
        public string BirthCertificatePicture { get; set; }

        [Ignore]
        public string ApprovalPicture { get; set; }

        [Ignore]
        public string NationalCardPicture { get; set; }

        #endregion

        [FormPart]
        [Title("مستندات هویتی")]
        public class FilesViewModel : FormViewModel
        {
            [Label("تصویر شناسنامه")]
            [File]
            public string BirthCertificatePicture { get; set; }

            [Label("تصویر تأییدیه")]
            [File]
            public string ApprovalPicture { get; set; }

            [Label("تصویر کارت ملی")]
            [File]
            public string NationalCardPicture { get; set; }
        }

        #region address info

        [Ignore]
        public int? CityId { get; set; }

        [Ignore]
        public string? Address { get; set; }

        [Ignore]
        public string? PostalCode { get; set; }

        [Ignore]
        public string? PhoneNumber { get; set; }

        #endregion

        [FormPart]
        [Title("اطلاعات سکونت")]
        public class AddressInfoViewModel : FormViewModel
        {
            [Label("شهر")]
            [Partial("formComponents/city")]
            public int? CityId { get; set; }

            [Label("آدرس")]
            public string? Address { get; set; }

            [Label("کد پستی")]
            [MaxLength(10)]
            [Numeric]
            public string? PostalCode { get; set; }

            [Label("شماره تماس")]
            [MaxLength(11)]
            [Numeric]
            public string? PhoneNumber { get; set; }
        }

        #region business info

        [Ignore]
        public int? BusinessCityId { get; set; }

        [Ignore]
        public string? BusinessAddress { get; set; }

        [Ignore]
        public string? BusinessPhoneNumber { get; set; }

        [Ignore]
        public string? BusinessPostalCode { get; set; }

        [Ignore]
        public int? BusinessSubCategoryId { get; set; }

        #endregion

        [FormPart]
        [Title("اطلاعات کسب و کار")]
        public class BusinessInfoViewModel : FormViewModel
        {
            [Label("شهر")]
            [Partial("formComponents/city")]
            public int? BusinessCityId { get; set; }

            [Label("آدرس")]
            public string? BusinessAddress { get; set; }

            [Label("شماره تماس شرکت")]
            [MaxLength(11)]
            [Numeric]
            public string? BusinessPhoneNumber { get; set; }

            [Label("کد پستی")]
            [MaxLength(10)]
            [Numeric]

            public string? BusinessPostalCode { get; set; }

            [Label("عنوان صنفی")]
            [Partial("formComponents/business")]
            public int? BusinessSubCategoryId { get; set; }
        }

        #region legal info

        [Ignore]
        public string? CompanyName { get; set; }

        [Ignore]
        public string? CommertialName { get; set; }

        [Ignore]
        public string? WebSiteURL { get; set; }

        [Ignore]
        public string? LegalInfoPhoneNumber { get; set; }

        [Ignore]
        public string? Description { get; set; }

        [Ignore]
        public string? NatitonalCode { get; set; }

        [Ignore]
        public string? RegisterNumber { get; set; }

        [Ignore]
        public string? LogoURL { get; set; }

        [Ignore]
        public DateTime RegisterDate { get; set; }

        #endregion

        [FormPart]
        [Title("اطلاعات حقوقی")]
        public class LegalInfoViewModel : FormViewModel
        {
            [Label("نام شرکت")]
            public string? CompanyName { get; set; }

            [Label("نام تجاری")]
            public string? CommertialName { get; set; }

            [Label("آدرس وبسایت")]
            public string? WebSiteURL { get; set; }

            [Label("شماره تماس")]
            public string? LegalInfoPhoneNumber { get; set; }

            [Label("توضیحات")]
            [TextArea]
            public string? Description { get; set; }

            [Label("شماره ملی")]
            public string? NatitonalCode { get; set; }

            [Label("شماره ثبت")]
            public string? RegisterNumber { get; set; }

            [Label("لوگو")]
            [File]
            public string? LogoURL { get; set; }

            [Label("تاریخ ثبت")]
            public DateTime RegisterDate { get; set; }

            [Label("تسویه سریع")]
            public bool QuickSettlement { get; set; }

            [Label("درصد کارمزد تسویه سریع")]
            public double QuickSettlementWagePercent { get; set; }
        }

        #region legal business address info

        [Ignore]
        public int? LegalBusinessAddressCityId { get; set; }

        [Ignore]
        public string? LegalBusinessAddressAddress { get; set; }

        //[Ignore]
        //public string? LegalBusinessAddressPostalCode { get; set; }

        #endregion

        [FormPart]
        [Title("اطلاعات محل کار")]
        public class LegalBusinessAddressInfoViewModel : FormViewModel
        {
            [Label("شهر")]
            [Partial("formComponents/city")]
            public int? LegalBusinessAddressCityId { get; set; }

            [Label("آدرس")]
            public string? LegalBusinessAddressAddress { get; set; }

            //[Label("کد پستی")]
            //[MaxLength(10)]
            //[Numeric]
            //public string? LegalBusinessAddressPostalCode { get; set; }
        }

        #region legal file

        [Ignore]
        public string NewsLetterPicture { get; set; }

        #endregion

        [FormPart]
        [Title("مستندات")]
        public class LegalFilesViewModel : FormViewModel
        {
            [Label("تصویر روزنامه رسمی")]
            [File]
            public string NewsLetterPicture { get; set; }
        }

        #region legal business info

        [Ignore]
        public string? LegalBusinessPhoneNumber { get; set; }

        [Ignore]
        public int? LegalBusinessBusinessSubCategoryId { get; set; }

        #endregion

        [FormPart]
        [Title("اطلاعات کسب و کار")]
        public class LegalBusinessInfoViewModel : FormViewModel
        {
            [Label("شماره تماس شرکت")]
            [MaxLength(11)]
            [Numeric]
            public string? LegalBusinessPhoneNumber { get; set; }

            [Label("عنوان صنفی")]
            [Partial("formComponents/business")]
            public int? LegalBusinessBusinessSubCategoryId { get; set; }
        }
    }
}