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
    public class DirInfo
    {
        public string FullName { get; set; }
        public FileAttributes Attributes { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastAccessTimeUtc { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastWriteTimeUtc { get; set; }
        public string Name { get; set; }
    }
    public class FileManagerDirInfoRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerDirInfoResponse : ServiceResponse<DirInfo> { }
    public class FileManagerDirInfo : FileManagerAction<FileManagerDirInfoRequest, FileManagerDirInfoResponse>
    {
        public FileManagerDirInfo(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerDirInfoRequest request, FileManagerDirInfoResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);

                response.Data = new DirInfo();

                response.Data.FullName = di.FullName;
                response.Data.Attributes = di.Attributes;
                response.Data.CreationTime = di.CreationTime;
                response.Data.CreationTimeUtc = di.CreationTimeUtc;
                response.Data.LastAccessTime = di.LastAccessTime;
                response.Data.LastAccessTimeUtc = di.LastAccessTimeUtc;
                response.Data.LastWriteTime = di.LastWriteTime;
                response.Data.LastWriteTimeUtc = di.LastWriteTimeUtc;
                response.Data.Name = di.Name;

                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerDirInfoRequest request, FileManagerDirInfoResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerDirInfoRequest request, FileManagerDirInfoResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
