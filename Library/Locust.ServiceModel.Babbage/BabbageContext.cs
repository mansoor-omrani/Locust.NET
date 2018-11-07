using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Data;

namespace Locust.ServiceModel.Babbage
{
    public class BabbageContext<TResponse, UData, VStatus, WRequest> : ServiceStrategyContext<TResponse, UData, VStatus, WRequest>
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
    {
        public int ExecMode { get; set; }
        public string CommandText { get; set; }
        public object OverrideRequest { get; set; }
        private Dictionary<string, CommandParameter> outputParameters;

        public Dictionary<string, CommandParameter> OutputParameters
        {
            get
            {
                if (outputParameters == null)
                {
                    outputParameters = new Dictionary<string, CommandParameter>();
                }

                return outputParameters;
            }
            set { outputParameters = value; }
        }

        public void AddOutput(string name, SqlDbType type, int size = 0)
        {
            OutputParameters.Add(name, CommandParameter.Output(type, size));
        }
    }
    public class BabbageContextWeb<TResponse, UData, VStatus, WRequest> : ServiceStrategyContextWeb<TResponse, UData, VStatus, WRequest>
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
    {
        public int ExecMode { get; set; }
        public object OverrideRequest { get; set; }
    }
}
