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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Shared/TestList.cshtml")]
    public partial class _Areas_Test_Views_Shared_TestList_cshtml : Locust.WebTools.ClientAwareWebViewPage<dynamic>
    {
        public _Areas_Test_Views_Shared_TestList_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
  
    Func<string, string> isActive =
        arg =>
            string.Compare(ViewContext.RouteData.Values["controller"]?.ToString()?.ToLower(),
                    arg, StringComparison.InvariantCultureIgnoreCase) == 0 ? "active" : "";

            
            #line default
            #line hidden
WriteLiteral("\r\n<h2>Tests</h2>\r\n<div");

WriteLiteral(" class=\"list-group\"");

WriteLiteral(">\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 322), Tuple.Create("\"", 362)
            
            #line 10 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 329), Tuple.Create<System.Object, System.Int32>(Localize("/test/requestinspect")
            
            #line default
            #line hidden
, 329), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 363), Tuple.Create("\"", 414)
, Tuple.Create(Tuple.Create("", 371), Tuple.Create("list-group-item", 371), true)
            
            #line 10 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 386), Tuple.Create<System.Object, System.Int32>(isActive("requestinspect")
            
            #line default
            #line hidden
, 387), false)
);

WriteLiteral(">\r\n        Request Inspector\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 461), Tuple.Create("\"", 491)
            
            #line 13 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 468), Tuple.Create<System.Object, System.Int32>(Localize("/test/dirs")
            
            #line default
            #line hidden
, 468), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 492), Tuple.Create("\"", 533)
, Tuple.Create(Tuple.Create("", 500), Tuple.Create("list-group-item", 500), true)
            
            #line 13 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 515), Tuple.Create<System.Object, System.Int32>(isActive("dirs")
            
            #line default
            #line hidden
, 516), false)
);

WriteLiteral(">\r\n        Directories\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 574), Tuple.Create("\"", 605)
            
            #line 16 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 581), Tuple.Create<System.Object, System.Int32>(Localize("/test/cache")
            
            #line default
            #line hidden
, 581), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 606), Tuple.Create("\"", 648)
, Tuple.Create(Tuple.Create("", 614), Tuple.Create("list-group-item", 614), true)
            
            #line 16 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 629), Tuple.Create<System.Object, System.Int32>(isActive("cache")
            
            #line default
            #line hidden
, 630), false)
);

WriteLiteral(">\r\n        Cache\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 683), Tuple.Create("\"", 719)
            
            #line 19 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 690), Tuple.Create<System.Object, System.Int32>(Localize("/test/servervars")
            
            #line default
            #line hidden
, 690), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 720), Tuple.Create("\"", 767)
, Tuple.Create(Tuple.Create("", 728), Tuple.Create("list-group-item", 728), true)
            
            #line 19 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 743), Tuple.Create<System.Object, System.Int32>(isActive("servervars")
            
            #line default
            #line hidden
, 744), false)
);

WriteLiteral(">\r\n        Server Variables\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 813), Tuple.Create("\"", 851)
            
            #line 22 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 820), Tuple.Create<System.Object, System.Int32>(Localize("/test/dbconnection")
            
            #line default
            #line hidden
, 820), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 852), Tuple.Create("\"", 901)
, Tuple.Create(Tuple.Create("", 860), Tuple.Create("list-group-item", 860), true)
            
            #line 22 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 875), Tuple.Create<System.Object, System.Int32>(isActive("dbconnection")
            
            #line default
            #line hidden
, 876), false)
);

WriteLiteral(">\r\n        Db Connection\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 944), Tuple.Create("\"", 974)
            
            #line 25 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 951), Tuple.Create<System.Object, System.Int32>(Localize("/test/mail")
            
            #line default
            #line hidden
, 951), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 975), Tuple.Create("\"", 1016)
, Tuple.Create(Tuple.Create("", 983), Tuple.Create("list-group-item", 983), true)
            
            #line 25 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 998), Tuple.Create<System.Object, System.Int32>(isActive("mail")
            
            #line default
            #line hidden
, 999), false)
);

WriteLiteral(">\r\n        Mail\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1050), Tuple.Create("\"", 1079)
            
            #line 28 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 1057), Tuple.Create<System.Object, System.Int32>(Localize("/test/sms")
            
            #line default
            #line hidden
, 1057), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 1080), Tuple.Create("\"", 1120)
, Tuple.Create(Tuple.Create("", 1088), Tuple.Create("list-group-item", 1088), true)
            
            #line 28 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 1103), Tuple.Create<System.Object, System.Int32>(isActive("sms")
            
            #line default
            #line hidden
, 1104), false)
);

WriteLiteral(">\r\n        Sms\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1153), Tuple.Create("\"", 1191)
            
            #line 31 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 1160), Tuple.Create<System.Object, System.Int32>(Localize("/test/notification")
            
            #line default
            #line hidden
, 1160), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 1192), Tuple.Create("\"", 1241)
, Tuple.Create(Tuple.Create("", 1200), Tuple.Create("list-group-item", 1200), true)
            
            #line 31 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 1215), Tuple.Create<System.Object, System.Int32>(isActive("notification")
            
            #line default
            #line hidden
, 1216), false)
);

WriteLiteral(">\r\n        Notification\r\n    </a>\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1283), Tuple.Create("\"", 1320)
            
            #line 34 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create("", 1290), Tuple.Create<System.Object, System.Int32>(Localize("/test/translation")
            
            #line default
            #line hidden
, 1290), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 1321), Tuple.Create("\"", 1369)
, Tuple.Create(Tuple.Create("", 1329), Tuple.Create("list-group-item", 1329), true)
            
            #line 34 "..\..\Areas\Test\Views\Shared\TestList.cshtml"
, Tuple.Create(Tuple.Create(" ", 1344), Tuple.Create<System.Object, System.Int32>(isActive("translation")
            
            #line default
            #line hidden
, 1345), false)
);

WriteLiteral(">\r\n        Translation\r\n    </a>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
