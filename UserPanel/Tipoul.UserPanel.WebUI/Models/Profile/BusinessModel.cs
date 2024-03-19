using System.Collections.Generic;

namespace Tipoul.UserPanel.WebUI.Models.Profile
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

        public int? JobStateId { get; set; }

        public int? JobCityId { get; set; }

        public string? JobAddress { get; set; }

        public string? JobPostalCode { get; set; }

        public string? JobPhoneNumber { get; set; }

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
