using Locust.Collections;

namespace Locust.Model
{
    public class ChangeArgs
    {
        public string DefaultValue { get; set; }
        public string[] Values { get; set; }
        public string Result { get; internal set; }
        public ChangeStatus Status { get; internal set; }
        public bool ValueComparison { get; internal set; }
        public bool AllowReplace { get; internal set; }
    }
}