using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3
{
    public abstract class Bootstrap3ViewPage: ClientAwareWebViewPage
    {
        private BootstrapHelper bootstrap;
        public BootstrapHelper Bootstrap
        {
            get
            {
                if (bootstrap == null)
                    bootstrap = new BootstrapHelper(this);
                return bootstrap;
            }
        }
    }
    public abstract class Bootstrap3ViewPage<TModel> : ClientAwareWebViewPage<TModel>
    {
        private BootstrapHelper<TModel> bootstrap;
        public BootstrapHelper<TModel> Bootstrap
        {
            get
            {
                if (bootstrap == null)
                    bootstrap = new BootstrapHelper<TModel>(this);
                return bootstrap;
            }
        }
    }
}
