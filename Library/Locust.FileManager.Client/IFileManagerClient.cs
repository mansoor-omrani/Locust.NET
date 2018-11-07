using Locust.ApiClient;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.FileManager.Client
{
    public interface IFileManagerClient
    {
        IFileManager FileManager { get; set; }
        bool DirectMode { get; set; }
        string BasePath { get; set; }
        Task<FileManagerCreateDirResponse> CreateDirAsync(string path);
        Task<FileManagerDirExistsResponse> DirExistsAsync(string path);
        Task<FileManagerDirInfoResponse> DirInfoAsync(string path);
        Task<FileManagerDirSizeResponse> DirSizeAsync(string path);
        Task<FileManagerFileExistsResponse> FileExistsAsync(string path);
        Task<FileManagerFileInfoResponse> FileInfoAsync(string path);
        Task<FileManagerFileInfosResponse> FileInfosAsync(string path);
        Task<FileManagerGetFileResponse> GetFileAsync(string path);
        Task<FileManagerGetFilesResponse> GetFilesAsync(string path);
        Task<FileManagerGetSubDirectoriesResponse> GetSubDirectoriesAsync(string path);
        Task<FileManagerDeleteDirResponse> DeleteDirAsync(string path, bool recursive = false);
        Task<FileManagerMoveDirResponse> MoveDirAsync(string path, string newPath);
        Task<FileManagerRenameDirResponse> RenameDirAsync(string path, string newname);
        Task<FileManagerDeleteFileResponse> DeleteFileAsync(string path);
        Task<FileManagerDeleteFilesResponse> DeleteFilesAsync(params string[] path);
        Task<FileManagerMoveFileResponse> MoveFileAsync(string path, string newPath);
        Task<FileManagerRenameFileResponse> RenameFileAsync(string path, string newname);
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, HttpPostedFileBase file, bool overwriteExisting = true, string filter = "");
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, string data, bool overwriteExisting = true, string filter = "");
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, byte[] data, bool overwriteExisting = true, string filter = "");
        Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, HttpFileCollectionBase files, bool overwriteExisting = true, string filter = "");
        Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, DataFile[] files, bool overwriteExisting = true, string filter = "");
        #region Cancellation versions
        Task<FileManagerCreateDirResponse> CreateDirAsync(string path, CancellationToken token);
        Task<FileManagerDirExistsResponse> DirExistsAsync(string path, CancellationToken token);
        Task<FileManagerDirInfoResponse> DirInfoAsync(string path, CancellationToken token);
        Task<FileManagerDirSizeResponse> DirSizeAsync(string path, CancellationToken token);
        Task<FileManagerFileExistsResponse> FileExistsAsync(string path, CancellationToken token);
        Task<FileManagerFileInfoResponse> FileInfoAsync(string path, CancellationToken token);
        Task<FileManagerFileInfosResponse> FileInfosAsync(string path, CancellationToken token);
        Task<FileManagerGetFileResponse> GetFileAsync(string path, CancellationToken token);
        Task<FileManagerGetFilesResponse> GetFilesAsync(string path, CancellationToken token);
        Task<FileManagerGetSubDirectoriesResponse> GetSubDirectoriesAsync(string path, CancellationToken token);
        Task<FileManagerDeleteDirResponse> DeleteDirAsync(string path, bool recursive, CancellationToken token);
        Task<FileManagerMoveDirResponse> MoveDirAsync(string path, string newPath, CancellationToken token);
        Task<FileManagerRenameDirResponse> RenameDirAsync(string path, string newname, CancellationToken token);
        Task<FileManagerDeleteFileResponse> DeleteFileAsync(string path, CancellationToken token);
        Task<FileManagerDeleteFilesResponse> DeleteFilesAsync(string[] paths, CancellationToken token);
        Task<FileManagerMoveFileResponse> MoveFileAsync(string path, string newPath, CancellationToken token);
        Task<FileManagerRenameFileResponse> RenameFileAsync(string path, string newname, CancellationToken token);
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, HttpPostedFileBase file, bool overwriteExisting, string filter, CancellationToken token);
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, string data, bool overwriteExisting, string filter, CancellationToken token);
        Task<FileManagerSaveFileResponse> SaveFileAsync(string path, string filename, byte[] data, bool overwriteExisting, string filter, CancellationToken token);
        Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, HttpFileCollectionBase files, bool overwriteExisting, string filter, CancellationToken token);
        Task<FileManagerSaveFilesResponse> SaveFilesAsync(string path, DataFile[] files, bool overwriteExisting, string filter, CancellationToken token);
        #endregion
    }
}