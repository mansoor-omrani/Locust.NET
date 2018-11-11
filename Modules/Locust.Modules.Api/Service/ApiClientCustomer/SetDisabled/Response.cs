using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetDisabledResponse : BaseServiceResponse<object, ApiClientCustomerSetDisabledStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerSetDisabledStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerSetDisabledStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerSetDisabledStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerSetDisabledStatus.Faulted;
        }

        public ApiClientCustomerSetDisabledResponse()
            : this(ApiClientCustomerSetDisabledStatus.None, default(object))
        { }
        public ApiClientCustomerSetDisabledResponse(ApiClientCustomerSetDisabledStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerSetDisabledStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerSetDisabledStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerSetDisabledStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerSetDisabledStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerSetDisabledStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerSetDisabledStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerSetDisabledStatus.InvalidStatus;
        }
    }
}