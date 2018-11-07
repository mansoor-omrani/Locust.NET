using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public class FileManagerMoveBaseRequest:FileManagerActionBaseRequest
    {
        public string NewPath { get; set; }
    }
}
