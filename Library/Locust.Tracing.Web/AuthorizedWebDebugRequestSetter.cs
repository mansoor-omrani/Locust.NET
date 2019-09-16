using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.WebTools;

namespace Locust.Tracing.Web
{
    public class AuthorizedWebDebugRequestSetter: PublicWebDebugRequestSetter, IAuthorizedDebugger
    {
        protected IHttpContextProvider contextProvider;
        protected HttpContextBase context;

        private void Init(IHttpContextProvider contextProvider)
        {
            if (contextProvider == null)
            {
                throw new ArgumentNullException("contextProvider");
            }

            this.contextProvider = contextProvider;
            context = contextProvider.Get();
        }
        public AuthorizedWebDebugRequestSetter()
        {
            Init(new DefaultHttpContextProvider());
        }
        public AuthorizedWebDebugRequestSetter(IHttpContextProvider contextProvider)
        {
            Init(contextProvider);
        }
        private bool? isAuthorized;
        public virtual bool IsAuthorized()
        {
            if (!isAuthorized.HasValue)
                isAuthorized = context.User.IsInRole("Admin") || context.User.IsInRole("Super");

            return isAuthorized.Value;
        }

        public override void SetDebugMode(bool debugMode)
        {
            if (IsAuthorized())
                base.SetDebugMode(debugMode);
        }
        public override void SetTraceMode(bool traceMode)
        {
            if (IsAuthorized())
                base.SetTraceMode(traceMode);
        }
        public override void SetDebugLevel(DebugLevel debugLevel)
        {
            if (IsAuthorized())
                base.SetDebugLevel(debugLevel);
        }
        public override void SetViewerType(MessageViewerType viewerType)
        {
            if (IsAuthorized())
                base.SetViewerType(viewerType);
        }
    }
}
