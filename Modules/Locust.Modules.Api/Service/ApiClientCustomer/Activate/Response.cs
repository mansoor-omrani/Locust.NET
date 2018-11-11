using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
    public partial class ApiClientCustomerActivateResponse : BaseServiceResponse<ApiClientCustomerActivateResponseData, ApiClientCustomerActivateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerActivateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerActivateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerActivateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerActivateStatus.Faulted;
        }

        public ApiClientCustomerActivateResponse()
            : this(ApiClientCustomerActivateStatus.None, default(ApiClientCustomerActivateResponseData))
        { }
        public ApiClientCustomerActivateResponse(ApiClientCustomerActivateStatus status, ApiClientCustomerActivateResponseData data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerActivateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerActivateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerActivateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerActivateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerActivateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerActivateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerActivateStatus.InvalidStatus;
        }
    }
}