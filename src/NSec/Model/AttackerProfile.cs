using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Model
{
    public class AttackerProfile
    {
        public string AnonymousUserId;
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string UserName { get; set; }

        public int Fingerprint
        {
            get
            {
                return (IPAddress + UserAgent).GetHashCode();
            }
        }
    }
}
