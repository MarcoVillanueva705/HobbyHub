#pragma checksum "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2d61b1cef3bb797307078224b676fe86ec50bb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DashBoard), @"mvc.1.0.view", @"/Views/Home/DashBoard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/DashBoard.cshtml", typeof(AspNetCore.Views_Home_DashBoard))]
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
#line 1 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\_ViewImports.cshtml"
using HobbyHub;

#line default
#line hidden
#line 2 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\_ViewImports.cshtml"
using HobbyHub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2d61b1cef3bb797307078224b676fe86ec50bb5", @"/Views/Home/DashBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b43894b7f1b1132efb6bd8d82f780aceacb1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DashBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hobby>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/rafting.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(14, 234, true);
            WriteLiteral("\r\n    <a href=\"/logout\">Log Out</a><br><br>\r\n\r\n<h1>Hobbies</h1>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Enthusiasts</th>\r\n        </tr>\r\n    </thead>\r\n    \r\n    <tbody>\r\n        \r\n");
            EndContext();
#line 16 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml"
         foreach (var hobby in @ViewBag.Allhobbies)
    {

#line default
#line hidden
            BeginContext(308, 28, true);
            WriteLiteral("        <tr>\r\n        <th><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 336, "\"", 370, 2);
            WriteAttributeValue("", 343, "ShowOneHobby/", 343, 13, true);
#line 19 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml"
WriteAttributeValue("", 356, hobby.HobbyId, 356, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(371, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(373, 10, false);
#line 19 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml"
                                             Write(hobby.Name);

#line default
#line hidden
            EndContext();
            BeginContext(383, 38, true);
            WriteLiteral("</a></th>\r\n        <td align = \"left\">");
            EndContext();
            BeginContext(422, 15, false);
#line 20 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml"
                      Write(hobby.Fan.Count);

#line default
#line hidden
            EndContext();
            BeginContext(437, 32, true);
            WriteLiteral("</td>\r\n        \r\n        </tr>\r\n");
            EndContext();
#line 23 "C:\Users\Bruch\Desktop\CodingDojo\C#\HobbyHub\Views\Home\DashBoard.cshtml"
    }

#line default
#line hidden
            BeginContext(476, 71, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<a href=\"/createHobby\">Create a Hobby</a>\r\n\r\n");
            EndContext();
            BeginContext(547, 34, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4634f6420e9949d697ecde8d19fc5836", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(581, 14, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hobby> Html { get; private set; }
    }
}
#pragma warning restore 1591