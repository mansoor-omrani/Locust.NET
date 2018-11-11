using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum AppCrossOriginDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}