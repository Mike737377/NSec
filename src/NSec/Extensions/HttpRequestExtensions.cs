using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NSec
{
    public static class HttpRequestExtensions
    {
        public static int GetFingerprint(this HttpRequestBase httpRequest)
        {
            return (httpRequest.UserHostAddress + httpRequest.UserAgent).GetHashCode();
        }
    }
}