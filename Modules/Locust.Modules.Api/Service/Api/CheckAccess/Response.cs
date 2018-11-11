using System;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiCheckAccessResponse : BaseServiceResponse<object, ApiCheckAccessStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiCheckAccessStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiCheckAccessStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiCheckAccessStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiCheckAccessStatus.Faulted;
        }

        public ApiCheckAccessResponse()
            : base(ApiCheckAccessStatus.None, default(object))
        { }
        public ApiCheckAccessResponse(ApiCheckAccessStatus status, object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiCheckAccessStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiCheckAccessStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiCheckAccessStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiCheckAccessStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApiCheckAccessStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiCheckAccessStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiCheckAccessStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            throw new NotImplementedException();
        }
    }
}