using NSec.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.SecurityEvents
{
    public class ThresholdReached
    {
        public SecurityEvent SecurityEvent { get; set; }

        public ThresholdReaction Reaction { get; set; }
    }
}