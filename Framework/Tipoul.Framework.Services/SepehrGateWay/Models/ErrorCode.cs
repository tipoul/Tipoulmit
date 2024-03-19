namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public enum ErrorCode
    {
        Success = 0,
        TransActionNotFound = -1,//تراکنش پیدا نشد
        InvaliIPOrBanedPort = -2,//در زمان دریافت توکن به دلیل عدم وجود )عدم تطابق( IP و یا به دلیل بسته بودن خروجی پورت 8081 از سمت Host این خطا ایجاد میگردد.
        TotalError = -3,//خطای عمومی
        CanNotProcessThisTransaction = -4,//امکان انجام درخواست برای این تراکنش وجود ندارد
        InvalidIP = -5,//آدرس IP نامعتبر میباشد )IP در لیست آدرسهای معرفی شده توسط پذیرنده موجود نمیباشد(
        ReversePaymentIsNotActive = -6,//عدم فعال بودن سرویس برگشت تراکنش برای پذیرنده
    }
}
