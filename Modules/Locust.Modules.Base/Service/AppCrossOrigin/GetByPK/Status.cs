using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum AppCrossOriginGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}