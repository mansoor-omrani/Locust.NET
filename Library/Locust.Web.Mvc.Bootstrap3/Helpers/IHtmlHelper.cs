using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3.Helpers
{
    public interface IHtmlHelper: IDisposable
    {
        WebViewPage Page { get; set; }
        void Render();
    }
}
