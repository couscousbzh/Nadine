#pragma checksum "D:\Projets\Git\Nadine\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dce3f0d0ca35c3b6ea066c5532f6df6101b8773b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Nadine.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(Nadine.Pages.Pages_Index), null)]
namespace Nadine.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Projets\Git\Nadine\Pages\_ViewImports.cshtml"
using Nadine;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dce3f0d0ca35c3b6ea066c5532f6df6101b8773b", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a63cfc3360697a570ac9a3a36eadaff49d6bcabf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(79, 46, false);
#line 4 "D:\Projets\Git\Nadine\Pages\Index.cshtml"
Write(await Html.PartialAsync("Samples/CounterView"));

#line default
#line hidden
            EndContext();
            BeginContext(125, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(191, 229, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 col-sm-12 col-xs-12\">\r\n        <h1>Usibox</h1>\r\n        <h2>V3.0.1</h2>\r\n        <p>Bienvenue sur le site d\'administration de votre Usibox.</p>\r\n        <p> ASPNETCORE_ENVIRONMENT = ");
            EndContext();
            BeginContext(421, 26, false);
#line 17 "D:\Projets\Git\Nadine\Pages\Index.cshtml"
                                Write(hostingEnv.EnvironmentName);

#line default
#line hidden
            EndContext();
            BeginContext(447, 44, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Index> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index>)PageContext?.ViewData;
        public Pages_Index Model => ViewData.Model;
    }
}
#pragma warning restore 1591