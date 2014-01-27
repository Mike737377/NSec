using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public static class SystemTime
    {
        public static DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}