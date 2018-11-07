using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Tracing
{
    public enum DebugLevel
    {
        Debug = 1,
        Trace = 2,
        Dialog = 4,
        System = 8,

        DebugTrace = 3,
        DebugDialog = 5,
        DebugSystem = 9,

        TraceDialog = 6,
        TraceSystem = 10,

        DialogSystem = 12,
        DebugTraceDialog = 7,
        DebugTraceSystem = 11,
        DebugDialogSystem = 13,
        TraceSystemDialog = 14,

        All = 15
    }
}
