#pragma checksum "C:\CSharp\epjSem3\Views\Authentication\SignUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9971365f86970f6e2e9894b1eecc24e179be78f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_SignUp), @"mvc.1.0.view", @"/Views/Authentication/SignUp.cshtml")]
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
#line 1 "C:\CSharp\epjSem3\Views\_ViewImports.cshtml"
using post_office;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CSharp\epjSem3\Views\_ViewImports.cshtml"
using post_office.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9971365f86970f6e2e9894b1eecc24e179be78f2", @"/Views/Authentication/SignUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588a1dfcb2bfeaf48f347fc02a3c0bbb5285a5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Authentication_SignUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
#nullable restore
#line 1 "C:\CSharp\epjSem3\Views\Authentication\SignUp.cshtml"
  
    ViewData["Title"] = "Sign Up";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\" height: 500px; width: 35%;position: absolute;top: 165px;right: 120px;\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9971365f86970f6e2e9894b1eecc24e179be78f23423", async() => {
                WriteLiteral(@"
        <div class=""row"">
            <div class=""text-center"" style=""margin-bottom: 50px;"">
                <p class=""h4 text-gray-900"" style=""font-size: 35px;"">Register Now!</p>
            </div>
            <div class=""col-lg-12"" style=""margin-bottom: 30px;"">
                <div class=""row"">
                    <div class=""form-group col-lg-6"" style=""position: relative;"">
                        <input name=""first-name"" class=""form-control form-control-user"" id=""first-name""
                            aria-describedby=""firstName"" placeholder=""First name"">
                        <div id=""first-name-error""></div>
                    </div>
                    <div class=""form-group col-lg-6"" style=""position: relative;"">
                        <input name=""last-name"" class=""form-control form-control-user"" id=""last-name""
                            aria-describedby=""lastName"" placeholder=""Last name"">
                        <div id=""last-name-error""></div>
                    </div>
     ");
                WriteLiteral(@"           </div>
            </div>
            <div class=""col-lg-12"" style=""margin-bottom: 30px;"">
                <div class=""row"">
                    <div class=""form-group col-lg-6"" style=""position: relative;"">
                        <input name=""phone"" class=""form-control form-control-user"" id=""phone"" aria-describedby=""phone""
                            placeholder=""Phone"">
                        <div id=""phone-error""></div>
                    </div>
                    <div class=""form-group col-lg-6"" style=""position: relative;"">
                        <input name=""email"" class=""form-control form-control-user"" id=""email"" aria-describedby=""email""
                            placeholder=""Email"">
                        <div id=""email-error""></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-12"" style=""margin-bottom: 30px;"">
                <div class=""row"">
                    <div class=""form-group col-lg-6"" style=""position:");
                WriteLiteral(@" relative;"">
                        <input name=""password"" class=""form-control form-control-user"" id=""password"" aria-describedby=""password""
                            placeholder=""Password"" type=""password"">
                        <div id=""password-error""></div>
                    </div>
                    <div class=""form-group col-lg-6"" style=""position: relative;"">
                        <input name=""repeat-password"" class=""form-control form-control-user"" id=""repeat-password""
                            aria-describedby=""repeatPassword"" placeholder=""Repeat Password"" type=""password"">
                        <div id=""repeat-password-error""></div>
                    </div>
                </div>
            </div>
            <a id=""btn-sign-up"" class=""btn btn-block btn-user""
                style=""background-color: transparent;color: #ffdc39;border: 1px solid #ffdc39;border-radius: 50px;width: 95%;padding: 10px 20px;margin: 0 auto;"">Sign
                up</a>
            <div class=""mt-4");
                WriteLiteral("\">\r\n                <div class=\"text-center\">\r\n                    <a class=\"small\" href=\"register.html\">Already a member?</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<script>\r\n    if(localStorage.getItem(\'user_data\'))\r\n        window.location.href = `");
#nullable restore
#line 65 "C:\CSharp\epjSem3\Views\Authentication\SignUp.cshtml"
                           Write(Url.ActionLink("Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("`\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
