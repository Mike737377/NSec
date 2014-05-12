using NSec.Infrastructure;
using NSec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.SecurityEvents
{
    public class ReportSecurityEvent : IMessage
    {
        public SecurityEvent Event { get; set; }
    }
}