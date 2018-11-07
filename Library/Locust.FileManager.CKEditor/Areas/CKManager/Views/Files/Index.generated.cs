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
    using Locust.FileManager.CKEditor;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CKManager/Views/Files/Index.cshtml")]
    public partial class _Areas_CKManager_Views_Files_Index_cshtml : Locust.WebTools.ClientAwareWebViewPage<dynamic>
    {
        public _Areas_CKManager_Views_Files_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
  
    ViewBag.PageTitle = "Files";
    ViewBag.Css = true;
    ViewBag.Js = true;

            
            #line default
            #line hidden
WriteLiteral("\r\n<header>\r\n    <div");

WriteLiteral(" class=\"form-inline\"");

WriteAttribute("dir", Tuple.Create(" dir=\"", 154), Tuple.Create("\"", 175)
            
            #line 8 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 160), Tuple.Create<System.Object, System.Int32>(Lang.Direction
            
            #line default
            #line hidden
, 160), false)
);

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnManageFolders\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 291), Tuple.Create("\"", 340)
            
            #line 10 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
       , Tuple.Create(Tuple.Create("", 299), Tuple.Create<System.Object, System.Int32>(GetText("CKManager", "btnManageFolders")
            
            #line default
            #line hidden
, 299), false)
);

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label>");

            
            #line 13 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
              Write(GetText("CKManager", "txtDisplayType"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            <select");

WriteLiteral(" id=\"selDisplayType\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\"List\"");

WriteLiteral(">");

            
            #line 15 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                Write(GetText("CKManager", "optDisplayTypeList"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                <option");

WriteLiteral(" value=\"Table\"");

WriteLiteral(">");

            
            #line 16 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                 Write(GetText("CKManager", "optDisplayTypeTable"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                <option");

WriteLiteral(" value=\"Thumbnail\"");

WriteLiteral(">");

            
            #line 17 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                     Write(GetText("CKManager", "optDisplayTypeThumbanil"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n            </select>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label>");

            
            #line 21 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
              Write(GetText("CKManager", "txtSortBy"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            <select");

WriteLiteral(" id=\"selSortBy\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\"Name\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                Write(GetText("CKManager", "optSortByName"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                <option");

WriteLiteral(" value=\"Extension\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                     Write(GetText("CKManager", "optSortByExtension"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                <option");

WriteLiteral(" value=\"Size\"");

WriteLiteral(">");

            
            #line 25 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                Write(GetText("CKManager", "optSortBySize"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                <option");

WriteLiteral(" value=\"CreationTime\"");

WriteLiteral(">");

            
            #line 26 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                        Write(GetText("CKManager", "optSortByCreationTime"));

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n            </select>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"rdSortDir\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" /> ");

            
            #line 30 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                                                Write(GetText("CKManager", "txtSortDirAscending"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            <label><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"rdSortDir\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(" /> ");

            
            #line 31 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                                                Write(GetText("CKManager", "txtSortDirDescending"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label>");

            
            #line 34 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
              Write(GetText("CKManager", "txtSearch"));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtSearch\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnUpload\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2002), Tuple.Create("\"", 2044)
            
            #line 38 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2010), Tuple.Create<System.Object, System.Int32>(GetText("CKManager", "btnUpload")
            
            #line default
            #line hidden
, 2010), false)
);

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnDeleteFiles\"");

WriteLiteral(" class=\"btn btn-danger\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2175), Tuple.Create("\"", 2222)
            
            #line 41 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
   , Tuple.Create(Tuple.Create("", 2183), Tuple.Create<System.Object, System.Int32>(GetText("CKManager", "btnDeleteFiles")
            
            #line default
            #line hidden
, 2183), false)
);

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnRenameFile\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2353), Tuple.Create("\"", 2399)
            
            #line 44 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
   , Tuple.Create(Tuple.Create("", 2361), Tuple.Create<System.Object, System.Int32>(GetText("CKManager", "btnRenameFile")
            
            #line default
            #line hidden
, 2361), false)
);

WriteLiteral(" disabled />\r\n        </div>\r\n    </div>\r\n</header>\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(" id=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" id=\"row\"");

WriteLiteral(">\r\n");

            
            #line 50 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 50 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
         if (Lang.Direction == Locust.Language.TextDirection.ltr)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-xs-2 no-float dirs\"");

WriteLiteral(">\r\n                <ul");

WriteAttribute("class", Tuple.Create(" class=\"", 2678), Tuple.Create("\"", 2701)
            
            #line 53 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2686), Tuple.Create<System.Object, System.Int32>(Lang.Direction
            
            #line default
            #line hidden
, 2686), false)
);

WriteAttribute("dir", Tuple.Create(" dir=\"", 2702), Tuple.Create("\"", 2723)
            
            #line 53 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2708), Tuple.Create<System.Object, System.Int32>(Lang.Direction
            
            #line default
            #line hidden
, 2708), false)
);

WriteLiteral("></ul>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"col-xs-10 no-float files\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"files\"");

WriteLiteral("></div>\r\n            </div>\r\n");

            
            #line 58 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-xs-10 no-float files\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"files\"");

