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
    public class FileManagerFileInfosRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerFileInfosResponse : ServiceResponse<List<FileInfo>> { }
    public class FileManagerFileInfos : FileManagerAction<FileManagerFileInfosRequest, FileManagerFileInfosResponse>
    {
        public FileManagerFileInfos(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerFileInfosRequest request, FileManagerFileInfosResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                response.Data = new List<FileInfo>();

                var di = new DirectoryInfo(path);
                var fis = di.GetFiles();
                
                foreach (var fi in fis)
                {
                    var _fi = new FileInfo();

                    _fi.FullName = fi.FullName;
                    _fi.Extension = fi.Extension;
                    _fi.DirectoryName = fi.DirectoryName;
                    _fi.Size = fi.Length;
                    _fi.Attributes = fi.Attributes;
                    _fi.CreationTime = fi.CreationTime;
                    _fi.CreationTimeUtc = fi.CreationTimeUtc;
                    _fi.LastAccessTime = fi.LastAccessTime;
                    _fi.LastAccessTimeUtc = fi.LastAccessTimeUtc;
                    _fi.LastWriteTime = fi.LastWriteTime;
                    _fi.LastWriteTimeUtc = fi.LastWriteTimeUtc;
                    _fi.Name = fi.Name;
                    _fi.IsReadOnly = fi.IsReadOnly;
                    _fi.Path = FileManager.GetRelativePath(_fi.DirectoryName);

                    response.Data.Add(_fi);
                }
                
                response.Succeeded();
            }
            else
            {
                response.Status = "PathNotFound";
            }
        }
        protected override void RunInternal(FileManagerFileInfosRequest request, FileManagerFileInfosResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerFileInfosRequest request, FileManagerFileInfosResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
