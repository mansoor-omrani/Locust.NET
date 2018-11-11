using System;
using Locust.ServiceModel;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetByPKResponse : BaseServiceResponse<ApiClientCustomerHub.Full, ApiClientCustomerHubGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubGetByPKStatus.Faulted;
        }

        public ApiClientCustomerHubGetByPKResponse()
            : base(ApiClientCustomerHubGetByPKStatus.None, default(ApiClientCustomerHub.Full))
        { }
        public ApiClientCustomerHubGetByPKResponse(ApiClientCustomerHubGetByPKStatus status,ApiClientCustomerHub.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerHubGetByPKStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubGetByPKStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiClientCustomerHubGetByPKStatus.NotFound;
        }
    }
}