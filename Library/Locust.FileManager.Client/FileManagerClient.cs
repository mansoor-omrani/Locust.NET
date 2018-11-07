using Locust.ApiClient;
using Locust.Configuration;
using Locust.Extensions;
using Locust.FileManager;
using Locust.FileManager.Web;
using Locust.Mime;
using Locust.Service;
using Locust.WebExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.FileManager.Client
{
    public class FileManagerClient : IFileManagerClient
    {
        public IFileManager FileManager { get; set; }
        public IApiClient ApiClient { get; set; }
        public bool DirectMode { get; set; }
        private string basePath;
        public string BasePath
        {
            get { return basePath; }
            set
            {
                basePath = value;
                
                FileManager.BasePath = FileManager.DefaultBasePath + basePath;
            }
        }
        public string AuthToken { get; set; }
        public FileManagerClient(IFileManager filemanager, IApiClient apiClient)
        {
            if (filemanager == null)
                throw new ArgumentNullException("filemanager");

            if (apiClient == null)
                throw new ArgumentNullException("apiClient");

            this.FileManager = filemanager;
            this.ApiClient = apiClient;

            AuthToken = Config.AppSettings.FileManagerRestrictHeaderToken;
        }
        private T FinalizeResponse<T>(ApiResponse ar) where T:ServiceResponse, new()
        {
            var result = new T();

            if (ar.Success)
            {
                if (!string.IsNullOrEmpty(ar.Result))
                {
                    try
                    {
                        result = JsonConvert.DeserializeObject<T>(ar.Result);
                    }
                    catch (Exception e)
                    {
                        result.Status = "DeserializeResponseError";
                        result.Exception = e;
                    }
                }
                else
                {
                    result.Status = "NoResponse";
                }
            }
            else
            {
                result.Status = "ApiFailed";

                if (ar.Exception != null)
                {
                    result.Exception = ar.Exception;
                }
            }

            return result;
        }
        private WebRequest Initializer(ApiRequest areq, WebRequest req)
        {
            req.Headers.Add("fmtoken", AuthToken);

            return req;
        }
        private string GetPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return BasePath;
            else
                return path[0] == '/' || path[0] == '\\' ? BasePath + path : BasePath + "/" + path;
        }
        #region None-Cancelleable
        public Task<FileManagerCreateDirResponse> CreateDirAsync(string path)
        {
            return CreateDirAsync(path, CancellationToken.None);
        }
        public Task<FileManagerDeleteDirResponse> DeleteDirAsync(string path, bool recursive = false)
        {
            return DeleteDirAsync(path, recursive, CancellationToken.None);
        }
        public Task<FileManagerDirExistsResponse> DirExistsAsync(string path)
        {
            return DirExistsAsync(path, CancellationToken.None);
        }
        public Task<FileManagerDirInfoResponse> DirInfoAsync(string path)
        {
            return DirInfoAsync(path, CancellationToken.None);
        }
        public Task<FileManagerDirSizeResponse> DirSizeAsync(string path)
        {
            return DirSizeAsync(path, CancellationToken.None);
        }
        public Task<FileManagerFileInfoResponse> FileInfoAsync(string path)
        {
            return FileInfoAsync(path, CancellationToken.None);
        }
        public Task<FileManagerFileInfosResponse> FileInfosAsync(string path)
        {
            return FileInfosAsync(path, CancellationToken.None);
        }
        public Task<FileManagerGetSubDirectoriesResponse> GetSubDirectoriesAsync(string path)
        {
            return GetSubDirectoriesAsync(path, CancellationToken.None);
        }
        public Task<FileManagerSaveFileResponse> SaveFileAsync(string path, HttpPostedFileBase file, bool overwriteExisting = true, string filter = "")
        {
            return SaveFileAsync(path, file, overwriteExisting, filter, CancellationToken.None);
        }
        public Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, string data, bool overwriteExisting = true, string filter = "")
        {
            return SaveFileAsync(path, filename, data, overwriteExisting, filter, CancellationToken.None);
        }
        public Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, byte[] data, bool overwriteExisting = true, string filter = "")
        {
            return SaveFileAsync(path, filename, data, overwriteExisting, filter, CancellationToken.None);
        }
        public Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, HttpFileCollectionBase files, bool overwriteExisting = true, string filter = "")
        {
            return SaveFilesAsync(path, files, overwriteExisting, filter, CancellationToken.None);
        }
        public Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, DataFile[] files, bool overwriteExisting = true, string filter = "")
        {
            return SaveFilesAsync(path, files, overwriteExisting, filter, CancellationToken.None);
        }
        public Task<FileManagerDeleteFileResponse> DeleteFileAsync(string path)
        {
            return DeleteFileAsync(path, CancellationToken.None);
        }
        public Task<FileManagerDeleteFilesResponse> DeleteFilesAsync(params string[] paths)
        {
            return DeleteFilesAsync(paths, CancellationToken.None);
        }
        public Task<FileManagerFileExistsResponse> FileExistsAsync(string path)
        {
            return FileExistsAsync(path, CancellationToken.None);
        }
        public Task<FileManagerGetFilesResponse> GetFilesAsync(string path)
        {
            return GetFilesAsync(path, CancellationToken.None);
        }
        public Task<FileManagerGetFileResponse> GetFileAsync(string path)
        {
            return GetFileAsync(path, CancellationToken.None);
        }
        #endregion
        #region Cancelleable
        public async Task<FileManagerCreateDirResponse> CreateDirAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.CreateDir.Run(new FileManagerCreateDirRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/create", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerCreateDirResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDeleteDirResponse> DeleteDirAsync(string path, bool recursive, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DeleteDir.Run(new FileManagerDeleteDirRequest { Path = path, Recursive = recursive });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/delete", new Dictionary<string, object> { { "path", GetPath(path) }, { "recursive", recursive } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDeleteDirResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDirExistsResponse> DirExistsAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DirExists.Run(new FileManagerDirExistsRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/exists", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDirExistsResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDirInfoResponse> DirInfoAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DirInfo.Run(new FileManagerDirInfoRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/info", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDirInfoResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDirSizeResponse> DirSizeAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DirSize.Run(new FileManagerDirSizeRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/size", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDirSizeResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerFileInfoResponse> FileInfoAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.FileInfo.Run(new FileManagerFileInfoRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/info", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerFileInfoResponse>(ar);

                if (response.Success && !string.IsNullOrEmpty(BasePath))
                {
                    response.Data.Path = response.Data.Path.Substring(BasePath.Length);
                }

                return response;
            }
        }
        public async Task<FileManagerFileInfosResponse> FileInfosAsync(string path, CancellationToken token)
        {
            FileManagerFileInfosResponse result;

            if (DirectMode)
            {
                result = FileManager.FileInfos.Run(new FileManagerFileInfosRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/infos", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerFileInfosResponse>(ar);

                if (response.Success && !string.IsNullOrEmpty(BasePath))
                {
                    foreach (var fi in response.Data)
                    {
                        fi.Path = fi.Path.Substring(BasePath.Length);
                    }
                }

                result = response;
            }

            if (result.Data == null)
            {
                result.Data = new List<FileInfo>();
            }

            return result;
        }
        public async Task<FileManagerGetSubDirectoriesResponse> GetSubDirectoriesAsync(string path, CancellationToken token)
        {
            FileManagerGetSubDirectoriesResponse result;

            if (DirectMode)
            {
                result = FileManager.GetSubDirectories.Run(new FileManagerGetSubDirectoriesRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/subdirs", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerGetSubDirectoriesResponse>(ar);

                result = response;
            }

            if (result.Data == null)
            {
                result.Data = new List<string>();
            }

            return result;
        }
        public async Task<FileManagerSaveFileResponse> SaveFileAsync(string path, HttpPostedFileBase file, bool overwriteExisting, string filter, CancellationToken token)
        {
            FileManagerSaveFileResponse response;

            if (file == null)
            {
                response = new FileManagerSaveFileResponse { Status = "NoFile" };
            }
            else
            {
                var data = await file.GetBytesAsync(8192, token);

                if (DirectMode)
                {
                    response = await FileManager.SaveFile.RunAsync(new FileManagerSaveFileRequest
                    {
                        Path = path,
                        FileName = file.FileName,
                        Data = data,
                        OverwriteExisting = overwriteExisting,
                        Filter = filter
                    });
                }
                else
                {
                    var ar = await ApiClient.SendAsync("/filemanager/file/save", file.FileName, data, new Dictionary<string, object>
                    {
                        { "path", GetPath(path) },
                        { "overwrite", overwriteExisting }
                    }, Initializer, MimeHelper.GetMimeType(file.FileName), token);
                    response = FinalizeResponse<FileManagerSaveFileResponse>(ar);
                }
            }

            return response;
        }
        public async Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, string data, bool overwriteExisting, string filter, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.SaveFile.RunAsync(new FileManagerSaveFileRequest
                {
                    Path = path,
                    FileName = filename,
                    Data = Encoding.UTF8.GetBytes(data),
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                });
            }
            else
            {
                var ar = await ApiClient.SendAsync("/filemanager/file/save", filename, Encoding.UTF8.GetBytes(data), new Dictionary<string, object>
                {
                    { "path", GetPath(path) },
                    { "overwrite", overwriteExisting }
                }, Initializer, MimeHelper.GetMimeType(filename), token);
                var response = FinalizeResponse<FileManagerSaveFileResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, byte[] data, bool overwriteExisting, string filter, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.SaveFile.RunAsync(new FileManagerSaveFileRequest
                {
                    Path = path,
                    FileName = filename,
                    Data = data,
                    OverwriteExisting = overwriteExisting,
                    Filter = filter
                });
            }
            else
            {
                var ar = await ApiClient.SendAsync("/filemanager/file/save", filename, data, new Dictionary<string, object>
                {
                    { "path", GetPath(path) },
                    { "overwrite", overwriteExisting }
                }, Initializer, MimeHelper.GetMimeType(filename), token);
                var response = FinalizeResponse<FileManagerSaveFileResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, HttpFileCollectionBase files, bool overwriteExisting, string filter, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.SaveFilesAsync(path, files, overwriteExisting, filter, token);
            }
            else
            {
                var _files = new List<SendData>();

                if (files != null)
                {
                    for (var i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        var data = await file.GetBytesAsync(8192, token);
                        _files.Add(new SendData { FileName = file.FileName, Data = data, ContentType = MimeHelper.GetMimeType(file.FileName) });
                    }
                }

                var ar = await ApiClient.SendAsync("/filemanager/file/save", _files.ToArray(), new Dictionary<string, object>
                {
                    { "path", GetPath(path) },
                    { "overwrite", overwriteExisting }
                }, Initializer, token);

                var response = FinalizeResponse<FileManagerSaveFilesResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, DataFile[] files, bool overwriteExisting, string filter, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.SaveFilesAsync(path, files, overwriteExisting, filter, token);
            }
            else
            {
                var _files = files?.Select(f => new SendData { FileName = f.FileName, Data = f.Data, ContentType = MimeHelper.GetMimeType(f.FileName) }).ToArray();

                var ar = await ApiClient.SendAsync("/filemanager/file/save", _files, new Dictionary<string, object>
                {
                    { "path", GetPath(path) },
                    { "overwrite", overwriteExisting }
                }, Initializer, token);

                var response = FinalizeResponse<FileManagerSaveFilesResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDeleteFileResponse> DeleteFileAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DeleteFile.Run(new FileManagerDeleteFileRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/delete", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDeleteFileResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerDeleteFilesResponse> DeleteFilesAsync(string[] paths, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.DeleteFiles.Run(new FileManagerDeleteFilesRequest { Paths = paths });
            }
            else
            {
                var _paths = paths?.Select(p => GetPath(p)).Join(",");
                var ar = await ApiClient.PostAsync("/filemanager/file/deletemany", new Dictionary<string, object> { { "paths", _paths } }, Initializer, token);
                var response = FinalizeResponse<FileManagerDeleteFilesResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerFileExistsResponse> FileExistsAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.FileExists.Run(new FileManagerFileExistsRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/exists", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerFileExistsResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerGetFilesResponse> GetFilesAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return FileManager.GetFiles.Run(new FileManagerGetFilesRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/files", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerGetFilesResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerGetFileResponse> GetFileAsync(string path, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.GetFile.RunAsync(new FileManagerGetFileRequest { Path = path });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/get", new Dictionary<string, object> { { "path", GetPath(path) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerGetFileResponse>(ar);

                return response;
            }
        }

        public Task<FileManagerMoveDirResponse> MoveDirAsync(string path, string newPath)
        {
            return MoveDirAsync(path, newPath, CancellationToken.None);
        }

        public Task<FileManagerMoveFileResponse> MoveFileAsync(string path, string newPath)
        {
            return MoveFileAsync(path, newPath, CancellationToken.None);
        }
        public Task<FileManagerRenameDirResponse> RenameDirAsync(string path, string newname)
        {
            return RenameDirAsync(path, newname, CancellationToken.None);
        }
        public Task<FileManagerRenameFileResponse> RenameFileAsync(string path, string newname)
        {
            return RenameFileAsync(path, newname, CancellationToken.None);
        }
        public async Task<FileManagerMoveDirResponse> MoveDirAsync(string path, string newPath, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.MoveDir.RunAsync(new FileManagerMoveDirRequest { Path = path, NewPath = newPath });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/move", new Dictionary<string, object> { { "path", GetPath(path) }, { "newpath", GetPath(newPath) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerMoveDirResponse>(ar);

                return response;
            }
        }

        public async Task<FileManagerMoveFileResponse> MoveFileAsync(string path, string newPath, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.MoveFile.RunAsync(new FileManagerMoveFileRequest { Path = path, NewPath = newPath });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/move", new Dictionary<string, object> { { "path", GetPath(path) }, { "newpath", GetPath(newPath) } }, Initializer, token);
                var response = FinalizeResponse<FileManagerMoveFileResponse>(ar);

                return response;
            }
        }
        public async Task<FileManagerRenameDirResponse> RenameDirAsync(string path, string newname, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.RenameDir.RunAsync(new FileManagerRenameDirRequest { Path = path, NewName = newname });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/dir/rename", new Dictionary<string, object> { { "path", GetPath(path) }, { "newname", newname } }, Initializer, token);
                var response = FinalizeResponse<FileManagerRenameDirResponse>(ar);

                return response;
            }
        }

        public async Task<FileManagerRenameFileResponse> RenameFileAsync(string path, string newname, CancellationToken token)
        {
            if (DirectMode)
            {
                return await FileManager.RenameFile.RunAsync(new FileManagerRenameFileRequest { Path = path, NewName = newname });
            }
            else
            {
                var ar = await ApiClient.PostAsync("/filemanager/file/rename", new Dictionary<string, object> { { "path", GetPath(path) }, { "newname", newname } }, Initializer, token);
                var response = FinalizeResponse<FileManagerRenameFileResponse>(ar);

                return response;
            }
        }
        #endregion
    }
}
