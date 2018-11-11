using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ServiceSettingGetAllByServiceStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}