using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Transactionv1
    {
        public long Id { get; set; }
        public long ?FactorNumber { get; set; }
        public int ?RespCode { get; set; }
        public string ?CardNumber { get; set; }
        public string ?RRN { get; set; }
        public string ?GTRN { get; set; }
        public string ?GTTN { get; set; }
        public long ?Amount { get; set; }
        public DateTime ?DatePaid { get; set; }
        public string ?TraceNumber { get; set; }
        public string ?IssuerBank { get; set; }

    }
}
