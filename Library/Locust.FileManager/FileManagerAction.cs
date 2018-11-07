using Locust.AppPath;
using Locust.Configuration;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public abstract class FileManagerAction<TRequest, TResponse>: ServiceAction<TRequest, TResponse>
        where TRequest: ServiceRequest
        where TResponse: ServiceResponse, new()
    {
        private static string serverType;
        private string ServerType => serverType;
        static FileManagerAction()
        {
            serverType = ((string)Config.AppSettings.ServerType).ToLower();
        }
        public IFileManager FileManager { get; set; }
        public FileManagerAction(IFileManager filemanager)
        {
            FileManager = filemanager;
        }
        private void Finalize(TRequest request, TResponse response)
        {
            var fmaBaseRequest = request as FileManagerActionBaseRequest;

            if (fmaBaseRequest != null)
            {
                response.MessageArgs.Add("path", fmaBaseRequest.Path);
            }

            var fmaMoveBaseRequest = request as FileManagerMoveBaseRequest;

            if (fmaMoveBaseRequest != null)
            {
                response.MessageArgs.Add("newpath", fmaMoveBaseRequest.NewPath);
            }

            var fmaRenameBaseRequest = request as FileManagerRenameBaseRequest;

            if (fmaRenameBaseRequest != null)
            {
                response.MessageArgs.Add("newname", fmaRenameBaseRequest.NewName);
            }

            response.MessageKey = this.GetType().Name;

            if (response.Exception != null)
            {
                var fme = response.Exception as FileManagerException;

                if (fme != null && !string.IsNullOrEmpty(fme.Status))
                {
                    response.Status = fme.Status;
                }
            }

            if (ServerType != "development")
                response.Exception = null;
        }
        public override TResponse Run(TRequest request)
        {
            var result = base.Run(request);

            Finalize(request, result);

            return result;
        }
        public override async Task<TResponse> RunAsync(TRequest request, CancellationToken token)
        {
            var result = await base.RunAsync(request, token);

            Finalize(request, result);

            return result;
        }
    }
}
