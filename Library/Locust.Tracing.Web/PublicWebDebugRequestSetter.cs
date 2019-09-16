using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.Tracing.Web
{
    public class PublicWebDebugRequestSetter:IDebugRequestSetter
    {
        public WebRequest Request { get; set; }

        private void SetHeader(string header, string value)
        {
            Request?.Headers.Set(header, value);
        }
        public virtual void SetDebugMode(bool debugMode)
        {
            SetHeader("x-app-debug", debugMode.ToString().ToLower());
        }

        public virtual void SetTraceMode(bool traceMode)
        {
            SetHeader("x-app-trace", traceMode.ToString().ToLower());
        }

        public virtual void SetDebugLevel(DebugLevel debugLevel)
        {
            SetHeader("x-app-debug-level", debugLevel.ToString());
        }

        public virtual void SetViewerType(MessageViewerType viewerType)
        {
            SetHeader("x-app-viewer-type", viewerType.ToString());
        }
    }
}
