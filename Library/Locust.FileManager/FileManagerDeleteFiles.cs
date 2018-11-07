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
    public class FileManagerDeleteFilesRequest : ServiceRequest
    {
        public string[] Paths { get; set; }
    }
    public class FileManagerDeleteFilesResponse : ServiceResponse { }
    public class FileManagerDeleteFiles : FileManagerAction<FileManagerDeleteFilesRequest, FileManagerDeleteFilesResponse>
    {
        public FileManagerDeleteFiles(IFileManager filemanager) : base(filemanager)
        {
        }

        private void DoRun(FileManagerDeleteFilesRequest request, FileManagerDeleteFilesResponse response)
        {
            if (request.Paths == null || request.Paths.Length == 0)
            {
                response.Status = "NoPaths";
            }
            else
            {
                var successCount = 0;

                foreach (var path in request.Paths)
                {
                    var r = FileManager.DeleteFile.Run(new FileManagerDeleteFileRequest { Path = path });

                    response.InnerResponses.Add(path, r);

                    if (r.Success)
                    {
                        successCount++;
                    }
                }

                if (successCount == request.Paths.Length)
                {
                    response.Succeeded();
                }
                else
                {
                    if (successCount == 0)
                    {
                        response.Errored();
                    }
                    else
                    {
                        response.MessageArgs.Add("successCount", successCount);
                        response.MessageArgs.Add("failedCount", request.Paths.Length - successCount);

                        response.Status = "PartialSuccess";
                    }
                }
            }
        }
        protected override void RunInternal(FileManagerDeleteFilesRequest request, FileManagerDeleteFilesResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDeleteFilesRequest request, FileManagerDeleteFilesResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
