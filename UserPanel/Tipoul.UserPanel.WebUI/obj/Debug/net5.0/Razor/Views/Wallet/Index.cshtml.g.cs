#pragma checksum "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec6c5af785ebb8915399a5738a6963392555a3f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wallet_Index), @"mvc.1.0.view", @"/Views/Wallet/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec6c5af785ebb8915399a5738a6963392555a3f2", @"/Views/Wallet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"148aecc430d0bccfd8f864ae8304f80dce560227", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Wallet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tipoul.UserPanel.WebUI.Models.Wallet.WalletViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/WizardStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Tools.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("modal-content"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/wallet/AddSettlement"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("styles", async() => {
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec6c5af785ebb8915399a5738a6963392555a3f26416", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec6c5af785ebb8915399a5738a6963392555a3f27593", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"<div class=""content  d-flex flex-column flex-column-fluid"" id=""kt_content"">
	<!--begin::زیر هدر-->
	<div class=""subheader py-2 py-lg-4  subheader-transparent "" id=""kt_subheader"">
		<div class="" container  d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap"">
			<!--begin::جزئیات-->
			<div class=""d-flex align-items-center flex-wrap mr-2"">
				<!--begin::Title-->
				<h5 class=""text-dark font-weight-bold mt-2 mb-2 mr-5"">حساب تیپول</h5>
				<!--end::Title-->
				<!--begin::Separator-->
				<div class=""subheader-separator subheader-separator-ver mt-2 mb-2 mr-5 bg-gray-200""></div>
				<!--end::Separator-->
			</div>
			<!--end::جزئیات-->
		</div>
	</div>
	<!--end::زیر هدر-->
	<!--begin::Entry-->
	<div class=""d-flex flex-column-fluid"">
		<!--begin::Container-->
		<div class="" container "">
			<!--begin::Row-->
			<div class=""row"">
");
#nullable restore
#line 30 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                 foreach (var item in Model)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"					<div class=""col-xl-8 col-lg-8 col-md-8 col-sm-8"">
						<div class=""card card-custom gutter-b card-stretch"">
							<div class=""card-body pt-4"">
								<div class=""d-flex align-items-center mb-7"">
									<div class=""d-flex flex-column text-center"">
										<a href=""#"" class=""text-dark font-weight-bold text-hover-primary font-size-h4 mb-0"">");
#nullable restore
#line 37 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
									</div>
								</div>
								<div class=""mb-7"">
									<div class=""d-flex justify-content-between align-items-center"">
										<span class=""text-dark-75 font-weight-bolder mr-2"">موجودی:</span>
										<a href=""#"" class=""text-muted text-hover-primary"">");
#nullable restore
#line 43 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                     Write(item.Amount.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"d-flex justify-content-between align-items-cente my-5\">\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"text-dark-75 font-weight-bolder mr-2\">کارمزدها:</span>\r\n\t\t\t\t\t\t\t\t\t\t<a href=\"#\" class=\"text-muted text-hover-primary\">");
#nullable restore
#line 47 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                     Write(item.AmountWage.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"d-flex justify-content-between align-items-cente my-5\">\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"text-dark-75 font-weight-bolder mr-2\">موجودی قابل برداشت:</span>\r\n\t\t\t\t\t\t\t\t\t\t<a href=\"#\" class=\"text-muted text-hover-primary\">");
#nullable restore
#line 51 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                     Write(item.AmountInHand.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"d-flex justify-content-between align-items-cente my-5\">\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"text-dark-75 font-weight-bolder mr-2\">موجودی قابل تسویه:</span>\r\n\t\t\t\t\t\t\t\t\t\t<a href=\"#\" class=\"text-muted text-hover-primary\">");
#nullable restore
#line 55 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                     Write(item.AmountSettlementable.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"d-flex justify-content-between align-items-cente my-5\">\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"text-dark-75 font-weight-bolder mr-2\">موجودی حساب تیپول:</span>\r\n\t\t\t\t\t\t\t\t\t\t<a href=\"#\" class=\"text-muted text-hover-primary\">");
#nullable restore
#line 59 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                                                                     Write(item.AmountInTipoul.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-2 px-2\"><a");
            BeginWriteAttribute("href", " href=\"", 3034, "\"", 3079, 2);
            WriteAttributeValue("", 3041, "/report/transactions?walletId=", 3041, 30, true);
#nullable restore
#line 63 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 3071, item.Id, 3071, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-sm btn-light-info font-weight-bolder\">تراکنش ها</a></div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-2 px-2\"><a");
            BeginWriteAttribute("href", " href=\"", 3200, "\"", 3242, 2);
            WriteAttributeValue("", 3207, "/report/customers?walletId=", 3207, 27, true);
#nullable restore
#line 64 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 3234, item.Id, 3234, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-sm btn-light-info font-weight-bolder\">مشتریان</a></div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-2 px-2\"><a");
            BeginWriteAttribute("href", " href=\"", 3361, "\"", 3405, 2);
            WriteAttributeValue("", 3368, "/report/settlements?walletId=", 3368, 29, true);
