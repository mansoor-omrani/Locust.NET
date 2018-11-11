using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateDeleteByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}