using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerAddResponse : BaseServiceResponse<int, ApiClientCustomerAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerAddStatus.Faulted;
        }

        public ApiClientCustomerAddResponse()
            : this(ApiClientCustomerAddStatus.None, default(int))
        { }
        public ApiClientCustomerAddResponse(ApiClientCustomerAddStatus status,int data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerAddStatus.InvalidStatus;
        }
    }
}