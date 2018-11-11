using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientSaveApisStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}