using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateAddResponse : BaseServiceResponse<object, StateAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateAddStatus.Faulted;
        }

        public StateAddResponse()
            : this(StateAddStatus.None, default(object))
        { }
        public StateAddResponse(StateAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateAddStatus.InvalidStatus;
        }
    }
}