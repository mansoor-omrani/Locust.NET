using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3.Helpers
{
    public class BootstrapModalHelper : IHtmlHelper
    {
        public WebViewPage Page { get; set; }
        public string Id { get; set; }
        public bool RenderHeaderManually { get; set; }
        public bool RenderBodyManually { get; set; }
        public bool RenderFooterManually { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Class { get; set; }
        public void Render()
        {
            Page.Write(
$@"<div class=""modal fade {Class}"" id=""{Id}"" tabindex=""-1"" role=""dialog"" aria-labelledby=""{Id}-label"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">");

            if (!RenderHeaderManually)
            {
                using (var modalHeader = new BootstrapModalHeaderHelper { Page = Page, ModalId = Id, Text = Header })
                {
                    modalHeader.Render();
                }
            }

            if (!RenderBodyManually)
                Page.Write($"<div class=\"modal-body\">{Body}");   // modal-body (start)
        }
        public void Dispose()
        {
            if (!RenderBodyManually)
                Page.Write("</div>");   // modal-body (end)

            if (!RenderFooterManually)
            {
                using (var modalFooter = new BootstrapModalFooterHelper { Page = Page })
                {
                    modalFooter.Render();
                }
            }

            Page.Write("</div></div></div>");
        }
    }
}
