using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubDeleteResponse : BaseServiceResponse<object, ApiClientCustomerHubDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubDeleteStatus.Faulted;
        }

        public ApiClientCustomerHubDeleteResponse()
            : this(ApiClientCustomerHubDeleteStatus.None, default(object))
        { }
        public ApiClientCustomerHubDeleteResponse(ApiClientCustomerHubDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerHubDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubDeleteStatus.InvalidStatus;
        }
    }
}