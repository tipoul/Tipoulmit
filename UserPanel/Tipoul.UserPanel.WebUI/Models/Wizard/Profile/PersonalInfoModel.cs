using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Wizard.Profile
{
    public class PersonalInfoModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string NationalCode { get; set; }

        public string AvatarURL { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
