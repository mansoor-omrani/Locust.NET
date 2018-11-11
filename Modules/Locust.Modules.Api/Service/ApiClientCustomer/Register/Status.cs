using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerRegisterStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, AppNotFound, ClientNotFound, NoHardwareCode, InvalidHardwareCode,
        NoActivationMethod, InvalidActivationMethod, NoMobileNo, InvalidMobileNo, NoEmail, InvalidEmail, NoSerialNoGiven, SerialNoInactive,
        RegisterDenied, CustomerDisabled, SerialNoUsed, HubOverflow
    }
}