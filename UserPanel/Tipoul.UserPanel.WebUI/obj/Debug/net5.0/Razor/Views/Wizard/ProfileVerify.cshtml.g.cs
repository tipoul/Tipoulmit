#pragma checksum "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e379df9ab6f9184f9a34250b8c10b7466a4d2dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wizard_ProfileVerify), @"mvc.1.0.view", @"/Views/Wizard/ProfileVerify.cshtml")]
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
#nullable restore
#line 1 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
using Tipoul.UserPanel.WebUI.Models.Wizard.Profile;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e379df9ab6f9184f9a34250b8c10b7466a4d2dc", @"/Views/Wizard/ProfileVerify.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"148aecc430d0bccfd8f864ae8304f80dce560227", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Wizard_ProfileVerify : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VerifyModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""content  d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <!--begin::Entry-->
    <div class=""d-flex flex-column-fluid"">
        <!--begin::Container-->
        <div class="" container "">
            <div class=""card card-custom"">
                <div class=""card-body p-0"">
                    <!--begin::ویزارد-->
                    <div class=""wizard wizard-1"" id=""kt_wizard_v1"" data-wizard-state=""first"" data-wizard-clickable=""false"">

                        ");
#nullable restore
#line 14 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                   Write(await Html.PartialAsync("_header"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <div class=\"wizard wizard-2\" id=\"kt_wizard_v2\" data-wizard-state=\"first\" data-wizard-clickable=\"false\">\r\n\r\n                        ");
#nullable restore
#line 19 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                   Write(await Html.PartialAsync("_profileSidebar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        <!--begin::ویزارد Body-->\r\n                        <div class=\"wizard-body py-8 px-8 py-lg-20 px-lg-10\">\r\n");
#nullable restore
#line 23 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                             if(Context.Request.Query["saved"] == "True")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-xl-12 mb-10 text-center\"><div class=\"alert alert-success py-2\">اطلاعات کسب و کار شما با موفقیت ثبت شد.</div></div>\r\n");
#nullable restore
#line 26 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e379df9ab6f9184f9a34250b8c10b7466a4d2dc7083", async() => {
                WriteLiteral(@"
                                <div class=""form-group row"">
                                    <label class=""col-form-label col-lg-3 col-sm-12 text-lg-right"">اعتبار سنجی</label>
                                    <div class=""col-lg-4 col-md-9 col-sm-12"">
");
#nullable restore
#line 31 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.VerificationPictureRejectReson))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"alert alert-danger\">");
#nullable restore
#line 33 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                       Write(Model.VerificationPictureRejectReson);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 34 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.VerificationPictureURL))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div");
                BeginWriteAttribute("class", " class=\"", 2135, "\"", 2244, 1);
#nullable restore
#line 37 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 2143, Model.IsVerificationPictureAccepted ? "bg-success d-inline-block pt-2 px-2 rounded" : string.Empty, 2143, 101, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <div class=\"image-input image-input-outline\" id=\"kt_image_1\">\r\n                                                    <div class=\"image-input-wrapper\"");
                BeginWriteAttribute("style", " style=\"", 2443, "\"", 2503, 4);
                WriteAttributeValue("", 2451, "background-image:", 2451, 17, true);
                WriteAttributeValue(" ", 2468, "url(", 2469, 5, true);
#nullable restore
#line 39 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 2473, Model.VerificationPictureURL, 2473, 29, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2502, ")", 2502, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div>\r\n");
#nullable restore
#line 40 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                     if (!string.IsNullOrWhiteSpace(Model.VerificationPictureRejectReson))
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <label class=\"btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow\" data-action=\"change\" data-toggle=\"tooltip\"");
                BeginWriteAttribute("title", " title=\"", 2880, "\"", 2888, 0);
                EndWriteAttribute();
                WriteLiteral(@" data-original-title=""تغییر آواتار"">
                                                            <i class=""fa fa-pen icon-sm text-muted""></i>
                                                            <input type=""file"" name=""profile_avatar"" accept="".png, .jpg, .jpeg"">
                                                            <input type=""hidden"" name=""profile_avatar_remove"">
                                                        </label>
");
#nullable restore
#line 47 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 50 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"dropzone dropzone-default\" id=\"kt_dropzone_1\" data-action-url=\"/wizard/uploadIdentityDocument?type=");
#nullable restore
#line 53 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                                                                                                       Write((int)VerifyModel.IdentityDocumentType.Verification);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" data-drop-zone=""true"">
                                                <div class=""dropzone-msg dz-message needsclick"">
                                                    <h3 class=""dropzone-msg-title"">تصویر اعتبار سنجی را در اینجا رها کنید یا برای بارگذاری کلیک کنید.</h3>
                                                </div>
                                            </div>
");
#nullable restore
#line 58 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-form-label col-lg-3 col-sm-12 text-lg-right"">تصویر شناسنامه</label>
                                    <div class=""col-lg-4 col-md-9 col-sm-12"">
");
#nullable restore
#line 64 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.BirthCertificatePictureRejectReason))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"alert alert-danger\">");
#nullable restore
#line 66 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                       Write(Model.BirthCertificatePictureRejectReason);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 67 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.BirthCertificatePictureURL))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div");
                BeginWriteAttribute("class", " class=\"", 5151, "\"", 5264, 1);
#nullable restore
#line 70 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 5159, Model.IsBirthCertificatePictureAccepted ? "bg-success d-inline-block pt-2 px-2 rounded" : string.Empty, 5159, 105, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <div class=\"image-input image-input-outline\" id=\"kt_image_1\">\r\n                                                    <div class=\"image-input-wrapper\"");
                BeginWriteAttribute("style", " style=\"", 5463, "\"", 5527, 4);
                WriteAttributeValue("", 5471, "background-image:", 5471, 17, true);
                WriteAttributeValue(" ", 5488, "url(", 5489, 5, true);
#nullable restore
#line 72 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 5493, Model.BirthCertificatePictureURL, 5493, 33, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5526, ")", 5526, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div>\r\n");
#nullable restore
#line 73 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                     if (!string.IsNullOrWhiteSpace(Model.BirthCertificatePictureRejectReason))
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <label class=\"btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow\" data-action=\"change\" data-toggle=\"tooltip\"");
                BeginWriteAttribute("title", " title=\"", 5909, "\"", 5917, 0);
                EndWriteAttribute();
                WriteLiteral(@" data-original-title=""تغییر آواتار"">
                                                            <i class=""fa fa-pen icon-sm text-muted""></i>
                                                            <input type=""file"" name=""profile_avatar"" accept="".png, .jpg, .jpeg"">
                                                            <input type=""hidden"" name=""profile_avatar_remove"">
                                                        </label>
");
#nullable restore
#line 80 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 83 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"dropzone dropzone-default\" id=\"kt_dropzone_2\" data-action-url=\"/wizard/uploadIdentityDocument?type=");
#nullable restore
#line 86 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                                                                                                       Write((int)VerifyModel.IdentityDocumentType.BirthCertificate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" data-drop-zone=""true"">
                                                <div class=""dropzone-msg dz-message needsclick"">
                                                    <h3 class=""dropzone-msg-title"">تصویر شناسنامه را در اینجا رها کنید یا برای بارگذاری کلیک کنید.</h3>
                                                </div>
                                            </div>
");
#nullable restore
#line 91 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div>

                                <div class=""form-group row"">
                                    <label class=""col-form-label col-lg-3 col-sm-12 text-lg-right"">تصویر کارت ملی</label>
                                    <div class=""col-lg-4 col-md-9 col-sm-12"">
");
#nullable restore
#line 98 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.NationalCardPictureRejectReason))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"alert alert-danger\">");
#nullable restore
#line 100 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                       Write(Model.NationalCardPictureRejectReason);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 101 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                         if (!string.IsNullOrWhiteSpace(Model.NationalCardPictureURL))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div");
                BeginWriteAttribute("class", " class=\"", 8171, "\"", 8280, 1);
#nullable restore
#line 104 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 8179, Model.IsNationalCardPictureAccepted ? "bg-success d-inline-block pt-2 px-2 rounded" : string.Empty, 8179, 101, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <div class=\"image-input image-input-outline\" id=\"kt_image_1\">\r\n                                                    <div class=\"image-input-wrapper\"");
                BeginWriteAttribute("style", " style=\"", 8479, "\"", 8539, 4);
                WriteAttributeValue("", 8487, "background-image:", 8487, 17, true);
                WriteAttributeValue(" ", 8504, "url(", 8505, 5, true);
#nullable restore
#line 106 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
WriteAttributeValue("", 8509, Model.NationalCardPictureURL, 8509, 29, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8538, ")", 8538, 1, true);
                EndWriteAttribute();
                WriteLiteral("></div>\r\n");
#nullable restore
#line 107 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                     if (!string.IsNullOrWhiteSpace(Model.NationalCardPictureRejectReason))
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <label class=\"btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow\" data-action=\"change\" data-toggle=\"tooltip\"");
                BeginWriteAttribute("title", " title=\"", 8917, "\"", 8925, 0);
                EndWriteAttribute();
                WriteLiteral(@" data-original-title=""تغییر آواتار"">
                                                            <i class=""fa fa-pen icon-sm text-muted""></i>
                                                            <input type=""file"" name=""profile_avatar"" accept="".png, .jpg, .jpeg"">
                                                            <input type=""hidden"" name=""profile_avatar_remove"">
                                                        </label>
");
#nullable restore
#line 114 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 117 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"dropzone dropzone-default\" id=\"kt_dropzone_3\" data-action-url=\"/wizard/uploadIdentityDocument?type=");
#nullable restore
#line 120 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                                                                                                                                       Write((int)VerifyModel.IdentityDocumentType.NationalCard);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" data-drop-zone=""true"">
                                                <div class=""dropzone-msg dz-message needsclick"">
                                                    <h3 class=""dropzone-msg-title"">تصویر کارت ملی را در اینجا رها کنید یا برای بارگذاری کلیک کنید.</h3>
                                                </div>
                                            </div>
");
#nullable restore
#line 125 "D:\Samodi\V2\src\src\UserPanel\Tipoul.UserPanel.WebUI\Views\Wizard\ProfileVerify.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div>
                                <!--begin::ویزارد اقدامات-->
                                <div class=""d-flex justify-content-between border-top mt-5 pt-10"">
                                    <div class=""mr-2"">
                                        <button type=""button"" class=""btn btn-light-primary font-weight-bold text-uppercase px-9 py-4"" data-wizard-type=""action-prev"">
                                            قبلی
                                        </button>
                                    </div>
                                    <div>
                                        <button type=""button"" class=""btn btn-success font-weight-bold text-uppercase px-9 py-4"" data-wizard-type=""action-submit"">
                                            ارسال
                                        </button>
                                        <a href=""/wizard/profilelegal"" class=""btn btn-light-primary fo");
                WriteLiteral(@"nt-weight-bold text-uppercase px-9 py-4 mx-3"" data-wizard-type=""action-next"">
                                            تکمیل پروفایل حقوقی (اختیاری)
                                        </a>
                                        <a href=""/wizard/bankaccount"" class=""btn btn-primary font-weight-bold text-uppercase px-9 py-4"" data-wizard-type=""action-next"">
                                            بعدی (حساب بانکی)
                                        </a>
                                    </div>
                                </div>
                                <!--end::ویزارد اقدامات-->
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <!--end::ویزارد Body-->
                    </div>
                    <!--end::ویزارد-->
                </div>
                <!--end::ویزارد-->
            </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VerifyModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
