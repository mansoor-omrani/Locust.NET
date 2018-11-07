using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3.Helpers
{
    public class BootstrapModalHeaderHelper : IHtmlHelper
    {
        public WebViewPage Page { get; set; }
        public string ModalId { get; set; }
        public string Text { get; set; }
        public bool ManualContent { get; set; }
        public void Render()
        {
            Page.Write($@"<div class=""modal-header"">");

            if (!ManualContent)
            {
                Page.Write(
$@"<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
    <h4 class=""modal-title"" id=""{ModalId}-label"">{Text}</h4>");
            }
        }
        public void Dispose()
        {
            Page.Write("</div>");
        }
    }
}
