using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.Wizard.Profile
{
    public class AddressModel
    {
        public AddressModel()
        {
            States = new List<StateCityModel>();
            SelectedStateCities = new List<StateCityModel>();
        }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string? Address { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumberValue { get; set; }

        public string? PhoneNumberCode { get; set; }

        public List<StateCityModel> States { get; set; }

        public List<StateCityModel> SelectedStateCities { get; set; }

        public class StateCityModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
