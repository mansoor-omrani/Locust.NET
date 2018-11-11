using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientAddResponse : BaseServiceResponse<int, ApiClientAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientAddStatus.Faulted;
        }

        public ApiClientAddResponse()
            : this(ApiClientAddStatus.None, default(int))
        { }
        public ApiClientAddResponse(ApiClientAddStatus status,int data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientAddStatus.InvalidStatus;
        }
    }
}