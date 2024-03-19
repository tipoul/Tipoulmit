
using System;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

using static Tipoul.Framework.StorageModels.User;

namespace Tipoul.AdminPanel.WebUI.Models.User
{
    [Title("کاربران")]
    public class UserListItemViewModel
    {
        public UserListItemViewModel(Framework.StorageModels.User model)
        {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            FatherName = model.FatherName;
            MobileNumber = model.MobileNumber;
            Email = model.Email;
        }

        public UserListItemViewModel()
        {
        }

        public int Id { get; set; }

        [HeaderTitle("نام")]
        public string? FirstName { get; set; }

        [HeaderTitle("نام خانوادگی")]
        public string? LastName { get; set; }

        [HeaderTitle("نام پدر")]
        public string? FatherName { get; set; }

        [HeaderTitle("شماره موبایل")]
        public string? MobileNumber { get; set; }

        [HeaderTitle("ایمیل")]
        public string? Email { get; set; }
    }
}