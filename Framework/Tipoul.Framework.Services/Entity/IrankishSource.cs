using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.Services.Entity
{
    [Table("Source", Schema = "Irankish")]
    public class IrankishSource
    {
        [Key]
        public int Id { get; set; }
        public int TipoulGetwayId { get; set; }
        public string TerminalId { get; set; }
        public string RsaPublicKey { get; set; }
        public string PassPhrase { get; set; }
        public string AcceptorId { get; set; }
        
    }
}
