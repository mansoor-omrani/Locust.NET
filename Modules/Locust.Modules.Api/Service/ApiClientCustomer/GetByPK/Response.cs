using System;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByPKResponse : BaseServiceResponse<ApiClientCustomer.Full, ApiClientCustomerGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerGetByPKStatus.Faulted;
        }

        public ApiClientCustomerGetByPKResponse()
            : base(ApiClientCustomerGetByPKStatus.None, default(ApiClientCustomer.Full))
        { }
        public ApiClientCustomerGetByPKResponse(ApiClientCustomerGetByPKStatus status,ApiClientCustomer.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerGetByPKStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerGetByPKStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiClientCustomerGetByPKStatus.NotFound;
        }
    }
}