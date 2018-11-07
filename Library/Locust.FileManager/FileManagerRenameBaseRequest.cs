using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public class FileManagerRenameBaseRequest: FileManagerActionBaseRequest
    {
        public string NewName { get; set; }
    }
}
