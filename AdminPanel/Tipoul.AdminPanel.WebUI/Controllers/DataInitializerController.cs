using Ighan.SimpleExcel;
using Ighan.SimpleExcel.Attributes;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Tipoul.Framework.DataAccessLayer;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class DataInitializerController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;

        public DataInitializerController(TipoulFrameworkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var startTime = DateTime.Now;

            await dbContext.BusinessCategories.AddRangeAsync(new List<Framework.StorageModels.BusinessCategory>
        {
                        new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات دامپزشکی",
                Code = "0742",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات دامپزشکی", Code = "07420001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "07420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعاونی کشاورزی و دامداری",
                Code = "0763",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دامداری ", Code = "07630001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کشاورزی و باغداری", Code = "07630002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مرغداری", Code = "07630003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پرورش زنبور عسل", Code = "07630004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پرورش ماهی و آبزی پروری", Code = "07630005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پرورش و تولید قارچ", Code = "07630006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "07630000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات کشاورزی و باغبانی",
                Code = "0780",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "چمن‌کاری و فضای سبز", Code = "07800001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "07800000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعاونی مسکن",
                Code = "1520",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تعاونی مسکن", Code = "15200001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "شرکتهای ساختمانی و انبوه سازی", Code = "15200002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "15200000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تاسیسات ساختمان",
                Code = "1711",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تاسیسات ساختمان(لوله کشی،سرمایشی،گرمایشی)", Code = "17110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوله بازکنی و تشخیص ترکیدگی لوله", Code = "17110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کانال سازی کولر", Code = "17110005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سیستم های حرارتی، برودتی و تهویه مطبوع", Code = "17110004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تخلیه چاه", Code = "17110003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "17110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات برق ساختمان",
                Code = "1731",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "سیم کشی", Code = "17310002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "الکتروموتور،سیم پیچ و ژنراتور", Code = "17310001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تاسیسات برقی ساختمان", Code = "17310005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "17310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بنایی، معماری، سنگبری، موکت و پارکت و رنگ ساختمان",
                Code = "1740",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنایی و معماری", Code = "17400001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تولید و نصب آلاچیق", Code = "17400002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سیمانکار و موزاییک ساز", Code = "17400003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نقاش ساختمان", Code = "17400004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه سیمان و مصنوعات سیمانی", Code = "17400005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فخاران تولید آجر و گچ", Code = "17400006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نماسازی ساختمان", Code = "17400007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کاشی و سرامیک", Code = "17400008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آرماتور و اسکلت بندی،آهن کشی ساختمان", Code = "17400009" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سنگ بر و سنگ تراش", Code = "17400010" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سوله سازی", Code = "17400011" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "17400000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نجاری و کارهای چوبی",
                Code = "1750",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "نجاری و درودگری", Code = "17500001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خاتم کاری، منبت کاری و مصنوعات چوبی", Code = "17500002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "17500000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "شیروانی سازی و خدمات پوشش سقف و بامها",
                Code = "1761",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "17610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات بتن",
                Code = "1771",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "17710000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر خدمات ساختمانی",
                Code = "1799",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "داربست و اتصالات فلزی", Code = "17990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوله و اتصالات ساختمانی", Code = "17990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مصالح ساختمانی", Code = "17990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آسانسور و بالابر برقی", Code = "17990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "17990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات چاپ و انتشار متفرقه",
                Code = "2741",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "چاپ خانه داران", Code = "27410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات نشر", Code = "27410002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات تایپ و ترجمه", Code = "27410003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "27410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات حروفچینی و لیتوگرافی",
                Code = "2791",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "27910000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات نظافت، جلا و کفسابی",
                Code = "2842",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "28420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خطوط ریلی",
                Code = "4011",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "40110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "حمل و نقل درون و حومه شهر",
                Code = "4111",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "41110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "راه‌آهن مسافربری",
                Code = "4112",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی ", Code = "41120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات آمبولانس",
                Code = "4119",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "41190000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تاکسیرانی و کرایه اتومبیل",
                Code = "4121",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "41210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خطوط اتوبوس",
                Code = "4131",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پایانه اتوبوسی بین شهری", Code = "41310001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "41310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات باربری شهری و غیرشهری",
                Code = "4214",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "42140000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات پستی و پیک",
                Code = "4215",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "42150000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "انبار عمومی و ذخیره محصولات کشاورزی، سردخانه‌ای و گلخانه‌ای",
                Code = "4225",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات سردخانه", Code = "42250001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی ", Code = "42250000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خطوط کشتیرانی و حمل و نقل دریایی",
                Code = "4411",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی ", Code = "44110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات قایق، جت اسکی و تفریحات دریایی",
                Code = "4457",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "44570000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات دریایی",
                Code = "4468",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "44680000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خطوط هواپیمایی و حمل و نقل هوایی",
                Code = "4511",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "45110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فرودگاه‌ها و ترمینالهای هوایی",
                Code = "4582",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "45820000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آژانس مسافرتی، خدمات گردشگری و تور",
                Code = "4722",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "47220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "عوارض راه",
                Code = "4784",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "47840000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات حمل و نقل [سایر موارد]",
                Code = "4789",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "47890000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تجهیزات و ابزارهای مخابراتی و تلفنی",
                Code = "4812",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تلفن همراه و تجهیزات جانبی", Code = "48120001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تلفن و دستگاههای مخابراتی وتجهیزات ارتباطی", Code = "48120002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی  ", Code = "48120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دفتر خدمات مخابراتی محلی و راه‌دور",
                Code = "4814",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "48140000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات شبکه‌های کامپیوتری و اینترنت",
                Code = "4816",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات شبکه های کامپيوتری", Code = "48160001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ارائه دهنده خدمات اینترنت", Code = "48160002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "48160000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تلگراف",
                Code = "4821",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "48210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مرکز حواله الکترونیکی وجوه",
                Code = "4829",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "48290000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تلویزیونهای کابلی و پولی",
                Code = "4899",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "48990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "شرکتهای خدماتی (آب، برق، گاز)",
                Code = "4900",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "اداره برق و قبوض آن", Code = "49000001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "اداره گاز و قبوض آن", Code = "49000002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "اداره آب و فاضلاب و قبوض آن", Code = "49000003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "49000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم یدکی اتومبیل",
                Code = "5013",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50130000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مبلمان اداری و تجاری",
                Code = "5021",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مصالح ساختمانی [سایر موارد]",
                Code = "5039",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50390000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم اداری، چاپی و عکاسی",
                Code = "5044",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50440000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کامپیوتر و لوازم جانبی",
                Code = "5045",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50450000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ماشینهای تجاری [ سایر موارد]",
                Code = "5046",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "وسایل آموزشی و کمک آموزشی سمعی و بصری", Code = "50460001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تولید و فروش مانکن", Code = "50460002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "50460000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تجهیزات و لوازم پزشکی، دندانپزشکی و بیمارستانی",
                Code = "5047",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تجهیزات و لوازم پزشکی، بیمارستانی و آزمایشگاهی", Code = "50470001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تجهیزات و لوازم دندانپزشکی", Code = "50470002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "50470000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دفاتر و مراکز فروش محصولات فلزی",
                Code = "5051",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آهن آلات ساختمانی میلگرد، نبشی و ورق", Code = "50510011" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشندگان آهن، فولاد و سایر فلزات", Code = "50510001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ضایعات فلزی و غیرفلزی", Code = "50510002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تراشکاری و فلزکاری", Code = "50510003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لعاب کاری و رنگ کاری فلزات", Code = "50510004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آهن سازان", Code = "50510005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ذوب فلزات،ریخته گری و قالب سازی", Code = "50510006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آلومینیوم و مصنوعات نوردی آن", Code = "50510007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مس و مصنوعات مسی", Code = "50510008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پرسکاری فلزات", Code = "50510009" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آبکاران", Code = "50510010" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "50510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "قطعات و تجهیزات الکتریکی",
                Code = "5065",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشندگان عمده تجهیزات و قطعات الکترونیکی", Code = "50650001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تابلوسازان و موسسات برق صنعتی", Code = "50650002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تولید کننده لوازم برقی و بردهای الکترونیکی", Code = "50650003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "50650000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ابزار و تجهیزات",
                Code = "5072",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "عمده فروشان ابزار و تجهیزات", Code = "50720001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "50720000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تجهیزات لوله‌کشی و گرمایشی",
                Code = "5074",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50740000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موارد مصرفی صنعتی [سایر موارد]",
                Code = "5085",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50850000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سنگها و فلزات گرانبها ساعت و جواهرات",
                Code = "5094",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50940000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای ماندگار [سایر موارد]",
                Code = "5099",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "50990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم التحریر، ملزومات دفتری، کاغذ پرینتر و نوشت‌افزار",
                Code = "5111",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دارو، داروهای نسخه‌ای و داروهای متفرقه",
                Code = "5122",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پارچه، کمد و نخ و سایر کالاهای خشک",
                Code = "5131",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "51310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "یونفرمهای زنانه، مردانه و بچه‌گانه و لباسهای کار",
                Code = "5137",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51370000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کفشهای تجاری",
                Code = "5139",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51390000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مواد شیمیایی (سایر موارد)",
                Code = "5169",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مواد شیمیایی و آلی", Code = "51690001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مواد، مصنوعات پلاستیکی و نایلون", Code = "51690002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "گازهای صنعتی", Code = "51690003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "51690000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نفت خام و محصولات نفتی",
                Code = "5172",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51720000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کتاب، روزنامه و نشریه",
                Code = "5192",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کتابخانه", Code = "51920002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "توزیع عمده کتاب،روزنامه، مجله و گاهنامه", Code = "51920001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "51920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "گل‌، مواد گلفروشی و گلخانه",
                Code = "5193",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51930000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "رنگ، جلا و مواد مصرفی نقاشی",
                Code = "5198",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر کالاهای غیرماندگار",
                Code = "5199",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "51990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای تامین محصولات تزییات داخلی",
                Code = "5200",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "هود و سینک و کابینت فروشی", Code = "52000001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم و کالای بهداشتی ساختمان", Code = "52000002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "52000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای الوار و مصالح ساختمانی",
                Code = "5211",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی   ", Code = "52110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای شیشه، رنگ و کاغذ دیواری",
                Code = "5231",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کاغذدیواری و تزیینات داخلی ساختمان", Code = "52310001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "شیشه بری و فروشندگی شیشه و آیینه", Code = "52310002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی   ", Code = "52310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ابزار فروشیها",
                Code = "5251",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پیچ و مهره فروشان", Code = "52510002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه قفل، لولا و یراق آلات", Code = "52510003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ابزار فروشان", Code = "52510001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "قفل و کلید سازی", Code = "52510004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "52510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای لوازم باغبانی و گلخانه‌ای",
                Code = "5261",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مواد اولیه و لوازم کشاورزی و باغبانی", Code = "52610001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کود، سم و داروهای شیمیایی محصولات کشاورزی", Code = "52610002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم آبیاری و آبرسانی کشاورزی و صنعتی", Code = "52610003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "52610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان خانه‌های سیار",
                Code = "5271",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "52710000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "عمده فروشیها",
                Code = "5300",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "بار فروشان  عمده فروشی میوه و تره بار", Code = "53000001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنکدار مواد غذایی عمده فروش برنج", Code = "53000002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنکدار مواد غذایی عمده فروش چای", Code = "53000003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنکدار مواد غذایی عمده فروش روغنهای خوراکی", Code = "53000004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنکدار مواد غذایی عمده فروش کلی", Code = "53000005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بنکدار و طاقه فروش پارچه", Code = "53000006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "عمده فروشی لوازم کفاشی", Code = "53000007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "عمده فروش مواد شوینده و پاک کننده", Code = "53000008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "53000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای محصولات معاف از مالیات",
                Code = "5309",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "53090000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "حراجیها",
                Code = "5310",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "53100000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای زنجیره‌ای و بزرگ",
                Code = "5311",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه زنجیره ای رفاه", Code = "53110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه زنجیره ای شهروند", Code = "53110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه زنجیره ای اتکا", Code = "53110003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "53110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خواروبار فروشی",
                Code = "5331",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "53310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای عمومی متفرقه",
                Code = "5399",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "53990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سوپرمارکتها و فروشگاههای محصولات غذایی",
                Code = "5411",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "سوپرمارکت و خواروبارفروشی", Code = "54110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تعاونی مصرف", Code = "54110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "توزیع کنندگان مواد شوینده و بهداشتی", Code = "54110003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "54110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان گوشت بسته‌بندی شده و یخ زده",
                Code = "5422",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کشتارگاه", Code = "54220001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "قصابی و فروش محصولات گوشتی", Code = "54220002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فرآورده های گوشتی، همبرگر، سوسیس و کالباس", Code = "54220004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "54220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "قنادیها و آجیل فروشیها",
                Code = "5441",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "زعفران فروشی", Code = "54410006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "قنادی و شیرینی فروشی", Code = "54410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "حلواساز و عصار", Code = "54410003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "عسل فروشی", Code = "54410004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سوهان و گز", Code = "54410005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خشکبار و آجیل فروش", Code = "54410002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "54410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای محصولات لبنی",
                Code = "5451",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "54510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نانوایی‌ها",
                Code = "5462",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آسیاب و آرد فروشی", Code = "54620002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نانوایی و نان فانتزی", Code = "54620001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "54620000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه مواد غذایی متفرقه- مینی مارکت (بقالی)- فروشگاه کالای خاص",
                Code = "5499",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "شرکت تولید و پخش مواد غذایی", Code = "54990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "یخ فروشی", Code = "54990006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "میوه و سبزی فروشی", Code = "54990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "میدان میوه و تره بار", Code = "54990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه زیتون، ترشی و ادویه جات", Code = "54990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "غلات و حبوبات", Code = "54990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه چای، قهوه و شکلات", Code = "54990007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "54990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خودرو و کامیون ( نو و دست دوم)- فروش، سرویس، تعمیر، قطعات و رهن",
                Code = "5511",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "نمایندگی مجاز ایران خودرو", Code = "55110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نمایندگی مجاز سایپا", Code = "55110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نمایندگی مجاز سایر خودروسازان", Code = "55110003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نمایشگاه و فروشگاه اتومبیل", Code = "55110004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات لیزینگ", Code = "55110005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "55110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خودرو و کامیون ( فقط دست دوم)- فروش، سرویس، تعمیر، قطعات و رهن",
                Code = "5521",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لاستیک فروشیها",
                Code = "5532",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "قطعات و لوازم خودرو",
                Code = "5533",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم یدکی فروشی", Code = "55330001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تزیینات اتومبیل و نصب دزدگیر", Code = "55330002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تشکدوزان و صندلی سازان اتومبیل", Code = "55330003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "55330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ایستگاه خدماتی",
                Code = "5541",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "جایگاه عرضه سوخت و فرآورده‌های نفتی", Code = "55410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "جایگاه عرضه CNG", Code = "55410002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "55410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "جایگاههای سوخت اتوماتیک",
                Code = "5542",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان قایق",
                Code = "5551",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان تریلرهای تفریحی، تاسیساتی و اقامتی",
                Code = "5561",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان و فروشگاههای لوازم موتور سیکلت",
                Code = "5571",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55710000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان خانه‌های متحرک",
                Code = "5592",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان خودروهای برفی",
                Code = "5598",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "55980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ماشین‌آلات متفرقه، هواپیما و ماشین‌آلات کشاورزی",
                Code = "5599",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات حفاری", Code = "55990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات راه سازی و ساختمانی", Code = "55990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات و ادوات کشاورزی", Code = "55990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات صنعتی", Code = "55990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات چاپ و صحافی", Code = "55990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات مرغداری", Code = "55990006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ماشین آلات تراشکاری", Code = "55990007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "باسکول داری", Code = "55990008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "جرثقیل", Code = "55990009" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "55990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه پوشاک و پوشاک جانبی (اکسسوری) مردانه و پسرانه",
                Code = "5611",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه لباسهای زنانه پیش دوخته",
                Code = "5621",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه پوشاک خاص و جانبی (اکسسوری)",
                Code = "5631",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "شال و روسری فروشی", Code = "56310001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه بدلیجات تزئینی (اکسسوری)", Code = "56310002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "56310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه پوشاک نوزاد و کودک",
                Code = "5641",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پوشاک نوزاد و کودک", Code = "56410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم نوزاد و سیسمونی", Code = "56410002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "56410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه پوشاک خانواده",
                Code = "5651",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه پوشاک ورزشی و سوارکاری",
                Code = "5655",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56550000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کفش فروشیها",
                Code = "5661",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "چرم، پشم و پوست",
                Code = "5681",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56810000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پوشاک بزرگسالان",
                Code = "5691",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56910000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خیاطی، دوزندگی و رفوگری البسه",
                Code = "5697",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مانتو و شلوار و لباس زنانه سفارشی و مجلسی", Code = "56970002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لباس عروس", Code = "56970003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خیاطی و تعمیرات لباس", Code = "56970001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم ایمنی و لباس کار", Code = "56970004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دوزندگی لباس نظامی", Code = "56970005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "56970000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه موی مصنوعی و کلاه گیس",
                Code = "5698",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "56980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پوشاک و پوشاک جانبی متفرقه",
                Code = "5699",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر فروشگاههای پوشاک (دستکش،کلاه،شال گردن، جوراب، حوله و ...)", Code = "56990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "منسوجات و کالای کشباف", Code = "56990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "56990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مبلمان، تزئینات، تجهیزات خانگی",
                Code = "5712",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "57120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای کفپوش",
                Code = "5713",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه فرش، گلیم و موکت و تابلو فرش", Code = "57130001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "57130000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پرده، کرکره و پارچه مبلی",
                Code = "5714",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دوخت نصب و تعمیر انواع پرده", Code = "57140001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "رومبلی،روتختی و تزیینات پرده ای", Code = "57140002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "57140000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "شومینه، آتشدان و لوازم جانبی آنها",
                Code = "5718",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "57180000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم و تزئینات خانگی خاص و متفرقه",
                Code = "5719",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشندگان لوستر و آباژور", Code = "57190001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشندگان آیینه و قاب عکس", Code = "57190002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشندگان اجناس سفالی و سرامیکی", Code = "57190003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوستر و آیینه شمعدان", Code = "57190004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم بسته بندی و ظروف یکبار مصرف", Code = "57190005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "57190000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه دستگاههای خانگی",
                Code = "5722",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه لوازم خانگی", Code = "57220002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم و ظروف آشپزخانه", Code = "57220001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "57220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای لوازم الکترونیکی",
                Code = "5732",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه لوازم صوتی و تصویری", Code = "57320001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نمایندگی لوازم صوتی و تصویری", Code = "57320002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "57320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای لوازم موسیقی (ادوات و نت)",
                Code = "5733",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "57330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای نرم‌افزار کامپیوتری",
                Code = "5734",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "57340000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه محصولات رسانه ای",
                Code = "5735",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "57350000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تهیه غذا",
                Code = "5811",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "58110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "غذافروشی ها و رستورانها",
                Code = "5812",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "رستوران، چلوکبابی و سالن غذاخوری", Code = "58120001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تالار های پذیرایی", Code = "58120006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "طباخان و فروشندگان کله، پاچه و سیرابی", Code = "58120002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "جگر، دل و قلوه", Code = "58120003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سفره خانه", Code = "58120004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کبابی، حلیم و آش", Code = "58120005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "چای خانه و قهوه خانه", Code = "58120007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کافی شاپ و کافه تریا", Code = "58120008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "58120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "رستورانهای فست فود",
                Code = "5814",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "بستنی فروشی", Code = "58140001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "رستورانهای غذای آماده", Code = "58140002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "58140000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای دیجیتال کتاب، فیلم، موسیقی و چند -رسانه ای",
                Code = "5815",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "58150000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای دیجیتال - بازیهای دیجیتال",
                Code = "5816",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "58160000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای دیجیتال نرم افزارهای کاربردی (به -غیر از بازی)",
                Code = "5817",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "58170000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالاهای دیجیتال فروش کالای دیجیتال در مقیاس بزرگ",
                Code = "5818",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "58180000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "داروخانه‌ها",
                Code = "5912",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "داروخانه", Code = "59120001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات تولید و پخش دارو", Code = "59120002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای دسته دوم فروشی (سمساری و امانت فروشی)",
                Code = "5931",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "عتیقه فروشی فروش، تعمیر و بازسازی",
                Code = "5932",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای رهنی",
                Code = "5933",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "انبارهای اوراق خودرو",
                Code = "5935",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59350000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "همانندسازی عتیقه جات",
                Code = "5937",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59370000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای دوچرخه- فروش و خدمات",
                Code = "5940",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59400000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه کالای ورزشی",
                Code = "5941",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم و کالای ورزشی", Code = "59410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم صید و شکار", Code = "59410002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کتاب فروشیها",
                Code = "5942",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه لوازم التحریر و تجهیزات اداری",
                Code = "5943",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59430000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای جواهرآلات، ساعت مچی، ساعت، نقره",
                Code = "5944",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "ساعت فروشی", Code = "59440001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "نقره فروشی", Code = "59440002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "طراحی وساخت طلا و جواهر", Code = "59440003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروش طلا، جواهر و سنگهای قیمتی", Code = "59440004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خرده فروشی سکه طلا", Code = "59440005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59440000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای اسباب بازی، بازی و سرگرمی",
                Code = "5945",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59450000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دوربین و تجهیزات عکاسی و فیلمبرداری",
                Code = "5946",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59460000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کادویی، کارت و بدلیجات",
                Code = "5947",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تولید کارت، پاکت، جعبه و محصولات کاغذی و مقوایی", Code = "59470001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59470000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "چمدان و کالای چرمی",
                Code = "5948",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59480000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم خیاطی، سوزن دوزی و پارچه",
                Code = "5949",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "نساجی و ریسندگی", Code = "59490002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پارچه فروشی", Code = "59490003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "رنگرزی و صباغی", Code = "59490007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه نخ، کاموا و لوازم بافندگی", Code = "59490004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تشک، پتو و کالای خواب", Code = "59490005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "گونی و کیسه دوزی", Code = "59490006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "گل دوزی و سوزن دوزی", Code = "59490001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خرازی", Code = "59490008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم و تزئینات سفره عقد و لباس عروس", Code = "59490009" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59490000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه کریستال و بلور",
                Code = "5950",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم کادویی و کالای لوکس", Code = "59500001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59500000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- خدمات بیمه",
                Code = "5960",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59600000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- خدمات مسافری",
                Code = "5962",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59620000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تبلیغات و فروش خانه به خانه",
                Code = "5963",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59630000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- ارسال کاتالوگ",
                Code = "5964",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59640000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- ترکیب فروش کاتالوگی و خرد",
                Code = "5965",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59650000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- فروش بر اساس تماس فروشنده با مشتری",
                Code = "5966",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59660000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- فروش بر اساس تماس مشتری با فروشنده",
                Code = "5967",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59670000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم -فروش مستمر (اشتراک)",
                Code = "5968",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59680000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازاریابی مستقیم- سایر روشها",
                Code = "5969",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59690000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای تجهیزات ساخت کاردستی و صنایع دستی هنری",
                Code = "5970",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کوزه و سفال گری", Code = "59700003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "ملیله کاری", Code = "59700002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "صنایع دستی", Code = "59700001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59700000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان آثارهنری و صاحبان گالریها",
                Code = "5971",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "گالری هنری", Code = "59710001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "طراحی و گرافیک و نقاشی", Code = "59710002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خطاطی و تابلو نویسی", Code = "59710003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59710000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای سکه و تمبر",
                Code = "5972",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59720000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای کالای مذهبی",
                Code = "5973",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59730000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم کمک شنوایی پزشکی (سمعک)",
                Code = "5975",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59750000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لوازم ارتوپدی پزشکی و اعضا مصنوعی",
                Code = "5976",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59760000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه لوازم آرایشی",
                Code = "5977",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم آرایشی و بهداشتی", Code = "59770001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "عطر و ادکلن", Code = "59770002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59770000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ماشین چاپ- فروش و ارائه خدمات",
                Code = "5978",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59780000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان سوخت",
                Code = "5983",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59830000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "گلفروشیها",
                Code = "5992",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاهها و دکه‌های فروش سیگار",
                Code = "5993",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه قلیان و متعلقات", Code = "59930001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59930000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "روزنامه‌فروشی‌ها و دکه‌های روزنامه",
                Code = "5994",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59940000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاه حیوانات خانگی و کالاهای مرتبط",
                Code = "5995",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه پرنده و ماهی", Code = "59950001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "فروشگاه حیوانات خانگی و غذا و لوازم آنها", Code = "59950002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "59950000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "استخرهای شنا -فروش و خدمات",
                Code = "5996",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59960000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ریش تراش فروش و خدمات",
                Code = "5997",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59970000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خیمه و پشه‌بند",
                Code = "5998",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خرده فروشی کالاهای متفرقه و خاص",
                Code = "5999",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "59990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات مالی- عملیات پرداخت دستی",
                Code = "6010",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "60100000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات مالی- عملیات پرداخت اتوماتیک",
                Code = "6011",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "60110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات مالی- کالا و خدمات",
                Code = "6012",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "60120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات غیر مالی ارز، حواله غیرالکتریکی، چک مسافرتی، پس انداز و صندوقهای سپرده گذاری",
                Code = "6051",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "60510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دلالی",
                Code = "6211",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "62110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بیمه و قراردادهای مالی",
                Code = "6300",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "63000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آژانسهای فروش مدیریت و اجاره املاک",
                Code = "6513",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "65130000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات اقامتی هتل، مسافرخانه، اقامتگاه و مراکز خدمات اقامتی",
                Code = "7011",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مسافرخانه و مهمانپذير و پانسیون", Code = "70110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "هتل", Code = "70110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "70110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مالکیت مشترک",
                Code = "7012",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "70120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "اردوگاههای ورزشی تفریحی",
                Code = "7032",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "70320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پارکهای جنگلی تفریحی",
                Code = "7033",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "70330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "رختشوی خانه‌ها",
                Code = "7210",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72100000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مغازه‌های لباسشویی",
                Code = "7211",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خشک‌شویی‌ها",
                Code = "7216",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72160000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "قالی شویی و شستشوی روکش مبلمان",
                Code = "7217",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72170000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "استودیوهای عکاسی",
                Code = "7221",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سالنهای زیبایی و آرایشگاهها",
                Code = "7230",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آرایشگری مردانه", Code = "72300001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آرایشگری زنانه و سالنهای زیبایی", Code = "72300002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "72300000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیر، نظافت و واکس کفش و کلاه",
                Code = "7251",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات کفن و دفن",
                Code = "7261",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات پرداخت مالیات",
                Code = "7276",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72760000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات مشاوره- وام، ازدواج و شخصی",
                Code = "7277",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات مشاوره ازدواج", Code = "72770001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "72770000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بنگاههای خرید و فروش",
                Code = "7278",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72780000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "اجاره لباس- لباس فرم، یونیفرم و لباسهای خاص",
                Code = "7296",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72960000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سالنهای ماساژ",
                Code = "7297",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72970000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مراکز سلامتی و زیبایی",
                Code = "7298",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "72980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات شخصی متفرقه [سایر موارد]",
                Code = "7299",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات مجالس و تشریفات", Code = "72990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب و کارهای مرتبط با این گروه صنفی", Code = "72990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تبلیغاتی",
                Code = "7311",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آژانسهای گزارش مصرف کارتهای اعتباری",
                Code = "7321",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "عکاسی، هنر و گرافیک تجاری",
                Code = "7333",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تکثیر، کپی و بازسازی",
                Code = "7338",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مهر و آرم و چاپ اسکرین", Code = "73380001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "صحافی، دفتر و آلبوم سازی", Code = "73380002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "73380000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "عریضه نویسی",
                Code = "7339",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73390000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات سمپاشی و دفع حشرات موذی",
                Code = "7342",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات نظافتی",
                Code = "7349",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73490000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آژانسهای کاریابی و تامین نیروی کار موقت",
                Code = "7361",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "برنامه نویسان کامپیوتری، تحلیلگران اطلاعات و طراحان سیستمهای کامپیوتری خاص",
                Code = "7372",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73720000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بازیابی اطلاعات",
                Code = "7375",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73750000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تعمیر و نگهداری کامپیوتر",
                Code = "7379",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73790000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مدیریت، مشاوره و خدمات مردمی",
                Code = "7392",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تامین کنندگان سیستمهای امنیتی، محافظ خصوصی، ماشینهای ضدگلوله و سگهای نگهبان",
                Code = "7393",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "نصابان دوربین‌های مدار بسته", Code = "73930001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "73930000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "رهن، اجاره تجهیزات،ابزار، مبلمان و دستگاههای مختلف",
                Code = "7394",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم کرایه برگزاری مجالس", Code = "73940001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب و کارهای مرتبط با این گروه صنفی", Code = "73940000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لابراتوارهای ظهور و رتوش عکس",
                Code = "7395",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "73950000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات کسب وکار [سایر موارد]",
                Code = "7399",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "73990000" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "برگزاری سمینار و همایش", Code = "73990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دارالترجمه رسمی", Code = "73990002" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات کرایه اتومبیل",
                Code = "7512",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75120000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات اجاره کامیون و تریلر تاسیساتی",
                Code = "7513",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75130000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات اجاره خودروهای تفریحاتی و خانه‌های متحرک",
                Code = "7519",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75190000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پارکینگ، پارکومتر و گاراژ",
                Code = "7523",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75230000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "صافکاری خودرو",
                Code = "7531",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تعمیر و روکش لاستیک خودرو",
                Code = "7534",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75340000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نقاشی خودرو",
                Code = "7535",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75350000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات خودرو [ و نه فروشندگان]",
                Code = "7538",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "اگزوزسازی", Code = "75380001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آهن گری و آهن کشی انواع خودرو", Code = "75380002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "باطری ساز و باطری فروش", Code = "75380003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "تعمیرکاران خودرو", Code = "75380004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات برق اتومبیل", Code = "75380005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "75380000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کارواش",
                Code = "7542",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "یدک‌کشی و بکسل خودرو",
                Code = "7549",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "75490000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیرگاه لوازم الکترونیکی",
                Code = "7622",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تعمیرکار لوازم صوتی و تصویری", Code = "76220001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "76220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیرگاه سیستمهای برودتی و یخچال فریزر",
                Code = "7623",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "76230000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیرگاه لوازم و دستگاههای کوچک الکترونیکی",
                Code = "7629",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "تعمیرکار لوازم خانگی", Code = "76290001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "76290000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیرگاه ساعت مچی، ساعت دیواری و جواهرآلات",
                Code = "7631",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "76310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیر، بازسازی و تعویض روکش مبلمان",
                Code = "7641",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "76410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات جوشکاری",
                Code = "7692",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "76920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تعمیرگاه لوازم متفرقه و خدمات مرتبط",
                Code = "7699",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "76990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پخش و تولید محصولات چند رسانه‌ای",
                Code = "7829",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "78290000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سینما",
                Code = "7832",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "78320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشگاههای کرایه فیلم و DVD",
                Code = "7841",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "78410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "تهیه کنندگان تئاتر و آژانسهای فروش بلیط تئاتر",
                Code = "7922",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "گروههای موسیقی، ارکستر و سرگرمیهای متفرقه",
                Code = "7929",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79290000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سالنهای بیلیارد",
                Code = "7932",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79320000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سالنهای بولینگ",
                Code = "7933",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79330000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "ورزشهای تجاری، انجمنهای ورزش حرفه ای، زمینهای ورزشی، برگزارکنندگان مسابقات",
                Code = "7941",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "استادیومهای ورزشی", Code = "79410001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "79410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نمایشگاهها و جاذبه های توریستی",
                Code = "7991",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "موزه‌ها و نمایشگاههای هنری", Code = "79910001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "79910000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "برگزارکنندگان کلاسهای عمومی گلف",
                Code = "7992",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79920000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "فروشندگان دستگاه های بازی ویدئویی و سرگرمی",
                Code = "7993",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79930000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سالنهای دستگاههای بازی ویدئویی و سرگرمی",
                Code = "7994",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79940000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "شهربازی، سیرک و کارناوال",
                Code = "7996",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79960000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "باشگاههای خصوصی، باشگا ههای خصوصی آموزش گلف و سوارکاری",
                Code = "7997",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "79970000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آکواریوم عمومی، باغ وحش و استخرهای نمایش دلفینها",
                Code = "7998",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آکواریوم و دلفیناریوم", Code = "79980001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "79980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات تفریحی [سایر موارد]",
                Code = "7999",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پارک آبی", Code = "79990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "79990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پزشکان [سایر موارد]",
                Code = "8011",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پزشک عمومی", Code = "80110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "پزشک متخصص", Code = "80110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "80110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات دندانپزشکی و ارتوپدی",
                Code = "8021",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80210000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "متخصصان بیماری استخوان",
                Code = "8031",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کایروپراکتورها",
                Code = "8041",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "چشم پزشکان و بینایی سنجها",
                Code = "8042",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80420000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات عینک و لنز",
                Code = "8043",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80430000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پزشکان متخصص پا",
                Code = "8049",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80490000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مراکز پرستاری و مراقبتهای فردی",
                Code = "8050",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خانه سالمندان", Code = "80500001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "80500000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "بیمارستانها",
                Code = "8062",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "بیمارستان دولتی", Code = "80620001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "بیمارستان خصوصی", Code = "80620002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "درمانگاه", Code = "80620003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "80620000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لابراتورهای پزشکی و دندانپزشکی",
                Code = "8071",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "80710000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات درمانی و متخصصان سلامت (سایر موارد)",
                Code = "8099",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات رادیولوژی و سونوگرافی", Code = "80990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کلینیک ترک اعتیاد", Code = "80990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لیزر و زیبایی", Code = "80990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "عطاری و گیاهان دارویی", Code = "80990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کلینیک پوست و مو", Code = "80990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان انتقال خون", Code = "80990006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "کلینیکهای روانشناسی و گفتاردرمانی", Code = "80990007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "80990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات حقوقی و دادگستری",
                Code = "8111",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر ازدواج و طلاق", Code = "81110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "81110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مدارس ابتدایی، راهنمایی و دبیرستان",
                Code = "8211",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مدارس ابتدایی", Code = "82110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مدارس راهنمایی", Code = "82110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مدارس متوسطه", Code = "82110003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "هنرستانها", Code = "82110004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مدارس دانش‌آموزان استثنایی (ابتدایی- راهنمایی و دبیرستان)", Code = "82110005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "82110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کالجها، دانشگاه‌ها و مراکز آموزش عالی",
                Code = "8220",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه دولتی", Code = "82200001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه آزاد", Code = "82200002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه غیرانتفاعی", Code = "82200003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه جامع علمی کاربردی", Code = "82200004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه پیام نور", Code = "82200005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دانشگاه علوم پزشکی", Code = "82200006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مرکز تربیت معلم", Code = "82200007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "82200000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مراکز آموزش مکاتیه‌ای و مجازی",
                Code = "8241",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "82410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "مراکز آموزش کسب‌وکار و منشی‌گری",
                Code = "8244",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "82440000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "آموزشگاههای فنی و حرفه ای",
                Code = "8249",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه خیاطی و طراحی دوخت", Code = "82490001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه آرایشگری و پیرایشگری", Code = "82490002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه کامپیوتر (سخت افزار- نرم‌افزار)", Code = "82490003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه رباتیک", Code = "82490004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه تعمیرات موبایل", Code = "82490005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه خلبانی", Code = "82490006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه برق", Code = "82490007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه فرش، قالیبافی و تابلو فرش", Code = "82490008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "82490000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر مراکز ارائه دهنده خدمات آموزشی",
                Code = "8299",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه زبانهای خارجی", Code = "82990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه هنر و موسیقی", Code = "82990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه رانندگی", Code = "82990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاه درسی و کنکور", Code = "82990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "آموزشگاههای بزرگ و چند منظوره", Code = "82990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "82990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات نگهداری از کودکان",
                Code = "8351",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "مهد کودک", Code = "83510001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "83510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "موسسات خیریه و خدمات اجتماعی",
                Code = "8398",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کمیته امداد", Code = "83980001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "83980000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "انجمنها و اتحادیه­های مدنی، اجتماعی و برادری",
                Code = "8641",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "86410000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سازمانهای سیاسی",
                Code = "8651",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "86510000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سازمانهای مذهبی",
                Code = "8661",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "حسینیه، مساجد و مصلی", Code = "86610001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر امام جمعه و مراجع", Code = "86610002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "حوزه علمیه و مدارس دینی", Code = "86610003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "86610000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "اتحادیه های خودرو",
                Code = "8675",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "86750000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر سازمانهای عضویت پذیر",
                Code = "8699",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "86990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "لابراتوارهای تست (غیرپزشکی)",
                Code = "8734",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "87340000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات معماری، مهندسی و پژوهشی",
                Code = "8911",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات معماری،مهندسی و نقشه برداری", Code = "89110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "لوازم مهندسی و نقشه کشی", Code = "89110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "89110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات حسابداری، حسابرسی و دفترداری",
                Code = "8931",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "89310000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر خدمات حرفه ای",
                Code = "8999",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات بازرگانی واردات و صادرات", Code = "89990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات مهندسی، نظام مهندسی", Code = "89990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "گرمابه داران", Code = "89990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مشاورین املاک و مستغلات", Code = "89990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "حفرچاه عمیق و نیمه عمیق", Code = "89990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "خدمات مهاجرت و ویزا", Code = "89990006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "89990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "دادگاه و خدمات دادرسی",
                Code = "9211",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "شورای حل اختلاف", Code = "92110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "92110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "جرایم",
                Code = "9222",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "92220000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پرداخت اوراق قرضه و وثیقه",
                Code = "9223",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "92230000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "پرداخت مالیات",
                Code = "9311",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "ادارات گمرک", Code = "93110001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان امور مالیاتی", Code = "93110002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "93110000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "سایر خدمات دولتی",
                Code = "9399",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر ثبت اسناد رسمی", Code = "93990001" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر پیشخوان دولت", Code = "93990002" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سفارتخانه", Code = "93990003" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر پلیس + 10", Code = "93990004" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر ICT روستایی", Code = "93990005" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "شهرداری", Code = "93990006" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر امور مشترکین", Code = "93990007" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفتر کفالت و اتباع خارجی", Code = "93990008" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان تعزیرات حکومتی", Code = "93990009" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان ثبت احوال", Code = "93990010" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مرکز تعویض پلاک", Code = "93990011" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان پزشکی قانونی", Code = "93990012" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سازمان آتش نشانی", Code = "93990013" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "مرکز معاینه فنی خودرو", Code = "93990014" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر خدمات الکترونیک شهر", Code = "93990015" },
                    new Framework.StorageModels.BusinessSubCategory { Title = "سایر کسب‌وکارهای مرتبط با این گروه صنفی", Code = "93990000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات پستی -مخصوص دولت",
                Code = "9402",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "94020000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "جمع‌آوری وجوه دولتی",
                Code = "9405",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "94050000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "نمایشگاه کتاب ",
                Code = "9700",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "97000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = " قوه قضاییه ",
                Code = "9800",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر خدمات الکترونیکی قضایی", Code = "98000000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "قوه قضاییه ",
                Code = "9801",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "دفاتر ثبت اسناد و املاک قوه قضاییه", Code = "98010000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "خدمات پرداخت الکترونیکی",
                Code = "9802",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "پرداخت‌یاری", Code = "98020000" }
                }
            },
            new Framework.StorageModels.BusinessCategory
            {
                Title = "کسب و کارهای ویژه",
                Code = "9803",
                BusinessSubCategories = new List<Framework.StorageModels.BusinessSubCategory>
                {
                    new Framework.StorageModels.BusinessSubCategory { Title = "کسب و کارهای مرتبط با این گروه صنفی", Code = "98030000" }
                }
            }
        });

            var jobs = await dbContext.SaveChangesAsync();

            int banksAdded = await AddBanksAsync();

            int cityAndStates = await AddCityAndStatesAsync();

            return Json(new
            {
                Success = true,
                BanksAddedCount = banksAdded,
                CityAndStates = cityAndStates,
                Jobs = jobs,
                Duration = (DateTime.Now - startTime).ToString()
            });

        }

        private async Task<int> AddCityAndStatesAsync()
        {
            await dbContext.States.AddRangeAsync(new List<Framework.StorageModels.State>
        {
            new Framework.StorageModels.State
            {
                Name = "آذربایجان شرقی",
                Code = "AZE",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اسکو", NameEn = "Oskoo", Code = "101001" },
                    new Framework.StorageModels.City { Name = "ایلخچی", NameEn = "Ilikhchi", Code = "101002" },
                    new Framework.StorageModels.City { Name = "سهند", NameEn = "Sahand", Code = "101003" },
                    new Framework.StorageModels.City { Name = "اهر", NameEn = "Ahar", Code = "101004" },
                    new Framework.StorageModels.City { Name = "هوراند", NameEn = "Horand", Code = "101005" },
                    new Framework.StorageModels.City { Name = "آذرشهر", NameEn = "AzarShahr", Code = "101006" },
                    new Framework.StorageModels.City { Name = "گوگان", NameEn = "Googan", Code = "101007" },
                    new Framework.StorageModels.City { Name = "ممقان", NameEn = "Mamaghan", Code = "101008" },
                    new Framework.StorageModels.City { Name = "بستان آباد", NameEn = "BostanAbad", Code = "101009" },
                    new Framework.StorageModels.City { Name = "تیکمه داش", NameEn = "Tikmehdash", Code = "101010" },
                    new Framework.StorageModels.City { Name = "بناب", NameEn = "Bonab", Code = "101011" },
                    new Framework.StorageModels.City { Name = "باسمنج", NameEn = "Basmenj", Code = "101012" },
                    new Framework.StorageModels.City { Name = "تبریز", NameEn = "Tabriz", Code = "101013" },
                    new Framework.StorageModels.City { Name = "خسروشهر", NameEn = "KhosroShahr", Code = "101014" },
                    new Framework.StorageModels.City { Name = "سردرود", NameEn = "Sardrood", Code = "101015" },
                    new Framework.StorageModels.City { Name = "جلفا", NameEn = "Jolfa", Code = "101016" },
                    new Framework.StorageModels.City { Name = "سیه رود", NameEn = "Siahrood", Code = "101017" },
                    new Framework.StorageModels.City { Name = "هادیشهر", NameEn = "HadiShahr", Code = "101018" },
                    new Framework.StorageModels.City { Name = "قره آغاج", NameEn = "Gharehaghaj", Code = "101019" },
                    new Framework.StorageModels.City { Name = "خمارلو", NameEn = "Khomarlo", Code = "101020" },
                    new Framework.StorageModels.City { Name = "دوزدوزان", NameEn = "Doozdoozan", Code = "101021" },
                    new Framework.StorageModels.City { Name = "سراب", NameEn = "Sarab", Code = "101022" },
                    new Framework.StorageModels.City { Name = "شربیان", NameEn = "Sharabian", Code = "101023" },
                    new Framework.StorageModels.City { Name = "مهربان", NameEn = "Mehraban", Code = "101024" },
                    new Framework.StorageModels.City { Name = "تسوج", NameEn = "Tasoj", Code = "101025" },
                    new Framework.StorageModels.City { Name = "خامنه", NameEn = "Khamene", Code = "101026" },
                    new Framework.StorageModels.City { Name = "سیس", NameEn = "Sis", Code = "101027" },
                    new Framework.StorageModels.City { Name = "شبستر", NameEn = "Shabestar", Code = "101028" },
                    new Framework.StorageModels.City { Name = "شرفخانه", NameEn = "Sharafkhaneh", Code = "101029" },
                    new Framework.StorageModels.City { Name = "شندآباد", NameEn = "ShendAbad", Code = "101030" },
                    new Framework.StorageModels.City { Name = "صوفیان", NameEn = "Soofian", Code = "101031" },
                    new Framework.StorageModels.City { Name = "کوزه کنان", NameEn = "Kuzehkonan", Code = "101032" },
                    new Framework.StorageModels.City { Name = "وایقان", NameEn = "Vaighan", Code = "101033" },
                    new Framework.StorageModels.City { Name = "عجب شیر", NameEn = "Ajabshir", Code = "101034" },
                    new Framework.StorageModels.City { Name = "آبش احمد", NameEn = "AbeshAhmad", Code = "101035" },
                    new Framework.StorageModels.City { Name = "کلیبر", NameEn = "Kaleibar", Code = "101036" },
                    new Framework.StorageModels.City { Name = "خداجو[1]", NameEn = "khodajoo", Code = "101037" },
                    new Framework.StorageModels.City { Name = "مراغه", NameEn = "Maragheh", Code = "101038" },
                    new Framework.StorageModels.City { Name = "بناب جدید", NameEn = "BonabJadid", Code = "101039" },
                    new Framework.StorageModels.City { Name = "زنوز", NameEn = "Zonooz", Code = "101040" },
                    new Framework.StorageModels.City { Name = "کشکسرای", NameEn = "Kashksaray", Code = "101041" },
                    new Framework.StorageModels.City { Name = "مرند", NameEn = "Marand", Code = "101042" },
                    new Framework.StorageModels.City { Name = "یامچی", NameEn = "Yamchi", Code = "101043" },
                    new Framework.StorageModels.City { Name = "لیلان", NameEn = "Leylan", Code = "101044" },
                    new Framework.StorageModels.City { Name = "ملکان", NameEn = "Malekan", Code = "101045" },
                    new Framework.StorageModels.City { Name = "آقکند", NameEn = "Aghkand", Code = "101046" },
                    new Framework.StorageModels.City { Name = "ترک", NameEn = "Tork", Code = "101047" },
                    new Framework.StorageModels.City { Name = "ترکمانچای", NameEn = "Torkamanchai", Code = "101048" },
                    new Framework.StorageModels.City { Name = "میانه", NameEn = "Mianeh", Code = "101049" },
                    new Framework.StorageModels.City { Name = "بخشایش", NameEn = "Bakhshayesh", Code = "101050" },
                    new Framework.StorageModels.City { Name = "خواجه", NameEn = "Khaje", Code = "101051" },
                    new Framework.StorageModels.City { Name = "زرنق", NameEn = "Zarnagh", Code = "101052" },
                    new Framework.StorageModels.City { Name = "کلوانق", NameEn = "Kalvangh", Code = "101053" },
                    new Framework.StorageModels.City { Name = "هریس", NameEn = "Haris", Code = "101054" },
                    new Framework.StorageModels.City { Name = "نظرکهریزی", NameEn = "Nazarkahrizi", Code = "101055" },
                    new Framework.StorageModels.City { Name = "هشترود", NameEn = "Hashtrood", Code = "101056" },
                    new Framework.StorageModels.City { Name = "خاروانا", NameEn = "Kharvana", Code = "101057" },
                    new Framework.StorageModels.City { Name = "ورزقان", NameEn = "Varzaghan", Code = "101058" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "آذربایجان غربی",
                Code = "AZW",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ارومیه", NameEn = "Urumieh", Code = "102001" },
                    new Framework.StorageModels.City { Name = "سرو", NameEn = "Sero", Code = "102002" },
                    new Framework.StorageModels.City { Name = "سیلوانه", NameEn = "Silvaneh", Code = "102003" },
                    new Framework.StorageModels.City { Name = "قوشچی", NameEn = "Ghooshchi", Code = "102004" },
                    new Framework.StorageModels.City { Name = "نوشین", NameEn = "Noshin", Code = "102005" },
                    new Framework.StorageModels.City { Name = "اشنویه", NameEn = "Oshnavieh", Code = "102006" },
                    new Framework.StorageModels.City { Name = "نالوس", NameEn = "Naloos", Code = "102007" },
                    new Framework.StorageModels.City { Name = "بوکان", NameEn = "Bookan", Code = "102008" },
                    new Framework.StorageModels.City { Name = "سیمینه", NameEn = "Simineh", Code = "102009" },
                    new Framework.StorageModels.City { Name = "پلدشت", NameEn = "Poldasht", Code = "102010" },
                    new Framework.StorageModels.City { Name = "نازک علیا", NameEn = "NazokOlia", Code = "102011" },
                    new Framework.StorageModels.City { Name = "پیرانشهر", NameEn = "Piranshahr", Code = "102012" },
                    new Framework.StorageModels.City { Name = "گردکشانه", NameEn = "GerdKashaneh", Code = "102013" },
                    new Framework.StorageModels.City { Name = "تکاب", NameEn = "Takab", Code = "102014" },
                    new Framework.StorageModels.City { Name = "آواجیق", NameEn = "Avajigh", Code = "102015" },
                    new Framework.StorageModels.City { Name = "سیه چشمه", NameEn = "Siyahcheshmeh", Code = "102016" },
                    new Framework.StorageModels.City { Name = "قره ضیاء الدین", NameEn = "GhareZiaDin", Code = "102017" },
                    new Framework.StorageModels.City { Name = "ایواوغلی", NameEn = "Ivooghli", Code = "102018" },
                    new Framework.StorageModels.City { Name = "خوی", NameEn = "Khoy", Code = "102019" },
                    new Framework.StorageModels.City { Name = "دیزج دیز", NameEn = "DizajDiz", Code = "102020" },
                    new Framework.StorageModels.City { Name = "زرآباد", NameEn = "ZarAbad", Code = "102021" },
                    new Framework.StorageModels.City { Name = "فیرورق", NameEn = "Firooragh", Code = "102022" },
                    new Framework.StorageModels.City { Name = "قطور", NameEn = "Ghotur", Code = "102023" },
                    new Framework.StorageModels.City { Name = "ربط", NameEn = "Rabt", Code = "102024" },
                    new Framework.StorageModels.City { Name = "سردشت", NameEn = "Sardasht", Code = "102025" },
                    new Framework.StorageModels.City { Name = "میرآباد", NameEn = "MirAbad", Code = "102026" },
                    new Framework.StorageModels.City { Name = "تازه شهر", NameEn = "TazehShahr", Code = "102027" },
                    new Framework.StorageModels.City { Name = "سلماس", NameEn = "Salmas", Code = "102028" },
                    new Framework.StorageModels.City { Name = "شاهین دژ", NameEn = "Shahindezh", Code = "102029" },
                    new Framework.StorageModels.City { Name = "کشاورز", NameEn = "Keshavarz", Code = "102030" },
                    new Framework.StorageModels.City { Name = "محمودآباد", NameEn = "MahmoodAbad", Code = "102031" },
                    new Framework.StorageModels.City { Name = "شوط", NameEn = "Shoot", Code = "102032" },
                    new Framework.StorageModels.City { Name = "مرگنلر", NameEn = "Marganlar", Code = "102033" },
                    new Framework.StorageModels.City { Name = "بازرگان", NameEn = "Bazargan", Code = "102034" },
                    new Framework.StorageModels.City { Name = "ماکو", NameEn = "Makoo", Code = "102035" },
                    new Framework.StorageModels.City { Name = "خلیفان", NameEn = "Khalifan", Code = "102036" },
                    new Framework.StorageModels.City { Name = "مهاباد", NameEn = "Mahabad", Code = "102037" },
                    new Framework.StorageModels.City { Name = "باروق", NameEn = "Barogh", Code = "102038" },
                    new Framework.StorageModels.City { Name = "چهاربرج", NameEn = "ChaharBorj", Code = "102039" },
                    new Framework.StorageModels.City { Name = "میاندوآب", NameEn = "Miandoab", Code = "102040" },
                    new Framework.StorageModels.City { Name = "محمدیار", NameEn = "Mohammadyar", Code = "102041" },
                    new Framework.StorageModels.City { Name = "نقده", NameEn = "Naghadeh", Code = "102042" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "اردبیل",
                Code = "ARD",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اردبیل", NameEn = "Ardebil", Code = "103001" },
                    new Framework.StorageModels.City { Name = "هیر", NameEn = "Hir", Code = "103002" },
                    new Framework.StorageModels.City { Name = "بیله سوار", NameEn = "Bilesavar", Code = "103003" },
                    new Framework.StorageModels.City { Name = "جعفرآباد", NameEn = "JafarAbad", Code = "103004" },
                    new Framework.StorageModels.City { Name = "اصلاندوز", NameEn = "Aslandooz", Code = "103005" },
                    new Framework.StorageModels.City { Name = "پارس آباد", NameEn = "ParsAbad", Code = "103006" },
                    new Framework.StorageModels.City { Name = "تازه کند", NameEn = "TazeKand", Code = "103007" },
                    new Framework.StorageModels.City { Name = "خلخال", NameEn = "Khalkhal", Code = "103008" },
                    new Framework.StorageModels.City { Name = "کلور", NameEn = "Kaloor", Code = "103009" },
                    new Framework.StorageModels.City { Name = "هشتجین", NameEn = "Hashtjin", Code = "103010" },
                    new Framework.StorageModels.City { Name = "سرعین", NameEn = "Sarein", Code = "103011" },
                    new Framework.StorageModels.City { Name = "گیوی", NameEn = "Givi", Code = "103012" },
                    new Framework.StorageModels.City { Name = "تازه کندانگوت", NameEn = "TazeKandeAngoot", Code = "103013" },
                    new Framework.StorageModels.City { Name = "گرمی", NameEn = "Germi", Code = "103014" },
                    new Framework.StorageModels.City { Name = "رضی", NameEn = "Razi", Code = "103015" },
                    new Framework.StorageModels.City { Name = "فخرآباد", NameEn = "FakhrAbad", Code = "103016" },
                    new Framework.StorageModels.City { Name = "لاهرود", NameEn = "Lahrood", Code = "103017" },
                    new Framework.StorageModels.City { Name = "مرادلو", NameEn = "Moradloo", Code = "103018" },
                    new Framework.StorageModels.City { Name = "مشگین شهر", NameEn = "MeshginShahr", Code = "103019" },
                    new Framework.StorageModels.City { Name = "آبی بیگلو", NameEn = "AbiBigloo", Code = "103020" },
                    new Framework.StorageModels.City { Name = "عنبران", NameEn = "Anbaran", Code = "103021" },
                    new Framework.StorageModels.City { Name = "نمین", NameEn = "Namin", Code = "103022" },
                    new Framework.StorageModels.City { Name = "کوراییم", NameEn = "Kooraeem", Code = "103023" },
                    new Framework.StorageModels.City { Name = "نیر", NameEn = "Nayer", Code = "103024" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "اصفهان",
                Code = "ESF",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اردستان", NameEn = "Ardestan", Code = "104001" },
                    new Framework.StorageModels.City { Name = "زواره", NameEn = "Zavareh", Code = "104002" },
                    new Framework.StorageModels.City { Name = "مهاباد", NameEn = "Mahabad", Code = "104003" },
                    new Framework.StorageModels.City { Name = "اژیه", NameEn = "Azhiyeh", Code = "104004" },
                    new Framework.StorageModels.City { Name = "اصفهان", NameEn = "Isfahan", Code = "104005" },
                    new Framework.StorageModels.City { Name = "بهارستان", NameEn = "Baharestan", Code = "104006" },
                    new Framework.StorageModels.City { Name = "تودشک", NameEn = "Toodeshk", Code = "104007" },
                    new Framework.StorageModels.City { Name = "حسن اباد", NameEn = "HasanAbad", Code = "104008" },
                    new Framework.StorageModels.City { Name = "خوراسگان", NameEn = "Khoorasgan", Code = "104009" },
                    new Framework.StorageModels.City { Name = "سگزی", NameEn = "Segzi", Code = "104010" },
                    new Framework.StorageModels.City { Name = "کوهپایه", NameEn = "Koohpayeh", Code = "104011" },
                    new Framework.StorageModels.City { Name = "محمدآباد", NameEn = "MohammadAbad", Code = "104012" },
                    new Framework.StorageModels.City { Name = "نصرآباد", NameEn = "NasrAbad", Code = "104013" },
                    new Framework.StorageModels.City { Name = "نیک آباد", NameEn = "NikAbad", Code = "104014" },
                    new Framework.StorageModels.City { Name = "هرند", NameEn = "Harand", Code = "104015" },
                    new Framework.StorageModels.City { Name = "ورزنه", NameEn = "Varzaneh", Code = "104016" },
                    new Framework.StorageModels.City { Name = "ابوزیدآباد", NameEn = "AboozeidAbad", Code = "104017" },
                    new Framework.StorageModels.City { Name = "آران وبیدگل", NameEn = "AranBidgol", Code = "104018" },
                    new Framework.StorageModels.City { Name = "سفیدشهر", NameEn = "SefidShahr", Code = "104019" },
                    new Framework.StorageModels.City { Name = "نوش آباد", NameEn = "NooshAbad", Code = "104020" },
                    new Framework.StorageModels.City { Name = "حبیب آباد", NameEn = "HabibAbad", Code = "104021" },
                    new Framework.StorageModels.City { Name = "خورزوق", NameEn = "Khorzough", Code = "104022" },
                    new Framework.StorageModels.City { Name = "دستگرد", NameEn = "Dastgerd", Code = "104023" },
                    new Framework.StorageModels.City { Name = "دولت آباد", NameEn = "DolatAbad", Code = "104024" },
                    new Framework.StorageModels.City { Name = "شاپورآباد", NameEn = "ShapoorAbad", Code = "104025" },
                    new Framework.StorageModels.City { Name = "کمشچه", NameEn = "Komeshcheh", Code = "104026" },
                    new Framework.StorageModels.City { Name = "تیران", NameEn = "Tiran", Code = "104027" },
                    new Framework.StorageModels.City { Name = "رضوانشهر", NameEn = "Rezvanshahr", Code = "104028" },
                    new Framework.StorageModels.City { Name = "عسگران", NameEn = "Asgaran", Code = "104029" },
                    new Framework.StorageModels.City { Name = "چادگان", NameEn = "Chadegan", Code = "104030" },
                    new Framework.StorageModels.City { Name = "رزوه", NameEn = "Rozveh", Code = "104031" },
                    new Framework.StorageModels.City { Name = "خمینی شهر", NameEn = "KhomeiniShahr", Code = "104032" },
                    new Framework.StorageModels.City { Name = "درچه", NameEn = "Dorche", Code = "104033" },
                    new Framework.StorageModels.City { Name = "کوشک", NameEn = "Kooshk", Code = "104034" },
                    new Framework.StorageModels.City { Name = "خوانسار", NameEn = "Khansar", Code = "104035" },
                    new Framework.StorageModels.City { Name = "جندق", NameEn = "Jandagh", Code = "104036" },
                    new Framework.StorageModels.City { Name = "خور", NameEn = "Khoor", Code = "104037" },
                    new Framework.StorageModels.City { Name = "فرخی", NameEn = "Farkhi", Code = "104038" },
                    new Framework.StorageModels.City { Name = "دهاقان", NameEn = "Dehaghan", Code = "104039" },
                    new Framework.StorageModels.City { Name = "گلشن", NameEn = "Golshan", Code = "104040" },
                    new Framework.StorageModels.City { Name = "حنا", NameEn = "Hana", Code = "104041" },
                    new Framework.StorageModels.City { Name = "سمیرم", NameEn = "Samirom", Code = "104042" },
                    new Framework.StorageModels.City { Name = "کمه", NameEn = "Kameh", Code = "104043" },
                    new Framework.StorageModels.City { Name = "ونک", NameEn = "Vanak", Code = "104044" },
                    new Framework.StorageModels.City { Name = "شاهین شهر", NameEn = "ShahinShahr", Code = "104045" },
                    new Framework.StorageModels.City { Name = "گرگاب", NameEn = "Gorgab", Code = "104046" },
                    new Framework.StorageModels.City { Name = "گزبرخوار", NameEn = "GazBarkhar", Code = "104047" },
                    new Framework.StorageModels.City { Name = "لای بید", NameEn = "Laybid", Code = "104048" },
                    new Framework.StorageModels.City { Name = "میمه", NameEn = "Meimeh", Code = "104049" },
                    new Framework.StorageModels.City { Name = "وزوان", NameEn = "Vezvan", Code = "104050" },
                    new Framework.StorageModels.City { Name = "شهرضا", NameEn = "Shahreza", Code = "104051" },
                    new Framework.StorageModels.City { Name = "منظریه", NameEn = "Manzarieh", Code = "104052" },
                    new Framework.StorageModels.City { Name = "افوس", NameEn = "Afoos", Code = "104053" },
                    new Framework.StorageModels.City { Name = "بویین ومیاندشت", NameEn = "BooeenMiandasht", Code = "104054" },
                    new Framework.StorageModels.City { Name = "داران", NameEn = "Daran", Code = "104055" },
                    new Framework.StorageModels.City { Name = "دامنه", NameEn = "Damane", Code = "104056" },
                    new Framework.StorageModels.City { Name = "برف انبار", NameEn = "Barfanbar", Code = "104057" },
                    new Framework.StorageModels.City { Name = "فریدونشهر", NameEn = "FereidoonShahr", Code = "104058" },
                    new Framework.StorageModels.City { Name = "ابریشم", NameEn = "Abrisham", Code = "104059" },
                    new Framework.StorageModels.City { Name = "ایمانشهر", NameEn = "ImanShahr", Code = "104060" },
                    new Framework.StorageModels.City { Name = "بهاران شهر", NameEn = "BaharanShahr", Code = "104061" },
                    new Framework.StorageModels.City { Name = "پیربکران", NameEn = "Pirbakran", Code = "104062" },
                    new Framework.StorageModels.City { Name = "فلاورجان", NameEn = "Falavarjan", Code = "104063" },
                    new Framework.StorageModels.City { Name = "قهدریجان", NameEn = "Ghahderijan", Code = "104064" },
                    new Framework.StorageModels.City { Name = "کلیشادوسودرجان", NameEn = "KelishadSooderjan", Code = "104065" },
                    new Framework.StorageModels.City { Name = "برزک", NameEn = "Barzok", Code = "104066" },
                    new Framework.StorageModels.City { Name = "جوشقان وکامو", NameEn = "JosheghanKamo", Code = "104067" },
                    new Framework.StorageModels.City { Name = "قمصر", NameEn = "Ghamsar", Code = "104068" },
                    new Framework.StorageModels.City { Name = "کاشان", NameEn = "Kashan", Code = "104069" },
                    new Framework.StorageModels.City { Name = "مشکات", NameEn = "Meshkat", Code = "104070" },
                    new Framework.StorageModels.City { Name = "نیاسر", NameEn = "Niasar", Code = "104071" },
                    new Framework.StorageModels.City { Name = "گلپایگان", NameEn = "Golpayegan", Code = "104072" },
                    new Framework.StorageModels.City { Name = "گلشهر", NameEn = "Golshahr", Code = "104073" },
                    new Framework.StorageModels.City { Name = "گوگد", NameEn = "Gogad", Code = "104074" },
                    new Framework.StorageModels.City { Name = "باغ بهادران", NameEn = "Baghbahadoran", Code = "104075" },
                    new Framework.StorageModels.City { Name = "چرمهین", NameEn = "Charmahin", Code = "104076" },
                    new Framework.StorageModels.City { Name = "چمگردان", NameEn = "Chamgordan", Code = "104077" },
                    new Framework.StorageModels.City { Name = "زاینده رود", NameEn = "Zayanderood", Code = "104078" },
                    new Framework.StorageModels.City { Name = "زرین شهر", NameEn = "ZarrinShahr", Code = "104079" },
                    new Framework.StorageModels.City { Name = "سده لنجان", NameEn = "SedehLenjan", Code = "104080" },
                    new Framework.StorageModels.City { Name = "فولادشهر", NameEn = "FooladShahr", Code = "104081" },
                    new Framework.StorageModels.City { Name = "ورنامخواست", NameEn = "Varnamkhast", Code = "104082" },
                    new Framework.StorageModels.City { Name = "دیزیچه", NameEn = "Dizicheh", Code = "104083" },
                    new Framework.StorageModels.City { Name = "زیباشهر", NameEn = "ZibaShahr", Code = "104084" },
                    new Framework.StorageModels.City { Name = "طالخونچه", NameEn = "Talkhoonche", Code = "104085" },
                    new Framework.StorageModels.City { Name = "کرکوند", NameEn = "Karkevand", Code = "104086" },
                    new Framework.StorageModels.City { Name = "مبارکه", NameEn = "Mobarakeh", Code = "104087" },
                    new Framework.StorageModels.City { Name = "مجلسی", NameEn = "Majlesi", Code = "104088" },
                    new Framework.StorageModels.City { Name = "انارک", NameEn = "Anarak", Code = "104089" },
                    new Framework.StorageModels.City { Name = "بافران", NameEn = "Bafran", Code = "104090" },
                    new Framework.StorageModels.City { Name = "نایین", NameEn = "Naeen", Code = "104091" },
                    new Framework.StorageModels.City { Name = "جوزدان", NameEn = "Jowzdan", Code = "104092" },
                    new Framework.StorageModels.City { Name = "دهق", NameEn = "Dehagh", Code = "104093" },
                    new Framework.StorageModels.City { Name = "علویجه", NameEn = "Alavijeh", Code = "104094" },
                    new Framework.StorageModels.City { Name = "کهریزسنگ", NameEn = "KahrizSang", Code = "104095" },
                    new Framework.StorageModels.City { Name = "گلدشت", NameEn = "Goldasht", Code = "104096" },
                    new Framework.StorageModels.City { Name = "نجف آباد", NameEn = "NajafAbad", Code = "104097" },
                    new Framework.StorageModels.City { Name = "بادرود", NameEn = "Badrood", Code = "104098" },
                    new Framework.StorageModels.City { Name = "خالدآباد", NameEn = "KhaledAbad", Code = "104099" },
                    new Framework.StorageModels.City { Name = "نطنز", NameEn = "Natanz", Code = "104100" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "البرز",
                Code = "ALB",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "چهارباغ", NameEn = "ChaharBagh", Code = "105001" },
                    new Framework.StorageModels.City { Name = "شهرجدیدهشتگرد", NameEn = "ShahrejadidHashtgerd", Code = "105002" },
                    new Framework.StorageModels.City { Name = "کوهسار", NameEn = "Koohsar", Code = "105003" },
                    new Framework.StorageModels.City { Name = "گلسار", NameEn = "Golsar", Code = "105004" },
                    new Framework.StorageModels.City { Name = "هشتگرد", NameEn = "Hashtgerd", Code = "105005" },
                    new Framework.StorageModels.City { Name = "طالقان", NameEn = "Taleghan", Code = "105006" },
                    new Framework.StorageModels.City { Name = "اشتهارد", NameEn = "Eshtehard", Code = "105007" },
                    new Framework.StorageModels.City { Name = "آسارا", NameEn = "Asara", Code = "105008" },
                    new Framework.StorageModels.City { Name = "کرج", NameEn = "Karaj", Code = "105009" },
                    new Framework.StorageModels.City { Name = "کمال شهر", NameEn = "KamalShahr", Code = "105010" },
                    new Framework.StorageModels.City { Name = "گرمدره", NameEn = "Garmdareh", Code = "105011" },
                    new Framework.StorageModels.City { Name = "ماهدشت", NameEn = "Mahdasht", Code = "105012" },
                    new Framework.StorageModels.City { Name = "محمدشهر", NameEn = "MohammadShahr", Code = "105013" },
                    new Framework.StorageModels.City { Name = "مشکین دشت", NameEn = "Meshkindasht", Code = "105014" },
                    new Framework.StorageModels.City { Name = "تنکمان", NameEn = "Tonkaman", Code = "105015" },
                    new Framework.StorageModels.City { Name = "نظرآباد", NameEn = "NazarAbad", Code = "105016" },
                    new Framework.StorageModels.City { Name = "فردیس", NameEn = "Fardis", Code = "105017" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "ایلام",
                Code = "EIL",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ایلام", NameEn = "Ilam", Code = "106001" },
                    new Framework.StorageModels.City { Name = "چوار", NameEn = "Chovar", Code = "106002" },
                    new Framework.StorageModels.City { Name = "ایوان", NameEn = "Ivan", Code = "106003" },
                    new Framework.StorageModels.City { Name = "زرنه", NameEn = "Zarneh", Code = "106004" },
                    new Framework.StorageModels.City { Name = "آبدانان", NameEn = "Abdanan", Code = "106005" },
                    new Framework.StorageModels.City { Name = "سراب باغ", NameEn = "SarabBagh", Code = "106006" },
                    new Framework.StorageModels.City { Name = "مورموری", NameEn = "Murmuri", Code = "106007" },
                    new Framework.StorageModels.City { Name = "بدره", NameEn = "Badreh", Code = "106008" },
                    new Framework.StorageModels.City { Name = "دره شهر", NameEn = "DarrehShahr", Code = "106009" },
                    new Framework.StorageModels.City { Name = "پهله", NameEn = "Pahle", Code = "106010" },
                    new Framework.StorageModels.City { Name = "دهلران", NameEn = "Dehloran", Code = "106011" },
                    new Framework.StorageModels.City { Name = "موسیان", NameEn = "Moosian", Code = "106012" },
                    new Framework.StorageModels.City { Name = "میمه", NameEn = "Meimeh", Code = "106013" },
                    new Framework.StorageModels.City { Name = "آسمان آباد", NameEn = "AsemanAbad", Code = "106014" },
                    new Framework.StorageModels.City { Name = "توحید", NameEn = "Tohid", Code = "106015" },
                    new Framework.StorageModels.City { Name = "سرابله", NameEn = "Sarableh", Code = "106016" },
                    new Framework.StorageModels.City { Name = "لومار", NameEn = "Loomar", Code = "106017" },
                    new Framework.StorageModels.City { Name = "ارکواز", NameEn = "Arkavaz", Code = "106018" },
                    new Framework.StorageModels.City { Name = "دلگشا", NameEn = "Delgosha", Code = "106019" },
                    new Framework.StorageModels.City { Name = "صالح آباد", NameEn = "SalehAbad", Code = "106020" },
                    new Framework.StorageModels.City { Name = "مهران", NameEn = "Mehran", Code = "106021" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "بوشهر",
                Code = "BSH",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "بوشهر", NameEn = "Boshehr", Code = "107001" },
                    new Framework.StorageModels.City { Name = "چغادک", NameEn = "Choghadak", Code = "107002" },
                    new Framework.StorageModels.City { Name = "خارک", NameEn = "Khark", Code = "107003" },
                    new Framework.StorageModels.City { Name = "اهرم", NameEn = "Ahrom", Code = "107004" },
                    new Framework.StorageModels.City { Name = "دلوار", NameEn = "Delvar", Code = "107005" },
                    new Framework.StorageModels.City { Name = "انارستان", NameEn = "Anarestan", Code = "107006" },
                    new Framework.StorageModels.City { Name = "جم", NameEn = "Jam", Code = "107007" },
                    new Framework.StorageModels.City { Name = "ریز", NameEn = "Riz", Code = "107008" },
                    new Framework.StorageModels.City { Name = "آب پخش", NameEn = "Abpakhsh", Code = "107009" },
                    new Framework.StorageModels.City { Name = "برازجان", NameEn = "Borazjan", Code = "107010" },
                    new Framework.StorageModels.City { Name = "تنگ ارم", NameEn = "Tang eram", Code = "107011" },
                    new Framework.StorageModels.City { Name = "دالکی", NameEn = "Dalaki", Code = "107012" },
                    new Framework.StorageModels.City { Name = "سعد آباد", NameEn = "SaedAbad", Code = "107013" },
                    new Framework.StorageModels.City { Name = "شبانکاره", NameEn = "Shabankareh", Code = "107014" },
                    new Framework.StorageModels.City { Name = "کلمه", NameEn = "Kalameh", Code = "107015" },
                    new Framework.StorageModels.City { Name = "وحدتیه", NameEn = "Vahdatiyeh", Code = "107016" },
                    new Framework.StorageModels.City { Name = "خورموج", NameEn = "Khormoj", Code = "107017" },
                    new Framework.StorageModels.City { Name = "شنبه", NameEn = "Shanbeh", Code = "107018" },
                    new Framework.StorageModels.City { Name = "کاکی", NameEn = "Kaki", Code = "107019" },
                    new Framework.StorageModels.City { Name = "آبدان", NameEn = "Abdan", Code = "107020" },
                    new Framework.StorageModels.City { Name = "بردخون", NameEn = "Bordkhun", Code = "107021" },
                    new Framework.StorageModels.City { Name = "بردستان", NameEn = "Bardestan", Code = "107022" },
                    new Framework.StorageModels.City { Name = "بندردیر", NameEn = "BandarDayyer", Code = "107023" },
                    new Framework.StorageModels.City { Name = "امام حسن", NameEn = "EmamHasan", Code = "107024" },
                    new Framework.StorageModels.City { Name = "بندردیلم", NameEn = "BandarDeylam", Code = "107025" },
                    new Framework.StorageModels.City { Name = "بندرکنگان", NameEn = "BandarKangan", Code = "107026" },
                    new Framework.StorageModels.City { Name = "بنک", NameEn = "Banak", Code = "107027" },
                    new Framework.StorageModels.City { Name = "سیراف", NameEn = "Siraf", Code = "107028" },
                    new Framework.StorageModels.City { Name = "عسلویه", NameEn = "Asaloyeh", Code = "107029" },
                    new Framework.StorageModels.City { Name = "نخل تقی", NameEn = "Nakhltaghi", Code = "107030" },
                    new Framework.StorageModels.City { Name = "بندرریگ", NameEn = "BandarRig", Code = "107031" },
                    new Framework.StorageModels.City { Name = "بندرگناوه", NameEn = "BandarGenaveh", Code = "107032" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "تهران",
                Code = "THR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اسلامشهر", NameEn = "EslamShahr", Code = "108001" },
                    new Framework.StorageModels.City { Name = "چهاردانگه", NameEn = "Chahardangeh", Code = "108002" },
                    new Framework.StorageModels.City { Name = "صالح آباد", NameEn = "SalehAbad", Code = "108003" },
                    new Framework.StorageModels.City { Name = "گلستان", NameEn = "Golestan", Code = "108004" },
                    new Framework.StorageModels.City { Name = "نسیم شهر", NameEn = "NasimShahr", Code = "108005" },
                    new Framework.StorageModels.City { Name = "پاکدشت", NameEn = "Pakdasht", Code = "108006" },
                    new Framework.StorageModels.City { Name = "شریف آباد", NameEn = "SharifAbad", Code = "108007" },
                    new Framework.StorageModels.City { Name = "فرون آباد", NameEn = "FrounAbad", Code = "108008" },
                    new Framework.StorageModels.City { Name = "پیشوا", NameEn = "Pishva", Code = "108009" },
                    new Framework.StorageModels.City { Name = "بومهن", NameEn = "Boomehen", Code = "108010" },
                    new Framework.StorageModels.City { Name = "پردیس", NameEn = "Pardis", Code = "108011" },
                    new Framework.StorageModels.City { Name = "تهران", NameEn = "Tehran", Code = "108012" },
                    new Framework.StorageModels.City { Name = "آبسرد", NameEn = "Abesard", Code = "108013" },
                    new Framework.StorageModels.City { Name = "آبعلی", NameEn = "AbAli", Code = "108014" },
                    new Framework.StorageModels.City { Name = "دماوند", NameEn = "Damavand", Code = "108015" },
                    new Framework.StorageModels.City { Name = "رودهن", NameEn = "Roodehen", Code = "108016" },
                    new Framework.StorageModels.City { Name = "کیلان", NameEn = "Kilan", Code = "108017" },
                    new Framework.StorageModels.City { Name = "رباط کریم", NameEn = "Robatkarim", Code = "108018" },
                    new Framework.StorageModels.City { Name = "نصیرشهر", NameEn = "NasirShahr", Code = "108019" },
                    new Framework.StorageModels.City { Name = "باقرشهر", NameEn = "BagherShahr", Code = "108020" },
                    new Framework.StorageModels.City { Name = "حسن آباد", NameEn = "HasanAbad", Code = "108021" },
                    new Framework.StorageModels.City { Name = "کهریزک", NameEn = "Kahrizak", Code = "108022" },
                    new Framework.StorageModels.City { Name = "فشم", NameEn = "Fasham", Code = "108023" },
                    new Framework.StorageModels.City { Name = "لواسان", NameEn = "Lavasan", Code = "108024" },
                    new Framework.StorageModels.City { Name = "اندیشه", NameEn = "Andisheh", Code = "108025" },
                    new Framework.StorageModels.City { Name = "باغستان", NameEn = "Baghestan", Code = "108026" },
                    new Framework.StorageModels.City { Name = "شاهدشهر", NameEn = "ShahedShahr", Code = "108027" },
                    new Framework.StorageModels.City { Name = "شهریار", NameEn = "Shahryar", Code = "108028" },
                    new Framework.StorageModels.City { Name = "صباشهر", NameEn = "SabaShahr", Code = "108029" },
                    new Framework.StorageModels.City { Name = "فردوسیه", NameEn = "Ferdosieh", Code = "108030" },
                    new Framework.StorageModels.City { Name = "وحیدیه", NameEn = "Vahidieh", Code = "108031" },
                    new Framework.StorageModels.City { Name = "ارجمند", NameEn = "Arjmand", Code = "108032" },
                    new Framework.StorageModels.City { Name = "فیروزکوه", NameEn = "Firoozkooh", Code = "108033" },
                    new Framework.StorageModels.City { Name = "قدس", NameEn = "Ghods", Code = "108034" },
                    new Framework.StorageModels.City { Name = "صفادشت", NameEn = "Safadasht", Code = "108035" },
                    new Framework.StorageModels.City { Name = "ملارد", NameEn = "Malard", Code = "108036" },
                    new Framework.StorageModels.City { Name = "جوادآباد", NameEn = "JavadAbad", Code = "108037" },
                    new Framework.StorageModels.City { Name = "قرچک", NameEn = "Gharchak", Code = "108038" },
                    new Framework.StorageModels.City { Name = "ورامین", NameEn = "Varamin", Code = "108039" },
                    new Framework.StorageModels.City { Name = "شهرجدید پرند", NameEn = "Parand", Code = "108040" },
                    new Framework.StorageModels.City { Name = "ری", NameEn = "Rey", Code = "108041" },
                    new Framework.StorageModels.City { Name = "شمشک", NameEn = "Shemshak", Code = "108042" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "چهارمحال و بختیاری",
                Code = "CHB",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اردل", NameEn = "Ardal", Code = "109001" },
                    new Framework.StorageModels.City { Name = "بروجن", NameEn = "Boroojen", Code = "109002" },
                    new Framework.StorageModels.City { Name = "بلداجی", NameEn = "Beldaji", Code = "109003" },
                    new Framework.StorageModels.City { Name = "سفیددشت", NameEn = "Sefiddasht", Code = "109004" },
                    new Framework.StorageModels.City { Name = "فرادنبه", NameEn = "Faradonbeh", Code = "109005" },
                    new Framework.StorageModels.City { Name = "گندمان", NameEn = "Gandoman", Code = "109006" },
                    new Framework.StorageModels.City { Name = "نقنه", NameEn = "Naghneh", Code = "109007" },
                    new Framework.StorageModels.City { Name = "بن", NameEn = "Bon", Code = "109008" },
                    new Framework.StorageModels.City { Name = "سامان", NameEn = "Saman", Code = "109009" },
                    new Framework.StorageModels.City { Name = "سودجان", NameEn = "Soodejan", Code = "109010" },
                    new Framework.StorageModels.City { Name = "سورشجان", NameEn = "Sooreshjan", Code = "109011" },
                    new Framework.StorageModels.City { Name = "شهرکرد", NameEn = "Shahrekord", Code = "109012" },
                    new Framework.StorageModels.City { Name = "طاقانک", NameEn = "Taghanak", Code = "109013" },
                    new Framework.StorageModels.City { Name = "فرخ شهر", NameEn = "FarrokhShahr", Code = "109014" },
                    new Framework.StorageModels.City { Name = "کیان", NameEn = "Kian", Code = "109015" },
                    new Framework.StorageModels.City { Name = "نافچ", NameEn = "Nafch", Code = "109016" },
                    new Framework.StorageModels.City { Name = "هفشجان", NameEn = "Hafshejan", Code = "109017" },
                    new Framework.StorageModels.City { Name = "وردنجان", NameEn = "Vardanjan", Code = "109018" },
                    new Framework.StorageModels.City { Name = "باباحیدر", NameEn = "Babaheidar", Code = "109019" },
                    new Framework.StorageModels.City { Name = "پردنجان", NameEn = "Pordanjan", Code = "109020" },
                    new Framework.StorageModels.City { Name = "جونقان", NameEn = "Joonghan", Code = "109021" },
                    new Framework.StorageModels.City { Name = "فارسان", NameEn = "Farsan", Code = "109022" },
                    new Framework.StorageModels.City { Name = "چلگرد", NameEn = "Chelgerd", Code = "109023" },
                    new Framework.StorageModels.City { Name = "دستنا", NameEn = "Dastena", Code = "109024" },
                    new Framework.StorageModels.City { Name = "شلمزار", NameEn = "Shalamzar", Code = "109025" },
                    new Framework.StorageModels.City { Name = "گهرو", NameEn = "Gahroo", Code = "109026" },
                    new Framework.StorageModels.City { Name = "ناغان", NameEn = "Naghan", Code = "109027" },
                    new Framework.StorageModels.City { Name = "آلونی", NameEn = "Aloni", Code = "109028" },
                    new Framework.StorageModels.City { Name = "لردگان", NameEn = "Lordegan", Code = "109029" },
                    new Framework.StorageModels.City { Name = "مال خلیفه", NameEn = "Malekhalife", Code = "109030" },
                    new Framework.StorageModels.City { Name = "منج", NameEn = "Monj", Code = "109031" },
                    new Framework.StorageModels.City { Name = "دشتک", NameEn = "Dashtak", Code = "109032" },
                    new Framework.StorageModels.City { Name = "سرخون", NameEn = "Sarkhoon", Code = "109033" },
                    new Framework.StorageModels.City { Name = "کاج", NameEn = "Kaj", Code = "109034" },
                    new Framework.StorageModels.City { Name = "گوجان", NameEn = "Gujan", Code = "109035" },
                    new Framework.StorageModels.City { Name = "چلیچه", NameEn = "Cholicheh", Code = "109036" },
                    new Framework.StorageModels.City { Name = "صمصامی", NameEn = "Samsami", Code = "109037" },
                    new Framework.StorageModels.City { Name = "بازفت", NameEn = "Bazoft", Code = "109038" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "خراسان جنوبی",
                Code = "KHS",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ارسک", NameEn = "Eresk", Code = "110001" },
                    new Framework.StorageModels.City { Name = "بشرویه", NameEn = "Boshrooyeh", Code = "110002" },
                    new Framework.StorageModels.City { Name = "بیرجند", NameEn = "Birjand", Code = "110003" },
                    new Framework.StorageModels.City { Name = "خوسف", NameEn = "Khoosf", Code = "110004" },
                    new Framework.StorageModels.City { Name = "محمدشهر", NameEn = "MohammadShahr", Code = "110005" },
                    new Framework.StorageModels.City { Name = "اسدیه", NameEn = "Asadyeh", Code = "110006" },
                    new Framework.StorageModels.City { Name = "طبس مسینا", NameEn = "Tabasmasina", Code = "110007" },
                    new Framework.StorageModels.City { Name = "قهستان", NameEn = "Ghohestan", Code = "110008" },
                    new Framework.StorageModels.City { Name = "گزیک", NameEn = "Gazik", Code = "110009" },
                    new Framework.StorageModels.City { Name = "آیسک", NameEn = "Aysek", Code = "110010" },
                    new Framework.StorageModels.City { Name = "سرایان", NameEn = "Sarayan", Code = "110011" },
                    new Framework.StorageModels.City { Name = "سه قلعه", NameEn = "Se ghale", Code = "110012" },
                    new Framework.StorageModels.City { Name = "سربیشه", NameEn = "Sarbisheh", Code = "110013" },
                    new Framework.StorageModels.City { Name = "مود", NameEn = "Moud", Code = "110014" },
                    new Framework.StorageModels.City { Name = "اسلامیه", NameEn = "Eslamyeh", Code = "110015" },
                    new Framework.StorageModels.City { Name = "فردوس", NameEn = "Ferdos", Code = "110016" },
                    new Framework.StorageModels.City { Name = "اسفدن", NameEn = "Esfaden", Code = "110017" },
                    new Framework.StorageModels.City { Name = "آرین شهر", NameEn = "ArianShahr", Code = "110018" },
                    new Framework.StorageModels.City { Name = "حاجی آباد", NameEn = "HajiAbad", Code = "110019" },
                    new Framework.StorageModels.City { Name = "خضری دشت بیاض", NameEn = "Khazridashtbayaz", Code = "110020" },
                    new Framework.StorageModels.City { Name = "زهان", NameEn = "Zahan", Code = "110021" },
                    new Framework.StorageModels.City { Name = "قاین", NameEn = "Ghaen", Code = "110022" },
                    new Framework.StorageModels.City { Name = "نیمبلوک", NameEn = "Nimbolook", Code = "110023" },
                    new Framework.StorageModels.City { Name = "شوسف", NameEn = "Shoosf", Code = "110024" },
                    new Framework.StorageModels.City { Name = "نهبندان", NameEn = "Nehbandan", Code = "110025" },
                    new Framework.StorageModels.City { Name = "دیهوک", NameEn = "Deyhook", Code = "110026" },
                    new Framework.StorageModels.City { Name = "طبس", NameEn = "Tabas", Code = "110027" },
                    new Framework.StorageModels.City { Name = "عشق آباد", NameEn = "EshghAbad", Code = "110028" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "خراسان رضوی",
                Code = "KHR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "باخرز", NameEn = "Bakharz", Code = "111001" },
                    new Framework.StorageModels.City { Name = "بجستان", NameEn = "Bejestan", Code = "111002" },
                    new Framework.StorageModels.City { Name = "یونسی", NameEn = "Younesi", Code = "111003" },
                    new Framework.StorageModels.City { Name = "انابد", NameEn = "Anabad", Code = "111004" },
                    new Framework.StorageModels.City { Name = "بردسکن", NameEn = "Bardeskan", Code = "111005" },
                    new Framework.StorageModels.City { Name = "شهرآباد", NameEn = "ShahrAbad", Code = "111006" },
                    new Framework.StorageModels.City { Name = "شاندیز", NameEn = "Shandiz", Code = "111007" },
                    new Framework.StorageModels.City { Name = "طرقبه", NameEn = "Torghabeh", Code = "111008" },
                    new Framework.StorageModels.City { Name = "تایباد", NameEn = "Taibad", Code = "111009" },
                    new Framework.StorageModels.City { Name = "کاریز", NameEn = "Kariz", Code = "111010" },
                    new Framework.StorageModels.City { Name = "مشهدریزه", NameEn = "Mashhadrize", Code = "111011" },
                    new Framework.StorageModels.City { Name = "فیروزه", NameEn = "Firuzeh", Code = "111012" },
                    new Framework.StorageModels.City { Name = "همت آباد", NameEn = "HemmatAbad", Code = "111013" },
                    new Framework.StorageModels.City { Name = "احمدابادصولت", NameEn = "Ahmadabadesolat", Code = "111014" },
                    new Framework.StorageModels.City { Name = "تربت جام", NameEn = "Torbatjam", Code = "111015" },
                    new Framework.StorageModels.City { Name = "صالح آباد", NameEn = "SalehAbad", Code = "111016" },
                    new Framework.StorageModels.City { Name = "نصرآباد", NameEn = "NasrAbad", Code = "111017" },
                    new Framework.StorageModels.City { Name = "نیل شهر", NameEn = "NilShahr", Code = "111018" },
                    new Framework.StorageModels.City { Name = "بایک", NameEn = "Baek", Code = "111019" },
                    new Framework.StorageModels.City { Name = "تربت حیدریه", NameEn = "Torbatheydariyeh", Code = "111020" },
                    new Framework.StorageModels.City { Name = "رباط سنگ", NameEn = "Robatsang", Code = "111021" },
                    new Framework.StorageModels.City { Name = "کدکن", NameEn = "Kodkan", Code = "111022" },
                    new Framework.StorageModels.City { Name = "جغتای", NameEn = "Joghatay", Code = "111023" },
                    new Framework.StorageModels.City { Name = "نقاب", NameEn = "Neghab", Code = "111024" },
                    new Framework.StorageModels.City { Name = "چناران", NameEn = "Chenaran", Code = "111025" },
                    new Framework.StorageModels.City { Name = "گلمکان", NameEn = "Golmakan", Code = "111026" },
                    new Framework.StorageModels.City { Name = "خلیل آباد", NameEn = "KhalilAbad", Code = "111027" },
                    new Framework.StorageModels.City { Name = "کندر", NameEn = "Kondor", Code = "111028" },
                    new Framework.StorageModels.City { Name = "خواف", NameEn = "Khaf", Code = "111029" },
                    new Framework.StorageModels.City { Name = "سلامی", NameEn = "Salami", Code = "111030" },
                    new Framework.StorageModels.City { Name = "سنگان", NameEn = "Sangan", Code = "111031" },
                    new Framework.StorageModels.City { Name = "قاسم آباد", NameEn = "GhasemAbad", Code = "111032" },
                    new Framework.StorageModels.City { Name = "نشتیفان", NameEn = "Nashtifan", Code = "111033" },
                    new Framework.StorageModels.City { Name = "سلطان آباد", NameEn = "SoltanAbad", Code = "111034" },
                    new Framework.StorageModels.City { Name = "چاپشلو", NameEn = "Chapeshloo", Code = "111035" },
                    new Framework.StorageModels.City { Name = "درگز", NameEn = "Daregaz", Code = "111036" },
                    new Framework.StorageModels.City { Name = "لطف آباد", NameEn = "LotfAbad", Code = "111037" },
                    new Framework.StorageModels.City { Name = "نوخندان", NameEn = "Nokhandan", Code = "111038" },
                    new Framework.StorageModels.City { Name = "جنگل", NameEn = "Jangal", Code = "111039" },
                    new Framework.StorageModels.City { Name = "رشتخوار", NameEn = "Rashtkhar", Code = "111040" },
                    new Framework.StorageModels.City { Name = "دولت آباد", NameEn = "DolatAbad", Code = "111041" },
                    new Framework.StorageModels.City { Name = "داورزن", NameEn = "Davarzan", Code = "111042" },
                    new Framework.StorageModels.City { Name = "روداب", NameEn = "Ruodab", Code = "111043" },
                    new Framework.StorageModels.City { Name = "سبزوار", NameEn = "Sabzevar", Code = "111044" },
                    new Framework.StorageModels.City { Name = "ششتمد", NameEn = "Sheshtamad", Code = "111045" },
                    new Framework.StorageModels.City { Name = "سرخس", NameEn = "Sarakhs", Code = "111046" },
                    new Framework.StorageModels.City { Name = "مزدآوند", NameEn = "Mazdavand", Code = "111047" },
                    new Framework.StorageModels.City { Name = "سفیدسنگ", NameEn = "Sefidsang", Code = "111048" },
                    new Framework.StorageModels.City { Name = "فرهادگرد", NameEn = "Farhadgar", Code = "111049" },
                    new Framework.StorageModels.City { Name = "فریمان", NameEn = "Fariman", Code = "111050" },
                    new Framework.StorageModels.City { Name = "قلندرآباد", NameEn = "GhalandarAbad", Code = "111051" },
                    new Framework.StorageModels.City { Name = "باجگیران", NameEn = "Bajgiran", Code = "111052" },
                    new Framework.StorageModels.City { Name = "قوچان", NameEn = "Ghoochan", Code = "111053" },
                    new Framework.StorageModels.City { Name = "ریوش", NameEn = "Rivash", Code = "111054" },
                    new Framework.StorageModels.City { Name = "کاشمر", NameEn = "Kashmar", Code = "111055" },
                    new Framework.StorageModels.City { Name = "شهرزو", NameEn = "Shahrezoo", Code = "111056" },
                    new Framework.StorageModels.City { Name = "کلات", NameEn = "Kalat", Code = "111057" },
                    new Framework.StorageModels.City { Name = "بیدخت", NameEn = "Bidokht", Code = "111058" },
                    new Framework.StorageModels.City { Name = "کاخک", NameEn = "Kakhak", Code = "111059" },
                    new Framework.StorageModels.City { Name = "گناباد", NameEn = "Gonabad", Code = "111060" },
                    new Framework.StorageModels.City { Name = "رضویه", NameEn = "Razaviyeh", Code = "111061" },
                    new Framework.StorageModels.City { Name = "مشهد", NameEn = "Mashhad", Code = "111062" },
                    new Framework.StorageModels.City { Name = "مشهد ثامن", NameEn = "MashhadSamen", Code = "111063" },
                    new Framework.StorageModels.City { Name = "ملک آباد", NameEn = "MolkAbad", Code = "111064" },
                    new Framework.StorageModels.City { Name = "شادمهر", NameEn = "Shadmehr", Code = "111065" },
                    new Framework.StorageModels.City { Name = "فیض آباد", NameEn = "FeizAbad", Code = "111066" },
                    new Framework.StorageModels.City { Name = "بار", NameEn = "Baar", Code = "111067" },
                    new Framework.StorageModels.City { Name = "چکنه", NameEn = "Chakaneh", Code = "111068" },
                    new Framework.StorageModels.City { Name = "خرو", NameEn = "Kharv", Code = "111069" },
                    new Framework.StorageModels.City { Name = "درود", NameEn = "Darrood", Code = "111070" },
                    new Framework.StorageModels.City { Name = "عشق آباد", NameEn = "EshghAbad", Code = "111071" },
                    new Framework.StorageModels.City { Name = "قدمگاه", NameEn = "Ghadamgah", Code = "111072" },
                    new Framework.StorageModels.City { Name = "نیشابور", NameEn = "Neyshaboor", Code = "111073" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "خراسان شمالی",
                Code = "KHN",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اسفراین", NameEn = "Esfarayen", Code = "112001" },
                    new Framework.StorageModels.City { Name = "صفی آباد", NameEn = "SafiAbad", Code = "112002" },
                    new Framework.StorageModels.City { Name = "بجنورد", NameEn = "Bojnoord", Code = "112003" },
                    new Framework.StorageModels.City { Name = "حصارگرمخان", NameEn = "Hesargarmkhan", Code = "112004" },
                    new Framework.StorageModels.City { Name = "راز", NameEn = "Raz", Code = "112005" },
                    new Framework.StorageModels.City { Name = "جاجرم", NameEn = "Jajarm", Code = "112006" },
                    new Framework.StorageModels.City { Name = "سنخواست", NameEn = "Sankhast", Code = "112007" },
                    new Framework.StorageModels.City { Name = "شوقان", NameEn = "Shoghan", Code = "112008" },
                    new Framework.StorageModels.City { Name = "شیروان", NameEn = "Shirvan", Code = "112009" },
                    new Framework.StorageModels.City { Name = "لوجلی", NameEn = "Lojali", Code = "112010" },
                    new Framework.StorageModels.City { Name = "تیتکانلو", NameEn = "Titkanlo", Code = "112011" },
                    new Framework.StorageModels.City { Name = "فاروج", NameEn = "Farooj", Code = "112012" },
                    new Framework.StorageModels.City { Name = "ایور", NameEn = "Ivar", Code = "112013" },
                    new Framework.StorageModels.City { Name = "درق", NameEn = "Daragh", Code = "112014" },
                    new Framework.StorageModels.City { Name = "گرمه", NameEn = "Garmeh", Code = "112015" },
                    new Framework.StorageModels.City { Name = "آشخانه", NameEn = "Ashkhaneh", Code = "112016" },
                    new Framework.StorageModels.City { Name = "پیش قلعه", NameEn = "Pishghale", Code = "112017" },
                    new Framework.StorageModels.City { Name = "قاضی", NameEn = "Ghazi", Code = "112018" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "خوزستان",
                Code = "KHO",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "امیدیه", NameEn = "Omidieh", Code = "113001" },
                    new Framework.StorageModels.City { Name = "جایزان", NameEn = "Jayzan", Code = "113002" },
                    new Framework.StorageModels.City { Name = "قلعه خواجه", NameEn = "Ghalekhajeh", Code = "113003" },
                    new Framework.StorageModels.City { Name = "اندیمشک", NameEn = "Andimeshk", Code = "113004" },
                    new Framework.StorageModels.City { Name = "حسینیه", NameEn = "Hoseyniyeh", Code = "113005" },
                    new Framework.StorageModels.City { Name = "اهواز", NameEn = "Ahvaz", Code = "113006" },
                    new Framework.StorageModels.City { Name = "حمیدیه", NameEn = "Hamidieh", Code = "113007" },
                    new Framework.StorageModels.City { Name = "ایذه", NameEn = "Izeh", Code = "113008" },
                    new Framework.StorageModels.City { Name = "دهدز", NameEn = "Dehdez", Code = "113009" },
                    new Framework.StorageModels.City { Name = "اروندکنار", NameEn = "Arvandkenar", Code = "113010" },
                    new Framework.StorageModels.City { Name = "آبادان", NameEn = "Abadan", Code = "113011" },
                    new Framework.StorageModels.City { Name = "چویبده", NameEn = "Choebdeh", Code = "113012" },
                    new Framework.StorageModels.City { Name = "باغ ملک", NameEn = "Baghmalek", Code = "113013" },
                    new Framework.StorageModels.City { Name = "صیدون", NameEn = "Seydun", Code = "113014" },
                    new Framework.StorageModels.City { Name = "قلعه تل", NameEn = "Ghaletol", Code = "113015" },
                    new Framework.StorageModels.City { Name = "میداود", NameEn = "Meidavood", Code = "113016" },
                    new Framework.StorageModels.City { Name = "شیبان", NameEn = "Shiban", Code = "113017" },
                    new Framework.StorageModels.City { Name = "ملاثانی", NameEn = "Mollasani", Code = "113018" },
                    new Framework.StorageModels.City { Name = "ویس", NameEn = "Veys", Code = "113019" },
                    new Framework.StorageModels.City { Name = "بندرامام خمینی", NameEn = "BandarEmamKhomeini", Code = "113020" },
                    new Framework.StorageModels.City { Name = "بندرماهشهر", NameEn = "BandarMahshahr", Code = "113021" },
                    new Framework.StorageModels.City { Name = "چمران", NameEn = "Chamran", Code = "113022" },
                    new Framework.StorageModels.City { Name = "آغاجاری", NameEn = "Aghajari", Code = "113023" },
                    new Framework.StorageModels.City { Name = "بهبهان", NameEn = "Behbahan", Code = "113024" },
                    new Framework.StorageModels.City { Name = "سردشت", NameEn = "Sardasht", Code = "113025" },
                    new Framework.StorageModels.City { Name = "خرمشهر", NameEn = "KhoramShahr", Code = "113026" },
                    new Framework.StorageModels.City { Name = "مینوشهر", NameEn = "MinooShahr", Code = "113027" },
                    new Framework.StorageModels.City { Name = "چغامیش", NameEn = "Choghamish", Code = "113028" },
                    new Framework.StorageModels.City { Name = "حمزه", NameEn = "Hamzeh", Code = "113029" },
                    new Framework.StorageModels.City { Name = "دزآب", NameEn = "Dezab", Code = "113030" },
                    new Framework.StorageModels.City { Name = "دزفول", NameEn = "Dezfool", Code = "113031" },
                    new Framework.StorageModels.City { Name = "سالند", NameEn = "Saland", Code = "113032" },
                    new Framework.StorageModels.City { Name = "صفی آباد", NameEn = "SafiAbad", Code = "113033" },
                    new Framework.StorageModels.City { Name = "میانرود", NameEn = "Mianrood", Code = "113034" },
                    new Framework.StorageModels.City { Name = "بستان", NameEn = "Bostan", Code = "113035" },
                    new Framework.StorageModels.City { Name = "سوسنگرد", NameEn = "Soosangerd", Code = "113036" },
                    new Framework.StorageModels.City { Name = "رامشیر", NameEn = "Ramshir", Code = "113037" },
                    new Framework.StorageModels.City { Name = "مشراگه", NameEn = "Meshrageh", Code = "113038" },
                    new Framework.StorageModels.City { Name = "رامهرمز", NameEn = "Ramhormoz", Code = "113039" },
                    new Framework.StorageModels.City { Name = "دارخوین", NameEn = "Darkhovein", Code = "113040" },
                    new Framework.StorageModels.City { Name = "شادگان", NameEn = "Shadegan", Code = "113041" },
                    new Framework.StorageModels.City { Name = "الوان", NameEn = "Alvan", Code = "113042" },
                    new Framework.StorageModels.City { Name = "حر", NameEn = "Hor", Code = "113043" },
                    new Framework.StorageModels.City { Name = "شاوور", NameEn = "Shavoor", Code = "113044" },
                    new Framework.StorageModels.City { Name = "شوش", NameEn = "Shoosh", Code = "113045" },
                    new Framework.StorageModels.City { Name = "صالح مشطت", NameEn = "Salehmoshatat", Code = "113046" },
                    new Framework.StorageModels.City { Name = "شرافت", NameEn = "Sherafat", Code = "113047" },
                    new Framework.StorageModels.City { Name = "شوشتر", NameEn = "Shooshtar", Code = "113048" },
                    new Framework.StorageModels.City { Name = "گوریه", NameEn = "Gurieh", Code = "113049" },
                    new Framework.StorageModels.City { Name = "ترکالکی", NameEn = "Torkalaki", Code = "113050" },
                    new Framework.StorageModels.City { Name = "جنت مکان", NameEn = "Jannatmakan", Code = "113051" },
                    new Framework.StorageModels.City { Name = "سماله", NameEn = "Somaleh", Code = "113052" },
                    new Framework.StorageModels.City { Name = "صالح شهر", NameEn = "SalehShahr", Code = "113053" },
                    new Framework.StorageModels.City { Name = "گتوند", NameEn = "Gotvand", Code = "113054" },
                    new Framework.StorageModels.City { Name = "لالی", NameEn = "Lali", Code = "113055" },
                    new Framework.StorageModels.City { Name = "مسجدسلیمان", NameEn = "Masjedsoleiman", Code = "113056" },
                    new Framework.StorageModels.City { Name = "هفتگل", NameEn = "Haftgol", Code = "113057" },
                    new Framework.StorageModels.City { Name = "زهره", NameEn = "Zohre", Code = "113058" },
                    new Framework.StorageModels.City { Name = "هندیجان", NameEn = "Hendijan", Code = "113059" },
                    new Framework.StorageModels.City { Name = "رفیع", NameEn = "Rafi", Code = "113060" },
                    new Framework.StorageModels.City { Name = "هویزه", NameEn = "Hoveizeh", Code = "113061" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "زنجان",
                Code = "ZNJ",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ابهر", NameEn = "Abhar", Code = "114001" },
                    new Framework.StorageModels.City { Name = "سلطانیه", NameEn = "Soltanieh", Code = "114002" },
                    new Framework.StorageModels.City { Name = "صایین قلعه", NameEn = "Saeenghale", Code = "114003" },
                    new Framework.StorageModels.City { Name = "هیدج", NameEn = "Hidaj", Code = "114004" },
                    new Framework.StorageModels.City { Name = "حلب", NameEn = "Halab", Code = "114005" },
                    new Framework.StorageModels.City { Name = "زرین آباد", NameEn = "ZarinAbad", Code = "114006" },
                    new Framework.StorageModels.City { Name = "زرین رود", NameEn = "Zarrinroud", Code = "114007" },
                    new Framework.StorageModels.City { Name = "سجاس", NameEn = "Sojas", Code = "114008" },
                    new Framework.StorageModels.City { Name = "سهرورد", NameEn = "Sohrevard", Code = "114009" },
                    new Framework.StorageModels.City { Name = "قیدار", NameEn = "Gheidar", Code = "114010" },
                    new Framework.StorageModels.City { Name = "گرماب", NameEn = "Garmab", Code = "114011" },
                    new Framework.StorageModels.City { Name = "خرمدره", NameEn = "Khoramdareh", Code = "114012" },
                    new Framework.StorageModels.City { Name = "ارمغانخانه", NameEn = "Armaghankhaneh", Code = "114013" },
                    new Framework.StorageModels.City { Name = "زنجان", NameEn = "Zanjan", Code = "114014" },
                    new Framework.StorageModels.City { Name = "آب بر", NameEn = "Abbar", Code = "114015" },
                    new Framework.StorageModels.City { Name = "چورزق", NameEn = "Chavarzagh", Code = "114016" },
                    new Framework.StorageModels.City { Name = "دندی", NameEn = "Dandi", Code = "114017" },
                    new Framework.StorageModels.City { Name = "ماه نشان", NameEn = "Mahneshan", Code = "114018" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "سمنان",
                Code = "SEM",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "امیریه", NameEn = "Amiriyeh", Code = "115001" },
                    new Framework.StorageModels.City { Name = "دامغان", NameEn = "Damghan", Code = "115002" },
                    new Framework.StorageModels.City { Name = "دیباج", NameEn = "Dibaj", Code = "115003" },
                    new Framework.StorageModels.City { Name = "سرخه", NameEn = "Sorkheh", Code = "115004" },
                    new Framework.StorageModels.City { Name = "سمنان", NameEn = "Semnan", Code = "115005" },
                    new Framework.StorageModels.City { Name = "بسطام", NameEn = "Bastam", Code = "115006" },
                    new Framework.StorageModels.City { Name = "بیارجمند", NameEn = "Biarjmand", Code = "115007" },
                    new Framework.StorageModels.City { Name = "شاهرود", NameEn = "Shahrood", Code = "115008" },
                    new Framework.StorageModels.City { Name = "کلاته خیج", NameEn = "Kalatehkhij", Code = "115009" },
                    new Framework.StorageModels.City { Name = "مجن", NameEn = "Mojen", Code = "115010" },
                    new Framework.StorageModels.City { Name = "میامی", NameEn = "Miamey", Code = "115011" },
                    new Framework.StorageModels.City { Name = "ایوانکی", NameEn = "Ivanaki", Code = "115012" },
                    new Framework.StorageModels.City { Name = "آرادان", NameEn = "Aradan", Code = "115013" },
                    new Framework.StorageModels.City { Name = "گرمسار", NameEn = "Garmsar", Code = "115014" },
                    new Framework.StorageModels.City { Name = "درجزین", NameEn = "Darjazin", Code = "115015" },
                    new Framework.StorageModels.City { Name = "شهمیرزاد", NameEn = "Shahmirzad", Code = "115016" },
                    new Framework.StorageModels.City { Name = "مهدی شهر", NameEn = "MehdiShahr", Code = "115017" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "سیستان و بلوچستان",
                Code = "SBA",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ایرانشهر", NameEn = "IranShahr", Code = "116001" },
                    new Framework.StorageModels.City { Name = "بزمان", NameEn = "Bazman", Code = "116002" },
                    new Framework.StorageModels.City { Name = "بمپور", NameEn = "Bampoor", Code = "116003" },
                    new Framework.StorageModels.City { Name = "محمدان", NameEn = "Mohammadan", Code = "116004" },
                    new Framework.StorageModels.City { Name = "چابهار", NameEn = "Chabahar", Code = "116005" },
                    new Framework.StorageModels.City { Name = "نگور", NameEn = "Negor", Code = "116006" },
                    new Framework.StorageModels.City { Name = "خاش", NameEn = "Khash", Code = "116007" },
                    new Framework.StorageModels.City { Name = "نوک آباد", NameEn = "NookAbad", Code = "116008" },
                    new Framework.StorageModels.City { Name = "گلمورتی", NameEn = "Golmorti", Code = "116009" },
                    new Framework.StorageModels.City { Name = "بنجار", NameEn = "Bonjar", Code = "116010" },
                    new Framework.StorageModels.City { Name = "زابل", NameEn = "Zabol", Code = "116011" },
                    new Framework.StorageModels.City { Name = "زاهدان", NameEn = "Zahedan", Code = "116012" },
                    new Framework.StorageModels.City { Name = "میرجاوه", NameEn = "Mirjaveh", Code = "116013" },
                    new Framework.StorageModels.City { Name = "نصرت آباد", NameEn = "NosratAbad", Code = "116014" },
                    new Framework.StorageModels.City { Name = "زهک", NameEn = "Zahak", Code = "116015" },
                    new Framework.StorageModels.City { Name = "جالق", NameEn = "Jalgh", Code = "116016" },
                    new Framework.StorageModels.City { Name = "سراوان", NameEn = "Saravan", Code = "116017" },
                    new Framework.StorageModels.City { Name = "سیرکان", NameEn = "Sirkan", Code = "116018" },
                    new Framework.StorageModels.City { Name = "گشت", NameEn = "Gosht", Code = "116019" },
                    new Framework.StorageModels.City { Name = "محمدی", NameEn = "Mohammadi", Code = "116020" },
                    new Framework.StorageModels.City { Name = "پیشین", NameEn = "Pishin", Code = "116021" },
                    new Framework.StorageModels.City { Name = "راسک", NameEn = "Rask", Code = "116022" },
                    new Framework.StorageModels.City { Name = "سرباز", NameEn = "Sarbaz", Code = "116023" },
                    new Framework.StorageModels.City { Name = "سوران", NameEn = "Sooran", Code = "116024" },
                    new Framework.StorageModels.City { Name = "هیدوچ", NameEn = "Hidooch", Code = "116025" },
                    new Framework.StorageModels.City { Name = "زرآباد", NameEn = "ZarAbad", Code = "116026" },
                    new Framework.StorageModels.City { Name = "کنارک", NameEn = "Konarak", Code = "116027" },
                    new Framework.StorageModels.City { Name = "زابلی", NameEn = "Zaboli", Code = "116028" },
                    new Framework.StorageModels.City { Name = "اسپکه", NameEn = "Espakeh", Code = "116029" },
                    new Framework.StorageModels.City { Name = "بنت", NameEn = "Bent", Code = "116030" },
                    new Framework.StorageModels.City { Name = "فنوج", NameEn = "Fanooj", Code = "116031" },
                    new Framework.StorageModels.City { Name = "قصرقند", NameEn = "Ghasreghand", Code = "116032" },
                    new Framework.StorageModels.City { Name = "نیک شهر", NameEn = "NikShahr", Code = "116033" },
                    new Framework.StorageModels.City { Name = "ادیمی", NameEn = "Adimi", Code = "116034" },
                    new Framework.StorageModels.City { Name = "علی اکبر", NameEn = "Aliakbar", Code = "116035" },
                    new Framework.StorageModels.City { Name = "محمدآباد", NameEn = "MohammadAbad", Code = "116036" },
                    new Framework.StorageModels.City { Name = "دوست محمد", NameEn = "Dustmohammad", Code = "116037" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "فارس",
                Code = "FAR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ارسنجان", NameEn = "Arsanjan", Code = "117001" },
                    new Framework.StorageModels.City { Name = "استهبان", NameEn = "Estahban", Code = "117002" },
                    new Framework.StorageModels.City { Name = "ایج", NameEn = "Edge", Code = "117003" },
                    new Framework.StorageModels.City { Name = "رونیز", NameEn = "Roniz", Code = "117004" },
                    new Framework.StorageModels.City { Name = "اقلید", NameEn = "Eghlid", Code = "117005" },
                    new Framework.StorageModels.City { Name = "حسن آباد", NameEn = "HasanAbad", Code = "117006" },
                    new Framework.StorageModels.City { Name = "دژکرد", NameEn = "Dojkord", Code = "117007" },
                    new Framework.StorageModels.City { Name = "سده", NameEn = "Sedeh", Code = "117008" },
                    new Framework.StorageModels.City { Name = "ایزدخواست", NameEn = "Izadkhast", Code = "117009" },
                    new Framework.StorageModels.City { Name = "آباده", NameEn = "Abadeh", Code = "117010" },
                    new Framework.StorageModels.City { Name = "بهمن", NameEn = "Bahman", Code = "117011" },
                    new Framework.StorageModels.City { Name = "سورمق", NameEn = "Soormagh", Code = "117012" },
                    new Framework.StorageModels.City { Name = "صغاد", NameEn = "Soghad", Code = "117013" },
                    new Framework.StorageModels.City { Name = "بوانات", NameEn = "Bovanat", Code = "117014" },
                    new Framework.StorageModels.City { Name = "حسامی", NameEn = "Hesami", Code = "117015" },
                    new Framework.StorageModels.City { Name = "کره ای", NameEn = "Karehi", Code = "117016" },
                    new Framework.StorageModels.City { Name = "سعادت شهر", NameEn = "SaadatShahr", Code = "117017" },
                    new Framework.StorageModels.City { Name = "باب انار", NameEn = "Babanar", Code = "117018" },
                    new Framework.StorageModels.City { Name = "جهرم", NameEn = "Jahrom", Code = "117019" },
                    new Framework.StorageModels.City { Name = "خاوران", NameEn = "Khavaran", Code = "117020" },
                    new Framework.StorageModels.City { Name = "دوزه", NameEn = "Dozeh", Code = "117021" },
                    new Framework.StorageModels.City { Name = "قطب آباد", NameEn = "GhotbAbad", Code = "117022" },
                    new Framework.StorageModels.City { Name = "خرامه", NameEn = "Khorameh", Code = "117023" },
                    new Framework.StorageModels.City { Name = "صفاشهر", NameEn = "SafaShahr", Code = "117024" },
                    new Framework.StorageModels.City { Name = "قادرآباد", NameEn = "GhaderAbad", Code = "117025" },
                    new Framework.StorageModels.City { Name = "خنج", NameEn = "Khonj", Code = "117026" },
                    new Framework.StorageModels.City { Name = "جنت شهر", NameEn = "JanatShahr", Code = "117027" },
                    new Framework.StorageModels.City { Name = "داراب", NameEn = "Darab", Code = "117028" },
                    new Framework.StorageModels.City { Name = "دوبرجی", NameEn = "Doborji", Code = "117029" },
                    new Framework.StorageModels.City { Name = "فدامی", NameEn = "Fadami", Code = "117030" },
                    new Framework.StorageModels.City { Name = "مصیری", NameEn = "Masiri", Code = "117031" },
                    new Framework.StorageModels.City { Name = "حاجی آباد", NameEn = "HajiAbad", Code = "117032" },
                    new Framework.StorageModels.City { Name = "دبیران", NameEn = "Dabiran", Code = "117033" },
                    new Framework.StorageModels.City { Name = "شهرپیر", NameEn = "Shahrepir", Code = "117034" },
                    new Framework.StorageModels.City { Name = "اردکان", NameEn = "Ardakan", Code = "117035" },
                    new Framework.StorageModels.City { Name = "بیضا", NameEn = "Beiza", Code = "117036" },
                    new Framework.StorageModels.City { Name = "هماشهر", NameEn = "HomaShahr", Code = "117037" },
                    new Framework.StorageModels.City { Name = "سروستان", NameEn = "Sarvestan", Code = "117038" },
                    new Framework.StorageModels.City { Name = "کوهنجان", NameEn = "Koohenjan", Code = "117039" },
                    new Framework.StorageModels.City { Name = "خانه زنیان", NameEn = "Khanezenian", Code = "117040" },
                    new Framework.StorageModels.City { Name = "داریان", NameEn = "Darian", Code = "117041" },
                    new Framework.StorageModels.City { Name = "زرقان", NameEn = "Zarghan", Code = "117042" },
                    new Framework.StorageModels.City { Name = "شهرصدرا", NameEn = "Shahrsadra", Code = "117043" },
                    new Framework.StorageModels.City { Name = "شیراز", NameEn = "Shiraz", Code = "117044" },
                    new Framework.StorageModels.City { Name = "لپویی", NameEn = "Lapooee", Code = "117045" },
                    new Framework.StorageModels.City { Name = "دهرم", NameEn = "Dehram", Code = "117046" },
                    new Framework.StorageModels.City { Name = "فراشبند", NameEn = "Farashband", Code = "117047" },
                    new Framework.StorageModels.City { Name = "نوجین", NameEn = "Nojein", Code = "117048" },
                    new Framework.StorageModels.City { Name = "زاهدشهر", NameEn = "ZahedShahr", Code = "117049" },
                    new Framework.StorageModels.City { Name = "ششده", NameEn = "Sheshdeh", Code = "117050" },
                    new Framework.StorageModels.City { Name = "فسا", NameEn = "Fasa", Code = "117051" },
                    new Framework.StorageModels.City { Name = "نوبندگان", NameEn = "Nobandegan", Code = "117052" },
                    new Framework.StorageModels.City { Name = "فیروزآباد", NameEn = "FiroozAbad", Code = "117053" },
                    new Framework.StorageModels.City { Name = "میمند", NameEn = "Meimand", Code = "117054" },
                    new Framework.StorageModels.City { Name = "افزر", NameEn = "Afzar", Code = "117055" },
                    new Framework.StorageModels.City { Name = "امام شهر", NameEn = "EmamShahr", Code = "117056" },
                    new Framework.StorageModels.City { Name = "قیر", NameEn = "Gheer", Code = "117057" },
                    new Framework.StorageModels.City { Name = "کارزین[2]", NameEn = "Karzin", Code = "117058" },
                    new Framework.StorageModels.City { Name = "مبارک آباددیز", NameEn = "Mobarakabaddiz", Code = "117059" },
                    new Framework.StorageModels.City { Name = "بالاده", NameEn = "Baladeh", Code = "117060" },
                    new Framework.StorageModels.City { Name = "خشت", NameEn = "Khesht", Code = "117061" },
                    new Framework.StorageModels.City { Name = "قایمیه", NameEn = "Ghaemieh", Code = "117062" },
                    new Framework.StorageModels.City { Name = "کازرون", NameEn = "Kazeroon", Code = "117063" },
                    new Framework.StorageModels.City { Name = "کنارتخته", NameEn = "Kenartakhteh", Code = "117064" },
                    new Framework.StorageModels.City { Name = "نودان", NameEn = "Nodan", Code = "117065" },
                    new Framework.StorageModels.City { Name = "کوار", NameEn = "Kovar", Code = "117066" },
                    new Framework.StorageModels.City { Name = "گراش", NameEn = "Gerash", Code = "117067" },
                    new Framework.StorageModels.City { Name = "اوز", NameEn = "Evaz", Code = "117068" },
                    new Framework.StorageModels.City { Name = "بنارویه", NameEn = "Banarooyeh", Code = "117069" },
                    new Framework.StorageModels.City { Name = "بیرم", NameEn = "Beiram", Code = "117070" },
                    new Framework.StorageModels.City { Name = "جویم", NameEn = "Jooyam", Code = "117071" },
                    new Framework.StorageModels.City { Name = "خور", NameEn = "Khoor", Code = "117072" },
                    new Framework.StorageModels.City { Name = "عمادده", NameEn = "Emadodeh", Code = "117073" },
                    new Framework.StorageModels.City { Name = "لار", NameEn = "Lar", Code = "117074" },
                    new Framework.StorageModels.City { Name = "لطیفی", NameEn = "Latifi", Code = "117075" },
                    new Framework.StorageModels.City { Name = "اشکنان", NameEn = "Ashknan", Code = "117076" },
                    new Framework.StorageModels.City { Name = "اهل", NameEn = "Ahl", Code = "117077" },
                    new Framework.StorageModels.City { Name = "علامرودشت", NameEn = "Alamarvdasht", Code = "117078" },
                    new Framework.StorageModels.City { Name = "لامرد", NameEn = "Lamerd", Code = "117079" },
                    new Framework.StorageModels.City { Name = "رامجرد", NameEn = "Ramjerd", Code = "117080" },
                    new Framework.StorageModels.City { Name = "سیدان", NameEn = "Seyedan", Code = "117081" },
                    new Framework.StorageModels.City { Name = "کامفیروز", NameEn = "Kaamfirooz", Code = "117082" },
                    new Framework.StorageModels.City { Name = "مرودشت", NameEn = "Marvdasht", Code = "117083" },
                    new Framework.StorageModels.City { Name = "خومه زار", NameEn = "Khumehzar", Code = "117084" },
                    new Framework.StorageModels.City { Name = "نورآباد", NameEn = "NoorAbad", Code = "117085" },
                    new Framework.StorageModels.City { Name = "اسیر", NameEn = "Asir", Code = "117086" },
                    new Framework.StorageModels.City { Name = "گله دار", NameEn = "Galledar", Code = "117087" },
                    new Framework.StorageModels.City { Name = "مهر", NameEn = "Mehr", Code = "117088" },
                    new Framework.StorageModels.City { Name = "وراوی", NameEn = "Varavi", Code = "117089" },
                    new Framework.StorageModels.City { Name = "آباده طشک", NameEn = "Abadehtashk", Code = "117090" },
                    new Framework.StorageModels.City { Name = "قطرویه", NameEn = "Ghatruyeh", Code = "117091" },
                    new Framework.StorageModels.City { Name = "مشکان", NameEn = "Meshkan", Code = "117092" },
                    new Framework.StorageModels.City { Name = "نی ریز", NameEn = "Neyriz", Code = "117093" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "قزوین",
                Code = "QAZ",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "الوند", NameEn = "Alvand", Code = "118001" },
                    new Framework.StorageModels.City { Name = "بیدستان", NameEn = "Bidestan", Code = "118002" },
                    new Framework.StorageModels.City { Name = "شریفیه", NameEn = "Sharifieh", Code = "118003" },
                    new Framework.StorageModels.City { Name = "محمدیه", NameEn = "Mohammadieh", Code = "118004" },
                    new Framework.StorageModels.City { Name = "آبیک", NameEn = "Abeyek", Code = "118005" },
                    new Framework.StorageModels.City { Name = "خاکعلی", NameEn = "Khakali", Code = "118006" },
                    new Framework.StorageModels.City { Name = "ارداق", NameEn = "Ardagh", Code = "118007" },
                    new Framework.StorageModels.City { Name = "آبگرم", NameEn = "Abgarm", Code = "118008" },
                    new Framework.StorageModels.City { Name = "آوج", NameEn = "Avaj", Code = "118009" },
                    new Framework.StorageModels.City { Name = "بویین زهرا", NameEn = "Booeenzahra", Code = "118010" },
                    new Framework.StorageModels.City { Name = "دانسفهان", NameEn = "Danesfehan", Code = "118011" },
                    new Framework.StorageModels.City { Name = "سگزآباد", NameEn = "SagzAbad", Code = "118012" },
                    new Framework.StorageModels.City { Name = "شال", NameEn = "Shal", Code = "118013" },
                    new Framework.StorageModels.City { Name = "اسفرورین", NameEn = "Esfarvarin", Code = "118014" },
                    new Framework.StorageModels.City { Name = "تاکستان", NameEn = "Takestan", Code = "118015" },
                    new Framework.StorageModels.City { Name = "خرمدشت", NameEn = "Khoramdasht", Code = "118016" },
                    new Framework.StorageModels.City { Name = "ضیاءآباد", NameEn = "ZiaAbad", Code = "118017" },
                    new Framework.StorageModels.City { Name = "نرجه", NameEn = "Narje", Code = "118018" },
                    new Framework.StorageModels.City { Name = "اقبالیه", NameEn = "Eghbalyeh", Code = "118019" },
                    new Framework.StorageModels.City { Name = "رازمیان", NameEn = "Razmiyan", Code = "118020" },
                    new Framework.StorageModels.City { Name = "سیردان", NameEn = "Sirdan", Code = "118021" },
                    new Framework.StorageModels.City { Name = "قزوین", NameEn = "Qazvin", Code = "118022" },
                    new Framework.StorageModels.City { Name = "کوهین", NameEn = "Kouhin", Code = "118023" },
                    new Framework.StorageModels.City { Name = "محمودآبادنمونه", NameEn = "MahmudAbadNemuneh", Code = "118024" },
                    new Framework.StorageModels.City { Name = "معلم کلایه", NameEn = "Moalemkelayeh", Code = "118025" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "قم",
                Code = "QOM ",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "جعفریه", NameEn = "Jafarieh", Code = "119001" },
                    new Framework.StorageModels.City { Name = "دستجرد", NameEn = "Dastjerd", Code = "119002" },
                    new Framework.StorageModels.City { Name = "سلفچگان", NameEn = "Salafchegan", Code = "119003" },
                    new Framework.StorageModels.City { Name = "قم", NameEn = "Qom", Code = "119004" },
                    new Framework.StorageModels.City { Name = "قنوات", NameEn = "Ghanavat", Code = "119005" },
                    new Framework.StorageModels.City { Name = "کهک", NameEn = "Kahak", Code = "119006" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "کردستان",
                Code = "KRD",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "آرمرده", NameEn = "Armardeh", Code = "120001" },
                    new Framework.StorageModels.City { Name = "بانه", NameEn = "Baneh", Code = "120002" },
                    new Framework.StorageModels.City { Name = "بویین سفلی", NameEn = "Booeensofla", Code = "120003" },
                    new Framework.StorageModels.City { Name = "کانی سور", NameEn = "Kanisor", Code = "120004" },
                    new Framework.StorageModels.City { Name = "بابارشانی", NameEn = "Babarashani", Code = "120005" },
                    new Framework.StorageModels.City { Name = "بیجار", NameEn = "Bijar", Code = "120006" },
                    new Framework.StorageModels.City { Name = "یاسوکند", NameEn = "Yasokand", Code = "120007" },
                    new Framework.StorageModels.City { Name = "بلبان آباد", NameEn = "BolbanAbad", Code = "120008" },
                    new Framework.StorageModels.City { Name = "دهگلان", NameEn = "Dehgolan", Code = "120009" },
                    new Framework.StorageModels.City { Name = "دیواندره", NameEn = "Divandareh", Code = "120010" },
                    new Framework.StorageModels.City { Name = "زرینه", NameEn = "Zarineh", Code = "120011" },
                    new Framework.StorageModels.City { Name = "سروآباد", NameEn = "SarvAbad", Code = "120012" },
                    new Framework.StorageModels.City { Name = "سقز", NameEn = "Saghez", Code = "120013" },
                    new Framework.StorageModels.City { Name = "صاحب", NameEn = "Saheb", Code = "120014" },
                    new Framework.StorageModels.City { Name = "سنندج", NameEn = "Sanandaj", Code = "120015" },
                    new Framework.StorageModels.City { Name = "شویشه", NameEn = "Shoysheh", Code = "120016" },
                    new Framework.StorageModels.City { Name = "دزج", NameEn = "Dazj", Code = "120017" },
                    new Framework.StorageModels.City { Name = "دلبران", NameEn = "Delbaran", Code = "120018" },
                    new Framework.StorageModels.City { Name = "سریش آباد", NameEn = "SerishAbad", Code = "120019" },
                    new Framework.StorageModels.City { Name = "قروه", NameEn = "Ghorveh", Code = "120020" },
                    new Framework.StorageModels.City { Name = "کامیاران", NameEn = "Kamyaran", Code = "120021" },
                    new Framework.StorageModels.City { Name = "موچش", NameEn = "Mochesh", Code = "120022" },
                    new Framework.StorageModels.City { Name = "چناره", NameEn = "Chenareh", Code = "120023" },
                    new Framework.StorageModels.City { Name = "کانی دینار", NameEn = "Kanidinar", Code = "120024" },
                    new Framework.StorageModels.City { Name = "مریوان", NameEn = "Marivan", Code = "120025" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "کرمان",
                Code = "KRM",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ارزوییه", NameEn = "Orzooeeyeh", Code = "121001" },
                    new Framework.StorageModels.City { Name = "امین شهر", NameEn = "AminShahr", Code = "121002" },
                    new Framework.StorageModels.City { Name = "انار", NameEn = "Anar", Code = "121003" },
                    new Framework.StorageModels.City { Name = "بافت", NameEn = "Baft", Code = "121004" },
                    new Framework.StorageModels.City { Name = "بزنجان", NameEn = "Bezanjan", Code = "121005" },
                    new Framework.StorageModels.City { Name = "بردسیر", NameEn = "Bardsir", Code = "121006" },
                    new Framework.StorageModels.City { Name = "گلزار", NameEn = "Golzar", Code = "121007" },
                    new Framework.StorageModels.City { Name = "لاله زار", NameEn = "Lalezar", Code = "121008" },
                    new Framework.StorageModels.City { Name = "نگار", NameEn = "Negar", Code = "121009" },
                    new Framework.StorageModels.City { Name = "بروات", NameEn = "Baravat", Code = "121010" },
                    new Framework.StorageModels.City { Name = "بم", NameEn = "Bam", Code = "121011" },
                    new Framework.StorageModels.City { Name = "جبالبارز", NameEn = "Jebalbarez", Code = "121012" },
                    new Framework.StorageModels.City { Name = "جیرفت", NameEn = "Jiroft", Code = "121013" },
                    new Framework.StorageModels.City { Name = "درب بهشت", NameEn = "Darbbehesht", Code = "121014" },
                    new Framework.StorageModels.City { Name = "رابر", NameEn = "Rabor", Code = "121015" },
                    new Framework.StorageModels.City { Name = "راور", NameEn = "Ravar", Code = "121016" },
                    new Framework.StorageModels.City { Name = "هجدک", NameEn = "Hojedak", Code = "121017" },
                    new Framework.StorageModels.City { Name = "بهرمان", NameEn = "Bahreman", Code = "121018" },
                    new Framework.StorageModels.City { Name = "رفسنجان", NameEn = "Rafsanjan", Code = "121019" },
                    new Framework.StorageModels.City { Name = "صفاییه", NameEn = "Safaaeeyeh", Code = "121020" },
                    new Framework.StorageModels.City { Name = "کشکوییه", NameEn = "Koshkooeeyeh", Code = "121021" },
                    new Framework.StorageModels.City { Name = "مس سرچشمه", NameEn = "Mesesarcheshmeh", Code = "121022" },
                    new Framework.StorageModels.City { Name = "رودبار", NameEn = "Roodbar", Code = "121023" },
                    new Framework.StorageModels.City { Name = "محمدآباد", NameEn = "MohammadAbad", Code = "121024" },
                    new Framework.StorageModels.City { Name = "خانوک", NameEn = "Khanook", Code = "121025" },
                    new Framework.StorageModels.City { Name = "ریحان", NameEn = "Reyhan", Code = "121026" },
                    new Framework.StorageModels.City { Name = "زرند", NameEn = "Zarand", Code = "121027" },
                    new Framework.StorageModels.City { Name = "یزدان شهر", NameEn = "YazdanShahr", Code = "121028" },
                    new Framework.StorageModels.City { Name = "پاریز", NameEn = "Pariz", Code = "121029" },
                    new Framework.StorageModels.City { Name = "زیدآباد", NameEn = "ZeidAbad", Code = "121030" },
                    new Framework.StorageModels.City { Name = "سیرجان", NameEn = "Sirjan", Code = "121031" },
                    new Framework.StorageModels.City { Name = "نجف شهر", NameEn = "NajafShahr", Code = "121032" },
                    new Framework.StorageModels.City { Name = "هماشهر", NameEn = "HomaShahr", Code = "121033" },
                    new Framework.StorageModels.City { Name = "جوزم", NameEn = "Javazm", Code = "121034" },
                    new Framework.StorageModels.City { Name = "خاتون آباد", NameEn = "KhatoonAbad", Code = "121035" },
                    new Framework.StorageModels.City { Name = "خورسند", NameEn = "Khorsand", Code = "121036" },
                    new Framework.StorageModels.City { Name = "دهج", NameEn = "Dahej", Code = "121037" },
                    new Framework.StorageModels.City { Name = "شهربابک", NameEn = "Shahrebabak", Code = "121038" },
                    new Framework.StorageModels.City { Name = "دوساری", NameEn = "Dosari", Code = "121039" },
                    new Framework.StorageModels.City { Name = "عنبرآباد", NameEn = "AnbarAbad", Code = "121040" },
                    new Framework.StorageModels.City { Name = "مردهک", NameEn = "Mardehak", Code = "121041" },
                    new Framework.StorageModels.City { Name = "فاریاب", NameEn = "Faryab", Code = "121042" },
                    new Framework.StorageModels.City { Name = "فهرج", NameEn = "Fahraj", Code = "121043" },
                    new Framework.StorageModels.City { Name = "قلعه گنج", NameEn = "Ghaleganj", Code = "121044" },
                    new Framework.StorageModels.City { Name = "اختیارآباد", NameEn = "EkhtiarAbad", Code = "121045" },
                    new Framework.StorageModels.City { Name = "اندوهجرد", NameEn = "Andoohjerd", Code = "121046" },
                    new Framework.StorageModels.City { Name = "باغین", NameEn = "Baghin", Code = "121047" },
                    new Framework.StorageModels.City { Name = "جوپار", NameEn = "Joopar", Code = "121048" },
                    new Framework.StorageModels.City { Name = "چترود", NameEn = "Chatrood", Code = "121049" },
                    new Framework.StorageModels.City { Name = "راین", NameEn = "Rayen", Code = "121050" },
                    new Framework.StorageModels.City { Name = "زنگی آباد", NameEn = "ZangiAbad", Code = "121051" },
                    new Framework.StorageModels.City { Name = "شهداد", NameEn = "Shahdad", Code = "121052" },
                    new Framework.StorageModels.City { Name = "کاظم آباد", NameEn = "KazemAbad", Code = "121053" },
                    new Framework.StorageModels.City { Name = "کرمان", NameEn = "Kerman", Code = "121054" },
                    new Framework.StorageModels.City { Name = "گلباف", NameEn = "Golbaf", Code = "121055" },
                    new Framework.StorageModels.City { Name = "ماهان", NameEn = "Mahan", Code = "121056" },
                    new Framework.StorageModels.City { Name = "محی آباد", NameEn = "MohiAbad", Code = "121057" },
                    new Framework.StorageModels.City { Name = "کهنوج", NameEn = "Kahnooj", Code = "121058" },
                    new Framework.StorageModels.City { Name = "کوهبنان", NameEn = "Koohbanan", Code = "121059" },
                    new Framework.StorageModels.City { Name = "کیانشهر", NameEn = "KianShahr", Code = "121060" },
                    new Framework.StorageModels.City { Name = "منوجان", NameEn = "Manoojan", Code = "121061" },
                    new Framework.StorageModels.City { Name = "نودژ", NameEn = "Nodezh", Code = "121062" },
                    new Framework.StorageModels.City { Name = "نرماشیر", NameEn = "Narmashir", Code = "121063" },
                    new Framework.StorageModels.City { Name = "نظام شهر", NameEn = "NezamShahr", Code = "121064" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "کرمانشاه",
                Code = "KSH",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اسلام آبادغرب", NameEn = "Eslamabadgharb", Code = "122001" },
                    new Framework.StorageModels.City { Name = "حمیل", NameEn = "Hamil", Code = "122002" },
                    new Framework.StorageModels.City { Name = "باینگان", NameEn = "Bayangan", Code = "122003" },
                    new Framework.StorageModels.City { Name = "پاوه", NameEn = "Paveh", Code = "122004" },
                    new Framework.StorageModels.City { Name = "نودشه", NameEn = "Nowdeshah", Code = "122005" },
                    new Framework.StorageModels.City { Name = "نوسود", NameEn = "Nosoud", Code = "122006" },
                    new Framework.StorageModels.City { Name = "ازگله", NameEn = "Azgale", Code = "122007" },
                    new Framework.StorageModels.City { Name = "تازه آباد", NameEn = "TazehAbad", Code = "122008" },
                    new Framework.StorageModels.City { Name = "جوانرود", NameEn = "Javanrood", Code = "122009" },
                    new Framework.StorageModels.City { Name = "کرند", NameEn = "Kerend", Code = "122010" },
                    new Framework.StorageModels.City { Name = "گهواره", NameEn = "Gahvareh", Code = "122011" },
                    new Framework.StorageModels.City { Name = "روانسر", NameEn = "Ravansar", Code = "122012" },
                    new Framework.StorageModels.City { Name = "شاهو", NameEn = "Shahoo", Code = "122013" },
                    new Framework.StorageModels.City { Name = "سرپل ذهاب", NameEn = "Sarpolzahab", Code = "122014" },
                    new Framework.StorageModels.City { Name = "سطر", NameEn = "Satar", Code = "122015" },
                    new Framework.StorageModels.City { Name = "سنقر", NameEn = "Songhor", Code = "122016" },
                    new Framework.StorageModels.City { Name = "صحنه", NameEn = "Sahneh", Code = "122017" },
                    new Framework.StorageModels.City { Name = "میان راهان", NameEn = "Miyanrahan", Code = "122018" },
                    new Framework.StorageModels.City { Name = "سومار", NameEn = "Soomar", Code = "122019" },
                    new Framework.StorageModels.City { Name = "قصرشیرین", NameEn = "Ghasreshirin", Code = "122020" },
                    new Framework.StorageModels.City { Name = "رباط", NameEn = "Robat", Code = "122021" },
                    new Framework.StorageModels.City { Name = "کرمانشاه", NameEn = "Kermanshah", Code = "122022" },
                    new Framework.StorageModels.City { Name = "کوزران", NameEn = "Kozaran", Code = "122023" },
                    new Framework.StorageModels.City { Name = "هلشی", NameEn = "Halashi", Code = "122024" },
                    new Framework.StorageModels.City { Name = "کنگاور", NameEn = "Kangavar", Code = "122025" },
                    new Framework.StorageModels.City { Name = "سرمست", NameEn = "Sarmast", Code = "122026" },
                    new Framework.StorageModels.City { Name = "گیلانغرب", NameEn = "Gilangharb", Code = "122027" },
                    new Framework.StorageModels.City { Name = "بیستون", NameEn = "Bistoon", Code = "122028" },
                    new Framework.StorageModels.City { Name = "هرسین", NameEn = "Hersin", Code = "122029" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "کهگیلویه و بویراحمد",
                Code = "KOB",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "باشت", NameEn = "Basht", Code = "123001" },
                    new Framework.StorageModels.City { Name = "لیکک", NameEn = "Likak", Code = "123002" },
                    new Framework.StorageModels.City { Name = "گراب سفلی", NameEn = "Garabsofla", Code = "123003" },
                    new Framework.StorageModels.City { Name = "مادوان", NameEn = "Madavan", Code = "123004" },
                    new Framework.StorageModels.City { Name = "مارگون", NameEn = "Margoon", Code = "123005" },
                    new Framework.StorageModels.City { Name = "یاسوج", NameEn = "Yasooj", Code = "123006" },
                    new Framework.StorageModels.City { Name = "چرام", NameEn = "Choram", Code = "123007" },
                    new Framework.StorageModels.City { Name = "پاتاوه", NameEn = "Pataveh", Code = "123008" },
                    new Framework.StorageModels.City { Name = "چیتاب", NameEn = "Chitab", Code = "123009" },
                    new Framework.StorageModels.City { Name = "سی سخت", NameEn = "Sisakht", Code = "123010" },
                    new Framework.StorageModels.City { Name = "دهدشت", NameEn = "Dehdasht", Code = "123011" },
                    new Framework.StorageModels.City { Name = "دیشموک", NameEn = "Dishmok", Code = "123012" },
                    new Framework.StorageModels.City { Name = "سوق", NameEn = "Sugh", Code = "123013" },
                    new Framework.StorageModels.City { Name = "قلعه رییسی", NameEn = "Ghaleraeesi", Code = "123014" },
                    new Framework.StorageModels.City { Name = "لنده", NameEn = "Lendeh", Code = "123015" },
                    new Framework.StorageModels.City { Name = "دوگنبدان", NameEn = "Dogonbadan", Code = "123016" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "گلستان",
                Code = "GOL",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "آزادشهر", NameEn = "AzadShahr", Code = "124001" },
                    new Framework.StorageModels.City { Name = "نگین شهر", NameEn = "NeginShahr", Code = "124002" },
                    new Framework.StorageModels.City { Name = "نوده خاندوز", NameEn = "Nodekhanduz", Code = "124003" },
                    new Framework.StorageModels.City { Name = "انبارآلوم", NameEn = "Anbaralom", Code = "124004" },
                    new Framework.StorageModels.City { Name = "آق قلا", NameEn = "AghGhola", Code = "124005" },
                    new Framework.StorageModels.City { Name = "بندرگز", NameEn = "BandarGaz", Code = "124006" },
                    new Framework.StorageModels.City { Name = "نوکنده", NameEn = "Nokandeh", Code = "124007" },
                    new Framework.StorageModels.City { Name = "بندرترکمن", NameEn = "BandarTorkaman", Code = "124008" },
                    new Framework.StorageModels.City { Name = "خان ببین", NameEn = "Khanbebin", Code = "124009" },
                    new Framework.StorageModels.City { Name = "دلند", NameEn = "Deland", Code = "124010" },
                    new Framework.StorageModels.City { Name = "رامیان", NameEn = "Ramyan", Code = "124011" },
                    new Framework.StorageModels.City { Name = "علی آباد", NameEn = "AliAbad", Code = "124012" },
                    new Framework.StorageModels.City { Name = "فاضل آباد", NameEn = "FazelAbad", Code = "124013" },
                    new Framework.StorageModels.City { Name = "کردکوی", NameEn = "KordKooy", Code = "124014" },
                    new Framework.StorageModels.City { Name = "کلاله", NameEn = "Kolaleh", Code = "124015" },
                    new Framework.StorageModels.City { Name = "گالیکش", NameEn = "Galikesh", Code = "124016" },
                    new Framework.StorageModels.City { Name = "جلین", NameEn = "Jelin", Code = "124017" },
                    new Framework.StorageModels.City { Name = "سرخنکلاته", NameEn = "Sorkhankalateh", Code = "124018" },
                    new Framework.StorageModels.City { Name = "گرگان", NameEn = "Gorgan", Code = "124019" },
                    new Framework.StorageModels.City { Name = "سیمین شهر", NameEn = "SiminShahr", Code = "124020" },
                    new Framework.StorageModels.City { Name = "گمیش تپه", NameEn = "Gomeyshtapeh", Code = "124021" },
                    new Framework.StorageModels.City { Name = "اینچه برون", NameEn = "Incheboroon", Code = "124022" },
                    new Framework.StorageModels.City { Name = "گنبدکاووس", NameEn = "Gonbadkavoos", Code = "124023" },
                    new Framework.StorageModels.City { Name = "مراوه", NameEn = "Maraveh", Code = "124024" },
                    new Framework.StorageModels.City { Name = "مینودشت", NameEn = "Minoodasht", Code = "124025" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "گیلان",
                Code = "GIL",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "املش", NameEn = "Amlash", Code = "125001" },
                    new Framework.StorageModels.City { Name = "رانکوه", NameEn = "Rankoh", Code = "125002" },
                    new Framework.StorageModels.City { Name = "آستارا", NameEn = "Astara", Code = "125003" },
                    new Framework.StorageModels.City { Name = "لوندویل", NameEn = "Lavandevil", Code = "125004" },
                    new Framework.StorageModels.City { Name = "آستانه اشرفیه", NameEn = "AstanehAshrafieh", Code = "125005" },
                    new Framework.StorageModels.City { Name = "کیاشهر", NameEn = "KiaShahr", Code = "125006" },
                    new Framework.StorageModels.City { Name = "بندرانزلی", NameEn = "BandarAnzali", Code = "125007" },
                    new Framework.StorageModels.City { Name = "اسالم", NameEn = "Asalem", Code = "125008" },
                    new Framework.StorageModels.City { Name = "تالش", NameEn = "Talesh", Code = "125009" },
                    new Framework.StorageModels.City { Name = "چوبر", NameEn = "Choobar", Code = "125010" },
                    new Framework.StorageModels.City { Name = "حویق", NameEn = "Havigh", Code = "125011" },
                    new Framework.StorageModels.City { Name = "لیسار", NameEn = "Lisar", Code = "125012" },
                    new Framework.StorageModels.City { Name = "خشکبیجار", NameEn = "Khoshkebijar", Code = "125013" },
                    new Framework.StorageModels.City { Name = "خمام", NameEn = "Khomam", Code = "125014" },
                    new Framework.StorageModels.City { Name = "رشت", NameEn = "Rasht", Code = "125015" },
                    new Framework.StorageModels.City { Name = "سنگر", NameEn = "Sangar", Code = "125016" },
                    new Framework.StorageModels.City { Name = "کوچصفهان", NameEn = "Koochesfehan", Code = "125017" },
                    new Framework.StorageModels.City { Name = "لشت نشا", NameEn = "Lashtnesha", Code = "125018" },
                    new Framework.StorageModels.City { Name = "لولمان", NameEn = "Looleman", Code = "125019" },
                    new Framework.StorageModels.City { Name = "پره سر", NameEn = "Parehsar", Code = "125020" },
                    new Framework.StorageModels.City { Name = "رضوانشهر", NameEn = "Rezvanshahr", Code = "125021" },
                    new Framework.StorageModels.City { Name = "بره سر", NameEn = "Barehsar", Code = "125022" },
                    new Framework.StorageModels.City { Name = "توتکابن", NameEn = "Tootekabon", Code = "125023" },
                    new Framework.StorageModels.City { Name = "جیرنده", NameEn = "Jirandeh", Code = "125024" },
                    new Framework.StorageModels.City { Name = "رستم آباد", NameEn = "RostamAbad", Code = "125025" },
                    new Framework.StorageModels.City { Name = "رودبار", NameEn = "Roodbar", Code = "125026" },
                    new Framework.StorageModels.City { Name = "لوشان", NameEn = "Loshan", Code = "125027" },
                    new Framework.StorageModels.City { Name = "منجیل", NameEn = "Manjil", Code = "125028" },
                    new Framework.StorageModels.City { Name = "چابکسر", NameEn = "Chaboksar", Code = "125029" },
                    new Framework.StorageModels.City { Name = "رحیم آباد", NameEn = "RahimAbad", Code = "125030" },
                    new Framework.StorageModels.City { Name = "رودسر", NameEn = "Rodsar", Code = "125031" },
                    new Framework.StorageModels.City { Name = "کلاچای", NameEn = "Kalachay", Code = "125032" },
                    new Framework.StorageModels.City { Name = "واجارگاه", NameEn = "Vajargah", Code = "125033" },
                    new Framework.StorageModels.City { Name = "دیلمان", NameEn = "Deylaman", Code = "125034" },
                    new Framework.StorageModels.City { Name = "سیاهکل", NameEn = "Siahkal", Code = "125035" },
                    new Framework.StorageModels.City { Name = "احمدسرگوراب", NameEn = "AhmadSarGoorab", Code = "125036" },
                    new Framework.StorageModels.City { Name = "شفت", NameEn = "Shaft", Code = "125037" },
                    new Framework.StorageModels.City { Name = "صومعه سرا", NameEn = "Somesara", Code = "125038" },
                    new Framework.StorageModels.City { Name = "گوراب زرمیخ", NameEn = "Gorabzarmikh", Code = "125039" },
                    new Framework.StorageModels.City { Name = "مرجقل", NameEn = "Marjaghal", Code = "125040" },
                    new Framework.StorageModels.City { Name = "فومن", NameEn = "Fooman", Code = "125041" },
                    new Framework.StorageModels.City { Name = "ماسوله", NameEn = "Masooleh", Code = "125042" },
                    new Framework.StorageModels.City { Name = "رودبنه", NameEn = "Rodboneh", Code = "125043" },
                    new Framework.StorageModels.City { Name = "لاهیجان", NameEn = "Lahijan", Code = "125044" },
                    new Framework.StorageModels.City { Name = "اطاقور", NameEn = "Ataghor", Code = "125045" },
                    new Framework.StorageModels.City { Name = "چاف و چمخاله", NameEn = "Chaafchamkhale", Code = "125046" },
                    new Framework.StorageModels.City { Name = "شلمان", NameEn = "Shelman", Code = "125047" },
                    new Framework.StorageModels.City { Name = "کومله", NameEn = "Koomleh", Code = "125048" },
                    new Framework.StorageModels.City { Name = "لنگرود", NameEn = "Langerood", Code = "125049" },
                    new Framework.StorageModels.City { Name = "بازارجمعه", NameEn = "BazarJome", Code = "125050" },
                    new Framework.StorageModels.City { Name = "ماسال", NameEn = "Masal", Code = "125051" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "لرستان",
                Code = "LOR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ازنا", NameEn = "Azna", Code = "126001" },
                    new Framework.StorageModels.City { Name = "مومن آباد", NameEn = "MomenAbad", Code = "126002" },
                    new Framework.StorageModels.City { Name = "الیگودرز", NameEn = "Aligoodarz", Code = "126003" },
                    new Framework.StorageModels.City { Name = "شول آباد", NameEn = "SholAbad", Code = "126004" },
                    new Framework.StorageModels.City { Name = "اشترینان", NameEn = "Ashtarinan", Code = "126005" },
                    new Framework.StorageModels.City { Name = "بروجرد", NameEn = "Boroojerd", Code = "126006" },
                    new Framework.StorageModels.City { Name = "پلدختر", NameEn = "Poldokhtar", Code = "126007" },
                    new Framework.StorageModels.City { Name = "معمولان", NameEn = "Maemolan", Code = "126008" },
                    new Framework.StorageModels.City { Name = "چغلوندی", NameEn = "Chaghlondi", Code = "126009" },
                    new Framework.StorageModels.City { Name = "خرم آباد", NameEn = "KhoramAbad", Code = "126010" },
                    new Framework.StorageModels.City { Name = "زاغه", NameEn = "Zagheh", Code = "126011" },
                    new Framework.StorageModels.City { Name = "سپیددشت", NameEn = "SepidDasht", Code = "126012" },
                    new Framework.StorageModels.City { Name = "نورآباد", NameEn = "NoorAbad", Code = "126013" },
                    new Framework.StorageModels.City { Name = "هفت چشمه", NameEn = "Haftcheshmeh", Code = "126014" },
                    new Framework.StorageModels.City { Name = "سراب دوره", NameEn = "Sarabdoreh", Code = "126015" },
                    new Framework.StorageModels.City { Name = "ویسیان", NameEn = "Veysian", Code = "126016" },
                    new Framework.StorageModels.City { Name = "چالانچولان", NameEn = "Chalancholan", Code = "126017" },
                    new Framework.StorageModels.City { Name = "دورود", NameEn = "Dorood", Code = "126018" },
                    new Framework.StorageModels.City { Name = "الشتر", NameEn = "Alashtar", Code = "126019" },
                    new Framework.StorageModels.City { Name = "فیروزآباد", NameEn = "FiroozAbad", Code = "126020" },
                    new Framework.StorageModels.City { Name = "چقابل", NameEn = "Choghabel", Code = "126021" },
                    new Framework.StorageModels.City { Name = "درب گنبد", NameEn = "Darbgonbad", Code = "126022" },
                    new Framework.StorageModels.City { Name = "کونانی", NameEn = "Konani", Code = "126023" },
                    new Framework.StorageModels.City { Name = "کوهدشت", NameEn = "Koohdasht", Code = "126024" },
                    new Framework.StorageModels.City { Name = "گراب", NameEn = "Garab", Code = "126025" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "مازندران",
                Code = "MAZ",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "آمل", NameEn = "Amol", Code = "127001" },
                    new Framework.StorageModels.City { Name = "دابودشت", NameEn = "Dabodasht", Code = "127002" },
                    new Framework.StorageModels.City { Name = "رینه", NameEn = "Rineh", Code = "127003" },
                    new Framework.StorageModels.City { Name = "گزنک", NameEn = "Gaznak", Code = "127004" },
                    new Framework.StorageModels.City { Name = "امیرکلا", NameEn = "Amirkala", Code = "127005" },
                    new Framework.StorageModels.City { Name = "بابل", NameEn = "Babol", Code = "127006" },
                    new Framework.StorageModels.City { Name = "خوش رودپی", NameEn = "Khoshrodpey", Code = "127007" },
                    new Framework.StorageModels.City { Name = "زرگرمحله", NameEn = "Zargarmahaleh", Code = "127008" },
                    new Framework.StorageModels.City { Name = "گتاب", NameEn = "Gatab", Code = "127009" },
                    new Framework.StorageModels.City { Name = "گلوگاه", NameEn = "Galoogah", Code = "127010" },
                    new Framework.StorageModels.City { Name = "مرزیکلا", NameEn = "Marzikela", Code = "127011" },
                    new Framework.StorageModels.City { Name = "بابلسر", NameEn = "Babolsar", Code = "127012" },
                    new Framework.StorageModels.City { Name = "بهنمیر", NameEn = "Behnamir", Code = "127013" },
                    new Framework.StorageModels.City { Name = "کله بست", NameEn = "Kalebast", Code = "127014" },
                    new Framework.StorageModels.City { Name = "بهشهر", NameEn = "Behshahr", Code = "127015" },
                    new Framework.StorageModels.City { Name = "خلیل شهر", NameEn = "KhalilShahr", Code = "127016" },
                    new Framework.StorageModels.City { Name = "رستمکلا", NameEn = "Rostamkela", Code = "127017" },
                    new Framework.StorageModels.City { Name = "تنکابن", NameEn = "Tonekabon", Code = "127018" },
                    new Framework.StorageModels.City { Name = "خرم آباد", NameEn = "KhoramAbad", Code = "127019" },
                    new Framework.StorageModels.City { Name = "شیرود", NameEn = "Shirood", Code = "127020" },
                    new Framework.StorageModels.City { Name = "نشتارود", NameEn = "Nashtarood", Code = "127021" },
                    new Framework.StorageModels.City { Name = "جویبار", NameEn = "Jooybar", Code = "127022" },
                    new Framework.StorageModels.City { Name = "کوهی خیل", NameEn = "Kohikheyl", Code = "127023" },
                    new Framework.StorageModels.City { Name = "چالوس", NameEn = "Chaloos", Code = "127024" },
                    new Framework.StorageModels.City { Name = "کلاردشت", NameEn = "Kelardasht", Code = "127025" },
                    new Framework.StorageModels.City { Name = "مرزن آباد", NameEn = "MarzanAbad", Code = "127026" },
                    new Framework.StorageModels.City { Name = "رامسر", NameEn = "Ramsar", Code = "127027" },
                    new Framework.StorageModels.City { Name = "کتالم وسادات شهر", NameEn = "Katalom", Code = "127028" },
                    new Framework.StorageModels.City { Name = "ساری", NameEn = "Sari", Code = "127029" },
                    new Framework.StorageModels.City { Name = "فریم", NameEn = "Farim", Code = "127030" },
                    new Framework.StorageModels.City { Name = "کیاسر", NameEn = "Kiyasar", Code = "127031" },
                    new Framework.StorageModels.City { Name = "آلاشت", NameEn = "Alasht", Code = "127032" },
                    new Framework.StorageModels.City { Name = "پل سفید", NameEn = "Polsefid", Code = "127033" },
                    new Framework.StorageModels.City { Name = "زیرآب", NameEn = "Zirab", Code = "127034" },
                    new Framework.StorageModels.City { Name = "شیرگاه", NameEn = "Shirgah", Code = "127035" },
                    new Framework.StorageModels.City { Name = "سلمان شهر", NameEn = "SalmanShahr", Code = "127036" },
                    new Framework.StorageModels.City { Name = "عباس آباد", NameEn = "AbbasAbad", Code = "127037" },
                    new Framework.StorageModels.City { Name = "کلارآباد", NameEn = "KelarAbad", Code = "127038" },
                    new Framework.StorageModels.City { Name = "فریدونکنار", NameEn = "Fereidoonkenar", Code = "127039" },
                    new Framework.StorageModels.City { Name = "قائم شهر", NameEn = "GhaemShahr", Code = "127040" },
                    new Framework.StorageModels.City { Name = "کیاکلا", NameEn = "Kiakala", Code = "127041" },
                    new Framework.StorageModels.City { Name = "سرخرود", NameEn = "Sorkhrood", Code = "127042" },
                    new Framework.StorageModels.City { Name = "محمودآباد", NameEn = "MahmoodAbad", Code = "127043" },
                    new Framework.StorageModels.City { Name = "سورک", NameEn = "Sorak", Code = "127044" },
                    new Framework.StorageModels.City { Name = "نکا", NameEn = "Neka", Code = "127045" },
                    new Framework.StorageModels.City { Name = "ایزدشهر", NameEn = "IzadShahr", Code = "127046" },
                    new Framework.StorageModels.City { Name = "بلده", NameEn = "Baladeh", Code = "127047" },
                    new Framework.StorageModels.City { Name = "چمستان", NameEn = "Chamestan", Code = "127048" },
                    new Framework.StorageModels.City { Name = "رویان", NameEn = "Royan", Code = "127049" },
                    new Framework.StorageModels.City { Name = "نور", NameEn = "Noor", Code = "127050" },
                    new Framework.StorageModels.City { Name = "پول", NameEn = "Pul", Code = "127051" },
                    new Framework.StorageModels.City { Name = "نوشهر", NameEn = "Noshahr", Code = "127052" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "مرکزی",
                Code = "MAR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اراک", NameEn = "Arak", Code = "128001" },
                    new Framework.StorageModels.City { Name = "داودآباد", NameEn = "DavoodAbad", Code = "128002" },
                    new Framework.StorageModels.City { Name = "ساروق", NameEn = "Saroogh", Code = "128003" },
                    new Framework.StorageModels.City { Name = "سنجان", NameEn = "Senjan", Code = "128004" },
                    new Framework.StorageModels.City { Name = "کارچان", NameEn = "Karchan", Code = "128005" },
                    new Framework.StorageModels.City { Name = "کرهرود", NameEn = "Karahrood", Code = "128006" },
                    new Framework.StorageModels.City { Name = "آشتیان", NameEn = "Ashtian", Code = "128007" },
                    new Framework.StorageModels.City { Name = "تفرش", NameEn = "Tafresh", Code = "128008" },
                    new Framework.StorageModels.City { Name = "خمین", NameEn = "Khomein", Code = "128009" },
                    new Framework.StorageModels.City { Name = "قورچی باشی", NameEn = "Ghoorchebashi", Code = "128010" },
                    new Framework.StorageModels.City { Name = "جاورسیان", NameEn = "Javersian", Code = "128011" },
                    new Framework.StorageModels.City { Name = "خنداب", NameEn = "Khandab", Code = "128012" },
                    new Framework.StorageModels.City { Name = "دلیجان", NameEn = "Delijan", Code = "128013" },
                    new Framework.StorageModels.City { Name = "نراق", NameEn = "Naragh", Code = "128014" },
                    new Framework.StorageModels.City { Name = "پرندک[3]", NameEn = "Parandak", Code = "128015" },
                    new Framework.StorageModels.City { Name = "خشکرود", NameEn = "Khoshkrood", Code = "128016" },
                    new Framework.StorageModels.City { Name = "رازقان", NameEn = "Razeghan", Code = "128017" },
                    new Framework.StorageModels.City { Name = "زاویه", NameEn = "Zavieh", Code = "128018" },
                    new Framework.StorageModels.City { Name = "مامونیه", NameEn = "Mamoonieh", Code = "128019" },
                    new Framework.StorageModels.City { Name = "ساوه", NameEn = "Saveh", Code = "128020" },
                    new Framework.StorageModels.City { Name = "غرق آباد", NameEn = "GharghAbad", Code = "128021" },
                    new Framework.StorageModels.City { Name = "نوبران", NameEn = "Nobaran", Code = "128022" },
                    new Framework.StorageModels.City { Name = "آستانه سربند", NameEn = "Astanehsarband", Code = "128023" },
                    new Framework.StorageModels.City { Name = "توره", NameEn = "Toreh", Code = "128024" },
                    new Framework.StorageModels.City { Name = "شازند", NameEn = "Shazand", Code = "128025" },
                    new Framework.StorageModels.City { Name = "شهباز", NameEn = "Shahbaz", Code = "128026" },
                    new Framework.StorageModels.City { Name = "مهاجران", NameEn = "Mohajeran", Code = "128027" },
                    new Framework.StorageModels.City { Name = "هندودر", NameEn = "Hendodar", Code = "128028" },
                    new Framework.StorageModels.City { Name = "خنجین", NameEn = "Khenejin", Code = "128029" },
                    new Framework.StorageModels.City { Name = "فرمهین", NameEn = "Farmahin", Code = "128030" },
                    new Framework.StorageModels.City { Name = "کمیجان", NameEn = "Komijan", Code = "128031" },
                    new Framework.StorageModels.City { Name = "میلاجرد", NameEn = "Milajerd", Code = "128032" },
                    new Framework.StorageModels.City { Name = "محلات", NameEn = "Mahallat", Code = "128033" },
                    new Framework.StorageModels.City { Name = "نیمور", NameEn = "Nimoor", Code = "128034" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "هرمزگان",
                Code = "HOR",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ابوموسی", NameEn = "Aboomoosa", Code = "129001" },
                    new Framework.StorageModels.City { Name = "بستک", NameEn = "Bastak", Code = "129002" },
                    new Framework.StorageModels.City { Name = "جناح", NameEn = "Jenah", Code = "129003" },
                    new Framework.StorageModels.City { Name = "سردشت", NameEn = "Sardasht", Code = "129004" },
                    new Framework.StorageModels.City { Name = "گوهران", NameEn = "Goharan", Code = "129005" },
                    new Framework.StorageModels.City { Name = "بندرعباس", NameEn = "BandarAbas", Code = "129006" },
                    new Framework.StorageModels.City { Name = "تخت", NameEn = "Takht", Code = "129007" },
                    new Framework.StorageModels.City { Name = "فین", NameEn = "Fin", Code = "129008" },
                    new Framework.StorageModels.City { Name = "قلعه قاضی", NameEn = "Ghaleghazi", Code = "129009" },
                    new Framework.StorageModels.City { Name = "بندرلنگه", NameEn = "BandarLengeh", Code = "129010" },
                    new Framework.StorageModels.City { Name = "چارک", NameEn = "Charak", Code = "129011" },
                    new Framework.StorageModels.City { Name = "کنگ", NameEn = "Kong", Code = "129012" },
                    new Framework.StorageModels.City { Name = "کیش", NameEn = "Kish", Code = "129013" },
                    new Framework.StorageModels.City { Name = "پارسیان", NameEn = "Parsian", Code = "129014" },
                    new Framework.StorageModels.City { Name = "کوشکنار", NameEn = "Kushkenar", Code = "129015" },
                    new Framework.StorageModels.City { Name = "بندرجاسک", NameEn = "BandarJask", Code = "129016" },
                    new Framework.StorageModels.City { Name = "فارغان", NameEn = "Farghan", Code = "129017" },
                    new Framework.StorageModels.City { Name = "حاجی آباد", NameEn = "HajiAbad", Code = "129018" },
                    new Framework.StorageModels.City { Name = "سرگز", NameEn = "Sargaz", Code = "129019" },
                    new Framework.StorageModels.City { Name = "خمیر", NameEn = "Khomeyr", Code = "129020" },
                    new Framework.StorageModels.City { Name = "رویدر", NameEn = "Rooydar", Code = "129021" },
                    new Framework.StorageModels.City { Name = "بیکا", NameEn = "Bika", Code = "129022" },
                    new Framework.StorageModels.City { Name = "دهبارز", NameEn = "Dehbarez", Code = "129023" },
                    new Framework.StorageModels.City { Name = "زیارتعلی", NameEn = "Ziyaratali", Code = "129024" },
                    new Framework.StorageModels.City { Name = "سیریک", NameEn = "Sirik", Code = "129025" },
                    new Framework.StorageModels.City { Name = "درگهان", NameEn = "Dargahan", Code = "129026" },
                    new Framework.StorageModels.City { Name = "سوزا", NameEn = "Sooza", Code = "129027" },
                    new Framework.StorageModels.City { Name = "قشم", NameEn = "Gheshm", Code = "129028" },
                    new Framework.StorageModels.City { Name = "هرمز", NameEn = "Hormoz", Code = "129029" },
                    new Framework.StorageModels.City { Name = "سندرک", NameEn = "Senderk", Code = "129030" },
                    new Framework.StorageModels.City { Name = "میناب", NameEn = "Minab", Code = "129031" },
                    new Framework.StorageModels.City { Name = "هشتبندی", NameEn = "Hashtbandi", Code = "129032" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "همدان",
                Code = "HAM",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "اسدآباد", NameEn = "AsadAbad", Code = "130001" },
                    new Framework.StorageModels.City { Name = "بهار", NameEn = "Bahar", Code = "130002" },
                    new Framework.StorageModels.City { Name = "صالح آباد", NameEn = "SalehAbad", Code = "130003" },
                    new Framework.StorageModels.City { Name = "لالجین", NameEn = "Laljin", Code = "130004" },
                    new Framework.StorageModels.City { Name = "تویسرکان", NameEn = "Tooyserkan", Code = "130005" },
                    new Framework.StorageModels.City { Name = "سرکان", NameEn = "Serkan", Code = "130006" },
                    new Framework.StorageModels.City { Name = "فرسفج", NameEn = "Faresfaj", Code = "130007" },
                    new Framework.StorageModels.City { Name = "دمق", NameEn = "Damagh", Code = "130008" },
                    new Framework.StorageModels.City { Name = "رزن", NameEn = "Razan", Code = "130009" },
                    new Framework.StorageModels.City { Name = "قروه درجزین", NameEn = "Gharvedarjazin", Code = "130010" },
                    new Framework.StorageModels.City { Name = "فامنین", NameEn = "Famenin", Code = "130011" },
                    new Framework.StorageModels.City { Name = "شیرین سو", NameEn = "Shirinso", Code = "130012" },
                    new Framework.StorageModels.City { Name = "کبودرآهنگ", NameEn = "Kabodarahang", Code = "130013" },
                    new Framework.StorageModels.City { Name = "گل تپه", NameEn = "Goltapeh", Code = "130014" },
                    new Framework.StorageModels.City { Name = "ازندریان", NameEn = "Azandaryan", Code = "130015" },
                    new Framework.StorageModels.City { Name = "جوکار", NameEn = "Jokar", Code = "130016" },
                    new Framework.StorageModels.City { Name = "زنگنه", NameEn = "Zanganeh", Code = "130017" },
                    new Framework.StorageModels.City { Name = "سامن", NameEn = "Samen", Code = "130018" },
                    new Framework.StorageModels.City { Name = "ملایر", NameEn = "Malayer", Code = "130019" },
                    new Framework.StorageModels.City { Name = "برزول", NameEn = "Barzool", Code = "130020" },
                    new Framework.StorageModels.City { Name = "فیروزان", NameEn = "Firoozan", Code = "130021" },
                    new Framework.StorageModels.City { Name = "گیان", NameEn = "Giyan", Code = "130022" },
                    new Framework.StorageModels.City { Name = "نهاوند", NameEn = "Nahavand", Code = "130023" },
                    new Framework.StorageModels.City { Name = "جورقان", NameEn = "Jorghan", Code = "130024" },
                    new Framework.StorageModels.City { Name = "قهاوند", NameEn = "Ghahavand", Code = "130025" },
                    new Framework.StorageModels.City { Name = "مریانج", NameEn = "Meryanj", Code = "130026" },
                    new Framework.StorageModels.City { Name = "همدان", NameEn = "Hamedan", Code = "130027" }
                }
            },
            new Framework.StorageModels.State
            {
                Name = "یزد",
                Code = "YAZ",
                Cities = new List<Framework.StorageModels.City>
                {
                    new Framework.StorageModels.City { Name = "ابرکوه", NameEn = "Abarkooh", Code = "131001" },
                    new Framework.StorageModels.City { Name = "مهردشت", NameEn = "Mehrdasht", Code = "131002" },
                    new Framework.StorageModels.City { Name = "احمدآباد", NameEn = "AhmadAbad", Code = "131003" },
                    new Framework.StorageModels.City { Name = "اردکان", NameEn = "Ardakan", Code = "131004" },
                    new Framework.StorageModels.City { Name = "عقدا", NameEn = "Aghda", Code = "131005" },
                    new Framework.StorageModels.City { Name = "بافق", NameEn = "Bafgh", Code = "131006" },
                    new Framework.StorageModels.City { Name = "بهاباد", NameEn = "BehAbad", Code = "131007" },
                    new Framework.StorageModels.City { Name = "تفت", NameEn = "Taft", Code = "131008" },
                    new Framework.StorageModels.City { Name = "نیر", NameEn = "Nayer", Code = "131009" },
                    new Framework.StorageModels.City { Name = "مروست", NameEn = "Marvast", Code = "131010" },
                    new Framework.StorageModels.City { Name = "هرات", NameEn = "Harat", Code = "131011" },
                    new Framework.StorageModels.City { Name = "اشکذر", NameEn = "Ashkezar", Code = "131012" },
                    new Framework.StorageModels.City { Name = "خضرآباد", NameEn = "KhezrAbad", Code = "131013" },
                    new Framework.StorageModels.City { Name = "ندوشن", NameEn = "Nadoshan", Code = "131014" },
                    new Framework.StorageModels.City { Name = "مهریز", NameEn = "Mehriz", Code = "131018" },
                    new Framework.StorageModels.City { Name = "بفروییه", NameEn = "Bafrooeeyeh", Code = "131019" },
                    new Framework.StorageModels.City { Name = "میبد", NameEn = "Meibod", Code = "131020" },
                    new Framework.StorageModels.City { Name = "حمیدیا", NameEn = "Hamidia", Code = "131021" },
                    new Framework.StorageModels.City { Name = "زارچ", NameEn = "Zarch", Code = "131022" },
                    new Framework.StorageModels.City { Name = "شاهدیه", NameEn = "Shahedie", Code = "131023" },
                    new Framework.StorageModels.City { Name = "یزد", NameEn = "Yazd", Code = "131024" }
                }
            }
        });

            var cityAndStates = await dbContext.SaveChangesAsync();
            return cityAndStates;
        }

        #region temp

        public class JobModel
        {
            [CellIndex(0)]
            public string Code { get; set; }

            [CellIndex(1)]
            public string Title { get; set; }

            [CellIndex(2)]
            public string SubTitle { get; set; }

            [CellIndex(3)]
            public string SubCode { get; set; }
        }

        #endregion

        private async Task<int> AddBanksAsync()
        {
            await dbContext.Banks.AddRangeAsync(new List<Framework.StorageModels.Bank>
        {
            new Framework.StorageModels.Bank { Name = "استاندارد چارترد",Code="", LogoURL = "/files/bankicons/استاندارد-چارترد.png" },
            new Framework.StorageModels.Bank { Name = "بانک آینده",Code="AYN", LogoURL = "/files/bankicons/بانک-آینده.png" },
            new Framework.StorageModels.Bank { Name = "بانک اقتصادنوین",Code="ENB", LogoURL = "/files/bankicons/بانک-اقتصادنوین.png" },
            new Framework.StorageModels.Bank { Name = "بانک ایران زمین",Code="IRZ", LogoURL = "/files/bankicons/بانک-ایران-زمین.png" },
            new Framework.StorageModels.Bank { Name = "بانک پارسیان",Code="PAR", LogoURL = "/files/bankicons/بانک-پارسیان.png" },
            new Framework.StorageModels.Bank { Name = "بانک پاسارگاد",Code="PAS", LogoURL = "/files/bankicons/بانک-پاسارگاد.png" },
            new Framework.StorageModels.Bank { Name = "بانک تجارت",Code="TEJ", LogoURL = "/files/bankicons/بانک-تجارت.png" },
            new Framework.StorageModels.Bank { Name = "بانک تجارتی ایران و اروپا",Code="", LogoURL = "/files/bankicons/بانک-تجارتی-ایران-و-اروپا.png" },
            new Framework.StorageModels.Bank { Name = "بانک توسعه تعاون",Code="BTT", LogoURL = "/files/bankicons/بانک-توسعه-تعاون.png" },
            new Framework.StorageModels.Bank { Name = "بانک توسعه صادرات ایران",Code="BTS", LogoURL = "/files/bankicons/بانک-توسعه-صادرات-ایران.png" },
            new Framework.StorageModels.Bank { Name = "بانک خاورمیانه",Code="KHM", LogoURL = "/files/bankicons/بانک-خاورمیانه.png" },
            new Framework.StorageModels.Bank { Name = "بانک دی",Code="DEY", LogoURL = "/files/bankicons/بانک-دی.png" },
            new Framework.StorageModels.Bank { Name = "بانک رفاه کارگران",Code="REF", LogoURL = "/files/bankicons/بانک-رفاه-کارگران.png" },
            new Framework.StorageModels.Bank { Name = "بانک سامان",Code="SAM", LogoURL = "/files/bankicons/بانک-سامان.png" },
            new Framework.StorageModels.Bank { Name = "بانک سپه",Code="BSP", LogoURL = "/files/bankicons/بانک-سپه.png" },
            new Framework.StorageModels.Bank { Name = "بانک سرمایه",Code="SAR", LogoURL = "/files/bankicons/بانک-سرمایه.png" },
            new Framework.StorageModels.Bank { Name = "بانک سینا",Code="SIN", LogoURL = "/files/bankicons/بانک-سینا.png" },
            new Framework.StorageModels.Bank { Name = "بانک شهر",Code="SHR", LogoURL = "/files/bankicons/بانک-شهر.png" },
            new Framework.StorageModels.Bank { Name = "بانک صادرات ایران",Code="BSI", LogoURL = "/files/bankicons/بانک-صادرات-ایران.png" },
            new Framework.StorageModels.Bank { Name = "بانک صنعت و معدن",Code="BSM", LogoURL = "/files/bankicons/بانک-صنعت-و-معدن.png" },
            new Framework.StorageModels.Bank { Name = "بانک قرض‌الحسنه رسالت",Code="RES", LogoURL = "/files/bankicons/بانک-قرض‌الحسنه-رسالت.png" },
            new Framework.StorageModels.Bank { Name = "بانک قرض‌الحسنه مهر ایران",Code="MHR", LogoURL = "/files/bankicons/بانک-قرض‌الحسنه-مهر-ایران.png" },
            new Framework.StorageModels.Bank { Name = "بانک گردشگری",Code="GAR", LogoURL = "/files/bankicons/بانک-گردشگری.png" },
            new Framework.StorageModels.Bank { Name = "بانک مسکن",Code="BMK", LogoURL = "/files/bankicons/بانک-مسکن.png" },
            new Framework.StorageModels.Bank { Name = "بانک مشترک ایران - ونزوئلا",Code="", LogoURL = "/files/bankicons/بانک-مشترک-ایران---ونزوئلا.png" },
            new Framework.StorageModels.Bank { Name = "بانک ملت",Code="MEL", LogoURL = "/files/bankicons/بانک-ملت.png" },
            new Framework.StorageModels.Bank { Name = "بانک ملی ایران",Code="BMI", LogoURL = "/files/bankicons/بانک-ملی-ایران.png" },
            new Framework.StorageModels.Bank { Name = "بانک کارآفرین",Code="BKA", LogoURL = "/files/bankicons/بانک-کارآفرین.png" },
            new Framework.StorageModels.Bank { Name = "بانک کشاورزی",Code="BKV", LogoURL = "/files/bankicons/بانک-کشاورزی.png" },
            new Framework.StorageModels.Bank { Name = "پست بانک ایران",Code="PST", LogoURL = "/files/bankicons/پست-بانک-ایران.png" },
            new Framework.StorageModels.Bank { Name = "تعاون اسلامی برای سرمایه‌گذاری (مصرف التعاون الاسلامی للاستثمار)",Code="", LogoURL = "/files/bankicons/تعاون-اسلامی-برای-سرمایه‌گذاری-(مصرف-التعاون-الاسلامی-للاستثمار).png" },
            new Framework.StorageModels.Bank { Name = "فیوچر بانک (المستقبل)",Code="", LogoURL = "/files/bankicons/فیوچر-بانک-(المستقبل).png" },
            new Framework.StorageModels.Bank { Name = "مؤسسه اعتباری غیربانکی كاسپین",Code="", LogoURL = "/files/bankicons/مؤسسه-اعتباری-غیربانکی-كاسپین.png" },
            new Framework.StorageModels.Bank { Name = "مؤسسه اعتباری غیربانکی توسعه",Code="MET", LogoURL = "/files/bankicons/مؤسسه-اعتباری-غیربانکی-توسعه.png" },
            new Framework.StorageModels.Bank { Name = "مؤسسه اعتباری غیربانکی ملل",Code="", LogoURL = "/files/bankicons/مؤسسه-اعتباری-غیربانکی-ملل.png" },
            new Framework.StorageModels.Bank { Name = "موسسه اعتباری غیربانکی نور",Code="NOR", LogoURL = "/files/bankicons/موسسه-اعتباری-غیربانکی-نور.png" }
        });

            var banksAdded = await dbContext.SaveChangesAsync();
            return banksAdded;
        }
    }
}