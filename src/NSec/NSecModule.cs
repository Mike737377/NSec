using NSec.Config;
using NSec.Infrastructure;
using NSec.Lockouts;
using NSec.Model;
using NSec.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Web;
using FubuCore;
using System.Text.RegularExpressions;

namespace NSec
{
    public class NSecModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        #endregion IHttpModule Members

        public void OnBeginRequest(object sender, EventArgs e)
        {
            OnBeginRequest(ServiceFactory.GetInstance<HttpContextBase>(), ServiceFactory.GetInstance<IDataContext>(), ServiceFactory.GetInstance<IServiceBus>());
        }

        public void OnBeginRequest(HttpContextBase httpContext, IDataContext dataContext, IServiceBus bus)
        {
            var currentUrl = httpContext.Request.Url.ToString();

            if (NSecConfiguration.ExcludedUrlPatterns.Any(v => Regex.IsMatch(currentUrl, v)))
            {
                //do not filter request
                return;
            }

            var lockoutsQuery = dataContext.Lockouts.Query.Where(v => v.EndDate >= SystemTime.UtcNow);

            var anonymousLockouts = httpContext.Request.AnonymousID != null ? lockoutsQuery.Where(v => v.Type == Config.AttackerComparison.AnonymousId && v.AttackerDetail.Equals(httpContext.Request.AnonymousID)).ToArray() : new Lockout[] { };
            var ipLockouts = lockoutsQuery.Where(v => v.Type == Config.AttackerComparison.IPAddress && v.AttackerDetail.Equals(httpContext.Request.UserHostAddress)).ToArray();
            var sessionLockouts = lockoutsQuery.Where(v => v.Type == Config.AttackerComparison.SessionId && v.AttackerDetail.Equals(httpContext.Session.SessionID)).ToArray();
            var fingerprintLockouts = lockoutsQuery.Where(v => v.Type == Config.AttackerComparison.Fingerprint && v.AttackerDetail.Equals(httpContext.Request.GetFingerprint())).ToArray();
            var userAgentLockouts = lockoutsQuery.Where(v => v.Type == Config.AttackerComparison.UserAgent && v.AttackerDetail.Equals(httpContext.Request.UserAgent)).ToArray();

            var lockouts = anonymousLockouts.Union(ipLockouts).Union(sessionLockouts).Union(sessionLockouts).Union(fingerprintLockouts).Union(userAgentLockouts).ToArray();

            if (lockouts.Count() > 0)
            {
                httpContext.Response.SuppressContent = true;
                httpContext.Response.ClearHeaders();
                httpContext.Response.StatusCode = (int)NSecConfiguration.LockoutStatusCode;
                httpContext.Response.End();

                var throttles = lockouts.Where(v => v.Action == Config.SecurityAction.Throttle).ToList();

                throttles.ForEach(v =>
                    {
                        bus.Send(new LockoutAttacker()
                        {
                            Action = v.Action,
                            AttackerDetail = v.AttackerDetail,
                            MinimumPeriod = v.Period,
                            Type = v.Type
                        });
                    });
            }
        }
    }
}