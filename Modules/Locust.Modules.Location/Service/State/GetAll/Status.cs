using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}