#pragma checksum "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Notification\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec91b3bb669a8be3aa9090cf621744f9e4182096"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_Index), @"mvc.1.0.view", @"/Views/Notification/Index.cshtml")]
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
#line 1 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.AdminPanel.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.Utilities.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.Utilities.Converters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec91b3bb669a8be3aa9090cf621744f9e4182096", @"/Views/Notification/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5712d1f4212e130db5d8d7b5aa52ef3ba9610af6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Notification_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tipoul.AdminPanel.WebUI.Models.Notification.NotificationListViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Notification\Index.cshtml"
Write(await Html.PartialAsync("builder/list", Model));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tipoul.AdminPanel.WebUI.Models.Notification.NotificationListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
