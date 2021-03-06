#pragma checksum "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fbe4e0f0d575193a8d2ec74aa83a27356afa61e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_EditProfile), @"mvc.1.0.view", @"/Views/User/EditProfile.cshtml")]
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
#line 1 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
using TransforMe.BLLFactory;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fbe4e0f0d575193a8d2ec74aa83a27356afa61e", @"/Views/User/EditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4ec0b91b79b8c728cf36ad21f665d948bca277", @"/Views/_ViewImports.cshtml")]
    public class Views_User_EditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransforMe.ViewModels.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("edituser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
  
    ViewData["Title"] = "Edit profile";
    Layout = "~/Views/Shared/_UserLayout.cshtml";
    var _userLogic = LogicFactory.CreateUserLogic();
    var currentUser = _userLogic.GetUser(User.Identity.Name);
    string currentProfilepicture = "data:image/jpeg;base64," + Convert.ToBase64String(_userLogic.GetProfilePicture(currentUser.Id), 0, _userLogic.GetProfilePicture(currentUser.Id).Length);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"col midcol\">\r\n    <div class=\"form-holder\">\r\n        <h1>Edit profile</h1>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fbe4e0f0d575193a8d2ec74aa83a27356afa61e5461", async() => {
                WriteLiteral("\r\n            <div class=\"form-group profilepicform\">\r\n                <img id=\"uploadImage\" class=\"editprofilepic\"");
                BeginWriteAttribute("src", " src=\"", 798, "\"", 839, 1);
#nullable restore
#line 17 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 804, Url.Content(currentProfilepicture), 804, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <input name=\"picture\" id=\"outImage\" onChange=\"preview_2(this);\" type=\"file\" class=\"picinput\"");
                BeginWriteAttribute("value", " value=\"", 951, "\"", 992, 1);
#nullable restore
#line 18 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 959, currentProfilepicture.ToString(), 959, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group names\">\r\n                <input name=\"firstname\" class=\"form-control username-input\" type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1147, "\"", 1177, 1);
#nullable restore
#line 21 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1161, Model.Firstname, 1161, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1178, "\"", 1202, 1);
#nullable restore
#line 21 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1186, Model.Firstname, 1186, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group names\">\r\n                <input name=\"lastname\" class=\"form-control username-input\" type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1356, "\"", 1385, 1);
#nullable restore
#line 24 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1370, Model.Lastname, 1370, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1386, "\"", 1409, 1);
#nullable restore
#line 24 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1394, Model.Lastname, 1394, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group names\">\r\n                <input name=\"username\" class=\"form-control username-input\" type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1563, "\"", 1592, 1);
#nullable restore
#line 27 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1577, Model.Username, 1577, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1593, "\"", 1616, 1);
#nullable restore
#line 27 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1601, Model.Username, 1601, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input class=\"form-control\" type=\"password\" name=\"password\" placeholder=\"New password\"");
                BeginWriteAttribute("value", " value=\"", 1780, "\"", 1803, 1);
#nullable restore
#line 30 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 1788, Model.Password, 1788, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 50%; \">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input class=\"form-control\" type=\"password\" name=\"repeatpassword\" placeholder=\"Repeat password\"");
                BeginWriteAttribute("value", " value=\"", 1997, "\"", 2020, 1);
#nullable restore
#line 33 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\User\EditProfile.cshtml"
WriteAttributeValue("", 2005, Model.Password, 2005, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 50%;\">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <button class=\"btn btn-outline-info btn-block custombtn\" type=\"submit\">Submit</button>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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

<script>
    var outImage = ""uploadImage"";
    function preview_2(obj) {
        if (FileReader) {
            var reader = new FileReader();
            reader.readAsDataURL(obj.files[0]);
            reader.onload = function (e) {
                var image = new Image();
                image.src = e.target.result;
                image.onload = function () {
                    document.getElementById(outImage).src = image.src;
                };
            }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TransforMe.ViewModels.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
