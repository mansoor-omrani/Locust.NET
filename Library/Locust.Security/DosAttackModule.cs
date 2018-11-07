#region Using

using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Timers;
using System.Collections.Concurrent;
using System.Web.Configuration;
using Locust.Conversion;

#endregion

/// <summary>
/// Detects DoS attacks and blocks attackers for a limited period of time.
/// Date Created: 2012-11-06
/// By: S.Mansoor Omrani
/// </summary>
namespace Locust.Security
{
    public class DosAttackEntry
    {
        public bool IsBanned { get; set; }
        public bool IsRemoveCandidate { get; set; }
        public byte RequestCount { get; set; }
        public DateTime BanDate { get; set; }
        public DateTime LastRequestDate { get; set; }
        public byte LastMinute { get; set; }
        public byte LastSecond { get; set; }

        public DosAttackEntry()
        {
            LastRequestDate = DateTime.Now;
            BanDate = LastRequestDate;
            RequestCount = 1;
            LastMinute = (byte)LastRequestDate.Minute;
            LastSecond = (byte)LastRequestDate.Second;
        }
        public DosAttackEntry Clone()
        {
            var result = new DosAttackEntry
            {
                IsBanned = this.IsBanned,
                IsRemoveCandidate = this.IsRemoveCandidate,
                RequestCount = this.RequestCount,
                BanDate = this.BanDate,
                LastRequestDate = this.LastRequestDate,
                LastMinute = this.LastMinute,
                LastSecond = this.LastSecond
            };
            return result;
        }
    }
    public class DosAttackModule : IHttpModule
    {

        #region IHttpModule Members

        void IHttpModule.Dispose()
        {
            // Nothing to dispose; 
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        #endregion

        #region Private fields

        private static ConcurrentDictionary<string, DosAttackEntry> entries = new ConcurrentDictionary<string, DosAttackEntry>(50, 500);
        private static DateTime LastCheck = DateTime.Now;
        private static object _sync = new object();
        private static bool moduleEnabled;
        private static string[] excludeIPs;
        #endregion

        #region Constants
        private static int REQUEST_THRESHOLD = 15;         // each IP can only have 15 request per second
        private static int RELEASE_INTERVAL = 10 * 60;     // attackers will be blocked for 10 minutes
        private static int GC_CHECK_INTERVAL = 30 * 60;    // every 30 minutes the list of ip addresses will be checked to be cleaned
        private static int SESSION_TIMEOUT = 8 * 60;       // session time out: 8 minutes
        private static int GC_THRESHOLD = 30;              // if 30% of ip addresses are candidate to be removed
        // (i.e. their sessions have been timed out), try garbage collection
        // on the ip addresses list ("entries" variable).
        #endregion
        static DosAttackModule()
        {
            REQUEST_THRESHOLD = SafeClrConvert.ToInt32(WebConfigurationManager.AppSettings["DOS_REQUEST_THRESHOLD"]);
            if (REQUEST_THRESHOLD <= 0)
            {
                REQUEST_THRESHOLD = 15;
            }

            RELEASE_INTERVAL = SafeClrConvert.ToInt32(WebConfigurationManager.AppSettings["DOS_RELEASE_INTERVAL"]);
            if (RELEASE_INTERVAL <= 0)
            {
                RELEASE_INTERVAL = 10 * 60;
            }

            GC_CHECK_INTERVAL = SafeClrConvert.ToInt32(WebConfigurationManager.AppSettings["DOS_GC_CHECK_INTERVAL"]);
            if (GC_CHECK_INTERVAL <= 0)
            {
                GC_CHECK_INTERVAL = 30 * 60;
            }

            SESSION_TIMEOUT = SafeClrConvert.ToInt32(WebConfigurationManager.AppSettings["DOS_SESSION_TIMEOUT"]);
            if (SESSION_TIMEOUT <= 0)
            {
                SESSION_TIMEOUT = 8 * 60;
            }

            GC_THRESHOLD = SafeClrConvert.ToInt32(WebConfigurationManager.AppSettings["DOS_GC_THRESHOLD"]);
            if (GC_THRESHOLD <= 0)
            {
                GC_THRESHOLD = 30;
            }

            moduleEnabled = SafeClrConvert.ToBoolean(WebConfigurationManager.AppSettings["DOS_DEFENDER_ENABLED"] ?? "true");
            excludeIPs = SafeClrConvert.ToString(WebConfigurationManager.AppSettings["DOS_DEFENDER_EXCLUDE_IPS"]).Split(',');
        }
        public DosAttackModule()
        {
            
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            if (moduleEnabled)
            {
                CheckForGC();

                var ip = HttpContext.Current.Request.UserHostAddress;

                if (excludeIPs != null && excludeIPs.Length > 0 && Array.IndexOf(excludeIPs, ip) >= 0)
                {
                    return;
                }

                var en = entries.AddOrUpdate(ip, new DosAttackEntry(), UpdateEntry);

                if (en.IsBanned)
                {
                    var blockMinutes = RELEASE_INTERVAL / 60;
                    var remainSeconds = (DateTime.Now - en.BanDate).TotalSeconds;
                    var remainMinutes = remainSeconds / 60;

                    remainSeconds = remainSeconds - remainMinutes * 60;

                    HttpContext.Current.Response.Write(String.Format("DoS attack detected. You are blocked for {0} minute(s) (remaning {1} minutes and {2} seconds).", blockMinutes , remainMinutes, remainSeconds));
                    HttpContext.Current.Response.End();
                }
            }
        }
        private void CheckForGC()
        {
            var dt = DateTime.Now;
            var diff = dt - LastCheck;

            if (diff.TotalSeconds >= GC_CHECK_INTERVAL)
            {
                lock (_sync)
                    LastCheck = dt;

                var x = entries.ToArray();
                var removes = new List<string>();

                foreach (var y in x)
                {
                    var t = dt - y.Value.LastRequestDate;
                    if (t.TotalSeconds >= SESSION_TIMEOUT)
                    {
                        var z1 = entries.GetOrAdd(y.Key, new DosAttackEntry());
                        var z2 = z1.Clone();
                        z2.IsRemoveCandidate = true;
                        if (entries.TryUpdate(y.Key, z2, z1))
                        {
                            removes.Add(y.Key);
                        }
                    }
                }

                if (removes.Count > 0)
                {
                    if (x.Length / removes.Count >= GC_THRESHOLD)
                    {
                        foreach (var y in removes)
                        {
                            DosAttackEntry z;
                            entries.TryRemove(y, out z);
                        }
                    }
                }
            }
        }
        private DosAttackEntry UpdateEntry(string ip, DosAttackEntry oldentry)
        {
            var dt = DateTime.Now;

            oldentry.LastRequestDate = dt;

            if (oldentry.IsBanned)
            {
                var banSpan = dt - oldentry.BanDate;
                if (banSpan.TotalSeconds >= RELEASE_INTERVAL)
                {
                    oldentry.IsBanned = false;
                    oldentry.RequestCount = 1;
                }
            }
            else
            {
                var min = dt.Minute;
                var sec = dt.Second;

                if (oldentry.LastMinute == min && oldentry.LastSecond == sec)
                    oldentry.RequestCount++;
                else
                    oldentry.RequestCount = 1;

                if (oldentry.RequestCount >= REQUEST_THRESHOLD)
                {
                    oldentry.BanDate = dt;
                    oldentry.IsBanned = true;
                }
            }

            return oldentry;
        }
    }
}