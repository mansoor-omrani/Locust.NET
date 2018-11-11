using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetApisResponse : BaseServiceListResponse<ClientApi, ApiClientGetApisStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetApisStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetApisStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetApisStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetApisStatus.Faulted;
        }

        public ApiClientGetApisResponse()
            : this(ApiClientGetApisStatus.None, new List<ClientApi>())
        { }
        public ApiClientGetApisResponse(ApiClientGetApisStatus status, IList<ClientApi> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetApisStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetApisStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetApisStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientGetApisStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientGetApisStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetApisStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetApisStatus.InvalidStatus;
        }
    }
}