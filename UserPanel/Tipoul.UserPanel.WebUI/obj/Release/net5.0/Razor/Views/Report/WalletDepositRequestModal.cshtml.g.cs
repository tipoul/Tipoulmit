#pragma checksum "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75a7fec985249a45f801af57bb18aecdf05bdc0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_WalletDepositRequestModal), @"mvc.1.0.view", @"/Views/Report/WalletDepositRequestModal.cshtml")]
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
#line 1 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.UserPanel.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\_ViewImports.cshtml"
using Tipoul.Framework.DataAccessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
using Tipoul.Framework.Utilities.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
using static Tipoul.Framework.Utilities.Extentions.DataTableExtentionMethods;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a7fec985249a45f801af57bb18aecdf05bdc0d", @"/Views/Report/WalletDepositRequestModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"148aecc430d0bccfd8f864ae8304f80dce560227", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Report_WalletDepositRequestModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<input hidden name=\"walletId\" id=\"walletId\"");
            BeginWriteAttribute("value", " value=\"", 238, "\"", 252, 1);
#nullable restore
#line 6 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
WriteAttributeValue("", 246, Model, 246, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<div class=\"row\">\r\n\t<div class=\"col-md-6\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>مبلغ:</label>\r\n\t\t\t<input type=\"number\" class=\"form-control\" name=\"amount\"");
            BeginWriteAttribute("value", " value=\"", 418, "\"", 426, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"col-md-6\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>کد رهگیری:</label>\r\n\t\t\t<input type=\"text\" class=\"form-control\" name=\"transactionTrace\"");
            BeginWriteAttribute("value", " value=\"", 603, "\"", 611, 0);
            EndWriteAttribute();
            WriteLiteral(@">
		</div>
	</div>
</div>
<div class=""row"">
	<div class=""col-md-6"">
		<div class=""form-group mb-2"">
			<label>حساب مبدا (شبا):</label>
			<div class=""row"">
				<input type=""text"" class=""form-control p-2 m-0"" name=""sourceIban"" value=""IR"" maxlength=""26"" style=""text-align:left;"">
			</div>
		</div>
	</div>
	<div class=""col-md-6"">
		<div class=""form-group mb-2"">
			<label>حساب مقصد (شبا):</label>
			<div class=""row"">
				<input type=""text"" class=""form-control p-2 m-0"" name=""destIban"" value=""IR"" maxlength=""26"" style=""text-align:left;"">
			</div>
		</div>
	</div>
</div>
<div class=""row"">
	<div class=""col-md-6"">
		<div class=""form-group mb-2"">
			<label for=""depositType"">نوع واریز</label>
			<select class=""form-control"" name=""depositType"">
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75a7fec985249a45f801af57bb18aecdf05bdc0d6532", async() => {
                WriteLiteral("انتخاب کنید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
                 foreach (System.Data.DataRow item in new TransferTypeEnum().ToDataTable().Rows)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75a7fec985249a45f801af57bb18aecdf05bdc0d8018", async() => {
#nullable restore
#line 47 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
                                            Write(item["Value"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
                       WriteLiteral(item["Key"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Projects\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Report\WalletDepositRequestModal.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</select>\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"col-md-6\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>تاریخ واریز:</label>\r\n\t\t\t<input type=\"text\" class=\"form-control\" name=\"transactionDate\"");
            BeginWriteAttribute("value", " value=\"", 1772, "\"", 1780, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<div class=\"row\">\r\n\t<div class=\"col-md-6\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>نام و نام خانوادگی واریز کننده:</label>\r\n\t\t\t<input type=\"text\" class=\"form-control\" name=\"depositerName\"");
            BeginWriteAttribute("value", " value=\"", 2002, "\"", 2010, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"col-md-6\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>کد ملی واریز کننده:</label>\r\n\t\t\t<input type=\"text\" class=\"form-control\" name=\"depositerNationalCode\"");
            BeginWriteAttribute("value", " value=\"", 2201, "\"", 2209, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<div class=\"row\">\r\n\t<div class=\"col-md-12\">\r\n\t\t<div class=\"form-group mb-2\">\r\n\t\t\t<label>توضیحات:</label>\r\n\t\t\t<textarea type=\"text\" class=\"form-control\" name=\"description\"");
            BeginWriteAttribute("value", " value=\"", 2410, "\"", 2418, 0);
            EndWriteAttribute();
            WriteLiteral(" rows=\"2\"></textarea>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<span class=\"text-danger\" style=\"text-align:right;width:100%;display:block;padding-top:10px\" id=\"lblError\"></span>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591