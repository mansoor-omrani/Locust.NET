using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.Full;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByHashResponse : BaseServiceResponse<ResponseType, ApiClientGetByHashStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetByHashStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetByHashStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetByHashStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetByHashStatus.Faulted;
        }

        public ApiClientGetByHashResponse()
            : this(ApiClientGetByHashStatus.None, default(ResponseType))
        { }
        public ApiClientGetByHashResponse(ApiClientGetByHashStatus status,ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetByHashStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetByHashStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetByHashStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientGetByHashStatus.Errored;
        }
		
		public override void NotFound()
        {
            this.Status = ApiClientGetByHashStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientGetByHashStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetByHashStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetByHashStatus.InvalidStatus;
        }
    }
}