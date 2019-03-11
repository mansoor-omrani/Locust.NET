﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Locust.Extensions;
    using Locust.Test.Models;
    using Locust.Test.Mvc;
    using Locust.Test.Service;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Translation/Index.cshtml")]
    public partial class _Areas_Test_Views_Translation_Index_cshtml : Locust.WebTools.ClientAwareWebViewPage<dynamic>
    {
        public _Areas_Test_Views_Translation_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Test\Views\Translation\Index.cshtml"
  
    ViewBag.PageTitle = "Translation";
    ViewBag.Js = true;

    var items = (Dictionary<string, string[]>)ViewBag.Items;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Items</h2>\r\n<h3>Current Translator: ");

            
            #line 10 "..\..\Areas\Test\Views\Translation\Index.cshtml"
                   Write(ViewBag.TranslatorType);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n<center><button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btnLoad\"");

WriteLiteral(">Load</button></center>\r\n\r\n<table");

WriteLiteral(" class=\"table table-bordered table-condensed table-hover table-striped\"");

WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Value</t" +
"h>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");

            
            #line 21 "..\..\Areas\Test\Views\Translation\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 21 "..\..\Areas\Test\Views\Translation\Index.cshtml"
         foreach (var item in items)
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <td>");

            
            #line 24 "..\..\Areas\Test\Views\Translation\Index.cshtml"
               Write(item.Key);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td>");

            
            #line 25 "..\..\Areas\Test\Views\Translation\Index.cshtml"
                Write(item.Value?.Join(","));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n");

            
            #line 27 "..\..\Areas\Test\Views\Translation\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591