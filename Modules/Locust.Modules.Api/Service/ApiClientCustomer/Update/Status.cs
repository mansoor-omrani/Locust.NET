using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound, AccessTokenExists, RefreshTokenExists, InvalidLifeLength, NoEncryptionCode
    }
}