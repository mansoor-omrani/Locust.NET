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
    public class FileManagerDeleteFileRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerDeleteFileResponse : ServiceResponse { }
    public class FileManagerDeleteFile : FileManagerAction<FileManagerDeleteFileRequest, FileManagerDeleteFileResponse>
    {
        public FileManagerDeleteFile(IFileManager filemanager) : base(filemanager)
        {
        }

        private void DoRun(FileManagerDeleteFileRequest request, FileManagerDeleteFileResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (File.Exists(path))
            {
                var fi = FileManager.FileInfo(path);

                if (fi.Success)
                {
                    File.Delete(path);

                    FileManager.UpdateQuota(-fi.Data.Size);

                    response.Succeeded();
                }
                else
                {
                    response.Status = "FetchFileInfoFailed";
                }
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerDeleteFileRequest request, FileManagerDeleteFileResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDeleteFileRequest request, FileManagerDeleteFileResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
