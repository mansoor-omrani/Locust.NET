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
    public class FileInfo
    {
        public string FullName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string DirectoryName { get; set; }
        public string Path { get; set; }
        public FileAttributes Attributes { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastAccessTimeUtc { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastWriteTimeUtc { get; set; }
        public string Name { get; set; }
        public bool IsReadOnly { get; set; }
    }
    public class FileManagerFileInfoRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerFileInfoResponse : ServiceResponse<FileInfo> { }
    public class FileManagerFileInfo : FileManagerAction<FileManagerFileInfoRequest, FileManagerFileInfoResponse>
    {
        public FileManagerFileInfo(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerFileInfoRequest request, FileManagerFileInfoResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (File.Exists(path))
            {
                var fi = new System.IO.FileInfo(path);

                response.Data = new FileInfo();

                response.Data.FullName = fi.FullName;
                response.Data.Extension = fi.Extension;
                response.Data.DirectoryName = fi.DirectoryName;
                response.Data.Size = fi.Length;
                response.Data.Attributes = fi.Attributes;
                response.Data.CreationTime = fi.CreationTime;
                response.Data.CreationTimeUtc = fi.CreationTimeUtc;
                response.Data.LastAccessTime = fi.LastAccessTime;
                response.Data.LastAccessTimeUtc = fi.LastAccessTimeUtc;
                response.Data.LastWriteTime = fi.LastWriteTime;
                response.Data.LastWriteTimeUtc = fi.LastWriteTimeUtc;
                response.Data.Name = fi.Name;
                response.Data.IsReadOnly = fi.IsReadOnly;
                response.Data.Path = FileManager.GetRelativePath(response.Data.DirectoryName);

                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerFileInfoRequest request, FileManagerFileInfoResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerFileInfoRequest request, FileManagerFileInfoResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
