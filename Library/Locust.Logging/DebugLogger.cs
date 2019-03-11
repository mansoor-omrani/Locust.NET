﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging
{
    public class DebugLogger:BaseLogger
    {
        protected override void LogCategoryInternal(string data)
        {
            Debug.Write(data);
        }

        protected override void LogInternal(string data)
        {
            Debug.Write(data);
        }
    }
}