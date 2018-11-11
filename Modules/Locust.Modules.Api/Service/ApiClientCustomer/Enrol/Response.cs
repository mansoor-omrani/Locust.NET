using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerEnrolResponse : BaseServiceResponse<ApiClientCustomerEnrolResponseData, ApiClientCustomerEnrolStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerEnrolStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerEnrolStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerEnrolStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerEnrolStatus.Faulted;
        }

        public ApiClientCustomerEnrolResponse()
            : this(ApiClientCustomerEnrolStatus.None, default(ApiClientCustomerEnrolResponseData))
        { }
        public ApiClientCustomerEnrolResponse(ApiClientCustomerEnrolStatus status, ApiClientCustomerEnrolResponseData data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerEnrolStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerEnrolStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerEnrolStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientCustomerEnrolStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerEnrolStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerEnrolStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerEnrolStatus.InvalidStatus;
        }
    }
}