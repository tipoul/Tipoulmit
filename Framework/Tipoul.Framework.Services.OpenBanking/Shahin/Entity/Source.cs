using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Entity
{
    [Table("Source", Schema = "ShahinDB")]
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public string ?AccountNo { get; set; }
        public string ?Username { get; set; }
        public string ?Password { get; set; }
        public string ?NationalCode { get; set; }
        public Boolean ActiveState { get; set; }
        
    }
}
