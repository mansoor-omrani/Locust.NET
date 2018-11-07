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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Home/Login.cshtml")]
    public partial class _Areas_Test_Views_Home_Login_cshtml : Locust.WebTools.ClientAwareWebViewPage<Locust.Test.Models.LoginViewModel>
    {
        public _Areas_Test_Views_Home_Login_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Areas\Test\Views\Home\Login.cshtml"
  
    ViewBag.PageTitle = "Login";
    Layout = "~/Areas/Test/Views/Shared/_NotAuthenticatedLayout.cshtml";
    var returnUrl = "?returnurl=" + ViewData["returnurl"]?.ToString() ?? "";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-sm-offset-4 col-sm-4\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Areas\Test\Views\Home\Login.cshtml"
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Test\Views\Home\Login.cshtml"
             if (ViewData["Message"] != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"alert alert-danger\"");

WriteLiteral(">");

            
            #line 14 "..\..\Areas\Test\Views\Home\Login.cshtml"
                                           Write(ViewBag.Message);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 15 "..\..\Areas\Test\Views\Home\Login.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <form");

WriteLiteral(" class=\"form-horizontal\"");

WriteAttribute("action", Tuple.Create(" action=\"", 549), Tuple.Create("\"", 599)
            
            #line 16 "..\..\Areas\Test\Views\Home\Login.cshtml"
, Tuple.Create(Tuple.Create("", 558), Tuple.Create<System.Object, System.Int32>(Localize("/test/home/login" + returnUrl)
            
            #line default
            #line hidden
, 558), false)
);

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"username\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">UserName</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"username\"");

WriteLiteral(" id=\"username\"");

WriteAttribute("value", Tuple.Create(" value=\"", 830), Tuple.Create("\"", 853)
            
            #line 19 "..\..\Areas\Test\Views\Home\Login.cshtml"
                  , Tuple.Create(Tuple.Create("", 838), Tuple.Create<System.Object, System.Int32>(Model.UserName
            
            #line default
            #line hidden
, 838), false)
);

WriteLiteral(" />\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"password\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">Password</label>\r\n                    <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"password\"");

WriteLiteral(" id=\"password\"");

WriteLiteral(" />\r\n                </div>\r\n\r\n                <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default btn-md\"");

WriteLiteral(">Login</button>\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
