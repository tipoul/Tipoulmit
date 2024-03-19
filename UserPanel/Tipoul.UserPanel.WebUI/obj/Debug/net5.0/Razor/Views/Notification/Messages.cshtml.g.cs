#pragma checksum "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5acee0fa3e5114f5a73159887cb70b820280374e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_Messages), @"mvc.1.0.view", @"/Views/Notification/Messages.cshtml")]
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
#line 1 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.UserPanel.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.DataAccessLayer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5acee0fa3e5114f5a73159887cb70b820280374e", @"/Views/Notification/Messages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"148aecc430d0bccfd8f864ae8304f80dce560227", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Notification_Messages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tipoul.Framework.StorageModels.Notification>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
      
    Model.Add(new Tipoul.Framework.StorageModels.Notification
            {
                Description = "توضیحات تست برای پیام از اپراتور به کاربر",
                Link = "#",
                Title = "عنوان تست برای پیام",
                Priority = Tipoul.Framework.StorageModels.Notification.PriorityType.Medium
            });

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content  d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <!--begin::Entry-->
    <div class=""d-flex flex-column-fluid"">
        <!--begin::Container-->
        <div class="" container "">
            <!--begin::صندوق ورودی-->
            <div class=""d-flex flex-row"">

                ");
#nullable restore
#line 21 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
           Write(await Html.PartialAsync("_SideBar"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                <!--begin::لیست-->
                <div class=""flex-row-fluid ml-lg-8 d-block"" id=""kt_صندوق ورودی_list"">
                    <!--begin::Card-->
                    <div class=""card card-custom card-stretch"">
                        <!--begin::Body-->
                        <div class=""card-body table-responsive px-0"">
                            <!--begin::Items-->
                            <div class=""list list-hover min-w-500px"" data-صندوق="""" ورودی=""list"">
");
#nullable restore
#line 31 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""d-flex align-items-start list-item card-spacer-x py-3"" data-صندوق="""" ورودی=""message"">
                                        <div class=""d-flex align-items-center"">
                                            <div class=""d-flex align-items-center flex-wrap w-xxl-200px mr-3"" data-toggle=""view"">
                                                <span class=""symbol symbol-35 mr-3"">
                                                    <span class=""symbol-label"" style=""background-image: url('assets/media/users/100_13.jpg')""></span>
                                                </span>
                                                <a href=""#"" class=""font-weight-bold text-dark-75 text-hover-primary"">محسن پیربادی</a>
                                            </div>
                                        </div>
                                        <div class=""flex-grow-1 mt-2 mr-2"" data-toggle=""view"">
                                            <div>
 ");
            WriteLiteral("                                               <span class=\"font-weight-bolder font-size-lg mr-2\">");
#nullable restore
#line 44 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                                                                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                <span class=\"text-muted\">");
#nullable restore
#line 45 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n                                            <div class=\"mt-2\">\r\n                                                <span");
            BeginWriteAttribute("class", " class=\"", 2764, "\"", 3020, 6);
            WriteAttributeValue("", 2772, "label", 2772, 5, true);
            WriteAttributeValue(" ", 2777, "label-light-", 2778, 13, true);
#nullable restore
#line 48 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
WriteAttributeValue("", 2790, item.Priority == Tipoul.Framework.StorageModels.Notification.PriorityType.Low ? "info" : item.Priority == Tipoul.Framework.StorageModels.Notification.PriorityType.Medium ? "warning" : "danger", 2790, 195, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2985, "font-weight-bold", 2986, 17, true);
            WriteAttributeValue(" ", 3002, "label-inline", 3003, 13, true);
            WriteAttributeValue(" ", 3015, "mr-1", 3016, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    ");
#nullable restore
#line 49 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                                Write(item.Priority == Tipoul.Framework.StorageModels.Notification.PriorityType.Low ? "اولویت پایین" : item.Priority == Tipoul.Framework.StorageModels.Notification.PriorityType.Medium ? "اولویت متوسط" : "اولویت بالا");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </span>
                                            </div>
                                        </div>
                                        <div class=""mt-2 mr-3 font-weight-bolder w-150px text-right date-container"" data-toggle=""view"">");
#nullable restore
#line 53 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                                                                                                                  Write(Tipoul.Framework.Utilities.Converters.DateConverter.ToShamsy(item.CreateDate, true));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                    </div>\r\n");
#nullable restore
#line 55 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Notification\Messages.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <!--end::Items-->
                        </div>
                        <!--end::Body-->
                    </div>
                    <!--end::Card-->
                </div>
                <!--end::لیست-->
            </div>
            <!--end::صندوق ورودی-->
        </div>
        <!--end::Container-->
    </div>
    <!--end::Entry-->
</div>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tipoul.Framework.StorageModels.Notification>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
