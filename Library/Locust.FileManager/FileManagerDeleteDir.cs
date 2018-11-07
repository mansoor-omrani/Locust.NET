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
    public class FileManagerDeleteDirRequest : FileManagerActionBaseRequest
    {
        public bool Recursive { get; set; }
    }
    public class FileManagerDeleteDirResponse : ServiceResponse { }
    public class FileManagerDeleteDir : FileManagerAction<FileManagerDeleteDirRequest, FileManagerDeleteDirResponse>
    {
        public FileManagerDeleteDir(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerDeleteDirRequest request, FileManagerDeleteDirResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (string.Compare(path, FileManager.GetAbsolutePath("/"), true) == 0)
            {
                response.Status = "Forbidden";
            }
            else
            {
                if (Directory.Exists(path))
                {
                    if (!request.Recursive)
                    {
                        var subdirs = Directory.GetDirectories(path);

                        if (subdirs != null && subdirs.Length > 0)
                        {
                            response.Status = "HasSubDirs";
                            return;
                        }

                        var files = Directory.GetFiles(path);

                        if (files != null && files.Length > 0)
                        {
                            response.Status = "HasFiles";
                            return;
                        }

                    }

                    Directory.Delete(path, request.Recursive);

                    response.Succeeded();
                }
                else
                {
                    response.Status = "NotExists";
                }
            }
        }
        protected override void RunInternal(FileManagerDeleteDirRequest request, FileManagerDeleteDirResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDeleteDirRequest request, FileManagerDeleteDirResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
