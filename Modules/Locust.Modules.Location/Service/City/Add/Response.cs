using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityAddResponse : BaseServiceResponse<object, CityAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityAddStatus.Faulted;
        }

        public CityAddResponse()
            : this(CityAddStatus.None, default(object))
        { }
        public CityAddResponse(CityAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityAddStatus.Errored;
        }
        public override void NotFound()
        {
            this.Status = CityAddStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = CityAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityAddStatus.InvalidStatus;
        }
    }
}