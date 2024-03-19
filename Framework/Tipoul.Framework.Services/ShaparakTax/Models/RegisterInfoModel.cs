using System;
using System.Globalization;

namespace Tipoul.Framework.Services.ShaparakTax.Models
{
    public class RegisterInfoModel
    {
        public RegisterInfoModel(DateTime birthDate)
        {
            var pc = new PersianCalendar();

            Birthdate = $"{pc.GetYear(birthDate).ToString()}{pc.GetMonth(birthDate).ToString().PadLeft(2, '0')}{pc.GetDayOfMonth(birthDate).ToString().PadLeft(2, '0')}";
        }

        public string NationalID { get; set; }

        public int TaxpayerType { get; } = 1;

        public string Birthdate { get; }

        public string PostalCode { get; set; }

        public string MobileNumber { get; set; }

        public string TaxpayerBusinessName { get; set; }

        public string Tel { get; set; }

        public string TelCode { get; set; }

        public string Latutide { get; } = "0";

        public string Longitude { get; } = "0";

        public int IsTejari { get; set; }

        public string TrackingNumber { get; set; }
    }
}