WriteLiteral("></div>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"col-xs-2 no-float dirs\"");

WriteLiteral(">\r\n                <ul");

WriteAttribute("class", Tuple.Create(" class=\"", 3081), Tuple.Create("\"", 3104)
            
            #line 65 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 3089), Tuple.Create<System.Object, System.Int32>(Lang.Direction
            
            #line default
            #line hidden
, 3089), false)
);

WriteAttribute("dir", Tuple.Create(" dir=\"", 3105), Tuple.Create("\"", 3126)
            
            #line 65 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 3111), Tuple.Create<System.Object, System.Int32>(Lang.Direction
            
            #line default
            #line hidden
, 3111), false)
);

WriteLiteral("></ul>\r\n            </div>\r\n");

            
            #line 67 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n<footer>\r\n    <center>\r\n        <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btnOk\"");

WriteLiteral(">");

            
            #line 72 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                              Write(GetText("CKManager", "btnOk"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"btnReturn\"");

WriteLiteral(">");

            
            #line 73 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
                                                  Write(GetText("CKManager", "btnReturn"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n    </center>\r\n</footer>\r\n\r\n<div");

WriteLiteral(" id=\"upload-modal\"");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove\"");

WriteLiteral("></i></button>\r\n                <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral("></h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<input");

WriteLiteral(" id=\"baseFilesPath\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3911), Tuple.Create("\"", 3941)
            
            #line 89 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
, Tuple.Create(Tuple.Create("", 3919), Tuple.Create<System.Object, System.Int32>(ViewBag.BaseFilesPath
            
            #line default
            #line hidden
, 3919), false)
);

WriteLiteral(" />\r\n\r\n");

DefineSection("header", () => {

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"//ajax.googleapis.com/ajax/libs/jqueryui/1.8.9/themes/base/jquery-ui.css\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"https://cdnjs.cloudflare.com/ajax/libs/plupload/3.1.2/jquery.ui.plupload/c" +
"ss/jquery.ui.plupload.css\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"https://cdn.jsdelivr.net/npm/tooltipster@4.2.6/dist/css/tooltipster.bundle" +
".min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"https://cdn.jsdelivr.net/npm/tooltipster@4.2.6/dist/css/plugins/tooltipste" +
"r/sideTip/themes/tooltipster-sideTip-noir.min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"//cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"https://cdn.jsdelivr.net/npm/magnific-popup@1.1.0/dist/magnific-popup.css\"" +
"");

WriteLiteral(" integrity=\"sha256-RdH19s+RN0bEXdaXsajztxnALYs/Z43H/Cdm1U4ar24=\"");

WriteLiteral(" crossorigin=\"anonymous\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"https://cdn.jsdelivr.net/npm/bootstrap-dialog@1.34.6/dist/css/bootstrap-di" +
"alog.min.css\"");

WriteLiteral(" integrity=\"sha256-XFE3ff6QDsqD5QZPqidvKjt7qjbTBDmSKqmw9bzspM4=\"");

WriteLiteral(" crossorigin=\"anonymous\"");

WriteLiteral(">\r\n");

});

WriteLiteral("\r\n");

DefineSection("footer", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"//ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/jquery-ui.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"https://cdnjs.cloudflare.com/ajax/libs/plupload/3.1.2/plupload.full.min.js\"" +
"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"https://cdnjs.cloudflare.com/ajax/libs/plupload/3.1.2/jquery.ui.plupload/jq" +
"uery.ui.plupload.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"//cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/npm/tooltipster@4.2.6/dist/js/tooltipster.bundle.m" +
"in.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/npm/magnific-popup@1.1.0/dist/jquery.magnific-popu" +
"p.min.js\"");

WriteLiteral(" integrity=\"sha256-P93G0oq6PBPWTP1IR8Mz/0jHHUpaWL0aBJTKauisG7Q=\"");

WriteLiteral(" crossorigin=\"anonymous\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/npm/bootstrap-dialog@1.34.6/dist/js/bootstrap-dial" +
"og.min.js\"");

WriteLiteral(" integrity=\"sha256-QNeLKypKBOMbTcuLSI8WMwbIuOb5G4S/O1NR+6OIL14=\"");

WriteLiteral(" crossorigin=\"anonymous\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/npm/pako@1.0.6/dist/pako.min.js\"");

WriteLiteral(" integrity=\"sha256-9TLeW6tAsEKUUCX9AbSDY6A9F+O/p0mDFwLJEDvn5C8=\"");

WriteLiteral(" crossorigin=\"anonymous\"");

WriteLiteral("></script>\r\n");

            
            #line 112 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 112 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
       #if DEBUG 
            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/gh/mansoor-omrani/locustjs@v1.4.8/dist/locust.js\"");

WriteLiteral("></script>\r\n");

            
            #line 114 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 114 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
       #else 
            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"https://cdn.jsdelivr.net/gh/mansoor-omrani/locustjs/dist/locust.min.js\"");

WriteLiteral("></script>\r\n");

            
            #line 116 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 116 "..\..\Areas\CKManager\Views\Files\Index.cshtml"
       #endif 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
