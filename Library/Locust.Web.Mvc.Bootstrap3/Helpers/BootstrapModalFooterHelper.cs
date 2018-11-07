using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3.Helpers
{
    public class BootstrapModalFooterHelper : IHtmlHelper
    {
        public WebViewPage Page { get; set; }
        public void Render()
        {
            Page.Write("<div class=\"modal-footer\">");
        }
        public void Dispose()
        {
            Page.Write("</div>");
        }
    }
}
