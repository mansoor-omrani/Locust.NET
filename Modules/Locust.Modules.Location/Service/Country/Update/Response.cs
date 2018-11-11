using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryUpdateResponse : BaseServiceResponse<object, CountryUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryUpdateStatus.Faulted;
        }

        public CountryUpdateResponse()
            : this(CountryUpdateStatus.None, default(object))
        { }
        public CountryUpdateResponse(CountryUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryUpdateStatus.InvalidStatus;
        }
    }
}