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
    public class FileManagerRenameDirRequest : FileManagerRenameBaseRequest
    {
    }
    public class FileManagerRenameDirResponse : ServiceResponse { }
    public class FileManagerRenameDir : FileManagerAction<FileManagerRenameDirRequest, FileManagerRenameDirResponse>
    {
        public FileManagerRenameDir(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerRenameDirRequest request, FileManagerRenameDirResponse response)
        {
            var i = request?.Path.LastIndexOf('/') ?? -1;
            if (i < 0)
                i = request.Path?.LastIndexOf('\\') ?? -1;
            var path = FileManager.GetAbsolutePath(request.Path);
            var dir = i < 0 ? "" : request.Path.Substring(0, i);
            var newPath = FileManager.GetAbsolutePath(dir + "/" + request.NewName);
            
            for (var j = 0; j < 1; j++)
            {
                if (string.Compare(path, FileManager.GetAbsolutePath("/"), true) == 0)
                {
                    response.Status = "Forbidden";
                    break;
                }

                if (File.Exists(path))
                {
                    response.Status = "NotDir";
                    break;
                }

                if (string.IsNullOrEmpty(request.NewName))
                {
                    response.Status = "NoNewName";
                    break;
                }

                if (!Directory.Exists(path))
                {
                    response.Status = "NotExists";
                    break;
                }

                if (Directory.Exists(newPath) || File.Exists(newPath))
                {
                    response.Status = "NewNameExists";
                    break;
                }

                Directory.Move(path, newPath);

                response.Succeeded();
            }
        }
        protected override void RunInternal(FileManagerRenameDirRequest request, FileManagerRenameDirResponse response)
        {
            DoRun(request, response);

        }
        protected override Task RunInternalAsync(FileManagerRenameDirRequest request, FileManagerRenameDirResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
