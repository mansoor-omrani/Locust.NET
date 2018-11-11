using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum ApplicationDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}