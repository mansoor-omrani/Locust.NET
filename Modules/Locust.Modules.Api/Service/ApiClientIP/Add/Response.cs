using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPAddResponse : BaseServiceResponse<object, ApiClientIPAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientIPAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientIPAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientIPAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientIPAddStatus.Faulted;
        }

        public ApiClientIPAddResponse()
            : this(ApiClientIPAddStatus.None, default(object))
        { }
        public ApiClientIPAddResponse(ApiClientIPAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientIPAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientIPAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientIPAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientIPAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientIPAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientIPAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientIPAddStatus.InvalidStatus;
        }
    }
}