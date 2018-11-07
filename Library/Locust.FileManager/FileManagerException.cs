using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public class FileManagerException: Exception
    {
        public string Status { get; set; }
        public FileManagerException(string status, string message):base(message)
        {
            Status = status;
        }
        public FileManagerException(string status, string message, Exception innerException) : base(message, innerException)
        {
            Status = status;
        }
    }
}
