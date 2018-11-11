using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientIPSetIsActiveStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}