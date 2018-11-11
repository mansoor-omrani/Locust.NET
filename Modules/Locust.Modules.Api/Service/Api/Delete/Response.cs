using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiDeleteResponse : BaseServiceResponse<object, ApiDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiDeleteStatus.Faulted;
        }

        public ApiDeleteResponse()
            : this(ApiDeleteStatus.None, default(object))
        { }
        public ApiDeleteResponse(ApiDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiDeleteStatus.InvalidStatus;
        }
    }
}