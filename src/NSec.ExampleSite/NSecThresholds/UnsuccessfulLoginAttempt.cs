using NSec.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSec.ExampleSite.NSecThresholds
{
    public class UnsuccessfulLoginAttempt : Threshold
    {
        public UnsuccessfulLoginAttempt()
        {
            this.Conditions = new ThresholdConditions()
            {
                EventType = EventType.UnsuccessfulLoginAttempt,
                MinimumSecurityEvents = 5,
                Period = TimeSpan.Zero
            };

            this.Reactions.Add(new ThresholdReaction(Config.SecurityAction.Throttle, AttackerComparison.IPAddress, new TimeSpan(0, 15, 0)));
        }
    }
}