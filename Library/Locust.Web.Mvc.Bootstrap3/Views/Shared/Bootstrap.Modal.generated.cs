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
    
    #line 1 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
    using Locust.Web.Mvc.Bootstrap3.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Bootstrap.Modal.cshtml")]
    public partial class _Views_Shared_Bootstrap_Modal_cshtml : System.Web.Mvc.WebViewPage<BootstrapModal>
    {
        public _Views_Shared_Bootstrap_Modal_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteAttribute("class", Tuple.Create(" class=\"", 91), Tuple.Create("\"", 122)
, Tuple.Create(Tuple.Create("", 99), Tuple.Create("modal", 99), true)
, Tuple.Create(Tuple.Create(" ", 104), Tuple.Create("fade", 105), true)
            
            #line 4 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
, Tuple.Create(Tuple.Create(" ", 109), Tuple.Create<System.Object, System.Int32>(Model.Class
            
            #line default
            #line hidden
, 110), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 123), Tuple.Create("\"", 137)
            
            #line 4 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
, Tuple.Create(Tuple.Create("", 128), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 128), false)
);

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteAttribute("aria-labelledby", Tuple.Create(" aria-labelledby=\"", 166), Tuple.Create("\"", 199)
            
            #line 4 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                  , Tuple.Create(Tuple.Create("", 184), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 184), false)
, Tuple.Create(Tuple.Create("", 193), Tuple.Create("-label", 193), true)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(" role=\"document\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n");

            
            #line 7 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
            
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
             if (!Model.HideHeader)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-label=\"Close\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times;</span></button>\r\n                    <h4");

WriteLiteral(" class=\"modal-title\"");

WriteAttribute("id", Tuple.Create(" id=\"", 573), Tuple.Create("\"", 593)
            
            #line 11 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
, Tuple.Create(Tuple.Create("", 578), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 578), false)
, Tuple.Create(Tuple.Create("", 587), Tuple.Create("-label", 587), true)
);

WriteLiteral(">");

            
            #line 11 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                                                            Write(Model.HeaderText);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                </div>\r\n");

            
            #line 13 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                 if (!string.IsNullOrEmpty(Model.BodyTemplateName))
                {
                    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
               Write(Html.Partial(Model.BodyTemplateName, Model.BodyTemplateModel));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                                                                                  ;
                }
                else
                {
                    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
               Write(Model.BodyText);

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                                   
                    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
               Write(Html.Raw(Model.Body));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                                         
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");

            
            #line 25 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
            
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
             if (!Model.HideFooter)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n");

            
            #line 28 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                 foreach (var btn in Model.Buttons)
                {
                    
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
               Write(Html.Partial("Bootstrap.Button", btn));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
                                                          
                }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n");

            
            #line 33 "..\..\Views\Shared\Bootstrap.Modal.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591