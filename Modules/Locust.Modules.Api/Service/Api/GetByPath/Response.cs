using System;
using Locust.ServiceModel;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPathResponse : BaseServiceResponse<API.Full, ApiGetByPathStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiGetByPathStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiGetByPathStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiGetByPathStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiGetByPathStatus.Faulted;
        }

        public ApiGetByPathResponse()
            : base(ApiGetByPathStatus.None, default(API.Full))
        { }
        public ApiGetByPathResponse(ApiGetByPathStatus status,API.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiGetByPathStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiGetByPathStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiGetByPathStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiGetByPathStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiGetByPathStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiGetByPathStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiGetByPathStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApiGetByPathStatus.NotFound;
        }
    }
}