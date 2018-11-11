using System;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginAddResponse : BaseServiceResponse<object, AppCrossOriginAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppCrossOriginAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppCrossOriginAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppCrossOriginAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppCrossOriginAddStatus.Faulted;
        }

        public AppCrossOriginAddResponse()
            : this(AppCrossOriginAddStatus.None, default(object))
        { }
        public AppCrossOriginAddResponse(AppCrossOriginAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppCrossOriginAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppCrossOriginAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppCrossOriginAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppCrossOriginAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppCrossOriginAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppCrossOriginAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppCrossOriginAddStatus.InvalidStatus;
        }
    }
}