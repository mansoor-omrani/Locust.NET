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
    public class FileManagerGetFilesRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerGetFilesResponse : ServiceResponse<List<string>>
    {
    }
    public class FileManagerGetFiles : FileManagerAction<FileManagerGetFilesRequest, FileManagerGetFilesResponse>
    {
        public FileManagerGetFiles(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerGetFilesRequest request, FileManagerGetFilesResponse response)
        {
            response.Data = new List<string>();

            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    var _file = file.Replace(FileManager.GetAbsolutePath(""), "");
                    _file = _file.Replace("\\", "/");

                    if (_file[0] != '/')
                        _file = '/' + _file;
                    
                    response.Data.Add(_file);
                }

                response.Succeeded();
            }
            else
            {
                response.Status = "PathNotFound";
            }
        }
        protected override void RunInternal(FileManagerGetFilesRequest request, FileManagerGetFilesResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerGetFilesRequest request, FileManagerGetFilesResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
