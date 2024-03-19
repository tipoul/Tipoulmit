using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Tipoul.Framework.StorageModels
{
    public class User
    {
        public User()
        {
            CreateDate = DateTime.Now;
            IdentityDocuments = new List<IdentityDocument>();
            BankAccounts = new List<BankAccount>();
            UserAvatarHistories = new List<UserAvatarHistory>();
            UserVerificationHistories = new List<UserVerificationHistory>();
            UserWageTypeHistories = new List<UserWageTypeHistory>();
            Settlements = new List<Settlement>();
            UserWageHistories = new List<UserWageHistory>();
        }

        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? FatherName { get; set; }

        public string? AvatarURL { get; set; }

        public string? NationalCode { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? MobileNumber { get; set; }

        public bool MobileNumberConfirmed { get; set; }

        public string? Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool QuickSettlement { get; set; }
        
        public int? CityId { get; set; }

        public string? Address { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? VerificationCode { get; set; }

        public int? JobCityId { get; set; }

        public string? JobAddress { get; set; }

        public string? JobPostalCode { get; set; }

        public string? JobPhoneNumber { get; set; }

        public int? BusinessSubCategoryId { get; set; }

        public int? LegalProfileId { get; set; }

        public int? WalletId { get; set; }

        public string? TaxCode { get; set; }
        public string? OBHAuthCode { get; set; }
        
        public bool? Trashed { get; set; }

        public UserType Type { get; set; }

        public DateTime CreateDate { get; set; }

        public City JobCity { get; set; }

        public City City { get; set; }

        public LegalProfile LegalProfile { get; set; }

        public BusinessSubCategory BusinessSubCategory { get; set; }

        public Wallet Wallet { get; set; }

        public List<BankAccount> BankAccounts { get; set; }

        public List<IdentityDocument> IdentityDocuments { get; set; }

        public List<UserAvatarHistory> UserAvatarHistories { get; set; }

        public List<UserVerificationHistory> UserVerificationHistories { get; set; }

        public List<UserTaxRequestHistory> UserTaxRequestHistories { get; set; }

        public List<UserWageTypeHistory> UserWageTypeHistories { get; set; }

        public List<UserWageHistory> UserWageHistories { get; set; }

        public List<Settlement> Settlements { get; set; }

        public enum UserType
        {
            AdminPanel = 1,
            UserPanel = 2
        }

        public static List<UserType> GetAllUserTypes()
        {
            return Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();
        }

        public static string GetUserTypeName(UserType userType)
        {
            switch (userType)
            {
                case UserType.AdminPanel:
                    return "اپراتور";
                case UserType.UserPanel:
                    return "کاربر";
                default:
                    throw new InvalidEnumArgumentException(nameof(userType));
            }
        }
    }
}
