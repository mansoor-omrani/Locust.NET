using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubUpdateResponse : BaseServiceResponse<object, ApiClientCustomerHubUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubUpdateStatus.Faulted;
        }

        public ApiClientCustomerHubUpdateResponse()
            : this(ApiClientCustomerHubUpdateStatus.None, default(object))
        { }
        public ApiClientCustomerHubUpdateResponse(ApiClientCustomerHubUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerHubUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubUpdateStatus.InvalidStatus;
        }
    }
}