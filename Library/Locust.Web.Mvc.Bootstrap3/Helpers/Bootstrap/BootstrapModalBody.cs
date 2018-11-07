using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public class BootstrapModalBody : HtmlDiv
    {
        public BootstrapModalBody()
        {
            Classes.Add("modal-body");
        }
    }
}
