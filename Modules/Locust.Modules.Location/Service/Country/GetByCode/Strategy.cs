using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetByCodeStrategy : CountryGetByCodeStrategyBase
    {

		public CountryGetByCodeStrategy ():base()
		{
			Init();
		}

		public override void Run(CountryGetByCodeContext context)
		{
			 ExecuteSingle(context);
			// ExecuteSingle(context, (req) => req.Id);
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(CountryGetByCodeContext context)
		{
            return ExecuteSingleAsync(context);
            // return ExecuteSingleAsync(context, (req) => req.Id);
            // return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
            // return ExecuteSingleAsync(context, (reader) => {});
            // return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
            // return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);

		}
    }
}