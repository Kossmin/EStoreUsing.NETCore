#pragma checksum "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84411c59fe25b5de3ff1ef0730b0959158f5289c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "D:\Demo\Ass03Solution\eStore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Demo\Ass03Solution\eStore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84411c59fe25b5de3ff1ef0730b0959158f5289c", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
  
    foreach (var item in Model.Orders)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"accordion-item\">\r\n        <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 150, "\"", 168, 1);
#nullable restore
#line 10 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
WriteAttributeValue("", 155, item.OrderId, 155, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <button class=\"accordion-button\" type=\"button\" data-toggle=\"collapse\" data-target=\"#order-");
#nullable restore
#line 11 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                                                                                 Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\" aria-controls=\"collapseOne\">\r\n                Order number #");
#nullable restore
#line 12 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                         Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </button>\r\n        </h2>\r\n");
#nullable restore
#line 15 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
          
            if (item.isOrdered == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("id", " id=\"", 512, "\"", 536, 2);
            WriteAttributeValue("", 517, "order-", 517, 6, true);
#nullable restore
#line 18 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
WriteAttributeValue("", 523, item.OrderId, 523, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""accordion-collapse collapse show"" aria-labelledby=""headingOne"">
                    <div class=""accordion-body"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th scope=""col"">Name</th>
                                    <th scope=""col"">Unit Price</th>
                                    <th scope=""col"">Quantity</th>
                                </tr>
                            </thead>
");
#nullable restore
#line 28 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                              
                                var orderdetailObject = (from a in Model.OrderDetails where a.OrderId == item.OrderId select a).ToList().OrderBy(p => p.ProductId);
                                foreach (var orderdetail in orderdetailObject)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tbody>\r\n                                        <tr>\r\n                                            <td>");
#nullable restore
#line 35 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 36 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 37 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                    </tbody>\r\n");
#nullable restore
#line 40 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                }


                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n\r\n                    </div>\r\n                </div> ");
#nullable restore
#line 47 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                       }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("id", " id=\"", 2017, "\"", 2041, 2);
            WriteAttributeValue("", 2022, "order-", 2022, 6, true);
#nullable restore
#line 50 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2028, item.OrderId, 2028, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""accordion-collapse collapse"" aria-labelledby=""headingOne"">
                    <div class=""accordion-body"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th scope=""col"">Name</th>
                                    <th scope=""col"">Unit Price</th>
                                    <th scope=""col"">Quantity</th>
                                </tr>
                            </thead>
");
#nullable restore
#line 60 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                              
                                var orderdetailObject = (from a in Model.OrderDetails where a.OrderId == item.OrderId select a).ToList().OrderBy(p => p.ProductId);
                                foreach (var orderdetail in orderdetailObject)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tbody>\r\n                                        <tr>\r\n                                            <td>");
#nullable restore
#line 67 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 68 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 69 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                           Write(orderdetail.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                    </tbody>\r\n");
#nullable restore
#line 72 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 78 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 81 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
    }
    if ((Model.Orders.FirstOrDefault(p => p.isOrdered == false)) != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84411c59fe25b5de3ff1ef0730b0959158f5289c11989", async() => {
                WriteLiteral("Check out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 85 "D:\Demo\Ass03Solution\eStore\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
