using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Conversion;
using Locust.Extensions;
using Locust.WebTools;

namespace Locust.Tracing.Web
{
    public class AuthorizedWebDebugRequestGetter : PublicWebDebugRequestGetter, IAuthorizedDebugger
    {
        public AuthorizedWebDebugRequestGetter()
        { }
        public AuthorizedWebDebugRequestGetter(IHttpContextProvider contextProvider):base(contextProvider)
        {
        }

        private bool? isAuthorized;
        public virtual bool IsAuthorized()
        {
            if (!isAuthorized.HasValue)
                isAuthorized = context.User.IsInRole("Admin") || context.User.IsInRole("Super");

            return isAuthorized.Value;
        }

        private bool? debugMode;
        public override bool GetDebugMode()
        {
            if (!debugMode.HasValue)
                debugMode = IsAuthorized() && base.GetDebugMode();

            return debugMode.Value;
        }

        private bool? traceMode;
        public override bool GetTraceMode()
        {
            if (!traceMode.HasValue)
                traceMode = IsAuthorized() && base.GetTraceMode();

            return traceMode.Value;
        }

        private DebugLevel? debugLevel;
        public override DebugLevel GetDebugLevel()
        {
            if (!debugLevel.HasValue)
            {
                var result = DebugLevel.Dialog;

                if (context != null && IsAuthorized())
                {
                    result = base.GetDebugLevel();
                }

                debugLevel = result;
            }
            return debugLevel.Value;
        }

        private MessageViewerType? viewerType;
        public override MessageViewerType GetViewerType()
        {
            if (!viewerType.HasValue)
            {
                var result = MessageViewerType.Guest;

                if (context != null && IsAuthorized())
                {
                    result = base.GetViewerType();
                }

                viewerType = result;
            }

            return viewerType.Value;
        }
    }
}
