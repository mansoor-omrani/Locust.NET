using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPKResponse : BaseServiceResponse<API.Full, ApiGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiGetByPKStatus.Faulted;
        }

        public ApiGetByPKResponse()
            : this(ApiGetByPKStatus.None, default(API.Full))
        { }
        public ApiGetByPKResponse(ApiGetByPKStatus status,API.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiGetByPKStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiGetByPKStatus.InvalidStatus;
        }
    }
}