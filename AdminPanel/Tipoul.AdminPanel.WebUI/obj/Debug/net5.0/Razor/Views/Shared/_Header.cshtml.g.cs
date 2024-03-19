#pragma checksum "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d39a5b3d39581edda9479e66df4967de5439f434"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Header), @"mvc.1.0.view", @"/Views/Shared/_Header.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.AdminPanel.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.Utilities.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.Utilities.Converters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d39a5b3d39581edda9479e66df4967de5439f434", @"/Views/Shared/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5712d1f4212e130db5d8d7b5aa52ef3ba9610af6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!--begin::Header-->
<div id=""kt_header"" class=""header  header-fixed "">
    <!--begin::Header Wrapper-->
    <div class=""header-wrapper rounded-top-xl d-flex flex-grow-1 align-items-center"">
        <!--begin::Container-->
        <div class="" container-fluid  d-flex align-items-center justify-content-end justify-content-lg-between flex-wrap"">
            <!--begin::Menu Wrapper-->
            <div class=""header-menu-wrapper header-menu-wrapper-left"" id=""kt_header_menu_wrapper"">
                <!--begin::Menu-->
                <div id=""kt_header_menu"" class=""header-menu header-menu-mobile  header-menu-layout-default "">
                    <!--begin::Nav-->
                    <ul class=""menu-nav "">

                        ");
#nullable restore
#line 16 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("درگاه های تجاری", new List<SubMenu> {
                        new SubMenu { Title = "افزودن درگاه", Link = "/CommertialGateWay/form" },
                        new SubMenu { Title = "مشاهده درگاه ها", Link = "/CommertialGateWay" },
                        new SubMenu { Title = "مشاهده گزارشات درگاه ها", Link = "/CommertialGateWay/report" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 22 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("تیکت ها", new List<SubMenu> {
                        new SubMenu { Title = "افزودن تیکت", Link = "/Ticket/form" },
                        new SubMenu { Title = "مشاهده تیکت ها", Link = "/Ticket" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 27 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("حساب های بانکی", new List<SubMenu> {
                        new SubMenu { Title = "افزودن حساب بانکی", Link = "/BankAccount/form" },
                        new SubMenu { Title = "مشاهده حساب های بانکی", Link = "/BankAccount" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 32 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("پیام ها و اطلاعیه ها", new List<SubMenu> {
                        new SubMenu { Title = "افزودن پیام و اطلاعیه", Link = "/Notification/form" },
                        new SubMenu { Title = "مشاهده پیام ها و اطلاعیه ها", Link = "/Notification" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 37 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("مدیریت کاربران", new List<SubMenu> {
                        new SubMenu { Title = "افزودن کاربر", Link = "/User/form" },
                        new SubMenu { Title = "مشاهده کاربران", Link = "/User" },
                        new SubMenu { Title = "مشاهده گزارشات کاربران", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 43 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("احراز هویت", new List<SubMenu> {
                        //new SubMenu { Title = "افزودن مدارک", Link = "/Verification/Form" },
                        new SubMenu { Title = "مشاهده احراز هویت ها", Link = "/Verification" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 48 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("پروفایل ها", new List<SubMenu> {
                        new SubMenu { Title = "مشاهده پروفایل ها", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 52 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("تراکنش ها", new List<SubMenu> {
                        new SubMenu { Title = "مشاهده تراکنش ها", Link = "/" },
                        new SubMenu { Title = "مشاهده گزارشات تراکنش ها", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 56 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("تسویه ها", new List<SubMenu> {
                        new SubMenu { Title = "مشاهده تسویه ها", Link = "/Settlement/Settlements" },
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                         ");
#nullable restore
#line 59 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                    Write(CreateMenu("درخواست های واریز", new List<SubMenu> {
                        new SubMenu { Title = "مشاهده درخواست های واریز", Link = "/WalletDepositRequest/WalletDepositRequests" },
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 62 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("اپراتور ها", new List<SubMenu> {
                        new SubMenu { Title = "افزودن اپراتور", Link = "/" },
                        new SubMenu { Title = "مشاهده اپراتور ها", Link = "/" },
                        new SubMenu { Title = "مشاهده گزارشات اپراتور ها", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 68 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("مدیریت کارمزد ها", new List<SubMenu> {
                        new SubMenu { Title = "افزودن بسته", Link = "/" },
                        new SubMenu { Title = "مشاهده بسته ها", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 73 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
                   Write(CreateMenu("تخفیف", new List<SubMenu> {
                        new SubMenu { Title = "افزودن تخفیف", Link = "/" },
                        new SubMenu { Title = "مشاهده تخفیف ها", Link = "/" }
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </ul>
                    <!--end::Nav-->
                </div>
                <!--end::Menu-->
            </div>
            <!--end::Menu Wrapper-->
        </div>
        <!--end::Container-->
    </div>
    <!--end::Header Wrapper-->
</div>
<!--end::Header-->
");
        }
        #pragma warning restore 1998
#nullable restore
#line 90 "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Header.cshtml"
            
    private HtmlString CreateMenu(string title, List<SubMenu> subMenus)
    {
        var html =
        "<li class='menu-item  menu-item-submenu menu-item-rel' data-menu-toggle='click' aria-haspopup='true'>" +
        "	<a href='javascript:;' class='menu-link menu-toggle'>" +
        $"		<span class='menu-text'>{title}</span><i class='menu-arrow'></i>" +
        "	</a>" +
        "	<div class='menu-submenu menu-submenu-classic menu-submenu-left'>" +
        "		<ul class='menu-subnav'>" +
        $"			{string.Concat(subMenus.Select(subMenu => CreateSubMenu(subMenu)))}" +
        "		</ul>" +
        "	</div>" +
        "</li>";

        return new HtmlString(html);

        static string CreateSubMenu(SubMenu subMenu)
        {
            return
            "<li class='menu-item' aria-haspopup='true'>" +
            $"	<a href='{subMenu.Link}' class='menu-link'>" +
            $"		<span class='menu-text'>{subMenu.Title}</span><span class='menu-desc'></span>" +
            "	</a>" +
            "</li>";
        }
    }

    public class SubMenu
    {
        public string Title { get; set; }

        public string Link { get; set; }
    }

#line default
#line hidden
#nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591