#pragma checksum "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
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
#line 1 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\_ViewImports.cshtml"
using WebCarApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\_ViewImports.cshtml"
using WebCarApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\_ViewImports.cshtml"
using WebCarApp.Services.Models.Car;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f82c57d182e128233fc85556397208b1d28e2a15", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebCarApp.Web.Models.OrderModels.OrderDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchBar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/OrderSearch.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<nav class=\"navbar navbar-expand-lg navbar-dark bg-dark\">\r\n\r\n    <div class=\"collapse navbar-collapse\" id=\"navbarTogglerDemo02\">\r\n        <ul class=\"navbar-nav mr-auto mt-2 mt-lg-0\">\r\n            <li class=\"nav-item active\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e6584", async() => {
                WriteLiteral("Create new Order<span class=\"sr-only\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n            <li class=\"nav-item active\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e7946", async() => {
                WriteLiteral("Show All Orders<span class=\"sr-only\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </li>
        </ul>
        <div class=""form-inline my-2 my-lg-0"">
            <input class=""OrderNumberFormControl"" type=""search"" placeholder=""Enter Order Number"" name=""orderNumber"" required>
            <button class=""btn btn-outline-light my-2 my-sm-0"" type=""submit"" name=""orderSearchButton"">Search</button>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e9579", async() => {
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
</nav>


<div style=""        position: relative;
        background: url(https://png.pngtree.com/thumb_back/fh260/background/20190223/ourmid/pngtree-order-system-management-stage-banner-background-lightgeometric-stagestairsorder-systemblue-image_83414.jpg) center;
        background-size: cover;
        height: 500px;
        width: 100%;
        z-index: 0;"">
    <div style=""background: rgba(0,0,0,0.3);position: absolute; top: 0; left:0; right:0; bottom: 0; "">&nbsp;</div>

    <h1 style=""color: white; font-weight:700; text-align: center; margin: 0; position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);"">
        Order Number:
        <br>
        ");
#nullable restore
#line 40 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
   Write(Model.OrderNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </h1>
</div>


<div class=""MyContainer"">
    <div class=""CarDetailsTable"">
        <div id=""carDetailsText"">
            <h1>
                Order Details:
            </h1>
        </div>

        <table class=""table table-bordered "">
            <tbody>
                <tr>
                    <td class=""success""><h4>Order Number:</h4> </td>
                    <td>");
#nullable restore
#line 57 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.OrderNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Order Status:</h4> </td>\r\n                    <td>");
#nullable restore
#line 61 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Purchase Date:</h4> </td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.PurchaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Purchase Price:</h4> </td>\r\n                    <td>");
#nullable restore
#line 69 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.PurchasePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                </tr>

            </tbody>
        </table>
        <div id=""carDetailsText"">
            <h1>
                Car Details:
            </h1>
        </div>
        <table class=""table table-bordered "">
            <tbody>
                <tr>
                    <td class=""success""><h4>Make:</h4> </td>
                    <td>");
#nullable restore
#line 83 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Model:</h4> </td>\r\n                    <td>");
#nullable restore
#line 87 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Model Year:</h4> </td>\r\n                    <td>");
#nullable restore
#line 91 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.ModelYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Vehicle identification number:</h4> </td>\r\n                    <td>");
#nullable restore
#line 95 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.VIN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Transmission:</h4> </td>\r\n                    <td>");
#nullable restore
#line 99 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Tranmission);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Fuel Type:</h4> </td>\r\n                    <td>");
#nullable restore
#line 103 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Car Color:</h4> </td>\r\n                    <td>");
#nullable restore
#line 107 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Car Price:</h4> </td>\r\n                    <td>");
#nullable restore
#line 111 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Cubic Centimeters:</h4> </td>\r\n                    <td>");
#nullable restore
#line 115 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.CubicCentimeters);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Horse Power:</h4> </td>\r\n                    <td>");
#nullable restore
#line 119 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.HorsePower);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Model Year:</h4> </td>\r\n                    <td>");
#nullable restore
#line 123 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.ModelYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Kilowatts:</h4> </td>\r\n                    <td>");
#nullable restore
#line 127 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.CarDetails.Kilowatt);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                </tr>

            </tbody>
        </table>
        <div id=""carDetailsText"">
            <h1>
                Client Details:
            </h1>
        </div>

        <table class=""table table-bordered "">
            <tbody>
                <tr>
                    <td class=""success""><h4>Client Name:</h4> </td>
                    <td>");
#nullable restore
#line 142 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.ClientDetails.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 142 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                                                  Write(Model.ClientDetails.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>EGN:</h4> </td>\r\n                    <td>");
#nullable restore
#line 146 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.ClientDetails.EGN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Email:</h4> </td>\r\n                    <td>");
#nullable restore
#line 150 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.ClientDetails.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"success\"><h4>Phone Number:</h4> </td>\r\n                    <td>");
#nullable restore
#line 154 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
                   Write(Model.ClientDetails.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                </tr>
                <tr>

            </tbody>
        </table>

    </div>
    <!-- you need to include the shieldui css and js assets in order for the charts to work -->
    <link rel=""stylesheet"" type=""text/css"" href=""http://www.shieldui.com/shared/components/latest/css/light-glow/all.min.css"" />
    <script type=""text/javascript"" src=""http://www.shieldui.com/shared/components/latest/js/shieldui-all.min.js""></script>

  

</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f841bf562caf4d1fa5cfde40d4ba6bf083e93c3e21865", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 169 "C:\Users\dimitar.sotirov\source\repos\WebCarApp\WebCarApp\Views\Orders\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebCarApp.Web.Models.OrderModels.OrderDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591