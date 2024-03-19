using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Enums
{
    public enum BabatEnum
    {
        [Description("واریز حقوق")]
        HOGHOGH,
        [Description("امور بیمه خدمات")]
        BIME,
        [Description("امور درمانی")]
        DARMANI,
        [Description("امور سرمایه گذاری و بورس")]
        BOURS,
        [Description("امور ارزی در چارچوب ضوابط و مقررات")]
        ARZ,
        [Description("پرداخت قرض و تادیه دیون (قرض الحسنه، بدهی)")]
        GHARZ_AND_DION,
        [Description("امور بازنشستگی")]
        BAZNESHASTEGI,
        [Description("معاملات اموالمنقول")]
        MOAMELAT_MANGHOL,
        [Description("معاملات اموال غیر منقول")]
        MOAMELAT_GHEIR_MANGHOOL,
        [Description("مدیریت نقدینگی")]
        NAGHDINEGI,
        [Description("عوارض گمرکی")]
        GOMROK,
        [Description("تسویه مالیاتی")]
        MALIAT,
        [Description("سایر خدمات دولتی")]
        DOWLATI,
        [Description("تسهیلات و تعهدات")]
        TASHILAT,
        [Description("تودیع وثیقه")]
        VASIGHE,
        [Description("هزینه عمومی و امور روزمره")]
        OMUMI,
        [Description("کمکهای خیریه")]
        KHEIRIEH,
        [Description("خرید کالا")]
        KALA,
        [Description("خرید خدمات")]
        KHADAMAT,
    }
}
