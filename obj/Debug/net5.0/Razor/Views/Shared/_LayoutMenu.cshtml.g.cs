#pragma checksum "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a3034de55533cbdf41e789fda12b3d830bcc2f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutMenu), @"mvc.1.0.view", @"/Views/Shared/_LayoutMenu.cshtml")]
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
#line 1 "C:\CSharp\Project_PostOffice\Views\_ViewImports.cshtml"
using post_office;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
using post_office.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a3034de55533cbdf41e789fda12b3d830bcc2f8", @"/Views/Shared/_LayoutMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588a1dfcb2bfeaf48f347fc02a3c0bbb5285a5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/defaults/logo-light.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-9 container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius:50%; width:38px;height:38px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<style>\r\n    .active-nav{\r\n        background:#7ac8ac;\r\n        border-left:5px solid #c2f3e2;\r\n    }\r\n</style>\r\n<div class=\"logo-details\"  >\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a3034de55533cbdf41e789fda12b3d830bcc2f84323", async() => {
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
<ul class=""nav-links"" style=""position:initial;margin-bottom:0"">
    <li style=""height: 65px; background-image: linear-gradient(rgb(255 230 114 / 0.75),rgb(251 211 31 / 0.96)) "">
        <div style=""height:inherit; padding:13px 10px; width:22%;float:left"">
            <span>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a3034de55533cbdf41e789fda12b3d830bcc2f85748", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 560, "~/img/AvtUser/", 560, 14, true);
#nullable restore
#line 16 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
AddHtmlAttributeValue("", 574, AuthenticetionModel.avt!=""?AuthenticetionModel.avt:"default.png", 574, 68, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </span>\r\n        </div>\r\n        <div style=\"height:inherit; padding:11px 0 10px 5px; width:78%;float:left\">\r\n            <span style=\"font-size: 15px; color: #faf6e1; font-weight: 500; float: left; font-family: system-ui\">");
#nullable restore
#line 20 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
                                                                                                            Write(post_office.Models.AuthenticetionModel.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <br>\r\n            <span style=\"font-size: 12px; color: #faf4de; float: left; font-family: system-ui\">\r\n                ");
#nullable restore
#line 23 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
           Write(post_office.Models.AuthenticetionModel.roleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span");
            BeginWriteAttribute("onclick", " onclick=\"", 1189, "\"", 1253, 3);
            WriteAttributeValue("", 1199, "window.location.href=\'", 1199, 22, true);
#nullable restore
#line 24 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 1221, Url.Action("MyAccount","Auth"), 1221, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1252, "\'", 1252, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" style="" cursor: pointer"">
                    <i style=""color: #f9f3de;"" id=""mysetting"" class=""fa fa-cog""></i>
                </span>
            </span>

        </div>
    </li>
    </ul>
<ul class=""nav-links"" style=""height:75vh;overflow-y:scroll;overflow-x:hidden"" id=""scroll-menu"">

    <li>
        <a");
            BeginWriteAttribute("href", " href=\"", 1573, "\"", 1611, 1);
#nullable restore
#line 35 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 1580, Url.Action("Dashboard","Auth"), 1580, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"__dash\" class=\"menu\">\r\n            <i class=\"fa fa-home icons\"></i>\r\n            <span class=\"links_name\">Dashboard</span>\r\n        </a>\r\n    </li>\r\n");
#nullable restore
#line 40 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_USER"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__user\"");
            BeginWriteAttribute("href", " href=\"", 1871, "\"", 1905, 1);
#nullable restore
#line 43 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 1878, Url.Action("Users","Auth"), 1878, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n                <i class=\"fa fa-user \"></i>\r\n                <span class=\"links_name\">Users</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 48 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.roleName == "Super Admin")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 2154, "\"", 2189, 1);
#nullable restore
#line 52 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 2161, Url.Action("Roles", "Auth"), 2161, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"__role\" class=\"menu\">\r\n                <i class=\"fa fa-object-group icons\"></i>\r\n                <span class=\"links_name\">Roles</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 57 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_CUSTOMER"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__cus\"");
            BeginWriteAttribute("href", " href=\"", 2479, "\"", 2518, 1);
#nullable restore
#line 61 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 2486, Url.Action("Customers", "Auth"), 2486, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-users \"></i>\r\n                <span class=\"links_name\">Customers</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 67 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_CONTACT"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__cont\"");
            BeginWriteAttribute("href", " href=\"", 2790, "\"", 2828, 1);
#nullable restore
#line 71 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 2797, Url.Action("Contacts", "Auth"), 2797, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-address-book\"></i>\r\n                <span class=\"links_name\">Contacts</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 77 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_BILL"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__bills\"");
            BeginWriteAttribute("href", " href=\"", 3103, "\"", 3138, 1);
#nullable restore
#line 81 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 3110, Url.Action("Bills", "Auth"), 3110, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-file \"></i>\r\n                <span class=\"links_name\">Bills</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 87 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.roleName == "Super Admin")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__branches\"");
            BeginWriteAttribute("href", " href=\"", 3405, "\"", 3443, 1);
#nullable restore
#line 91 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 3412, Url.Action("Branches", "Auth"), 3412, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-object-ungroup \"></i>\r\n                <span class=\"links_name\">Branches</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 97 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_SERVICE"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__svc\"");
            BeginWriteAttribute("href", " href=\"", 3722, "\"", 3759, 1);
#nullable restore
#line 101 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 3729, Url.Action("Service", "Auth"), 3729, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-truck \"></i>\r\n                <span class=\"links_name\">Services</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 107 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_PRODUCT_CATEGORY"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__pc\"");
            BeginWriteAttribute("href", " href=\"", 4037, "\"", 4082, 1);
#nullable restore
#line 111 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 4044, Url.Action("ProductCategory", "Auth"), 4044, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n                <i class=\"fa fa-th-large\"></i>\r\n                <span class=\"links_name\">Product categories</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 116 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_PRODUCT"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__pd\"");
            BeginWriteAttribute("href", " href=\"", 4361, "\"", 4399, 1);
#nullable restore
#line 120 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 4368, Url.Action("Products", "Auth"), 4368, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-product-hunt \"></i>\r\n                <span class=\"links_name\">Products</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 126 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 127 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("VIEW_ATTRIBUTE"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__attr\"");
            BeginWriteAttribute("href", " href=\"", 4679, "\"", 4719, 1);
#nullable restore
#line 130 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 4686, Url.Action("Attributes", "Auth"), 4686, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-flag \"></i>\r\n                <span class=\"links_name\">Attributes</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 136 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 137 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
     if (AuthenticetionModel.hasPermission("SETTING_TRANSPORT_FEE"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a id=\"__spf\"");
            BeginWriteAttribute("href", " href=\"", 4999, "\"", 5039, 1);
#nullable restore
#line 140 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 5006, Url.Action("SettingFee", "Auth"), 5006, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu\">\r\n\r\n                <i class=\"fa fa-balance-scale\"></i>\r\n                <span class=\"links_name\">Setting transport fee</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 146 "C:\CSharp\Project_PostOffice\Views\Shared\_LayoutMenu.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</ul>\r\n\r\n\r\n<script type=\"text/javascript\">\r\n\r\n   \r\n</script>");
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
