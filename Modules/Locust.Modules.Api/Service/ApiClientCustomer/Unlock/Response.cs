using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUnlockResponse : BaseServiceResponse<object, ApiClientCustomerUnlockStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerUnlockStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerUnlockStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerUnlockStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerUnlockStatus.Faulted;
        }

        public ApiClientCustomerUnlockResponse()
            : this(ApiClientCustomerUnlockStatus.None, default(object))
        { }
        public ApiClientCustomerUnlockResponse(ApiClientCustomerUnlockStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerUnlockStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerUnlockStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerUnlockStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerUnlockStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerUnlockStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerUnlockStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerUnlockStatus.InvalidStatus;
        }
    }
}