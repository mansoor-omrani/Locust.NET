using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerRefreshStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus,
        NoApp,
        NoRefreshToken,
        NoAccessToken,
        BadRefreshRequest,
        InvalidRefreshToken
    }
}