#pragma checksum "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c319b40d708fedd1dacaff3406527b7051a55b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MessagesPartial), @"mvc.1.0.view", @"/Views/Shared/_MessagesPartial.cshtml")]
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
#line 2 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
using TransforMe.Interface.Logics;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c319b40d708fedd1dacaff3406527b7051a55b1", @"/Views/Shared/_MessagesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4ec0b91b79b8c728cf36ad21f665d948bca277", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MessagesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransforMe.ViewModels.MessageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
  
    IUserLogic userLogic = TransforMe.BLLFactory.LogicFactory.CreateUserLogic();

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 176, "\"", 272, 1);
#nullable restore
#line 7 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
WriteAttributeValue("", 183, Url.Action("UserProfile", "User", new { userId = userLogic.GetUser(Model.Username).Id }), 183, 89, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <img class=\"postimage\"");
            BeginWriteAttribute("src", " src=\"", 302, "\"", 333, 1);
#nullable restore
#line 8 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
WriteAttributeValue("", 308, Url.Content(Model.Image), 308, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"This is a profile picture.\">\r\n</a>\r\n<h1 style=\"font-size: 20px;padding-top: 2%;\">");
#nullable restore
#line 10 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
                                        Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<p class=\"d-xl-flex justify-content-xl-start\">");
#nullable restore
#line 11 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
                                         Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<small style=\"padding-right:2%;\" class=\"d-xl-flex justify-content-xl-end\">");
#nullable restore
#line 12 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_MessagesPartial.cshtml"
                                                                     Write(Model.PostedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TransforMe.ViewModels.MessageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
