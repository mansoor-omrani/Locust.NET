using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientGetApisStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, ClientNotFound, ConfirmDeleteAllApis, ApisAppMismatch
    }
}