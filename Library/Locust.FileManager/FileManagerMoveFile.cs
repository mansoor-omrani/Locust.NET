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
    public class FileManagerMoveFileRequest : FileManagerMoveBaseRequest
    {
    }
    public class FileManagerMoveFileResponse : ServiceResponse { }
    public class FileManagerMoveFile : FileManagerAction<FileManagerMoveFileRequest, FileManagerMoveFileResponse>
    {
        public FileManagerMoveFile(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerMoveFileRequest request, FileManagerMoveFileResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);
            var newPath = FileManager.GetAbsolutePath(request.NewPath);

            if (File.Exists(newPath) || Directory.Exists(newPath))
            {
                response.Status = "TargetExists";
            }
            else
            {
                if (File.Exists(path))
                {
                    File.Move(path, newPath);

                    response.Succeeded();
                }
                else
                {
                    response.Status = "NotExists";
                }
            }
        }
        protected override void RunInternal(FileManagerMoveFileRequest request, FileManagerMoveFileResponse response)
        {
            DoRun(request, response);

        }
        protected override Task RunInternalAsync(FileManagerMoveFileRequest request, FileManagerMoveFileResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
