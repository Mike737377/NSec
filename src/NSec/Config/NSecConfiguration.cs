using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace NSec.Config
{
    public static class NSecConfiguration
    {
        internal static Func<HttpContextBase, string> GetCurrentUserName { get; private set; }
        internal static readonly List<Threshold> ThresholdList = new List<Threshold>();
        internal static readonly List<string> ExcludedUrlPatterns = new List<string>();

        static NSecConfiguration()
        {
            LockoutStatusCode = HttpStatusCode.Gone;
            GetCurrentUserName = x => x.User != null ? x.User.Identity.Name : string.Empty;
        }

        public static void AddThreshold(Threshold threshold)
        {
            ThresholdList.Add(threshold);
        }

        public static void ExcludeUrl(string urlPattern)
        {
            ExcludedUrlPatterns.Add(urlPattern);
        }

        public static void SetUserIdCallback(Func<HttpContextBase, string> getUserName)
        {
            GetCurrentUserName = getUserName;
        }

        public static HttpStatusCode LockoutStatusCode { get; set; }
    }
}