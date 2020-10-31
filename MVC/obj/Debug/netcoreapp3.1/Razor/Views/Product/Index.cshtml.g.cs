#pragma checksum "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f61a8fc98756ecdf73b7a325cd5ebc7175569e68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 2 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\_ViewImports.cshtml"
using Entities.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\_ViewImports.cshtml"
using MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61a8fc98756ecdf73b7a325cd5ebc7175569e68", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee1f4bd72cb0c6233d7bfc0367c8858e364a7afb", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row mt-5\">\r\n        <div class=\"col-md-2\"></div>\r\n        <div class=\"col-md-8 text-center\">\r\n\r\n");
#nullable restore
#line 7 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
             if (ViewBag.ProcessStatus == "Succeeded" && ViewBag.ResponseMessage != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-success mt-4\">\r\n                    <small>");
#nullable restore
#line 10 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                      Write(ViewBag.ResponseMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                </div>\r\n");
#nullable restore
#line 12 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
            }
            
            else if (ViewBag.ProcessStatus == "Failed" && ViewBag.ResponseMessage != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-danger mt-4\">\r\n                    <small>");
#nullable restore
#line 17 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                      Write(ViewBag.ResponseMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n\r\n\r\n");
#nullable restore
#line 23 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
             if (Model.Count == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-danger mt-4\">\r\n                    <small>Ürün Bulunamadı.</small>\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"

            }
            else
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-hover"">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th>Category ID</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>

");
#nullable restore
#line 47 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                         foreach (Product product in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 50 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                           Write(product.ProductID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                           Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                           Write(product.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                           Write(product.CategoryID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1866, "\"", 1907, 2);
            WriteAttributeValue("", 1873, "/Product/Update/", 1873, 16, true);
#nullable restore
#line 55 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
WriteAttributeValue("", 1889, product.ProductID, 1889, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-primary\">Update</a></td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1999, "\"", 2040, 2);
            WriteAttributeValue("", 2006, "/Product/Delete/", 2006, 16, true);
#nullable restore
#line 56 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
WriteAttributeValue("", 2022, product.ProductID, 2022, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-danger\">Delete</a></td>\r\n                        </tr>\r\n");
#nullable restore
#line 58 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 62 "C:\Users\eren_\Desktop\PROJELER\LoggerWebAPI2\MVC\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\"></div>\r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591