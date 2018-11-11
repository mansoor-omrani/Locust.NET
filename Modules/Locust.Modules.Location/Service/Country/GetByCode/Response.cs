using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetByCodeResponse : BaseServiceResponse<ResponseType, CountryGetByCodeStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryGetByCodeStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryGetByCodeStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryGetByCodeStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryGetByCodeStatus.Faulted;
        }

        public CountryGetByCodeResponse()
            : this(CountryGetByCodeStatus.None, default(ResponseType))
        { }
        public CountryGetByCodeResponse(CountryGetByCodeStatus status, ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryGetByCodeStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryGetByCodeStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryGetByCodeStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryGetByCodeStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryGetByCodeStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryGetByCodeStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryGetByCodeStatus.InvalidStatus;
        }
    }
}