using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Profile
{
    public class LegalProfileModel
    {
        public LegalProfileModel()
        {
            States = new List<IdName>();
            SelectedStateCities = new List<IdName>();
            BusinessCategories = new List<IdName>();
            SelectedBusinessCategoryBusinessSubCategories = new List<IdName>();
        }

        public string? CompanyName { get; set; }

        public string? CommertialName { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string CompanyAddress { get; set; }

        public string? WebSiteURL { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Description { get; set; }

        public string? NatitonalCode { get; set; }

        public string? RegisterNumber { get; set; }

        public string? LogoURL { get; set; }

        public int? BusinessCategoryId { get; set; }

        public int? BusinessSubCategoryId { get; set; }

        public string NewsleterPictureUrl { get; set; }

        public string NewsleterPictureRejectReason { get; set; }

        public bool IsNewsleterPictureAccepted { get; set; }

        public DateTime? RegisterDate { get; set; }

        public List<IdName> States { get; set; }

        public List<IdName> SelectedStateCities { get; set; }

        public List<IdName> BusinessCategories { get; set; }

        public List<IdName> SelectedBusinessCategoryBusinessSubCategories { get; set; }

        public class IdName
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
