using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum ApplicationGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}