using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Calendar;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class DateNowStrategy : DateNowStrategyBase
    {
		public DateNowStrategy()
		{
			Init();
		}

        private object GetDate(DateTimeValue date)
        {
            return
                new
                {
                    Year = date.Year,
                    Month = date.Month,
                    Day = date.Day,
                    DayOfWeek = date.DayOfWeek,
                    Hour = date.Hour,
                    Minute = date.Minute,
                    Second = date.Second,
                    Milliscond = date.Millisecond
                };
        }

        private void prepareResult(DateNowContext context)
        {
            var dateDb = new DateTimeField();
            var dateApp = new DateTimeField();

            if (string.Compare(context.Request.Calendar, "gregorian", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (context.Response.Success)
                {
                    dateDb.Gregorian.Read(context.Response.Now);
                }
                dateApp.Gregorian.Read(DateTime.Now);

                context.Response.Data = new
                {
                    Db = GetDate(dateDb.Gregorian),
                    App = GetDate(dateDb.Gregorian)
                };

                return;
            }

            if (string.Compare(context.Request.Calendar, "persian", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (context.Response.Success)
                {
                    dateDb.Gregorian.Read(context.Response.Now);
                }
                dateApp.Gregorian.Read(DateTime.Now);

                context.Response.Data = new
                {
                    Db = GetDate(dateDb.Persian),
                    App = GetDate(dateDb.Persian)
                };

                return;
            }
        }
		public override void Run(DateNowContext context)
        {
            ExecuteNonQuery(context);

            prepareResult(context);
            // ExecuteNonQuery(context, Func<DateNowRequest, string> keySpecifier);
        }

        public override async Task RunAsync(DateNowContext context)
        {
            await ExecuteNonQueryAsync(context);

            prepareResult(context);
            // return ExecuteNonQueryAsync(context, Func<DateNowRequest, string> keySpecifier);
        }
    }
}