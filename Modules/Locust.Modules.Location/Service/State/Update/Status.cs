using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}