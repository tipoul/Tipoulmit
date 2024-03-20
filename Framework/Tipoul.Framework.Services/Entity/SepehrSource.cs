using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.Services.Entity
{
    [Table("Source", Schema = "Sepehr")]
    public class SepehrSource
    {
        [Key]
        public int Id { get; set; }
        public int TipoulGetwayId { get; set; }
        public string TerminalId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
