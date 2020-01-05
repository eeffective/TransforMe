#pragma checksum "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0ba78c80541b489d79d3cf5fdffbb375b435933"
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
#nullable restore
#line 2 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
using TransforMe.Interface.Logics;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0ba78c80541b489d79d3cf5fdffbb375b435933", @"/Views/User/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4ec0b91b79b8c728cf36ad21f665d948bca277", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransforMe.ViewModels.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
  
    ViewData["Title"] = "UserProfile";
    Layout = "~/Views/Shared/_UserLayout.cshtml";
    IUserLogic userLogic = TransforMe.BLLFactory.LogicFactory.CreateUserLogic();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
  
    TempData["userId"] = Model.Id;
    var currentUser = userLogic.GetUser(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col midcol\" style=\"width: auto;\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0ba78c80541b489d79d3cf5fdffbb375b4359335317", async() => {
                WriteLiteral("\r\n        <div class=\"text-center box\">\r\n            <img class=\"rounded-circle\"");
                BeginWriteAttribute("src", " src=\"", 535, "\"", 586, 1);
#nullable restore
#line 17 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
WriteAttributeValue("", 541, Url.Content(Model.ProfilePicture.ToString()), 541, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 150px;max-width: 100%;\">\r\n            <h3 class=\"name\">");
#nullable restore
#line 18 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                        Write(Model.Firstname);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 18 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                         Write(Model.Lastname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n            <p class=\"title\" style=\"font-size: 12px;\">");
#nullable restore
#line 19 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                                 Write(Model.Followers);

#line default
#line hidden
#nullable disable
                WriteLiteral(" FOLLOWERS | ");
#nullable restore
#line 19 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                                                              Write(Model.Following);

#line default
#line hidden
#nullable disable
                WriteLiteral(" FOLLOWING</p>\r\n");
#nullable restore
#line 20 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
             if (currentUser.Id != Model.Id)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"btn-group\" role=\"group\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0ba78c80541b489d79d3cf5fdffbb375b4359337672", async() => {
#nullable restore
#line 23 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                                                                                                                                                                                                                                       Write(TempData["followstatus"].ToString());

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 988, "location.href=\'", 988, 15, true);
#nullable restore
#line 23 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
AddHtmlAttributeValue("", 1003, Url.Action("UserProfile", "User", new { userId = userLogic.GetUser(Model.Username).Id, followerId = currentUser.Id }), 1003, 118, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 1121, "\'", 1121, 1, true);
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <button class=\"btn btn-primary\" type=\"button\">LIKE&nbsp;</button>\r\n                </div>\r\n");
#nullable restore
#line 26 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

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
#line 40 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                         foreach (var item in Model.Messages)
                        {
                            Html.RenderPartial("_MessagesPartial", item);
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"tab-pane text-center\" role=\"tabpanel\" id=\"tab-2\">\r\n");
#nullable restore
#line 47 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\UserProfile.cshtml"
                     foreach (var item in Model.Progressions)
                    {
                        Html.RenderPartial("_ProgressionsPartial", item);
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
