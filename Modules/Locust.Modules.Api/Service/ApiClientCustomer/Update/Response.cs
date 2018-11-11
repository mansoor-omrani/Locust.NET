using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUpdateResponse : BaseServiceResponse<object, ApiClientCustomerUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerUpdateStatus.Faulted;
        }

        public ApiClientCustomerUpdateResponse()
            : this(ApiClientCustomerUpdateStatus.None, default(object))
        { }
        public ApiClientCustomerUpdateResponse(ApiClientCustomerUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerUpdateStatus.InvalidStatus;
        }
    }
}