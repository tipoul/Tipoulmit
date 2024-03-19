using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Enums
{
    public enum AccTypeEnum
    {
        [Description("حساب قرض الحسنه جاری ـ جم")]
        currentAccountJam,
        [Description("حساب قرض الحسنه")]
        qarzolHasane,
        [Description("حساب کوتاه مدت")]
        shortTermAccount,
        [Description("حساب پسانداز - اشخاص حقیقی")]
        realSavingAccount,
        [Description("حساب پسانداز - اشخاص حقوقی")]
        galSavingAccount,
        [Description("جاری - اشخاص حقیقی")]
        realCurrentAccount,
        [Description("جاری - اشخاص حقوقی")]
        egalCurrentAccount,
        [Description("پس انداز 17")]
        savingAccount17,
        [Description("ویژه حقوقی")]
        specialLegalAccount,
    }
}
