using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryAddResponse : BaseServiceResponse<object, CountryAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryAddStatus.Faulted;
        }

        public CountryAddResponse()
            : this(CountryAddStatus.None, default(object))
        { }
        public CountryAddResponse(CountryAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryAddStatus.InvalidStatus;
        }
    }
}