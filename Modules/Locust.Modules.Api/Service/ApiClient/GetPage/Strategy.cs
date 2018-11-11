using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetPageStrategy : ApiClientGetPageStrategyBase
    {
		public ApiClientGetPageStrategy ():base()
		{
			Init();
		}
		private void Initialize(ApiClientGetPageContext context)
		{
		}
		private void Finalize(ApiClientGetPageContext context)
		{
			if (context.Response.Success)
			{
			}
		}
		public override void Run(ApiClientGetPageContext context)
		{
			// Initialize(context);
			
			Execute(context);
			// Execute(context, (req) => req.Id);
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader, prev) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader, prev) => {}, (req) => req.Id);
			// Execute(context, (reader, prev) => {}, (req) => req.Id, (req) => req.LifeLength);
			
			// Finalize(context);
		}
		public override async Task RunAsync(ApiClientGetPageContext context)
		{
			// Initialize(context);
			
			await ExecuteAsync(context);
			// await ExecuteAsync(context, (req) => req.Id);
			// await ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// await ExecuteAsync(context, (reader) => {});
			// await ExecuteAsync(context, (reader, prev) => {});
			// await ExecuteAsync(context, (reader) => {}, (req) => req.Id);
			// await ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
			// await ExecuteAsync(context, (reader, prev) => {}, (req) => req.Id);
			// await ExecuteAsync(context, (reader, prev) => {}, (req) => req.Id, (req) => req.LifeLength);
			
			// Finalize(context);
		}
    }
}