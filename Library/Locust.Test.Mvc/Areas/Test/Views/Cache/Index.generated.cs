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
    
    #line 3 "..\..\Areas\Test\Views\Cache\Index.cshtml"
    using Locust.Caching;
    
    #line default
    #line hidden
    using Locust.Extensions;
    using Locust.Test.Models;
    using Locust.Test.Mvc;
    using Locust.Test.Service;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Cache/Index.cshtml")]
    public partial class _Areas_Test_Views_Cache_Index_cshtml : Locust.WebTools.ClientAwareWebViewPage<dynamic>
    {
        public _Areas_Test_Views_Cache_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\Test\Views\Cache\Index.cshtml"
  
    ViewBag.PageTitle = "Index";
    var factory = (ICacheFactory)ViewBag.Factory;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1>Index</h1>\r\n<ul>\r\n");

            
            #line 12 "..\..\Areas\Test\Views\Cache\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Test\Views\Cache\Index.cshtml"
     foreach (var item in factory.GetNames())
    {

            
            #line default
            #line hidden
WriteLiteral("        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 238), Tuple.Create("\"", 282)
            
            #line 14 "..\..\Areas\Test\Views\Cache\Index.cshtml"
, Tuple.Create(Tuple.Create("", 245), Tuple.Create<System.Object, System.Int32>(Localize("/test/cache/page/" + item)
            
            #line default
            #line hidden
, 245), false)
);

WriteLiteral(">");

            
            #line 14 "..\..\Areas\Test\Views\Cache\Index.cshtml"
                                                       Write(item);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 15 "..\..\Areas\Test\Views\Cache\Index.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>");

        }
    }
}
#pragma warning restore 1591
