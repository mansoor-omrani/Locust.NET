using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickUpdateResponse : BaseServiceResponse<object, AppSettingQuickUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingQuickUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingQuickUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingQuickUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingQuickUpdateStatus.Faulted;
        }

        public AppSettingQuickUpdateResponse()
            : this(AppSettingQuickUpdateStatus.None, default(object))
        { }
        public AppSettingQuickUpdateResponse(AppSettingQuickUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingQuickUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingQuickUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingQuickUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingQuickUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingQuickUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingQuickUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingQuickUpdateStatus.InvalidStatus;
        }
    }
}