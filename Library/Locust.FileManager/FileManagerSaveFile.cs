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
    public class FileManagerSaveFileRequest : FileManagerActionBaseRequest
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public bool OverwriteExisting { get; set; }
        public int BufferSize { get; set; }
        public string Filter { get; set; }
    }
    public class FileManagerSaveFileResponse : ServiceResponse { }
    public class FileManagerSaveFile : FileManagerAction<FileManagerSaveFileRequest, FileManagerSaveFileResponse>
    {
        public FileManagerSaveFile(IFileManager filemanager) : base(filemanager)
        {
        }

        protected override void RunInternal(FileManagerSaveFileRequest request, FileManagerSaveFileResponse response)
        {
            response.MessageArgs.Add("filename", request.FileName);

            if (string.IsNullOrEmpty(request.FileName))
            {
                response.Status = "NoFileName";
            }
            else
            {
                if (!string.IsNullOrEmpty(request.Filter) && Path.GetExtension(request.FileName).In(request.Filter))
                {
                    response.Status = "Denied";
                }
                else
                {
                    var path = FileManager.GetAbsolutePath(request.Path + "/" + request.FileName);

                    if (File.Exists(path) && !request.OverwriteExisting)
                    {
                        response.Status = "AlreadyExists";
                    }
                    else
                    {
                        if (Directory.Exists(path))
                        {
                            response.Status = "DirExists";
                        }
                        else
                        {
                            if (!FileManager.CheckQuota(request.Data?.Length ?? 0))
                            {
                                response.Status = "QuotaExceeded";
                            }
                            else
                            {
                                using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                {
                                    if (request.Data != null && request.Data.Length > 0)
                                    {
                                        writer.Write(request.Data);
                                    }
                                }

                                response.Succeeded();

                                FileManager.UpdateQuota(request.Data?.Length ?? 0);
                            }
                        }
                    }
                }
            }
        }
        protected override async Task RunInternalAsync(FileManagerSaveFileRequest request, FileManagerSaveFileResponse response, CancellationToken token)
        {
            response.MessageArgs.Add("filename", request.FileName);

            if (string.IsNullOrEmpty(request.FileName))
            {
                response.Status = "NoFileName";
            }
            else
            {
                if (!string.IsNullOrEmpty(request.Filter) && Path.GetExtension(request.FileName).In(request.Filter))
                {
                    response.Status = "Denied";
                }
                else
                {
                    var path = FileManager.GetAbsolutePath(request.Path + "/" + request.FileName);

                    if (File.Exists(path) && !request.OverwriteExisting)
                    {
                        response.Status = "AlreadyExists";
                    }
                    else
                    {
                        if (Directory.Exists(path))
                        {
                            response.Status = "DirExists";
                        }
                        else
                        {
                            try
                            {
                                var bufferSize = request.BufferSize <= 0 ? 8192 : request.BufferSize;

                                using (var writer = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: bufferSize, useAsync: true))
                                {
                                    if (request.Data != null && request.Data.Length > 0)
                                    {
                                        await writer.WriteAsync(request.Data, 0, request.Data.Length, token);
                                    }
                                };

                                response.Succeeded();
                            }
                            catch (AggregateException)
                            {
                                response.Status = "Cancelled";
                            }
                        }
                    }
                }
            }
        }
    }
}
