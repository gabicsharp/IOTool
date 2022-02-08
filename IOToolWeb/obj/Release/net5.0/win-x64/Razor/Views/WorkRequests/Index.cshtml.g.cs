#pragma checksum "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d8a88048b7e1aef6c74a4862b5aa2495614e3e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkRequests_Index), @"mvc.1.0.view", @"/Views/WorkRequests/Index.cshtml")]
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
#line 1 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\_ViewImports.cshtml"
using IOToolWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\_ViewImports.cshtml"
using IOToolWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d8a88048b7e1aef6c74a4862b5aa2495614e3e5", @"/Views/WorkRequests/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430edc1c8f818eff5d4d1750e439cbdb0c07bb51", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkRequests_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IOToolDataLibrary.Models.CustomTables.NewWorkRequestModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-card3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-card"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-card2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""card-title"">Request List To Process</h5>
                    <h6 class=""card-subtitle text-muted"">List with all requests for process registered in IOTool.</h6>
                </div>
                <div class=""card-body"">
                    <div class=""row col-12"">
");
#nullable restore
#line 15 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                         foreach (var item in Model)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                             if (item.Id_StatusRequest == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-6 col-md-6 col-lg-6"">
                                    <div class=""card"" style=""background-color:#D7004B;"">
                                        <div class=""card-header"">
                                            <h5 class=""card-title mb-0"">#");
#nullable restore
#line 22 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            <p class=\"card-text\">From: <b>");
#nullable restore
#line 25 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                     Write(item.From);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">To: <b>");
#nullable restore
#line 26 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   Write(item.To);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">Status: <b>");
#nullable restore
#line 27 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                       Write(item.StatusRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d8a88048b7e1aef6c74a4862b5aa2495614e3e57920", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 33 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                             if (item.Id_StatusRequest == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-6 col-md-6 col-lg-6"">
                                    <div class=""card"" style=""background-color:#F2E500;"">
                                        <div class=""card-header"">
                                            <h5 class=""card-title mb-0"">#");
#nullable restore
#line 39 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            <p class=\"card-text\">From: <b>");
#nullable restore
#line 42 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                     Write(item.From);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">To: <b>");
#nullable restore
#line 43 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   Write(item.To);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">Status: <b>");
#nullable restore
#line 44 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                       Write(item.StatusRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d8a88048b7e1aef6c74a4862b5aa2495614e3e512684", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d8a88048b7e1aef6c74a4862b5aa2495614e3e514987", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 50 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                             if (item.Id_StatusRequest == 3)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-6 col-md-6 col-lg-6"">
                                    <div class=""card"" style=""background-color: #4B4B46; color:#FFFFFF;"">
                                        <div class=""card-header"">
                                            <h5 class=""card-title mb-0"" style=""color: #FFFFFF;"">#");
#nullable restore
#line 56 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                                            Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        </div>\r\n                                        <div class=\"card-body\">\r\n                                            <p class=\"card-text\">From: <b>");
#nullable restore
#line 59 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                     Write(item.From);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">To: <b>");
#nullable restore
#line 60 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   Write(item.To);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            <p class=\"card-text\">Status: <b>");
#nullable restore
#line 61 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                       Write(item.StatusRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d8a88048b7e1aef6c74a4862b5aa2495614e3e519789", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 66 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Index.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IOToolDataLibrary.Models.CustomTables.NewWorkRequestModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
