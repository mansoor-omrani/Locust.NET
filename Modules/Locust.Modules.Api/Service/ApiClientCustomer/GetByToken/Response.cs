using System;
using Locust.ServiceModel;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByTokenResponse : BaseServiceResponse<ApiClientCustomer.Full, ApiClientCustomerGetByTokenStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerGetByTokenStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerGetByTokenStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerGetByTokenStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerGetByTokenStatus.Faulted;
        }

        public ApiClientCustomerGetByTokenResponse()
            : base(ApiClientCustomerGetByTokenStatus.None, default(ApiClientCustomer.Full))
        { }
        public ApiClientCustomerGetByTokenResponse(ApiClientCustomerGetByTokenStatus status,ApiClientCustomer.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerGetByTokenStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerGetByTokenStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerGetByTokenStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerGetByTokenStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerGetByTokenStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerGetByTokenStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerGetByTokenStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiClientCustomerGetByTokenStatus.NotFound;
        }
    }
}