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
    using Locust.Test.Models;
    using Locust.Test.Mvc;
    using Locust.Test.Service;
    
    #line 2 "..\..\Areas\Test\Views\Cache\Page.cshtml"
    using Locust.WebExtensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Cache/Page.cshtml")]
    public partial class _Areas_Test_Views_Cache_Page_cshtml : Locust.WebTools.ClientAwareWebViewPage<dynamic>
    {
        public _Areas_Test_Views_Cache_Page_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Areas\Test\Views\Cache\Page.cshtml"
  
    ViewBag.PageTitle = "Page";
    ViewBag.Css = true;
    ViewBag.Js = true;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Using ");

            
            #line 9 "..\..\Areas\Test\Views\Cache\Page.cshtml"
     Write(ViewBag.CacheName);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" class=\"form-inline\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"txtKey\"");

WriteLiteral(">Key</label>\r\n            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"txtKey\"");

WriteLiteral(" id=\"txtKey\"");

WriteLiteral(" placeholder=\"\"");

WriteLiteral(">\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"txtLifeLength\"");

WriteLiteral(">Life Length</label>\r\n            <input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"txtLifeLength\"");

WriteLiteral(" name=\"txtLifeLength\"");

WriteLiteral(" placeholder=\"in seconds e.g. 600\"");

WriteLiteral(">\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"txtDependentKey\"");

WriteLiteral(">Dependent Key</label>\r\n            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"txtDependentKey\"");

WriteLiteral(" id=\"txtDependentKey\"");

WriteLiteral(" placeholder=\"\"");

WriteLiteral(">\r\n        </div>\r\n    </form>\r\n    <br />\r\n    <form");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" class=\"col-sm-2 control-label\"");

WriteLiteral(" for=\"txtValue\"");

WriteLiteral(">Value</label>\r\n            <div");

WriteLiteral(" class=\"col-sm-10\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"txtValue\"");

WriteLiteral(" name=\"txtValue\"");

WriteLiteral("></textarea>\r\n            </div>\r\n        </div>\r\n    </form>\r\n    <div");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnAdd\"");

WriteLiteral(">Add</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnRemove\"");

WriteLiteral(">Remove</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnContains\"");

WriteLiteral(">Contains</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnGet\"");

WriteLiteral(">Get</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnTryGet\"");

WriteLiteral(" title=\"try to get cached item based on another cached item\"");

WriteLiteral(">TryGet</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnGetItem\"");

WriteLiteral(" title=\"Get cached item and its related setting\"");

WriteLiteral(">Get Item</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnClean\"");

WriteLiteral(" title=\"Clean cache (remove dead and expired items)\"");

WriteLiteral(">Clean</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnClear\"");

WriteLiteral(" title=\"Clear cache (remove all items)\"");

WriteLiteral(">Clear</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnCount\"");

WriteLiteral(" title=\"Get the number of items in the cache\"");

WriteLiteral(">Count</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnReset\"");

WriteLiteral(">Reset</button>\r\n    </div>\r\n</div>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2273), Tuple.Create("\"", 2292)
            
            #line 49 "..\..\Areas\Test\Views\Cache\Page.cshtml"
, Tuple.Create(Tuple.Create("", 2281), Tuple.Create<System.Object, System.Int32>(ViewBag.Id
            
            #line default
            #line hidden
, 2281), false)
);

WriteLiteral(" id=\"PageId\"");

WriteLiteral(" />\r\n<div");

WriteLiteral(" id=\"divMessage\"");

WriteLiteral("></div>\r\n");

        }
    }
}
#pragma warning restore 1591
