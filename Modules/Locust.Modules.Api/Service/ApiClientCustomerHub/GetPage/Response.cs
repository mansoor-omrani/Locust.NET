using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetPageResponse : BaseServicePageResponse<ApiClientCustomerHub.AdminGrid, ApiClientCustomerHubGetPageStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientCustomerHubGetPageStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientCustomerHubGetPageStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientCustomerHubGetPageStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientCustomerHubGetPageStatus.Faulted;
        }

        public ApiClientCustomerHubGetPageResponse()
            : this(ApiClientCustomerHubGetPageStatus.None, new PageData<ApiClientCustomerHub.AdminGrid>())
        { }
        public ApiClientCustomerHubGetPageResponse(ApiClientCustomerHubGetPageStatus status, PageData<ApiClientCustomerHub.AdminGrid> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientCustomerHubGetPageStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientCustomerHubGetPageStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientCustomerHubGetPageStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientCustomerHubGetPageStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientCustomerHubGetPageStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientCustomerHubGetPageStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientCustomerHubGetPageStatus.InvalidStatus;
        }
    }
}