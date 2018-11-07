using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Tracing
{
    public interface IDebugRequestSetter
    {
        void SetDebugMode(bool debugMode);
        void SetTraceMode(bool traceMode);
        void SetDebugLevel(DebugLevel debugLevel);
        void SetViewerType(MessageViewerType viewerType);
    }
}
