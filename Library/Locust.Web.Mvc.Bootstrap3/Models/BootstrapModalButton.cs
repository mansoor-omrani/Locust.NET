using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Models
{
    public class BootstrapModalButton : BootstrapButton
    {
        private bool dataDismiss;
        public bool DataDismiss
        {
            get
            {
                return dataDismiss;
            }
            set
            {
                if (value)
                {
                    if (!Attributes.ContainsKey("data-dismiss"))
                    {
                        Attributes.Add("data-dismiss", "modal");
                    }
                }
                else
                {
                    if (Attributes.ContainsKey("data-dismiss"))
                    {
                        this.Attributes.Remove("data-dismiss");
                    }
                }

                dataDismiss = value;
            }
        }
    }
}
