using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public class FileManagerActionBaseRequest: ServiceRequest
    {
        public string Path { get; set; }
    }
}
