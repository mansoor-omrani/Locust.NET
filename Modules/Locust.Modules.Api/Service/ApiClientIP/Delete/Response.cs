using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPDeleteResponse : BaseServiceResponse<object, ApiClientIPDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientIPDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientIPDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientIPDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientIPDeleteStatus.Faulted;
        }

        public ApiClientIPDeleteResponse()
            : this(ApiClientIPDeleteStatus.None, default(object))
        { }
        public ApiClientIPDeleteResponse(ApiClientIPDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientIPDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientIPDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientIPDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientIPDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientIPDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientIPDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientIPDeleteStatus.InvalidStatus;
        }
    }
}