using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NSec.Config
{
    public static class NSecConfiguration
    {
        internal static Func<HttpContextBase, string> GetCurrentUserId { get; private set; }
        internal static readonly List<Threshold> ThresholdList = new List<Threshold>();

        public static void AddThreshold(Threshold threshold)
        {
            ThresholdList.Add(threshold);
        }

        public static void SetUserIdCallback(Func<HttpContextBase, string> getUserIdFunc)
        {
            GetCurrentUserId = getUserIdFunc;
        }
    }
}