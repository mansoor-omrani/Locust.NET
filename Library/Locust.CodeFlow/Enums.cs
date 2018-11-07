using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.CodeFlow
{
    public enum MessageType
    {
        None,
        Trace,
        Debug,
        Dialog
    }

    public enum MessageSource
    {
        System,
        App,
        Server,
        Client,
        Host,
        Db,
        Service,
        File,
        Directory,
        Memory,
        CPU,
        Network,
        Resource,
        Device,
        Other
    }

    public enum MessageViewerType
    {
        Guest,
        Super,
        Admin,
        Developer,
        Manager,
        Member,
        User,
        PowerUser
    }

    public enum DebugLevel
    {
        Debug = 1,
        Trace = 2,
        Dialog = 4,
        DebugAndDialog = 5,
        DebugAndTrace = 3,
        TraceAndDialog = 6,
        All = 7
    }
}
