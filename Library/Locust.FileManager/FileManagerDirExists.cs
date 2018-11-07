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
    public class FileManagerDirExistsRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerDirExistsResponse : ServiceResponse { }
    public class FileManagerDirExists : FileManagerAction<FileManagerDirExistsRequest, FileManagerDirExistsResponse>
    {
        public FileManagerDirExists(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerDirExistsRequest request, FileManagerDirExistsResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerDirExistsRequest request, FileManagerDirExistsResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDirExistsRequest request, FileManagerDirExistsResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
