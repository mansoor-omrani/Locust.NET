﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Tracing
{
    public interface IDebugRequestGetter
    {
        bool GetDebugMode();
        bool GetTraceMode();
        DebugLevel GetDebugLevel();
        MessageViewerType GetViewerType();
    }
}
