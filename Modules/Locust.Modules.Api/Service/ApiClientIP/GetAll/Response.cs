using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using ApiClientIP = Locust.Modules.Api.Model.ApiClientIP;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPGetAllResponse : BaseServiceListResponse<ApiClientIP.AdminGrid, ApiClientIPGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientIPGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientIPGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientIPGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientIPGetAllStatus.Faulted;
        }

        public ApiClientIPGetAllResponse()
            : base(ApiClientIPGetAllStatus.None, new List<ApiClientIP.AdminGrid>())
        { }
        public ApiClientIPGetAllResponse(ApiClientIPGetAllStatus status, IList<ApiClientIP.AdminGrid> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientIPGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientIPGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientIPGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientIPGetAllStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiClientIPGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientIPGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientIPGetAllStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            throw new NotImplementedException();
        }
    }
}