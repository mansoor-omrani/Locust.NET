using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum AppCrossOriginGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}