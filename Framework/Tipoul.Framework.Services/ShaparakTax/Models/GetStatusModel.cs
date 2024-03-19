using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.ShaparakTax.Models
{
    public class GetStatusModel
    {
        public string TrackingNumber { get; set; }

        public string NationalId { get; set; }

        public string PostalCode { get; set; }
    }
}
