using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
    public class CustomerCheckResponseData: BaseModel
    {
        public bool IsValid { get; set; }
        public string Description { get; set; }
    }
    public partial class ApiClientCustomerCheckResponse : BaseServiceResponse<CustomerCheckResponseData, ApiClientCustomerCheckStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerCheckStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerCheckStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerCheckStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerCheckStatus.Faulted;
        }

        public ApiClientCustomerCheckResponse()
            : this(ApiClientCustomerCheckStatus.None, default(CustomerCheckResponseData))
        { }
        public ApiClientCustomerCheckResponse(ApiClientCustomerCheckStatus status, CustomerCheckResponseData data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerCheckStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerCheckStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerCheckStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerCheckStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerCheckStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerCheckStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerCheckStatus.InvalidStatus;
        }
    }
}