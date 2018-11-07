using Locust.Web.Mvc.Bootstrap3.Helpers;
using Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap;
using Locust.Web.Html;
using Locust.Web.Mvc.Bootstrap3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Locust.Web.Mvc.Bootstrap3
{
    public partial class BootstrapHelper
    {
		public IHtmlHelper CreateH1(string id = "", string @class = "")
        {
            var result = new HtmlHeading1 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
		public IHtmlHelper CreateH2(string id = "", string @class = "")
        {
            var result = new HtmlHeading2 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
		public IHtmlHelper CreateH3(string id = "", string @class = "")
        {
            var result = new HtmlHeading3 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
		public IHtmlHelper CreateH4(string id = "", string @class = "")
        {
            var result = new HtmlHeading4 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
		public IHtmlHelper CreateH5(string id = "", string @class = "")
        {
            var result = new HtmlHeading5 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
		public IHtmlHelper CreateH6(string id = "", string @class = "")
        {
            var result = new HtmlHeading6 { Id = id };

			result.Classes.Add(@class);

            return RenderToPage(result);
        }
	}
}