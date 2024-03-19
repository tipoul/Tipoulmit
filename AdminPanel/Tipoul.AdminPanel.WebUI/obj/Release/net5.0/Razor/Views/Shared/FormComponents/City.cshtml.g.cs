#pragma checksum "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6a902c973601c3342f5c0d5811834cb2c9ae3a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_FormComponents_City), @"mvc.1.0.view", @"/Views/Shared/FormComponents/City.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6a902c973601c3342f5c0d5811834cb2c9ae3a2", @"/Views/Shared/FormComponents/City.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5712d1f4212e130db5d8d7b5aa52ef3ba9610af6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_FormComponents_City : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
  
    var id = new Random().Next(10, 1000);

    var selectedStateId = Model == "0" ? 0 : await dbContext.Cities.Where(f => f.Id.ToString() == Model).Select(f => f.StateId).FirstOrDefaultAsync();

    var name = ViewBag.PropertyName ?? "CityId";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <select class=\"selectpicker w-100\"");
            BeginWriteAttribute("onchange", " onchange=\"", 440, "\"", 480, 1);
#nullable restore
#line 15 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
WriteAttributeValue("", 451, "stateChanged" + id + "()", 451, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 481, "\"", 495, 2);
            WriteAttributeValue("", 486, "state-", 486, 6, true);
#nullable restore
#line 15 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
WriteAttributeValue("", 492, id, 492, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-live-search=\"true\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a25912", async() => {
                WriteLiteral("انتخاب کنید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 16 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
AddHtmlAttributeValue("", 571, selectedStateId == 0, 571, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
             foreach (var state in await dbContext.States.ToListAsync())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a28177", async() => {
#nullable restore
#line 19 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                                                                               Write(state.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                   WriteLiteral(state.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
AddHtmlAttributeValue("", 759, state.Id == selectedStateId, 759, 30, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </div>\r\n    <div class=\"col-6\">\r\n        <select class=\"selectpicker w-100\"");
            BeginWriteAttribute("name", " name=\"", 926, "\"", 938, 1);
#nullable restore
#line 24 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
WriteAttributeValue("", 933, name, 933, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 939, "\"", 952, 2);
            WriteAttributeValue("", 944, "city-", 944, 5, true);
#nullable restore
#line 24 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
WriteAttributeValue("", 949, id, 949, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required data-live-search=\"true\">\r\n");
#nullable restore
#line 25 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
             if (selectedStateId == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a211905", async() => {
                WriteLiteral("ابتدا استان را انتخاب کنید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a213974", async() => {
                WriteLiteral("انتخاب کنید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                foreach (var city in await dbContext.Cities.Where(f => f.StateId == selectedStateId).ToListAsync())
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a215809", async() => {
#nullable restore
#line 34 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                                                                                  Write(city.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                       WriteLiteral(city.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 34 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
AddHtmlAttributeValue("", 1435, city.Id.ToString() == Model, 1435, 30, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </div>\r\n</div>\r\n\r\n<div");
            BeginWriteAttribute("id", " id=\"", 1567, "\"", 1587, 2);
            WriteAttributeValue("", 1572, "all-options-", 1572, 12, true);
#nullable restore
#line 41 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
WriteAttributeValue("", 1584, id, 1584, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display: none;\">\r\n");
#nullable restore
#line 42 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
     foreach (var city in await dbContext.Cities.ToListAsync())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span data-state-id=\"");
#nullable restore
#line 44 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                        Write(city.StateId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6a902c973601c3342f5c0d5811834cb2c9ae3a219465", async() => {
#nullable restore
#line 44 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                                                                Write(city.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                                               WriteLiteral(city.Id);

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
            WriteLiteral("</span>\r\n");
#nullable restore
#line 45 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<script>\r\n    window[\'stateChanged");
#nullable restore
#line 49 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                    Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'] = function() {\r\n        var stateId = $(\"#state-");
#nullable restore
#line 50 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                           Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").val();\r\n        var cityOptions = \"<option value=\'\' disabled selected>انتخاب کنید</option>\";\r\n        $(\"#all-options-");
#nullable restore
#line 52 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
                   Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").find(\"span\").each(function() {\r\n            if($(this).data(\"state-id\") == stateId)\r\n            cityOptions += $(this).html();\r\n        });\r\n        $(\"#city-");
#nullable restore
#line 56 "C:\Projects\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\FormComponents\City.cshtml"
            Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").html(cityOptions).selectpicker(\'refresh\');\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Tipoul.Framework.DataAccessLayer.TipoulFrameworkDbContext dbContext { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591