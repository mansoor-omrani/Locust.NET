using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public class BootstrapFormGroup : HtmlDiv
    {
        public BootstrapLabel Label { get; set; }
        public BootstrapFormInput Input { get; set; }
        public BootstrapFormGroup()
        {
            Classes.Add("form-group");

            Label = new BootstrapLabel();
            Input = new BootstrapFormInput();

            Children.Add(Label);
            Children.Add(Input);
        }
    }
}
