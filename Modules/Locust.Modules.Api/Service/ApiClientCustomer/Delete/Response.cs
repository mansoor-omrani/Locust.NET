using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerDeleteResponse : BaseServiceResponse<object, ApiClientCustomerDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerDeleteStatus.Faulted;
        }

        public ApiClientCustomerDeleteResponse()
            : this(ApiClientCustomerDeleteStatus.None, default(object))
        { }
        public ApiClientCustomerDeleteResponse(ApiClientCustomerDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerDeleteStatus.InvalidStatus;
        }
    }
}