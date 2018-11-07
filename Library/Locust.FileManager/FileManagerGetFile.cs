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
    public class FileManagerGetFileRequest : FileManagerActionBaseRequest
    {
        public int BufferSize { get; set; }
    }
    public class FileManagerGetFileResponse : ServiceResponse<byte[]> { }
    public class FileManagerGetFile : FileManagerAction<FileManagerGetFileRequest, FileManagerGetFileResponse>
    {
        public FileManagerGetFile(IFileManager filemanager) : base(filemanager)
        {
        }

        protected override void RunInternal(FileManagerGetFileRequest request, FileManagerGetFileResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);
            
            if (File.Exists(path))
            {
                response.Data = File.ReadAllBytes(path);

                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override async Task RunInternalAsync(FileManagerGetFileRequest request, FileManagerGetFileResponse response, CancellationToken token)
        {
            var path = FileManager.GetAbsolutePath(request.Path);
            
            if (File.Exists(path))
            {
                var bufferSize = request.BufferSize <= 0 ? 8192 : request.BufferSize;

                try
                {
                    using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize: bufferSize, useAsync: true))
                    {
                        var result = new byte[reader.Length];

                        await reader.ReadAsync(result, 0, (int)reader.Length, token);

                        response.Data = result;
                    }

                    response.Succeeded();
                }
                catch (AggregateException)
                {
                    response.Status = "Cancelled";
                }
            }
            else
            {
                response.Status = "NotExists";
            }
        }
    }
}
