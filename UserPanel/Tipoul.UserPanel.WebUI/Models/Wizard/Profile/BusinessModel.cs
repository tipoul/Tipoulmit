using System.Collections.Generic;

namespace Tipoul.UserPanel.WebUI.Models.Wizard.Profile
{
    public class BusinessModel
    {
        public BusinessModel()
        {
            JobStates = new List<IdName>();
            JobSelectedStateCities = new List<IdName>();
            BusinessCategories = new List<IdName>();
            BusinessSelectedCaqtegorySubCategories = new List<IdName>();
        }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string? JobAddress { get; set; }

        public string? JobPostalCode { get; set; }

        public string? JobPhoneNumberCode { get; set; }

        public string? JobPhoneNumberValue { get; set; }

        public int? BusinessCategoryId { get; set; }

        public int? BusinessSubCategoryId { get; set; }

        public List<IdName> JobStates { get; set; }

        public List<IdName> JobSelectedStateCities { get; set; }

        public List<IdName> BusinessCategories { get; set; }

        public List<IdName> BusinessSelectedCaqtegorySubCategories { get; set; }

        public class IdName
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
