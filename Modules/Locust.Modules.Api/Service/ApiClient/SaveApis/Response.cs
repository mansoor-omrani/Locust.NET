using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientSaveApisResponse : BaseServiceResponse<object, ApiClientSaveApisStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientSaveApisStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientSaveApisStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientSaveApisStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientSaveApisStatus.Faulted;
        }

        public ApiClientSaveApisResponse()
            : this(ApiClientSaveApisStatus.None, default(object))
        { }
        public ApiClientSaveApisResponse(ApiClientSaveApisStatus status, object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientSaveApisStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientSaveApisStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientSaveApisStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientSaveApisStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientSaveApisStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientSaveApisStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientSaveApisStatus.InvalidStatus;
        }
    }
}