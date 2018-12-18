using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class TaskExtensions
    {
        // source: http://www.salmanq.com/blog/task-timeouts/2013/02/
        public static async Task<T> TimeoutAfter<T>(this Task<T> task, int delay)
        {
            await Task.WhenAny(task, Task.Delay(delay));

            if (task.IsCompleted)
            {
                return task.Result;
            }
            else
            {
                throw new TimeoutException();
            }
        }
        // source: https://jeremylindsayni.wordpress.com/2016/05/28/how-to-set-a-maximum-time-to-allow-a-c-function-to-run-for/
        public static T TimeoutAfter2<T>(this Task<T> task, int delay)
        {
            var isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(delay));

            if (isCompletedSuccessfully)
            {
                return task.Result;
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
}
