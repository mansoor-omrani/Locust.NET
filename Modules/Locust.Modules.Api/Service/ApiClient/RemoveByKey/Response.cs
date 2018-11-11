using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByKeyResponse : BaseServiceResponse<object, ApiClientRemoveByKeyStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientRemoveByKeyStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientRemoveByKeyStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientRemoveByKeyStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientRemoveByKeyStatus.Faulted;
        }

        public ApiClientRemoveByKeyResponse()
            : this(ApiClientRemoveByKeyStatus.None, default(object))
        { }
        public ApiClientRemoveByKeyResponse(ApiClientRemoveByKeyStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientRemoveByKeyStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientRemoveByKeyStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientRemoveByKeyStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientRemoveByKeyStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientRemoveByKeyStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientRemoveByKeyStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientRemoveByKeyStatus.InvalidStatus;
        }
    }
}