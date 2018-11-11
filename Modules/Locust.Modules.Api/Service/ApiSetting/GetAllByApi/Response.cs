using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiSetting = Locust.Modules.Api.Model.ApiSetting;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingGetAllByApiResponse : BaseServiceListResponse<ApiSetting.Full, ApiSettingGetAllByApiStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiSettingGetAllByApiStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiSettingGetAllByApiStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiSettingGetAllByApiStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiSettingGetAllByApiStatus.Faulted;
        }

        public ApiSettingGetAllByApiResponse()
            : this(ApiSettingGetAllByApiStatus.None, new List<ApiSetting.Full>())
        { }
        public ApiSettingGetAllByApiResponse(ApiSettingGetAllByApiStatus status, IList<ApiSetting.Full> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiSettingGetAllByApiStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiSettingGetAllByApiStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiSettingGetAllByApiStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiSettingGetAllByApiStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiSettingGetAllByApiStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiSettingGetAllByApiStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiSettingGetAllByApiStatus.InvalidStatus;
        }
    }
}