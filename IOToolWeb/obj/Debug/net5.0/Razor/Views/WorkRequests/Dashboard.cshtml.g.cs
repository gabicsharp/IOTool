#pragma checksum "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdb02c648a9f7c455cc2fcbeec4ad2f0c0bad8de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkRequests_Dashboard), @"mvc.1.0.view", @"/Views/WorkRequests/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdb02c648a9f7c455cc2fcbeec4ad2f0c0bad8de", @"/Views/WorkRequests/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430edc1c8f818eff5d4d1750e439cbdb0c07bb51", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkRequests_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IOToolDataLibrary.Models.CustomTables.NewRequestClosedModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
   ViewData["Title"] = "Dashboard"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""card-title"">Request List</h5>
                    <h6 class=""card-subtitle text-muted"">List with all requests closed in IOTool.</h6>
                </div>
                <div class=""card-body"">
                    <table class=""table table-striped"" id=""table_dashboard"" width=""100%"">
                        <thead class=""thead-grey"">
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 18 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 21 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.RequestType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 24 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.TransportType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 27 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Week));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 30 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ETD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 33 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ETA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 36 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.From));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 39 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.FromLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 42 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.To));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 45 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ToLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 48 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 51 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Transporter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 54 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.AWB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 57 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 60 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.CostCenter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 63 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.BillNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 66 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.PalletNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 69 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.PricePallet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                            </tr>\n                        </thead>\n                        <tbody>\n");
#nullable restore
#line 74 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>\n                                    ");
#nullable restore
#line 78 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 81 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.RequestType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 84 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.TransportType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 87 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Week));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 90 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ETD.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 90 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.ETD.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 90 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                                                                                                                         Write(Html.DisplayFor(modelItem => item.ETD.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 93 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ETA.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 93 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.ETA.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 93 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                                                                                                                         Write(Html.DisplayFor(modelItem => item.ETA.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 96 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.From));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 99 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FromLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 102 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.To));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 105 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ToLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 108 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 111 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Transporter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 114 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.AWB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 117 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 120 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CostCenter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 123 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.BillNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 126 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PalletNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 129 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PricePallet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n\n                            </tr>\n");
#nullable restore
#line 133 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\n                        <tfoot>\n                            <tr>\n                                <th>\n                                    ");
#nullable restore
#line 138 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 141 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.RequestType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 144 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.TransportType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 147 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Week));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 150 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ETD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 153 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ETA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 156 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.From));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 159 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.FromLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 162 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.To));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 165 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.ToLocation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 168 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 171 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Transporter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 174 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.AWB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 177 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 180 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.CostCenter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 183 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.BillNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 186 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.PalletNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </th>\n                                <th>\n                                    ");
#nullable restore
#line 189 "D:\DSUsers\uidn3769\CodeShee\IOTool\IOToolWeb\Views\WorkRequests\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.PricePallet));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $('#table_dashboard tfoot th').each(function () {
        var title = $('#example thead th').eq($(this).index()).text();
        $(this).html('<input type=""text"" placeholder=""Search ' + title + '"" />');
    });

    $('#table_dashboard').DataTable({
        dom: 'Bfrtip',
        buttons: [
            { extend: 'csv', title: 'IOTool Dashboard', className: 'btn btn-table' },
            { extend: 'print', className: 'btn btn-table' }
        ],
        responsive: true,
    });
    var table = $('#table_dashboard').DataTable();

    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
                .search(this.value)
                .draw();
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IOToolDataLibrary.Models.CustomTables.NewRequestClosedModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
