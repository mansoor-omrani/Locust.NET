using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubQuickUpdateResponse : BaseServiceResponse<object, ApiClientCustomerHubQuickUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubQuickUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubQuickUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubQuickUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubQuickUpdateStatus.Faulted;
        }

        public ApiClientCustomerHubQuickUpdateResponse()
            : this(ApiClientCustomerHubQuickUpdateStatus.None, default(object))
        { }
        public ApiClientCustomerHubQuickUpdateResponse(ApiClientCustomerHubQuickUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubQuickUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubQuickUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubQuickUpdateStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientCustomerHubQuickUpdateStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubQuickUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubQuickUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubQuickUpdateStatus.InvalidStatus;
        }
    }
}