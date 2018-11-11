using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetByIdResponse : BaseServiceResponse<ResponseType, CountryGetByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryGetByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryGetByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryGetByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryGetByIdStatus.Faulted;
        }

        public CountryGetByIdResponse()
            : this(CountryGetByIdStatus.None, default(ResponseType))
        { }
        public CountryGetByIdResponse(CountryGetByIdStatus status, ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryGetByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryGetByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryGetByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryGetByIdStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryGetByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryGetByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryGetByIdStatus.InvalidStatus;
        }
    }
}