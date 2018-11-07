using Locust.Extensions;
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
    public class FileManagerSaveFilesRequest : FileManagerActionBaseRequest
    {
        public DataFile[] Files { get; set; }
        public bool OverwriteExisting { get; set; }
        public int BufferSize { get; set; }
        public string Filter { get; set; }
    }
    public class FileManagerSaveFilesResponse : ServiceResponse { }
    public class FileManagerSaveFiles : FileManagerAction<FileManagerSaveFilesRequest, FileManagerSaveFilesResponse>
    {
        public FileManagerSaveFiles(IFileManager filemanager) : base(filemanager)
        {
        }

        protected override void RunInternal(FileManagerSaveFilesRequest request, FileManagerSaveFilesResponse response)
        {
            if (request.Files == null || request.Files.Length == 0)
            {
                response.Status = "NoFiles";
            }
            else
            {
                var count = 0;
                var successCount = 0;

                foreach (var file in request.Files)
                {
                    var r = FileManager.SaveFile.Run(new FileManagerSaveFileRequest
                    {
                        BufferSize = request.BufferSize,
                        FileName = file.FileName,
                        Data = file.Data,
                        Filter = request.Filter,
                        OverwriteExisting = request.OverwriteExisting,
                        Path = request.Path
                    });

                    r.Info = $"Data: {file.Data?.Length} bytes";

                    if (r.Success)
                        successCount++;

                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        response.InnerResponses.Add(file.FileName, r);
                    }
                    else
                    {
                        response.InnerResponses.Add("NoNamed" + count, r);
                    }

                    count++;
                }

                if (successCount == response.InnerResponses.Count)
                {
                    response.Succeeded();
                }
                else
                {
                    if (successCount == 0)
                        response.Errored();
                    else
                    {
                        response.MessageArgs.Add("successCount", successCount);
                        response.MessageArgs.Add("failedCount", request.Files.Length - successCount);

                        response.Status = "PartialSuccess";
                    }
                }
            }
        }
        protected override async Task RunInternalAsync(FileManagerSaveFilesRequest request, FileManagerSaveFilesResponse response, CancellationToken token)
        {
            if (request.Files == null || request.Files.Length == 0)
            {
                response.Status = "NoFiles";
            }
            else
            {
                var count = 0;
                var successCount = 0;

                foreach (var file in request.Files)
                {
                    var r = await FileManager.SaveFile.RunAsync(new FileManagerSaveFileRequest
                    {
                        BufferSize = request.BufferSize,
                        FileName = file.FileName,
                        Data = file.Data,
                        Filter = request.Filter,
                        OverwriteExisting = request.OverwriteExisting,
                        Path = request.Path
                    }, token);

                    r.Info = $"Data: {file.Data?.Length} bytes";

                    if (r.Success)
                        successCount++;

                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        response.InnerResponses.Add(file.FileName, r);
                    }
                    else
                    {
                        response.InnerResponses.Add("NoNamed" + count, r);
                    }

                    count++;
                }

                if (successCount == response.InnerResponses.Count)
                {
                    response.Succeeded();
                }
                else
                {
                    if (successCount == 0)
                        response.Errored();
                    else
                    {
                        response.MessageArgs.Add("successCount", successCount);
                        response.MessageArgs.Add("failedCount", request.Files.Length - successCount);

                        response.Status = "PartialSuccess";
                    }
                }
            }
        }
    }
}
