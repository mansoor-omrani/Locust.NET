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
    public enum FileManagerCreateDirResponseStatus
    {
        Success,
        AlreadyExists,
        Failed
    }
    public class FileManagerCreateDirRequest : FileManagerActionBaseRequest
    { }
    public class FileManagerCreateDirResponse : ServiceResponse
    {
        public override bool IsSucceeded()
        {
            return this.Success || this.HasStatus(FileManagerCreateDirResponseStatus.AlreadyExists);
        }
    }
    public class FileManagerCreateDir : FileManagerAction<FileManagerCreateDirRequest, FileManagerCreateDirResponse>
    {
        public FileManagerCreateDir(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerCreateDirRequest request, FileManagerCreateDirResponse response)
        {
            var path = FileManager.GetAbsolutePath(request.Path);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                response.Succeeded();
            }
            else
            {
                response.SetStatus(FileManagerCreateDirResponseStatus.AlreadyExists);
            }
        }
        protected override void RunInternal(FileManagerCreateDirRequest request, FileManagerCreateDirResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerCreateDirRequest request, FileManagerCreateDirResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
