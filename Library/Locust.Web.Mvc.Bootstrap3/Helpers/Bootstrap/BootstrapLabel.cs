using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public class BootstrapLabel: HtmlLabel
    {
        private bool srOnly;
        public bool ScreenReaderOnly
        {
            get
            {
                return srOnly;
            }
            set
            {
                srOnly = value;

                if (!value)
                    Classes.Remove("sr-only");
                else
                    Classes.Add("sr-only");
            }
        }
        private bool controlLabel;
        public bool ControlLabel
        {
            get
            {
                return controlLabel;
            }
            set
            {
                controlLabel = value;

                if (!value)
                    Classes.Remove("control-label");
                else
                    Classes.Add("control-label");
            }
        }
    }
}
