using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClient = Locust.Modules.Api.Model.ApiClient.AdminGrid;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetAllResponse : BaseServiceListResponse<ApiClient, ApiClientGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetAllStatus.Faulted;
        }

        public ApiClientGetAllResponse()
            : this(ApiClientGetAllStatus.None, new List<ApiClient>())
        { }
        public ApiClientGetAllResponse(ApiClientGetAllStatus status, IList<ApiClient> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetAllStatus.InvalidStatus;
        }
    }
}