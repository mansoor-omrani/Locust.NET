using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}