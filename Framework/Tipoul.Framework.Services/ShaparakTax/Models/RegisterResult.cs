namespace Tipoul.Framework.Services.ShaparakTax.Models
{
    public class RegisterResult
    {
        public int ServiceLogId { get; set; }

        public string TrackingNumber { get; set; }

        /// <summary>
        /// شماره رهگیری ثبت نام الکترونیک پرونده مالیاتی
        /// </summary>
        public string FollowCode { get; set; }

        public ErrorStatusType ErrorStatus { get; set; }

        /// <summary>
        /// 1 => کدپستی قابل قبول نمی باشد
        /// 2 => نام واحد کسبی و یا شرکت باید تکمیل گردد
        /// 3 => نوع مودی قابل قبول نمی باشد
        /// 4 => امکان ثبت نام یک شخص انفراد ی در یک مکان بیش از یکبار وجود ندارد
        /// 5 => امکان تشخیص ا الپات ثبت نام از روی شماره پستی فراهم نمی باشد
        /// 6 => شماره ملی با تاری تولد مطابقت ندارد
        /// 7 => در صورت عدم استعلام شماره ملی و تاری تولد از ثبت احوال خطا ثبت احوال نمایش داده خواهد شد
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// تطابق شماره موبایل و کد ملی
        /// </summary>
        public bool? ShahkarValid { get; set; }

        /// <summary>
        /// کلید سیستمی پرونده مالیاتی
        /// </summary>
        public string TprId { get; set; }

        public enum ErrorStatusType
        {
            Success = 0,
            Error
        }
    }
}
