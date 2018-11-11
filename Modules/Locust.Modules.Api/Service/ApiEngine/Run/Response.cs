using System;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiEngineRunResponse : BaseServiceResponse<object, ApiEngineRunStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiEngineRunStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiEngineRunStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiEngineRunStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiEngineRunStatus.Faulted;
        }

        public ApiEngineRunResponse()
            : base(ApiEngineRunStatus.None, default(object))
        { }
        public ApiEngineRunResponse(ApiEngineRunStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiEngineRunStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiEngineRunStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiEngineRunStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiEngineRunStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiEngineRunStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiEngineRunStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiEngineRunStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            throw new NotImplementedException();
        }
    }
}