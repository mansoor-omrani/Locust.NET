using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingUpdateResponse : BaseServiceResponse<object, AppSettingUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingUpdateStatus.Faulted;
        }

        public AppSettingUpdateResponse()
            : this(AppSettingUpdateStatus.None, default(object))
        { }
        public AppSettingUpdateResponse(AppSettingUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingUpdateStatus.InvalidStatus;
        }
    }
}