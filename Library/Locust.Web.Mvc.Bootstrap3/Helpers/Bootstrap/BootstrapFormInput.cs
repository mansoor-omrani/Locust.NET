using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public class BootstrapFormInput: HtmlInput
    {
        public BootstrapFormInput()
        {
            Classes.Add("form-control");
        }
    }
}
