#pragma checksum "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d9760bb95076c401e390405ed71f4a9fea26081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserProfile), @"mvc.1.0.view", @"/Views/User/UserProfile.cshtml")]
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
#line 1 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\_ViewImports.cshtml"
using TransforMe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\_ViewImports.cshtml"
using TransforMe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9760bb95076c401e390405ed71f4a9fea26081", @"/Views/User/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4ec0b91b79b8c728cf36ad21f665d948bca277", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransforMe.ViewModels.ProfileViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
  
    ViewData["Title"] = "UserProfile";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col midcol\" style=\"width: auto;\">\r\n    <div class=\"text-center box\">\r\n        <img class=\"rounded-circle\"");
            BeginWriteAttribute("src", " src=\"", 266, "\"", 326, 1);
#nullable restore
#line 10 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
WriteAttributeValue("", 272, Url.Content(ViewData["profileProfilepic"].ToString()), 272, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 150px;max-width: 100%;\">\r\n        <h3 class=\"name\">");
#nullable restore
#line 11 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                    Write(ViewData["profilefirstname"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                                  Write(ViewData["profilelastname"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <p class=\"title\" style=\"font-size: 12px;\">");
#nullable restore
#line 12 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                             Write(ViewData["profilefollowers"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" FOLLOWERS | ");
#nullable restore
#line 12 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                                                                       Write(ViewData["profilefollowing"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" FOLLOWING</p>
        <div class=""btn-group"" role=""group""><button class=""btn btn-primary"" type=""button"">Follow</button><button class=""btn btn-primary"" type=""button"">Like&nbsp;</button></div>
    </div>
    <div>
        <ul class=""nav nav-tabs"" style=""width:100%"">
            <li class=""nav-item"" style=""width:50%;""><a class=""nav-link active text-center"" role=""tab"" data-toggle=""tab"" href=""#tab-1"" style=""min-width: 300px;"">Messages</a></li>
            <li class=""nav-item"" style=""width:50%;""><a class=""nav-link text-center"" role=""tab"" data-toggle=""tab"" href=""#tab-2"" style=""min-width: 370px;"">Progressions</a></li>
        </ul>
        <div style=""border-left:1px solid; border-right:1px solid; border-bottom:1px solid; border-color:#DEE2E6"">
            <div class=""tab-content"">
                <div class=""tab-pane active"" role=""tabpanel"" id=""tab-1"">
                    <div class=""text-left"" style=""margin-bottom: 1%;min-height: 16%;"">
");
#nullable restore
#line 24 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                         foreach (var item in Model.Messages)
                        {
                            Html.RenderPartial("_MessagesPartial", item);
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"tab-pane text-center\" role=\"tabpanel\" id=\"tab-2\">\r\n");
#nullable restore
#line 31 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                     foreach (var item in Model.Progressions)
                    {
                        Html.RenderPartial("_ProgressionsPartial", item);
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TransforMe.ViewModels.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
