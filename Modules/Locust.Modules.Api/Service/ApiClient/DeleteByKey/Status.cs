using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientDeleteByKeyStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound, HasChildren
    }
}