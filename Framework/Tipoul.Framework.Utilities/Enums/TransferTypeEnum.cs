using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Enums
{
    public enum TransferTypeEnum
    {
        [Description("آنی (حساب به حساب)")]
        LOCAL,
        [Description("پایا")]
        PAYA,
        [Description("ساتنا")]
        SATNA
    }
}
