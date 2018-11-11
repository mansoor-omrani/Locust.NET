using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryUpdateResponse : BaseServiceResponse<object, AppSettingCategoryUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryUpdateStatus.Faulted;
        }

        public AppSettingCategoryUpdateResponse()
            : this(AppSettingCategoryUpdateStatus.None, default(object))
        { }
        public AppSettingCategoryUpdateResponse(AppSettingCategoryUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryUpdateStatus.InvalidStatus;
        }
    }
}