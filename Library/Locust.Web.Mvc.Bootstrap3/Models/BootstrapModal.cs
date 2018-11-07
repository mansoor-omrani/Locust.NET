using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Models
{
    public class BootstrapModal
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string HeaderText { get; set; }
        public string BodyText { get; set; }
        public object Body { get; set; }
        public string BodyTemplateName { get; set; }
        public object BodyTemplateModel { get; set; }
        public bool HideHeader { get; set; }
        public bool HideFooter { get; set; }
        public List<BootstrapModalButton> Buttons { get; set; }
    }
}
