#pragma checksum "C:\CSharp\epjSem3\Views\Auth\Service.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6f6dc1b97ff9dc0d637a4e668eb760267eadd93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Service), @"mvc.1.0.view", @"/Views/Auth/Service.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6f6dc1b97ff9dc0d637a4e668eb760267eadd93", @"/Views/Auth/Service.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588a1dfcb2bfeaf48f347fc02a3c0bbb5285a5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Service : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<post_office.Models.ServiceModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
  
    ViewData["Title"] = "Service management";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-12"" style=""display: table; background: white; top: 20px;box-shadow: rgb(248 242 225 / 0.92) 10px 10px 20px 5px; padding:20px"">
    <div style=""height:50px;position:relative; padding:0"">
        <button class=""btn-action delete"" id=""btnDelete"" style=""float:left;margin-right:2vw"">Delete</button>
        <input class=""input-search form-control"" style=""float:left;width:380px;"" type=""text"" placeholder=""Search by code, name"" />
        <button class=""btn-action save"" id=""btnCreate"" style=""float:right;"">Create</button>

    </div>
    <table class=""table"" style="" border:2px solid #ddd;width:inherit"" id=""table-id"">
        <tr style=""color: white; background: #747583"">
            <th><input type=""checkbox"" id=""check-all"" onclick=""SelectAll(this)"" /></th>
            <th>#</th>
            <th>Name</th>
            <th>Price</th>
            <th>Slot</th>
            <th>Content</th>
            <th>Created At</th>
            <th>Status</th>
            <th>Action</th>
        </tr>");
            WriteLiteral(@"
        <tr class=""table-item"">
            <td class=""tbl-20""><input type=""checkbox"" class=""sub-check"" post-item=""post-"" /></td>
            <td class=""tbl-30"">1</td>
            <td class=""tbl-200"">bababbabnannanasbbsbsbbsbbababbababba</td>
            <td class=""tbl-200"">150 000</td>
            <td class=""tbl-30"">5</td>
            <td class=""tbl-120"">babababbaba</td>
            <td class=""tbl-120"">11 11 1111 11:11 </td>
            <td class=""sts-item tbl-40"" id=""sts-""></td>
            <td class=""tbl-180"">
                <span oid=""object-1"" class=""action-icon edit edit-service"" style=""padding:10px 5px 10px 10px"">
                    <i class=""fa fa-edit""></i>
                </span>

                <span oid=""object-1"" class=""action-icon delete delete-service"">
                    <i class=""fa fa-trash""></i>
                </span>
            </td>
        </tr>


    </table>
    <div class=""pagination-container"" style=""cursor:pointer"">
        <nav aria-label=""Page naviga");
            WriteLiteral("tion example\" style=\"position:unset;box-shadow:none; background:none;padding:0\">\r\n            <ul class=\"pagination\" id=\"paginations\">\r\n                <li class=\"page-item page-link\" data-page=\"prev\">&lt;</li>\r\n");
#nullable restore
#line 54 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                 for (int i = 1; i <= ViewBag.pagi; i++)
                {
                    if (i == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item page-link\" data-page=\"page-1\" style=\"background:#ddd\">");
#nullable restore
#line 58 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                                                                                              Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 59 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item page-link\" data-page=\"page-");
#nullable restore
#line 63 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 63 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 64 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <li class=""page-item page-link"" data-page=""next"">&gt;</li>
            </ul>
        </nav>
    </div>
</div>
<div id=""view-main"">
    <div id=""view-sub"" class=""col-11"">
        <div class=""col-12"" id=""view-title"">
            <label></label>
            <span style=""float:right; cursor:pointer"" id=""CloseForm"">
                <i class=""fa fa-window-close"" style=""pointer-events:none;font-size:38px""></i>
            </span>
        </div>
        <div id=""content"">
");
#nullable restore
#line 80 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
             using (Html.BeginForm("ServiceCU", "Service", FormMethod.Post, new { @id = "form-svc" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12\" style=\"padding:20px;min-height:450px;display:table;\">\r\n                    <div class=\"col-6\" style=\"border-right:3px solid #f4e8e4;min-height:inherit;float:left\">\r\n                        ");
#nullable restore
#line 84 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <label class=\"text-color\">Name:</label>\r\n                        ");
#nullable restore
#line 86 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.TextBoxFor(d => d.name, new { @class = "input-form-cu", @type = "text", @placeholder = "name" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 87 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.ValidationMessageFor(d => d.name, "", new { @class = "_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                        <label class=\"text-color\">Price:</label>\r\n                        ");
#nullable restore
#line 90 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.TextBoxFor(d => d.price, new { @class = "input-form-cu", @type = "text", @placeholder = "price" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 91 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.ValidationMessageFor(d => d.price, "", new { @class = "_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                        <label class=\"text-color\">Status:</label>\r\n                        ");
#nullable restore
#line 94 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.DropDownListFor(model => model.status, new List<SelectListItem> { new SelectListItem { Value = "1", Text = "Activated" },
                                                                                                new SelectListItem { Value = "0", Text = "Deactivated" },
                                                                                                new SelectListItem { Value = "2", Text = "status 3" } }, new { @style = "", @class = "dropdownlist" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <div class=\"col-6\" style=\"min-height:inherit;float:left\">\r\n                        <label class=\"text-color\">Slot:</label>\r\n                        ");
#nullable restore
#line 101 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.TextBoxFor(d => d.slot, new { @class = "input-form-cu", @type = "text", @placeholder = "slot" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 102 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.ValidationMessageFor(d => d.slot, "", new { @class = "_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                        <label class=\"text-color\">Content:</label>\r\n                        ");
#nullable restore
#line 105 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.TextAreaFor(d => d.content, new { @class = "input-form-cu txt-area", @type = "text", @placeholder = "content" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 106 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
                   Write(Html.ValidationMessageFor(d => d.content, "", new { @class = "_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <br />

                    </div>
                </div>
                <div class=""col-12"" style="" min-height: 70px; border-radius: 0 0 5px 5px; text-align:center"">
                    <button id=""btnServiceSave"" type=""submit"" class=""save btn-action pl-4 pr-4 pt-2 pb-2"">Save</button>
                    <a id=""btnServiceCancel"" onclick=""ResetForm()"" class=""cancel btn-action ml-1"" style=""cursor:pointer; padding:12px 25px"">Cancel</a>
                </div>
");
#nullable restore
#line 115 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>

    </div>
</div>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js""></script>

<script type=""text/javascript"">

    $(""#btnCreate"").click(function () {
        OpenForm(""Create service"",0);
    });
    $("".edit-service"").click(function () {
        var id = $(this).attr(""oid"").replace(""object-"", """");
        OpenForm(""Update service"",id)
    });
    function OpenForm(type, id) {
        $(""#content"").append('');
        $(""#view-main"").css(""display"", ""block"");
        document.getElementById(""view-title"").children[0].innerHTML = type;
        $("".sidebar"").css(""pointer-events"", ""none"")


    }
    $(""#CloseForm"").click(function () {
        ResetForm();
    });

    function ResetForm() {
        CloseForm();
");
#nullable restore
#line 145 "C:\CSharp\epjSem3\Views\Auth\Service.cshtml"
          post_office.Controllers.Administrator.ServiceController.id = 0; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        er = document.getElementsByClassName(""_error"");
        for (var i = 0; i < er.length; i++) {
            $(er).html("""");
        }
        $(""#form-svc"").trigger(""reset"");

    }
    $('#btnServiceSave').click(function () {
        er = document.getElementsByClassName(""_error"");
        for (var i = 0; i < er.length; i++) {
            if ($(er[i]).length > 0) {
                $(er[i]).shake();
            }
        }
    });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<post_office.Models.ServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
