#pragma checksum "/Users/admin/c#/Project_PostOffice/Views/Authentication/SignIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89f3939c52d6dffbfc81b22cf23b078158bb34b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_SignIn), @"mvc.1.0.view", @"/Views/Authentication/SignIn.cshtml")]
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
#line 1 "/Users/admin/c#/Project_PostOffice/Views/_ViewImports.cshtml"
using post_office;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/admin/c#/Project_PostOffice/Views/_ViewImports.cshtml"
using post_office.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89f3939c52d6dffbfc81b22cf23b078158bb34b4", @"/Views/Authentication/SignIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588a1dfcb2bfeaf48f347fc02a3c0bbb5285a5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Authentication_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "/Users/admin/c#/Project_PostOffice/Views/Authentication/SignIn.cshtml"
  
    ViewData["Title"] = "Sign In";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div style="" height: 500px; width: 40%;position: absolute;top: 150px;right: 80px;"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div style=""padding: 35px 90px;"">
                <div class=""text-center"" style=""margin-bottom: 50px;"">
                    <p class=""h4 text-gray-900"" style=""font-size: 35px;"">Welcome Back!</p>
                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89f3939c52d6dffbfc81b22cf23b078158bb34b43733", async() => {
                WriteLiteral(@"
                    <div class=""form-group"" style=""margin-bottom: 30px; position: relative;"">
                        <input name=""sign-in-phone"" class=""form-control form-control-user"" id=""sign-in-phone"" aria-describedby=""sign-in-phone""
                            placeholder=""Phone"">
                        <div id=""sign-in-phone-error""></div>
                    </div>
                    <div class=""form-group"" style=""margin-bottom: 30px; position: relative;"">
                        <input name=""sign-in-password"" class=""form-control form-control-user"" id=""sign-in-password"" aria-describedby=""sign-in-password""
                            placeholder=""Password"" type=""password"">
                        <div id=""sign-in-password-error""></div>
                    </div>
                    <div class=""form-group mb-3"">
                        <div class=""custom-control custom-checkbox small"">
                            <input type=""checkbox"" class=""custom-control-input"" id=""customCheck"">
                     ");
                WriteLiteral(@"       <label class=""custom-control-label"" for=""customCheck"">Remember
                                Me</label>
                        </div>
                    </div>
                    <a id=""btn-sign-in"" class=""btn btn-block btn-user""
                        style=""background-color: transparent;color: #ffdc39;border: 1px solid #ffdc39;border-radius: 50px;width: 100%;padding: 10px 20px;"">
                        Sign in
                    </a>
                ");
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
            WriteLiteral(@"
                <div class=""mt-3"">
                    <div class=""text-center"">
                        <a class=""small"" href=""#"">Forgot Password?</a>
                    </div>
                    <div class=""text-center"">
                        <a class=""small"" href=""register.html"">Create an Account!</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    if(localStorage.getItem('user_data'))
        window.location.href = `");
#nullable restore
#line 48 "/Users/admin/c#/Project_PostOffice/Views/Authentication/SignIn.cshtml"
                           Write(Url.ActionLink("Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("`\n</script>");
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