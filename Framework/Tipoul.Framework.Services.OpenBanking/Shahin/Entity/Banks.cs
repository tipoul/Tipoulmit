using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Entity
{
    [Table("Banks", Schema = "Publics")]   
    public class Banks
    {
        [Key]
        public int Id { get; set; }
        public string ?ShahinCode { get; set; }
        public string ?FullName { get; set; }
        public string ?PersianName { get; set; }
        public string ?Logo { get; set; }
        public string ?Code { get; set; }
        
    }
}
