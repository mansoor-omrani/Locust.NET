using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateGetByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}