using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateGetByCodeStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}