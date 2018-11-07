using Locust.AppPath;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.FileManager
{
    public class DataFile
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
    public interface IFileManager
    {
        string Root { get; set; }
        string DefaultBasePath { get; set; }
        string BasePath { get; set; }
        string SaveFileFilter { get; set; }
        bool CheckQuota(long newSize);
        void UpdateQuota(long newSize);
        string GetRelativePath(string path);
        string GetAbsolutePath(string path);
        FileManagerCreateDir CreateDir { get; }
        FileManagerDeleteDir DeleteDir { get; }
        FileManagerMoveDir MoveDir { get; }
        FileManagerDirExists DirExists { get; }
        FileManagerSaveFile SaveFile { get; }
        FileManagerSaveFiles SaveFiles { get; }
        FileManagerDeleteFile DeleteFile { get; }
        FileManagerDeleteFiles DeleteFiles { get; }
        FileManagerMoveFile MoveFile { get; }
        FileManagerFileExists FileExists { get; }
        FileManagerGetSubDirectories GetSubDirectories { get; }
        FileManagerGetFiles GetFiles { get; }
        FileManagerDirInfo DirInfo { get; }
        FileManagerDirSize DirSize { get; }
        FileManagerFileInfo FileInfo { get; }
        FileManagerFileInfos FileInfos { get; }
        FileManagerGetFile GetFile { get; }
        FileManagerRenameFile RenameFile { get; }
        FileManagerRenameDir RenameDir { get; }
    }    
    public class FileManager: IFileManager
    {
        public string Root { get; set; }
        public string DefaultBasePath { get; set; }
        public string BasePath { get; set; }
        public string SaveFileFilter { get; set; }
        public FileManagerCreateDir CreateDir { get; private set; }
        public FileManagerDeleteDir DeleteDir { get; private set; }
        public FileManagerMoveDir MoveDir { get; private set; }
        public FileManagerDirExists DirExists { get; private set; }
        public FileManagerSaveFile SaveFile { get; private set; }
        public FileManagerSaveFiles SaveFiles { get; private set; }
        public FileManagerDeleteFile DeleteFile { get; private set; }
        public FileManagerDeleteFiles DeleteFiles { get; private set; }
        public FileManagerMoveFile MoveFile { get; private set; }
        public FileManagerRenameFile RenameFile { get; private set; }
        public FileManagerRenameDir RenameDir { get; private set; }
        public FileManagerFileExists FileExists { get; private set; }
        public FileManagerGetSubDirectories GetSubDirectories { get; private set; }
        public FileManagerGetFiles GetFiles { get; private set; }
        public FileManagerDirInfo DirInfo { get; private set; }
        public FileManagerDirSize DirSize { get; private set; }
        public FileManagerFileInfo FileInfo { get; private set; }
        public FileManagerFileInfos FileInfos { get; private set; }
        public FileManagerGetFile GetFile { get; private set; }
        public FileManager()
        {
            DefaultBasePath = @"\data";
            BasePath = @"\data";

            CreateDir = new FileManagerCreateDir(this);
            DeleteDir = new FileManagerDeleteDir(this);
            MoveDir = new FileManagerMoveDir(this);
            DirExists = new FileManagerDirExists(this);
            SaveFile = new FileManagerSaveFile(this);
            SaveFiles = new FileManagerSaveFiles(this);
            DeleteFile = new FileManagerDeleteFile(this);
            DeleteFiles = new FileManagerDeleteFiles(this);
            MoveFile = new FileManagerMoveFile(this);
            RenameFile = new FileManagerRenameFile(this);
            RenameDir = new FileManagerRenameDir(this);
            FileExists = new FileManagerFileExists(this);
            GetSubDirectories = new FileManagerGetSubDirectories(this);
            GetFiles = new FileManagerGetFiles(this);
            DirInfo = new FileManagerDirInfo(this);
            DirSize = new FileManagerDirSize(this);
            FileInfo = new FileManagerFileInfo(this);
            FileInfos = new FileManagerFileInfos(this);
            GetFile = new FileManagerGetFile(this);
        }

        public virtual bool CheckQuota(long newSize)
        {
            return true;
        }
        public string GetRelativePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var root = GetAbsolutePath("/");

                if (path[path.Length - 1] != '\\')
                {
                    path = path + "\\";
                }

                var result = path.Replace(root, "").Replace("\\", "/");

                if (string.IsNullOrEmpty(result))
                    return "/";

                if (result[0] != '/')
                    result = '/' + result;

                if (result.Length > 1)
                    return result.EndsWith("/") ? result.Substring(0, result.Length - 1) : result;

                return result;
            }
            else
            {
                return "/";
            }
        }
        public string GetAbsolutePath(string path)
        {
            var result = "";

            if (!string.IsNullOrEmpty(path) && path[0] != '/')
            {
                path = '/' + path;
            }

            var root = "";

            if (string.IsNullOrEmpty(Root))
                root = ApplicationPath.Root + BasePath;
            else
                root = Root + BasePath;

            root = System.IO.Path.GetFullPath(root);
            result = (root + path).Replace("/", "\\");
            result = System.IO.Path.GetFullPath(result);

            if (result.Length < root.Length || result.Substring(0, root.Length) != root)
            {
                throw new FileManagerException("ForbiddenPath", $"Access to {path} is denied");
            }

            return result;
        }

        public virtual void UpdateQuota(long newSize)
        {
        }
    }

    public static class FileManagerExtensions
    {
        public static FileManagerCreateDirResponse CreateDir(this IFileManager fm, string path)
        {
            return fm.CreateDir.Run(new FileManagerCreateDirRequest { Path = path });
        }
        public static FileManagerDeleteDirResponse DeleteDir(this IFileManager fm, string path, bool recursize = false)
        {
            return fm.DeleteDir.Run(new FileManagerDeleteDirRequest { Path = path, Recursive = recursize });
        }
        public static FileManagerMoveDirResponse MoveDir(this IFileManager fm, string path, string newPath)
        {
            return fm.MoveDir.Run(new FileManagerMoveDirRequest { Path = path, NewPath = newPath });
        }
        public static FileManagerDirExistsResponse DirExists(this IFileManager fm, string path)
        {
            return fm.DirExists.Run(new FileManagerDirExistsRequest { Path = path });
        }
        public static FileManagerDirInfoResponse DirInfo(this IFileManager fm, string path)
        {
            return fm.DirInfo.Run(new FileManagerDirInfoRequest { Path = path });
        }
        public static FileManagerDirSizeResponse DirSize(this IFileManager fm, string path)
        {
            return fm.DirSize.Run(new FileManagerDirSizeRequest { Path = path });
        }
        public static FileManagerFileInfoResponse FileInfo(this IFileManager fm, string path)
        {
            return fm.FileInfo.Run(new FileManagerFileInfoRequest { Path = path });
        }
        public static FileManagerFileInfosResponse FileInfos(this IFileManager fm, string path)
        {
            return fm.FileInfos.Run(new FileManagerFileInfosRequest { Path = path });
        }
        public static FileManagerGetSubDirectoriesResponse GetSubDirectories(this IFileManager fm, string path)
        {
            return fm.GetSubDirectories.Run(new FileManagerGetSubDirectoriesRequest { Path = path });
        }
        public static FileManagerSaveFileResponse SaveFile(this IFileManager fm, string path, string filename, byte[] data, bool overwriteExisting = true, string filter = "")
        {
            return fm.SaveFile.Run(new FileManagerSaveFileRequest
            {
                Path = path,
                FileName = filename,
                Data = data,
                OverwriteExisting = overwriteExisting,
                Filter = filter
            });
        }
        public static FileManagerSaveFileResponse SaveFile(this IFileManager fm, string path, string filename, string data, bool overwriteExisting = true, string filter = "")
        {
            return fm.SaveFile.Run(new FileManagerSaveFileRequest
            {
                Path = path,
                FileName = filename,
                Data = Encoding.UTF8.GetBytes(data),
                OverwriteExisting = overwriteExisting,
                Filter = filter
            });
        }
        public static Task<FileManagerSaveFileResponse> SaveFileAsync(this IFileManager fm, string path, string filename, byte[] data, bool overwriteExisting, string filter, CancellationToken token)
        {
            return fm.SaveFile.RunAsync(new FileManagerSaveFileRequest
            {
                Path = path,
                FileName = filename,
                Data = data,
                OverwriteExisting = overwriteExisting,
                Filter = filter
            }, token);
        }
        public static Task<FileManagerSaveFileResponse> SaveFileAsync(this IFileManager fm, string path, string filename, string data, bool overwriteExisting, string filter, CancellationToken token)
        {
            return fm.SaveFile.RunAsync(new FileManagerSaveFileRequest
            {
                Path = path,
                FileName = filename,
                Data = Encoding.UTF8.GetBytes(data),
                OverwriteExisting = overwriteExisting,
                Filter = filter
            }, token);
        }
        public static FileManagerSaveFilesResponse SaveFiles(this IFileManager fm, string path, DataFile[] files, bool overwriteExisting = true, string filter = "")
        {
            return fm.SaveFiles.Run(new FileManagerSaveFilesRequest
            {
                Path = path,
                Files = files,
                OverwriteExisting = overwriteExisting,
                Filter = filter
            });
        }
        public static Task<FileManagerSaveFilesResponse> SaveFilesAsync(this IFileManager fm, string path, DataFile[] files, bool overwriteExisting, string filter, CancellationToken token)
        {
            return fm.SaveFiles.RunAsync(new FileManagerSaveFilesRequest
            {
                Path = path,
                Files = files,
                OverwriteExisting = overwriteExisting,
                Filter = filter
            }, token);
        }
        public static FileManagerDeleteFileResponse DeleteFile(this IFileManager fm, string path)
        {
            return fm.DeleteFile.Run(new FileManagerDeleteFileRequest { Path = path });
        }
        public static FileManagerDeleteFilesResponse DeleteFiles(this IFileManager fm, params string[] paths)
        {
            return fm.DeleteFiles.Run(new FileManagerDeleteFilesRequest { Paths = paths });
        }
        public static FileManagerMoveFileResponse MoveFile(this IFileManager fm, string path, string newPath)
        {
            return fm.MoveFile.Run(new FileManagerMoveFileRequest { Path = path, NewPath = newPath });
        }
        public static FileManagerRenameFileResponse RenameFile(this IFileManager fm, string path, string newname)
        {
            return fm.RenameFile.Run(new FileManagerRenameFileRequest { Path = path, NewName = newname });
        }
        public static FileManagerRenameDirResponse RenameDir(this IFileManager fm, string path, string newname)
        {
            return fm.RenameDir.Run(new FileManagerRenameDirRequest { Path = path, NewName = newname });
        }
        public static FileManagerFileExistsResponse FileExists(this IFileManager fm, string path)
        {
            return fm.FileExists.Run(new FileManagerFileExistsRequest { Path = path });
        }
        public static FileManagerGetFilesResponse GetFiles(this IFileManager fm, string path)
        {
            return fm.GetFiles.Run(new FileManagerGetFilesRequest { Path = path });
        }
        public static FileManagerGetFileResponse GetFile(this IFileManager fm, string path)
        {
            return fm.GetFile.Run(new FileManagerGetFileRequest { Path = path });
        }
        public static Task<FileManagerGetFileResponse> GetFileAsync(this IFileManager fm, string path)
        {
            return fm.GetFile.RunAsync(new FileManagerGetFileRequest { Path = path });
        }
    }
}
