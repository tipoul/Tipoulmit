namespace Tipoul.Framework.Services.Shaparak.Models.Enums
{
    public enum Status
    {
        //رد نهایی
        Rejected = 5,
        //در انتظار ارائه سرویس درخواستی
        Pending = 8,
        /*
         * تأخیر در پردازش
         * درمواردی از قبیل در دسترس نبودن سرویسهای استعالم اطالعات هویتی و آدرس پستی و ...
         * پردازش رکوردها تا زمان رفع مشکل بوجود آمده به تاخیر خواهد افتاد
         */
        Delaied = 12,
        //تایید نهایی
        Accepted = 14,
        //در پروسه بررسی و تایید داخلی شاپرک
        Processing = 20
    }
}
