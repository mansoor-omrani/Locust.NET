using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerRegisterResponse : BaseServiceResponse<object, ApiClientCustomerRegisterStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerRegisterStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerRegisterStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerRegisterStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerRegisterStatus.Faulted;
        }

        public ApiClientCustomerRegisterResponse()
            : this(ApiClientCustomerRegisterStatus.None, default(object))
        { }
        public ApiClientCustomerRegisterResponse(ApiClientCustomerRegisterStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerRegisterStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerRegisterStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerRegisterStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerRegisterStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerRegisterStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerRegisterStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerRegisterStatus.InvalidStatus;
        }
    }
}