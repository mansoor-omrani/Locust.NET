using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.CircuitBreaker
{
    public class CircuitBreakerOpenedException: Exception
    {
        public CircuitBreakerOpenedException()
        {
        }
        public CircuitBreakerOpenedException(Exception inner): base("CircuitBreaker is open", inner)
        {
        }
    }
    public class CircuitBreakerTimedOutException : Exception
    {
        public CircuitBreakerTimedOutException()
        {
        }
        public CircuitBreakerTimedOutException(Exception inner) : base("executing action timed out. CircuitBreaker opened.", inner)
        {
        }
    }
    public class CircuitBreakerConfig
    {
        public TaskScheduler TaskScheduler { get; set; }
        public int MaxFailure { get; set; }
        public int InactiveTime { get; set; }
    }
    public class CircuitBreaker
    {
        private int _failures;
        private bool _open;
        public object SynCroot { get; set; }
        public bool Open
        {
            get
            {
                return _open;
            }
        }
        public CircuitBreakerConfig Config
        {
            get; protected set;
        }
        public CircuitBreaker(CircuitBreakerConfig config)
        {
            Config = config;
            SynCroot = new object();
        }
        public void Execute(Action action)
        {
            if (action == null)
                throw new ArgumentException(nameof(action));

            if (Open)
                throw new CircuitBreakerOpenedException();

            try
            {
                action();
            }
            catch (Exception)
            {
                onError();

                throw;
            }
        }
        private void onError()
        {
            lock (SynCroot)
            {
                _failures++;

                if (_failures == Config.MaxFailure)
                {
                    _open = true;
                    new Timer(x =>
                    {
                        _failures = 0;
                        _open = false;
                    }, this, Config.InactiveTime, 0);
                }
            }
        }
        public void Execute(Action action, int timeout)
        {
            if (action == null) throw new ArgumentNullException("action");
            if (Open)
                throw new CircuitBreakerOpenedException();

            Task task = null;

            try
            {
                task = Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, Config.TaskScheduler ?? TaskScheduler.Default);

                if (task.Wait(timeout))
                {
                    return;
                }
            }
            catch (AggregateException e)
            {
                onError();

                throw new CircuitBreakerOpenedException(e.InnerException);
            }
            catch (Exception e)
            {
                onError();

                throw new CircuitBreakerOpenedException(e);
            }

            if (task.IsFaulted)
                throw new CircuitBreakerOpenedException(task.Exception.InnerException);
            else
                throw new CircuitBreakerTimedOutException();
        }
    }
}
