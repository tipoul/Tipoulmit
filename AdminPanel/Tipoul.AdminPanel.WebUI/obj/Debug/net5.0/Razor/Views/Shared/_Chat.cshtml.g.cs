#pragma checksum "D:\Samodi\V2\src\src\AdminPanel\Tipoul.AdminPanel.WebUI\Views\Shared\_Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61bf5a9f7132bd7e0ee91a85eebb7faca3996961"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Chat), @"mvc.1.0.view", @"/Views/Shared/_Chat.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61bf5a9f7132bd7e0ee91a85eebb7faca3996961", @"/Views/Shared/_Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5712d1f4212e130db5d8d7b5aa52ef3ba9610af6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Pic"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/300_12.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/300_21.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--begin::چت Panel-->
<div class=""modal modal-sticky modal-sticky-bottom-right"" id=""kt_chat_modal"" role=""dialog"" data-backdrop=""false"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <!--begin::Card-->
            <div class=""card card-custom"">
                <!--begin::Header-->
                <div class=""card-header align-items-center px-4 py-3"">
                    <div class=""text-left flex-grow-1"">
                        <!--begin::دراپ دان Menu-->
                        <div class=""dropdown dropdown-inline"">
                            <button type=""button"" class=""btn btn-clean btn-sm btn-icon btn-icon-md"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <span class=""svg-icon svg-icon-lg"">
                                    <!--begin::Svg Icon | path:assets/media/svg/icons/ارتباطات/Add-user.svg-->
                                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""ht");
            WriteLiteral(@"tp://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <polygon points=""0 0 24 0 24 24 0 24"" />
                                            <path d=""M18,8 L16,8 C15.4477153,8 15,7.55228475 15,7 C15,6.44771525 15.4477153,6 16,6 L18,6 L18,4 C18,3.44771525 18.4477153,3 19,3 C19.5522847,3 20,3.44771525 20,4 L20,6 L22,6 C22.5522847,6 23,6.44771525 23,7 C23,7.55228475 22.5522847,8 22,8 L20,8 L20,10 C20,10.5522847 19.5522847,11 19,11 C18.4477153,11 18,10.5522847 18,10 L18,8 Z M9,11 C6.790861,11 5,9.209139 5,7 C5,4.790861 6.790861,3 9,3 C11.209139,3 13,4.790861 13,7 C13,9.209139 11.209139,11 9,11 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                            <path d=""M0.00065168429,20.1992055 C0.388258525,15.4265159 4.26191235,13 8.98334134,13 C13.7712164,13 17.7048837,15.2931929 17.9979143,20.2");
            WriteLiteral(@" C18.0095879,20.3954741 17.9979143,21 17.2466999,21 C13.541124,21 8.03472472,21 0.727502227,21 C0.476712155,21 -0.0204617505,20.45918 0.00065168429,20.1992055 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                                        </g>
                                    </svg><!--end::Svg Icon-->
                                </span>
                            </button>
                            <div class=""dropdown-menu p-0 m-0 dropdown-menu-right dropdown-menu-md"">
                                <!--begin::Navigation-->
                                <ul class=""navi navi-hover py-5"">
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-drop""></i></span>
                                            <span class=""navi-text"">گروه جدید</span>
                                        </a>
                                   ");
            WriteLiteral(@" </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-list-3""></i></span>
                                            <span class=""navi-text"">مخاطب</span>
                                        </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-rocket-1""></i></span>
                                            <span class=""navi-text"">گروه ها</span>
                                            <span class=""navi-link-badge"">
                                                <span class=""label label-light-primary label-inline font-weight-bold"">جدید</span>
                                            </span>
                 ");
            WriteLiteral(@"                       </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-bell-2""></i></span>
                                            <span class=""navi-text"">تماس ها</span>
                                        </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-gear""></i></span>
                                            <span class=""navi-text"">تنظیمات</span>
                                        </a>
                                    </li>

                                    <li class=""navi-separator my-3""></li>

                                    <li class=""");
            WriteLiteral(@"navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-magnifier-tool""></i></span>
                                            <span class=""navi-text"">راهنما</span>
                                        </a>
                                    </li>
                                    <li class=""navi-item"">
                                        <a href=""#"" class=""navi-link"">
                                            <span class=""navi-icon""><i class=""flaticon2-bell-2""></i></span>
                                            <span class=""navi-text"">حریم خصوصی</span>
                                            <span class=""navi-link-badge"">
                                                <span class=""label label-light-danger label-rounded font-weight-bold"">5</span>
                                            </span>
                                        </a>
                   ");
            WriteLiteral(@"                 </li>
                                </ul>
                                <!--end::Navigation-->
                            </div>
                        </div>
                        <!--end::دراپ دان Menu-->
                    </div>
                    <div class=""text-center flex-grow-1"">
                        <div class=""text-dark-75 font-weight-bold font-size-h5"">محسن برومند</div>
                        <div>
                            <span class=""label label-dot label-success""></span>
                            <span class=""font-weight-bold text-muted font-size-sm"">فعال</span>
                        </div>
                    </div>
                    <div class=""text-right flex-grow-1"">
                        <button type=""button"" class=""btn btn-clean btn-sm btn-icon btn-icon-md"" data-dismiss=""modal"">
                            <i class=""ki ki-close icon-1x""></i>
                        </button>
                    </div>
                </div>
   ");
            WriteLiteral(@"             <!--end::Header-->
                <!--begin::Body-->
                <div class=""card-body"">
                    <!--begin::Scroll-->
                    <div class=""scroll scroll-pull"" data-height=""375"" data-mobile-height=""300"">
                        <!--begin::پیامs-->
                        <div class=""messages"">
                            <!--begin::پیام In-->
                            <div class=""d-flex flex-column mb-5 align-items-start"">
                                <div class=""d-flex align-items-center"">
                                    <div class=""symbol symbol-circle symbol-40 mr-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696113519", async() => {
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
            WriteLiteral(@"
                                    </div>
                                    <div>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">محسن برومند</a>
                                        <span class=""text-muted font-size-sm"">2 ساعت</span>
                                    </div>
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-success text-dark-50 font-weight-bold font-size-lg text-left max-w-400px"">
                                    چقدر احتمال دارید که شرکت ما را توصیه کنید
                                    به دوستان و خانواده خود؟
                                </div>
                            </div>
                            <!--end::پیام In-->
                            <!--begin::پیام Out-->
                            <div class=""d-flex flex-column mb-5 align-items-end"">
                                <div class=""d-flex align-items-center"">");
            WriteLiteral(@"
                                    <div>
                                        <span class=""text-muted font-size-sm"">3 دقیقه</span>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">شما</a>
                                    </div>
                                    <div class=""symbol symbol-circle symbol-40 ml-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696116147", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-primary text-dark-50 font-weight-bold font-size-lg text-right max-w-400px"">
                                    سلام در آنجا ، ما فقط می نویسیم تا به شما اطلاع دهیم
                                    که در مخزن گیت هاب مشترک شده اید.
                                </div>
                            </div>
                            <!--end::پیام Out-->
                            <!--begin::پیام In-->
                            <div class=""d-flex flex-column mb-5 align-items-start"">
                                <div class=""d-flex align-items-center"">
                                    <div class=""symbol symbol-circle symbol-40 mr-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696118122", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                                    <div>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">محسن برومند</a>
                                        <span class=""text-muted font-size-sm"">40 ثانیه</span>
                                    </div>
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-success text-dark-50 font-weight-bold font-size-lg text-left max-w-400px"">
                                    باشه ، فهمیدم
                                </div>
                            </div>
                            <!--end::پیام In-->
                            <!--begin::پیام Out-->
                            <div class=""d-flex flex-column mb-5 align-items-end"">
                                <div class=""d-flex align-items-center"">
                                    <div>
                                        <spa");
            WriteLiteral(@"n class=""text-muted font-size-sm"">همین الان</span>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">شما</a>
                                    </div>
                                    <div class=""symbol symbol-circle symbol-40 ml-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696120663", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-primary text-dark-50 font-weight-bold font-size-lg text-right max-w-400px"">
                                    برای همه مشکلات اعلان دریافت خواهید کرد ، درخواستها را بکشید!
                                </div>
                            </div>
                            <!--end::پیام Out-->
                            <!--begin::پیام In-->
                            <div class=""d-flex flex-column mb-5 align-items-start"">
                                <div class=""d-flex align-items-center"">
                                    <div class=""symbol symbol-circle symbol-40 mr-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696122576", async() => {
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
            WriteLiteral(@"
                                    </div>
                                    <div>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">محسن برومند</a>
                                        <span class=""text-muted font-size-sm"">40 ثانیه</span>
                                    </div>
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-success text-dark-50 font-weight-bold font-size-lg text-left max-w-400px"">
                                    شما می توانید با کلیک بر روی این مخزن بلافاصله از حالت انتخاب خارج شوید:<a href=""#"">https://github.com</a>
                                </div>
                            </div>
                            <!--end::پیام In-->
                            <!--begin::پیام Out-->
                            <div class=""d-flex flex-column mb-5 align-items-end"">
                                <div class=""d-flex align-items-cent");
            WriteLiteral(@"er"">
                                    <div>
                                        <span class=""text-muted font-size-sm"">همین الان</span>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">شما</a>
                                    </div>
                                    <div class=""symbol symbol-circle symbol-40 ml-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696125212", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-primary text-dark-50 font-weight-bold font-size-lg text-right max-w-400px"">
                                    آموزش رو دیدم.
                                </div>
                            </div>
                            <!--end::پیام Out-->
                            <!--begin::پیام In-->
                            <div class=""d-flex flex-column mb-5 align-items-start"">
                                <div class=""d-flex align-items-center"">
                                    <div class=""symbol symbol-circle symbol-40 mr-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696127078", async() => {
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
            WriteLiteral(@"
                                    </div>
                                    <div>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">محسن برومند</a>
                                        <span class=""text-muted font-size-sm"">40 ثانیه</span>
                                    </div>
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-success text-dark-50 font-weight-bold font-size-lg text-left max-w-400px"">
                                    بیشترین دوره های تجاری خریداری شده در این فروش!
                                </div>
                            </div>
                            <!--end::پیام In-->
                            <!--begin::پیام Out-->
                            <div class=""d-flex flex-column mb-5 align-items-end"">
                                <div class=""d-flex align-items-center"">
                                    <div>
          ");
            WriteLiteral(@"                              <span class=""text-muted font-size-sm"">همین الان</span>
                                        <a href=""#"" class=""text-dark-75 text-hover-primary font-weight-bold font-size-h6"">شما</a>
                                    </div>
                                    <div class=""symbol symbol-circle symbol-40 ml-3"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "61bf5a9f7132bd7e0ee91a85eebb7faca399696129653", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                                </div>
                                <div class=""mt-2 rounded p-5 bg-light-primary text-dark-50 font-weight-bold font-size-lg text-right max-w-400px"">
                                    شرکت BBQ برای جشن گرفتن دستاوردها و اهداف سه ماهه آخر. غذا و نوشیدنی تهیه شده
                                </div>
                            </div>
                            <!--end::پیام Out-->
                        </div>
                        <!--end::پیامs-->
                    </div>
                    <!--end::Scroll-->
                </div>
                <!--end::Body-->
                <!--begin::Footer-->
                <div class=""card-footer align-items-center"">
                    <!--begin::Compose-->
                    <textarea class=""form-control border-0 p-0"" rows=""2"" placeholder=""تایپ یک پیام""></textarea>
                    <div class=""d-flex align-items-center justify-content-between mt-5"">
   ");
            WriteLiteral(@"                     <div class=""mr-3"">
                            <a href=""#"" class=""btn btn-clean btn-icon btn-md mr-1""><i class=""flaticon2-photograph icon-lg""></i></a>
                            <a href=""#"" class=""btn btn-clean btn-icon btn-md""><i class=""flaticon2-photo-camera  icon-lg""></i></a>
                        </div>
                        <div>
                            <button type=""button"" class=""btn btn-primary btn-md text-uppercase font-weight-bold chat-send py-2 px-6"">ارسال</button>
                        </div>
                    </div>
                    <!--begin::Compose-->
                </div>
                <!--end::Footer-->
            </div>
            <!--end::Card-->
        </div>
    </div>
</div>
<!--end::چت Panel-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591