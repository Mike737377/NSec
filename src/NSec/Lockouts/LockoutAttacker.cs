using NSec.Config;
using NSec.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Lockouts
{
    public class LockoutAttacker : IMessage
    {
        public string AttackerDetail { get; set; }
        public AttackerComparison Type { get; set; }
        public TimeSpan MinimumPeriod { get; set; }
        public SecurityAction Action { get; set; }
    }
}