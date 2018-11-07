using Locust.WebExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.FileManager.Web
{
    public static class FileManagerExtensions
    {
        public static FileManagerSaveFilesResponse SaveFiles(this IFileManager fm, string path, HttpFileCollectionBase files, bool overwriteExisting = true, string filter = "")
        {
            FileManagerSaveFilesResponse response;

            if (files == null || files.Count == 0)
                response = new FileManagerSaveFilesResponse { Status = "NoPostedFile" };
            else
            {
                var _files = new List<DataFile>();

                foreach (HttpPostedFileBase file in files)
                {
                    var ms = new MemoryStream();
                    file.InputStream.CopyTo(ms);
                    _files.Add(new DataFile { FileName = file.FileName, Data = ms.ToArray() });
                }

                response = fm.SaveFiles.Run(new FileManagerSaveFilesRequest
                {
                    Path = path,
                    Files = _files.ToArray(),
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                });
            }

            return response;
        }
        public static async Task<FileManagerSaveFilesResponse> SaveFilesAsync(this IFileManager fm, string path, HttpFileCollectionBase files, bool overwriteExisting, string filter, CancellationToken token)
        {
            FileManagerSaveFilesResponse response;

            if (files == null || files.Count == 0)
                response = new FileManagerSaveFilesResponse { Status = "NoPostedFile" };
            else
            {
                var _files = new List<DataFile>();

                for (var i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    var data = await file.GetBytesAsync(8192, token);

                    _files.Add(new DataFile { FileName = file.FileName, Data = data });
                }

                response = await fm.SaveFiles.RunAsync(new FileManagerSaveFilesRequest
                {
                    Path = path,
                    Files = _files.ToArray(),
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                }, token);
            }

            return response;
        }
        public static FileManagerSaveFileResponse SaveFile(this IFileManager fm, string path, HttpPostedFileBase file, bool overwriteExisting = true, string filter = "")
        {
            FileManagerSaveFileResponse response;

            if (file == null)
                response = new FileManagerSaveFileResponse { Status = "NoPostedFile" };
            else
            {
                var ms = new MemoryStream();
                file.InputStream.CopyTo(ms);

                response = fm.SaveFile.Run(new FileManagerSaveFileRequest
                {
                    Path = path,
                    FileName = file.FileName,
                    Data = ms.ToArray(),
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                });
            }

            return response;
        }
        public static async Task<FileManagerSaveFileResponse> SaveFileAsync(this IFileManager fm, string path, HttpPostedFileBase file, bool overwriteExisting, string filter, CancellationToken token)
        {
            FileManagerSaveFileResponse response;

            if (file == null)
                response = new FileManagerSaveFileResponse { Status = "NoPostedFile" };
            else
            {
                var ms = new MemoryStream();
                await file.InputStream.CopyToAsync(ms, 8192, token);

                response = await fm.SaveFile.RunAsync(new FileManagerSaveFileRequest
                {
                    Path = path,
                    FileName = file.FileName,
                    Data = ms.ToArray(),
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                }, token);
            }

            return response;
        }
    }
}
