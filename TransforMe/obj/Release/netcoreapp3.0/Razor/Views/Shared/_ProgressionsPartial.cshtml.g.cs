#pragma checksum "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "311adf478ea9effe57161705a9131a12fc1b7316"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProgressionsPartial), @"mvc.1.0.view", @"/Views/Shared/_ProgressionsPartial.cshtml")]
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
#line 1 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
using TransforMe.Interface.Logics;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"311adf478ea9effe57161705a9131a12fc1b7316", @"/Views/Shared/_ProgressionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4ec0b91b79b8c728cf36ad21f665d948bca277", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProgressionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransforMe.ViewModels.ProgressionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
  
    IUserLogic userLogic = TransforMe.BLLFactory.LogicFactory.CreateUserLogic();
    var currentUser = userLogic.GetUser(User.Identity.Name);


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card mb-4 box-shadow rounded-0 prgpartial\">\r\n    <img id=\"prgimg\" class=\"card-img-top w-100 d-block rounded-0\"");
            BeginWriteAttribute("src", " src=\"", 364, "\"", 405, 1);
#nullable restore
#line 10 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
WriteAttributeValue("", 370, Url.Content(Model.ProgressPicture), 370, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 406, "\"", 521, 3);
            WriteAttributeValue("", 416, "location.href=\'", 416, 15, true);
#nullable restore
#line 10 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
WriteAttributeValue("", 431, Url.Action("UserProfile", "User", new { userId = userLogic.GetUser(Model.Username).Id }), 431, 89, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 520, "\'", 520, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"card-body\">\r\n        <h4 class=\"card-title\">");
#nullable restore
#line 12 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
                          Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <h6 class=\"text-muted card-subtitle mb-2\">Bodyweight : ");
#nullable restore
#line 13 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
                                                          Write(Model.Bodyweight);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KG</h6>\r\n        <h6 class=\"text-muted card-subtitle mb-2\">");
#nullable restore
#line 14 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
                                             Write(Model.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 15 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
          
            string deleteprgid = $"deleteMessage{Model.Id}";
            if (currentUser.Id == userLogic.GetUser(Model.Username).Id)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("id", " id=\"", 970, "\"", 987, 1);
#nullable restore
#line 19 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
WriteAttributeValue("", 975, deleteprgid, 975, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"float-right btn-danger msgdltbtn\">Delete</button>\r\n");
#nullable restore
#line 20 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<script>\r\n    document.getElementById(\'");
#nullable restore
#line 26 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
                        Write(deleteprgid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').onclick = function () {\r\n        alertify.confirm(\"Are you sure?\",\r\n                function () {\r\n                    location.href = \"");
#nullable restore
#line 29 "C:\Users\efali\Documents\GitHub\TransforMe\TransforMe\Views\Shared\_ProgressionsPartial.cshtml"
                                Write(Url.Action("DeleteProgression", "Progression", new {progressionId = Model.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n                }),\r\n            function() {\r\n                alertify.error(\'Cancelled\');\r\n            }\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TransforMe.ViewModels.ProgressionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
