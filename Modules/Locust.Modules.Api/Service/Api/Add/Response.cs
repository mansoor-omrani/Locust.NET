using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiAddResponse : BaseServiceResponse<int, ApiAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiAddStatus.Faulted;
        }

        public ApiAddResponse()
            : this(ApiAddStatus.None, default(int))
        { }
        public ApiAddResponse(ApiAddStatus status,int data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiAddStatus.InvalidStatus;
        }
    }
}