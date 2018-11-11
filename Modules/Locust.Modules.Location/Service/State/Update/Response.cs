using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateUpdateResponse : BaseServiceResponse<object, StateUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateUpdateStatus.Faulted;
        }

        public StateUpdateResponse()
            : this(StateUpdateStatus.None, default(object))
        { }
        public StateUpdateResponse(StateUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateUpdateStatus.InvalidStatus;
        }
    }
}