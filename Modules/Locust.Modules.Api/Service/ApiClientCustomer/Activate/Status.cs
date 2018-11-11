using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerActivateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoHashCode, CustomerNotFound, ClientDisabled, HubInactive, AlreadyActivated,
        ApiNotFound, ClientIPDenied, NullUpdate,
        // status inherited from usp1_Api_CheckAccess ...
        CustomerAccessPrevented, AccessDenied, ClientAccessPrevented, AccessForbidden
    }
}