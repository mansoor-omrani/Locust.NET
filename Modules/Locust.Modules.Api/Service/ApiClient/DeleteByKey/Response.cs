using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByKeyResponse : BaseServiceResponse<object, ApiClientDeleteByKeyStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientDeleteByKeyStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientDeleteByKeyStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientDeleteByKeyStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientDeleteByKeyStatus.Faulted;
        }

        public ApiClientDeleteByKeyResponse()
            : this(ApiClientDeleteByKeyStatus.None, default(object))
        { }
        public ApiClientDeleteByKeyResponse(ApiClientDeleteByKeyStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientDeleteByKeyStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientDeleteByKeyStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientDeleteByKeyStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientDeleteByKeyStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientDeleteByKeyStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientDeleteByKeyStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientDeleteByKeyStatus.InvalidStatus;
        }
    }
}