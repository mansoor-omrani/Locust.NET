using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum ApplicationGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}