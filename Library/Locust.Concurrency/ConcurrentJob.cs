using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using System.Diagnostics;

namespace Locust.Concurrency
{
    public enum ConcurrentJobState
    {
        NotStarted,
        Running,
        Sleeping,
        Finished,
        Aborted,
        Error
    }
    public enum ConcurrentJobCreationOptions
    {
        SilentAdd,
        AddAndRun,
        AddRunRemove
    }
    public class ConcurrentJobProgressArgs
    {
        public decimal Percent
        {
            get;
            set;
        }
    }
    public class ConcurrentJob
    {
        private string name;
        private Thread th;
        private Action<ConcurrentJob, object> job;
        private ConcurrentJobManager mgr;
        private ConcurrentJobCreationOptions options;

        public ConcurrentJob(ConcurrentJobManager mgr, Action<ConcurrentJob, object> job, ConcurrentJobCreationOptions options, string name = "")
        {
            this.State = ConcurrentJobState.NotStarted;
            this.name = name;
            this.job = job;
            this.mgr = mgr;
            this.options = options;
            this.Progress = new ConcurrentJobProgressArgs();
        }
        public ConcurrentJobCreationOptions Options
        {
            get { return options; }
        }
        public ConcurrentJobState State
        {
            get;
            private set;
        }
        public string Name
        {
            get { return name; }
        }
        public ConcurrentJobManager Manager
        {
            get { return mgr; }
        }
        public ConcurrentJobProgressArgs Progress
        {
            get;
            set;
        }
        public Exception Exception
        {
            get;
            private set;
        }

        public void Start(object obj = null)
        {
            lock (AppDomain.CurrentDomain)
            {
                if (this.State == ConcurrentJobState.NotStarted || this.State == ConcurrentJobState.Finished || this.State == ConcurrentJobState.Aborted || this.State == ConcurrentJobState.Error)
                {
                    this.State = ConcurrentJobState.Running;

                    if (this.Progress == null)
                    {
                        this.Progress = new ConcurrentJobProgressArgs();
                    }

                    this.Progress.Percent = 0;
                    this.Exception = null;

                    th = new Thread(() =>
                    {
                        try
                        {
                            this.State = ConcurrentJobState.Running;

                            this.job(this, obj);

                            this.State = ConcurrentJobState.Finished;

                            if (mgr != null)
                            {
                                this.mgr.NotifyFinish(this);
                            }
                        }
                        catch (ThreadAbortException)
                        {
                            this.State = ConcurrentJobState.Aborted;
                        }
                        catch (Exception e)
                        {
                            this.State = ConcurrentJobState.Error;
                            this.Exception = e;
                        }
                    });

                    th.IsBackground = true;

                    th.Start();
                }
            }
        }
        public void Abort()
        {
            lock (AppDomain.CurrentDomain)
            {
                if (this.State == ConcurrentJobState.Running)
                {
                    th.Abort();
                }
            }
        }
    }
    public class ConcurrentJobManager
    {
        private List<ConcurrentJob> jobs;

        public ConcurrentJobManager()
        {

            lock (AppDomain.CurrentDomain)
            {
                jobs = (List<ConcurrentJob>)AppDomain.CurrentDomain.GetData("ConcurrentJobs");

                if (jobs == null)
                {
                    jobs = new List<ConcurrentJob>();
                    AppDomain.CurrentDomain.SetData("ConcurrentJobs", jobs);
                }
            }
        }
        public int Count
        {
            get { return jobs.Count; }
        }
        public int Add(Action<ConcurrentJob, object> job, string name = "", ConcurrentJobCreationOptions options = ConcurrentJobCreationOptions.AddRunRemove, object obj = null)
        {
            var result = -1;
            ConcurrentJob cj = null;

            lock (AppDomain.CurrentDomain)
            {
                cj = new ConcurrentJob(this, job, options, name);
                jobs.Add(cj);

                result = jobs.Count - 1;
            }

            if (options == ConcurrentJobCreationOptions.AddRunRemove || options == ConcurrentJobCreationOptions.AddAndRun)
            {
                cj.Start(obj);
            }

            return result;
        }
        public void NotifyFinish(ConcurrentJob job)
        {
            var index = -1;

            if (job.Options == ConcurrentJobCreationOptions.AddRunRemove && job.State != ConcurrentJobState.Running)
            {
                index = this.IndexOf(job);

                if (index >= 0)
                {
                    try
                    {
                        jobs.RemoveAt(index);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("removing job('" + job.Name + "') failed");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
        }
        public int IndexOf(string jobname)
        {
            var result = -1;

            for (var i = 0; i < jobs.Count; i++)
            {
                if (jobs[i].Name == jobname)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        public int IndexOf(ConcurrentJob job)
        {
            return jobs.IndexOf(job);
        }
        public ConcurrentJob GetJob(int index)
        {
            ConcurrentJob result = null;

            if (index >= 0 && index < jobs.Count)
            {
                result = jobs[index];
            }

            return result;
        }
        public ConcurrentJob GetJob(string name)
        {
            ConcurrentJob result = null;

            for (var i = 0; i < jobs.Count; i++)
            {
                if (jobs[i].Name == name)
                {
                    result = jobs[i];
                    break;
                }
            }

            return result;
        }
        public enum RemoveResult
        {
            NotFound,
            Success,
            StillRunning
        }
        public RemoveResult Remove(int index)
        {
            var result = RemoveResult.NotFound;

            lock (AppDomain.CurrentDomain)
            {
                if (index >= 0 && index < jobs.Count)
                {
                    if (jobs[index].State != ConcurrentJobState.Running)
                    {
                        jobs.RemoveAt(index);
                        result = RemoveResult.Success;
                    }
                    else
                    {
                        result = RemoveResult.StillRunning;
                    }
                }
            }

            return result;
        }
        public RemoveResult Remove(ConcurrentJob job)
        {
            var index = this.IndexOf(job);

            return Remove(index);
        }
    }
}