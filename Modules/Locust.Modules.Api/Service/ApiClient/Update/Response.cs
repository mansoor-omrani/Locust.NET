using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientUpdateResponse : BaseServiceResponse<object, ApiClientUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientUpdateStatus.Faulted;
        }

        public ApiClientUpdateResponse()
            : this(ApiClientUpdateStatus.None, default(object))
        { }
        public ApiClientUpdateResponse(ApiClientUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientUpdateStatus.InvalidStatus;
        }
    }
}