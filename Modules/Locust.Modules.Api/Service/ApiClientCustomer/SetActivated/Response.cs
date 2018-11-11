using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetActivatedResponse : BaseServiceResponse<object, ApiClientCustomerSetActivatedStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerSetActivatedStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerSetActivatedStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerSetActivatedStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerSetActivatedStatus.Faulted;
        }

        public ApiClientCustomerSetActivatedResponse()
            : this(ApiClientCustomerSetActivatedStatus.None, default(object))
        { }
        public ApiClientCustomerSetActivatedResponse(ApiClientCustomerSetActivatedStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerSetActivatedStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerSetActivatedStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerSetActivatedStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerSetActivatedStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerSetActivatedStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerSetActivatedStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerSetActivatedStatus.InvalidStatus;
        }
    }
}