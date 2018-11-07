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
    public class FileManagerGetSubDirectoriesRequest : FileManagerActionBaseRequest
    {
    }
    public class FileManagerGetSubDirectoriesResponse : ServiceResponse<List<string>>
    {
    }
    public class FileManagerGetSubDirectories : FileManagerAction<FileManagerGetSubDirectoriesRequest, FileManagerGetSubDirectoriesResponse>
    {
        public FileManagerGetSubDirectories(IFileManager filemanager) : base(filemanager)
        {
        }
        private void DoRun(FileManagerGetSubDirectoriesRequest request, FileManagerGetSubDirectoriesResponse response)
        {
            response.Data = new List<string>();

            var path = FileManager.GetAbsolutePath(request.Path);

            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path);

                foreach (var dir in dirs)
                {
                    var _dir = dir.Replace(FileManager.GetAbsolutePath(""), "");
                    _dir = _dir.Replace("\\", "/");

                    if (_dir[0] != '/')
                        _dir = '/' + _dir;
                    
                    response.Data.Add(_dir);
                }

                response.Succeeded();
            }
            else
            {
                response.Status = "NotExists";
            }
        }
        protected override void RunInternal(FileManagerGetSubDirectoriesRequest request, FileManagerGetSubDirectoriesResponse response)
        {
            DoRun(request, response);
        }
        protected override Task RunInternalAsync(FileManagerGetSubDirectoriesRequest request, FileManagerGetSubDirectoriesResponse response, CancellationToken token)
        {
            DoRun(request, response);

            return Task.CompletedTask;
        }
    }
}
