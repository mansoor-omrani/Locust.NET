using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, InvalidHub, InvalidUser, IncorrectCryptLength, NoHardwareCode, InvalidLifeLength,
        AccessTokenExists, RefreshTokenExists
    }
}