using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPUpdateResponse : BaseServiceResponse<object, ApiClientIPUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientIPUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientIPUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientIPUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientIPUpdateStatus.Faulted;
        }

        public ApiClientIPUpdateResponse()
            : this(ApiClientIPUpdateStatus.None, default(object))
        { }
        public ApiClientIPUpdateResponse(ApiClientIPUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientIPUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientIPUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientIPUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientIPUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientIPUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientIPUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientIPUpdateStatus.InvalidStatus;
        }
    }
}