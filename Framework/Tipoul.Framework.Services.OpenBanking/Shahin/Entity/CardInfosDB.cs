using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Entity
{
    [Table("CardInfos", Schema = "ShahinDB")]
    public class CardInfos
    {
       
            [Key]
            public long Id { get; set; }
            public int BankId { get; set; }
            public int SourceId { get; set; }
            public string DestinationAccount { get; set; }
            public int DestinationAccountType { get; set; }
       
    }

}
