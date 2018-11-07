using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public class BootstrapInputGroup : HtmlDiv
    {
        public BootstrapFormInput Input { get; set; }
        public HtmlDiv BeforeAddOn { get; set; }
        public HtmlDiv AfterAddOn { get; set; }
        public BootstrapInputGroup(string beforeAddOn, string name, string afterAddOn = "")
        {
            Classes.Add("input-group");

            BeforeAddOn = new HtmlDiv();
            BeforeAddOn.InnerText = beforeAddOn;

            Children.Add(BeforeAddOn);

            Input = new BootstrapFormInput();
            Input.Name = Input.Id = name;

            Children.Add(Input);

            if (!string.IsNullOrEmpty(afterAddOn))
            {
                AfterAddOn = new HtmlDiv();
                AfterAddOn.InnerText = afterAddOn;

                Children.Add(AfterAddOn);
            }
        }
    }
}
