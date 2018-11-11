using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiCheckAccessStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, AccessDenied, CustomerAccessPrevented, ClientAccessPrevented, AccessForbidden
    }
}