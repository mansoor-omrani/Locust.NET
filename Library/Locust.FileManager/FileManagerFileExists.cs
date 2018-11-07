using Locust.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public class FileManagerFileExistsRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerFileExistsResponse : ServiceResponse { }
    public class FileManagerFileExists : FileManagerAction<FileManagerFileExistsRequest, FileManagerFileExistsResponse>
    {
        public FileManagerFileExists(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerFileExistsRequest request, FileManagerFileExistsResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (File.Exists(path))
            {
                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerFileExistsRequest request, FileManagerFileExistsResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerFileExistsRequest request, FileManagerFileExistsResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
