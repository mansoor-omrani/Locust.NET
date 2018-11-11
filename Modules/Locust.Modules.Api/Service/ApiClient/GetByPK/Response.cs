using System;
using Locust.ServiceModel;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByPKResponse : BaseServiceResponse<ApiClient.Full, ApiClientGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetByPKStatus.Faulted;
        }

        public ApiClientGetByPKResponse()
            : base(ApiClientGetByPKStatus.None, default(ApiClient.Full))
        { }
        public ApiClientGetByPKResponse(ApiClientGetByPKStatus status,ApiClient.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientGetByPKStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetByPKStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiClientGetByPKStatus.NotFound;
        }
    }
}