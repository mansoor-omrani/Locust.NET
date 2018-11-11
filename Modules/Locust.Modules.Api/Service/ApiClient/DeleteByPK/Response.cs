using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByPKResponse : BaseServiceResponse<object, ApiClientDeleteByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientDeleteByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientDeleteByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientDeleteByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientDeleteByPKStatus.Faulted;
        }

        public ApiClientDeleteByPKResponse()
            : this(ApiClientDeleteByPKStatus.None, default(object))
        { }
        public ApiClientDeleteByPKResponse(ApiClientDeleteByPKStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientDeleteByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientDeleteByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientDeleteByPKStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiClientDeleteByPKStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientDeleteByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientDeleteByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientDeleteByPKStatus.InvalidStatus;
        }
    }
}