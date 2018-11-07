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
    public class FileManagerMoveDirRequest : FileManagerMoveBaseRequest
    {
    }
    public class FileManagerMoveDirResponse : ServiceResponse { }
    public class FileManagerMoveDir : FileManagerAction<FileManagerMoveDirRequest, FileManagerMoveDirResponse>
    {
        public FileManagerMoveDir(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerMoveDirRequest request, FileManagerMoveDirResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);
            var newPath = FileManager.GetAbsolutePath(request.NewPath);

            if (string.Compare(path, FileManager.GetAbsolutePath("/"), true) == 0)
            {
                response.Status = "Forbidden";
            }
            else
            {
                if (File.Exists(newPath) || Directory.Exists(newPath))
                {
                    response.Status = "TargetExists";
                }
                else
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Move(path, newPath);

                        response.Succeeded();
                    }
                    else
                    {
                        response.Status = "NotExists";
                    }
                }
            }
        }
        protected override void RunInternal(FileManagerMoveDirRequest request, FileManagerMoveDirResponse response)
        {
            DoRun(request, response);

        }
        protected override Task RunInternalAsync(FileManagerMoveDirRequest request, FileManagerMoveDirResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