#nullable restore
#line 65 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 3397, item.Id, 3397, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-sm btn-light-info font-weight-bolder\">تسویه ها</a></div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-3 px-2\"><a");
            BeginWriteAttribute("href", " href=\"", 3525, "\"", 3579, 2);
            WriteAttributeValue("", 3532, "/report/walletDepositRequests?walletId=", 3532, 39, true);
#nullable restore
#line 66 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 3571, item.Id, 3571, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-sm btn-light-info font-weight-bolder\">تاریخچه واریزها</a></div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-3 px-2\"><a");
            BeginWriteAttribute("href", " href=\"", 3706, "\"", 3749, 2);
            WriteAttributeValue("", 3713, "/commertialGateWay?walletId=", 3713, 28, true);
#nullable restore
#line 67 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 3741, item.Id, 3741, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-sm btn-light-info font-weight-bolder\">درگاه های متصل</a></div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"row mt-10\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-4 px-2 mb-3\"><a href=\"#\" data-toggle=\"modal\" data-target=\"#settlementModal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3989, "\"", 4030, 3);
            WriteAttributeValue("", 3999, "ShowSettlementModal(\'", 3999, 21, true);
#nullable restore
#line 70 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 4020, item.Id, 4020, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4028, "\')", 4028, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-light-success\">ثبت تسویه عادی</a></div>\r\n");
#nullable restore
#line 71 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
                                     if (ViewBag.QuickSettlement != null && ViewBag.QuickSettlement == true)
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<div class=\"col-4 px-2 mb-3\"><a href=\"#\" data-toggle=\"modal\" data-target=\"#quickSettlementModal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4299, "\"", 4345, 3);
            WriteAttributeValue("", 4309, "ShowQuickSettlementModal(\'", 4309, 26, true);
#nullable restore
#line 73 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
WriteAttributeValue("", 4335, item.Id, 4335, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4343, "\')", 4343, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-light-success\">ثبت تسویه سریع</a></div>\r\n");
#nullable restore
#line 74 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
									}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<!--end::Body-->\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<!--end:: Card-->\r\n\t\t\t\t\t</div>\r\n");
#nullable restore
#line 81 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wallet\Index.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			</div>
			<!--end::Row-->
		</div>
		<!--end::Container-->
	</div>
	<!--end::Entry-->
</div>

<!-- مودال-->
<div class=""modal fade"" id=""settlementModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
	<div class=""modal-dialog modal-dialog-centered"" role=""document"">
		");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec6c5af785ebb8915399a5738a6963392555a3f219488", async() => {
                WriteLiteral("\r\n\t\t\t<div class=\"modal-header\">درخواست تسویه عادی</div>\r\n\t\t\t<div class=\"modal-body\">\r\n");
                WriteLiteral(@"			</div>
			<div class=""modal-footer"">
				<button type=""button"" class=""btn btn-light-primary font-weight-bold"" data-dismiss=""modal"">بستن</button>
				<button type=""submit"" class=""btn btn-primary font-weight-bold settlement-submit-button"">ذخیره تغییرات</button>
			</div>
		");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
	</div>
</div>
<!-- مودال-->
<div class=""modal fade"" id=""quickSettlementModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
	<div class=""modal-dialog modal-dialog-centered"" role=""document"">
		<div class=""modal-content"">
			<div class=""modal-header"">درخواست تسویه سریع</div>
			<div class=""modal-body"">
				
			</div>
			<div class=""modal-footer"">
				<button type=""button"" class=""btn btn-light-primary font-weight-bold"" data-dismiss=""modal"">بستن</button>
			</div>
		</div>
	</div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
	<script>
		function ShowSettlementModal(walletId) {
			$.get(""/wallet/GetSettlementModal?walletId="" + walletId).then(function (response) {
				$(""#settlementModal"").find("".modal-body"").html(response);
				$(""input[name=amount]"").keyup(function () {
					var value = parseInt($(this).val());
					var maxValue = parseInt($(this).prop(""max""));
					if (value > maxValue) {
						$("".settlement-submit-button"").prop(""disabled"", true);
						$("".max-amount-error"").show();
					}
					else {
						$("".settlement-submit-button"").prop(""disabled"", false);
						$("".max-amount-error"").hide();
					}
				});
			});
		}
		function ShowQuickSettlementModal(walletId) {
			$(""#quickSettlementModal"").find("".modal-body"").html();
			$.get(""/wallet/GetQuickSettlementModal?walletId="" + walletId).then(function (response) {
				$(""#quickSettlementModal"").find("".modal-body"").html(response);
				$(""input[name=amount]"").keyup(function () {
					var value = parseInt($(this).val());
					var maxValue = parseInt(");
                WriteLiteral(@"$(this).prop(""max""));
					if (value > maxValue) {
						$("".settlement-submit-button"").prop(""disabled"", true);
						$("".max-amount-error"").show();
					}
					else {
						$("".settlement-submit-button"").prop(""disabled"", false);
						$("".max-amount-error"").hide();
					}
				});
			});
		}
		$('#quickSettlementModal').on('hidden.bs.modal', function (e) {
			$(""#quickSettlementModal"").find("".modal-body"").html('');
		})
	</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tipoul.UserPanel.WebUI.Models.Wallet.WalletViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
