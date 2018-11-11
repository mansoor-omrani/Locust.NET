using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetAllResponse : BaseServiceListResponse<API.AdminGrid, ApiGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiGetAllStatus.Faulted;
        }

        public ApiGetAllResponse()
            : this(ApiGetAllStatus.None, new List<API.AdminGrid>())
        { }
        public ApiGetAllResponse(ApiGetAllStatus status, IList<API.AdminGrid> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiGetAllStatus.InvalidStatus;
        }
    }
}