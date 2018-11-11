using System;
using Locust.ServiceModel;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByKeyResponse : BaseServiceResponse<ApiClient.Full, ApiClientGetByKeyStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetByKeyStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetByKeyStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetByKeyStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetByKeyStatus.Faulted;
        }

        public ApiClientGetByKeyResponse()
            : base(ApiClientGetByKeyStatus.None, default(ApiClient.Full))
        { }
        public ApiClientGetByKeyResponse(ApiClientGetByKeyStatus status,ApiClient.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetByKeyStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetByKeyStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetByKeyStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientGetByKeyStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientGetByKeyStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetByKeyStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetByKeyStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiClientGetByKeyStatus.NotFound;
        }
    }
}