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
    public class FileManagerRenameFileRequest : FileManagerRenameBaseRequest
    {
    }
    public class FileManagerRenameFileResponse : ServiceResponse { }
    public class FileManagerRenameFile : FileManagerAction<FileManagerRenameFileRequest, FileManagerRenameFileResponse>
    {
        public FileManagerRenameFile(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerRenameFileRequest request, FileManagerRenameFileResponse response)
        {
            var i = request?.Path.LastIndexOf('/') ?? -1;
            if (i < 0)
                i = request.Path?.LastIndexOf('\\') ?? -1;
            var path = FileManager.GetAbsolutePath(request.Path);
            var dir = i < 0 ? "" : request.Path.Substring(0, i);
            var newPath = FileManager.GetAbsolutePath(dir + "/" + request.NewName);
            
            for (var j = 0; j < 1; j++)
            {
                if (Directory.Exists(path))
                {
                    response.Status = "NotFile";
                    break;
                }

                if (string.IsNullOrEmpty(request.NewName))
                {
                    response.Status = "NoNewName";
                    break;
                }

                if (!File.Exists(path))
                {
                    response.Status = "NotExists";
                    break;
                }

                var filename = System.IO.Path.GetFileName(request.Path);

                if ((File.Exists(newPath) || Directory.Exists(newPath)) && string.Compare(request.NewName, filename, true) != 0)
                {
                    response.Status = "NewNameExists";
                    response.MessageArgs.Add("newpath", newPath);

                    break;
                }

                File.Move(path, newPath);

                response.Succeeded();
            }
        }
        protected override void RunInternal(FileManagerRenameFileRequest request, FileManagerRenameFileResponse response)
        {
            DoRun(request, response);

        }
        protected override Task RunInternalAsync(FileManagerRenameFileRequest request, FileManagerRenameFileResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
