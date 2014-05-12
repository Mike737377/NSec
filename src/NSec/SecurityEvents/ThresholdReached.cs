using NSec.Config;
using NSec.Infrastructure;
using NSec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.SecurityEvents
{
    public class ThresholdReached : IMessage
    {
        public SecurityEvent SecurityEvent { get; set; }

        public ThresholdReaction Reaction { get; set; }
    }
}