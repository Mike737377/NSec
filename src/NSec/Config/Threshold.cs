using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Config
{
    public class Threshold
    {
        public delegate bool CriteraSearch(SecurityEvent currentSecurityEvent, IQueryable<SecurityEvent> allSecurityEvents);

        public Threshold()
        {
            Reactions = new List<ThresholdReaction>();
        }

        public string Name { get; set; }

        public CriteraSearch Critera { get; set; }

        public List<ThresholdReaction> Reactions { get; private set; }
    }

    public enum ThresholdReaction : int
    {
        BlockByIPAddress,
        BlockUserAgent,
        TrackSession,
        ThrottleIPAddress,
        ThrottleUserAgent
    }
}