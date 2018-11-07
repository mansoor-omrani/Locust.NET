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
    
    public class FileManagerDirSizeRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerDirSizeResponse : ServiceResponse<long> { }
    public class FileManagerDirSize : FileManagerAction<FileManagerDirSizeRequest, FileManagerDirSizeResponse>
    {
        public FileManagerDirSize(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerDirSizeRequest request, FileManagerDirSizeResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                response.Data = GetDirSize(path);

                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        private long GetDirSize(string path)
        {
            long result = 0;
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fi = new System.IO.FileInfo(file);
                result += fi.Length;
            }

            var dirs = Directory.GetDirectories(path);

            foreach (var dir in dirs)
            {
                result += GetDirSize(dir);
            }

            return result;
        }
        protected override void RunInternal(FileManagerDirSizeRequest request, FileManagerDirSizeResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDirSizeRequest request, FileManagerDirSizeResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
