using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiSettingGetAllByApiStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}