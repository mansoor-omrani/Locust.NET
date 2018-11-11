using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.GetPage;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetPageResponse : BaseServicePageResponse<ResponseType, ApiClientGetPageStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientGetPageStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientGetPageStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientGetPageStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientGetPageStatus.Faulted;
        }

        public ApiClientGetPageResponse()
            : this(ApiClientGetPageStatus.None, new PageData<ResponseType>())
        { }
        public ApiClientGetPageResponse(ApiClientGetPageStatus status, PageData<ResponseType> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientGetPageStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientGetPageStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientGetPageStatus.Failed;
        }
		public override void Errored()
        {
            this.Status = ApiClientGetPageStatus.Errored;
        }
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientGetPageStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientGetPageStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientGetPageStatus.InvalidStatus;
        }
    }
}