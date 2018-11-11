using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetAllResponse : BaseServiceListResponse<CityGetAllModel, CityGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityGetAllStatus.Faulted;
        }

        public CityGetAllResponse()
            : this(CityGetAllStatus.None, new List<CityGetAllModel>())
        { }
        public CityGetAllResponse(CityGetAllStatus status, IList<CityGetAllModel> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityGetAllStatus.InvalidStatus;
        }
    }
}