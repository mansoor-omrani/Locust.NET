using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum DateNowStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}