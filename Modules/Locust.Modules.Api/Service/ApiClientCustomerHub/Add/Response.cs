using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubAddResponse : BaseServiceResponse<int, ApiClientCustomerHubAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubAddStatus.Faulted;
        }

        public ApiClientCustomerHubAddResponse()
            : this(ApiClientCustomerHubAddStatus.None, default(int))
        { }
        public ApiClientCustomerHubAddResponse(ApiClientCustomerHubAddStatus status,int data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerHubAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubAddStatus.InvalidStatus;
        }
    }
}