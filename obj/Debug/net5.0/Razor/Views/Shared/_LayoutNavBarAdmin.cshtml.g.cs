#pragma checksum "C:\CSharp\epjSem3\Views\Shared\_LayoutNavBarAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91426c89b550f6e3fe70cadb5714eecaec3a1b8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutNavBarAdmin), @"mvc.1.0.view", @"/Views/Shared/_LayoutNavBarAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91426c89b550f6e3fe70cadb5714eecaec3a1b8b", @"/Views/Shared/_LayoutNavBarAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588a1dfcb2bfeaf48f347fc02a3c0bbb5285a5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutNavBarAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<nav class=""col-12"" style=""background: #fdfcf9; box-shadow: 0 0.25rem 0.75rem rgb(247 231 167 / 0.55)"">
    <div class=""sidebar-button col-5"">
        <i class=""search-item fa-search fa"" style=""pointer-events:inherit"" id=""search-show"">
        </i>
    
        <i class=""search-item fa fa-times "" style=""pointer-events:inherit"" id=""search-hide"">
        </i>
        <input class=""form-control input-search"" id=""input-search-id"" type=""text"" placeholder=""Search..."">
    </div>
    <div class=""sidebar-button col-4"">
        <span id=""title-bar"" style=""letter-spacing: 1.5px; color: #b7451b; font-weight: 600; font-size: 22px; font-family: monospace"">DASHBOARD</span>
    </div>

    <div class=""col-3"" style=""padding:0"">
        
            <div class=""cart-icon"" style=""float:right;margin-right:0"">
                <span onclick=""ShowAction()"" class=""cart-icon nameCurrent dropbtn "" style=""float: right; color: #c38a31; margin-top: 0.65vh;padding:12px 20px;background:rgb(249 237 230 / 0.61); border-rad");
            WriteLiteral(@"ius:5px;cursor:pointer"">
                    <i class=""fa fa-ellipsis-v"" style=""font-size:20px; color:#b7451b;cursor:pointer;pointer-events:none""></i>
                </span>

                <div class=""dropdown"" style=""float:left!important; margin-top:8vh; margin-left:-3vw"">

                    <div id=""myDropdown"" class=""dropdown-content show"">
                        <a");
            BeginWriteAttribute("href", " href=\'", 1408, "\'", 1447, 1);
#nullable restore
#line 25 "C:\CSharp\epjSem3\Views\Shared\_LayoutNavBarAdmin.cshtml"
WriteAttributeValue("", 1415, Url.Action("Index","DashBoard"), 1415, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Go to Home</a>\r\n                        <div class=\"dropdown-divider\" style=\"margin:0\"></div>\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1570, "\'", 1611, 1);
#nullable restore
#line 27 "C:\CSharp\epjSem3\Views\Shared\_LayoutNavBarAdmin.cshtml"
WriteAttributeValue("", 1577, Url.Action("ClientLogout","Auth"), 1577, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">  <i class=""fa fa-sign-out"" style=""color:white; margin-right:0.5vw""></i>Logout</a>
                    </div>
                </div>
            </div>

    </div>
</nav>

<script>
    function ShowAction() {
        document.getElementById(""myDropdown"").classList.toggle(""show"");
    }
    window.onclick = function (event) {
        if (!event.target.matches('.dropbtn')) {
            document.getElementById(""myDropdown"").classList.add(""show"");
        }
    }
</script>");
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
