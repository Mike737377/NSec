using NSec.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Lockouts
{
    public class UnlockProfile : IMessage
    {
        public string AnonymousUserId { get; set; }
        public string IPAddress { get; set; }
        public string Fingerprint { get; set; }
        public string UserName { get; set; }
    }
}
