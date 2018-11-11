using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByPKResponse : BaseServiceResponse<object, ApiClientRemoveByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientRemoveByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientRemoveByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientRemoveByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientRemoveByPKStatus.Faulted;
        }

        public ApiClientRemoveByPKResponse()
            : this(ApiClientRemoveByPKStatus.None, default(object))
        { }
        public ApiClientRemoveByPKResponse(ApiClientRemoveByPKStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientRemoveByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientRemoveByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientRemoveByPKStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientRemoveByPKStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientRemoveByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientRemoveByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientRemoveByPKStatus.InvalidStatus;
        }
    }
}