using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerRefreshResponse : BaseServiceResponse<CustomerRefreshResponseData, ApiClientCustomerRefreshStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerRefreshStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerRefreshStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerRefreshStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerRefreshStatus.Faulted;
        }

        public ApiClientCustomerRefreshResponse()
            : this(ApiClientCustomerRefreshStatus.None, default(CustomerRefreshResponseData))
        { }
        public ApiClientCustomerRefreshResponse(ApiClientCustomerRefreshStatus status, CustomerRefreshResponseData data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerRefreshStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerRefreshStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerRefreshStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerRefreshStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerRefreshStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerRefreshStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerRefreshStatus.InvalidStatus;
        }
    }
}