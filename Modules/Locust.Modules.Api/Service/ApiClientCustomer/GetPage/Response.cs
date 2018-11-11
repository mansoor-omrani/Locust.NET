using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetPageResponse : BaseServicePageResponse<ApiClientCustomer.AdminGrid, ApiClientCustomerGetPageStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerGetPageStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerGetPageStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerGetPageStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerGetPageStatus.Faulted;
        }

        public ApiClientCustomerGetPageResponse()
            : this(ApiClientCustomerGetPageStatus.None, new PageData<ApiClientCustomer.AdminGrid>())
        { }
        public ApiClientCustomerGetPageResponse(ApiClientCustomerGetPageStatus status, PageData<ApiClientCustomer.AdminGrid> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerGetPageStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerGetPageStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerGetPageStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerGetPageStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerGetPageStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerGetPageStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerGetPageStatus.InvalidStatus;
        }
    }
}