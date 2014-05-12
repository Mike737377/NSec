using NSec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Config
{
    public class Threshold
    {
        public Threshold()
        {
            Reactions = new List<ThresholdReaction>();
        }

        public string Name { get; set; }

        public ThresholdConditions Conditions { get; set; }

        public List<ThresholdReaction> Reactions { get; private set; }
    }

    public class ThresholdConditions
    {
        /// <summary>
        /// Gets or sets the period for the conditions to be matched over. Set to TimeSpan.Zero for all time matching.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        public TimeSpan Period { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of security events that have occurred within the period before the threshold is enacted upon.
        /// </summary>
        /// <value>
        /// The minimum security events.
        /// </value>
        public int MinimumSecurityEvents { get; set; }

        /// <summary>
        /// Gets or sets the type of the event to match.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        public EventType EventType { get; set; }
    }

    public class ThresholdReaction
    {
        public ThresholdReaction()
        { }

        public ThresholdReaction(SecurityAction action, AttackerComparison comparison, TimeSpan period)
        {
            Action = action;
            Comparison = comparison;
            Period = period;
        }

        public SecurityAction Action { get; set; }
        public AttackerComparison Comparison { get; set; }
        public TimeSpan Period { get; set; }
    }

    public enum AttackerComparison : int
    {
        IPAddress,
        UserAgent,
        Fingerprint,
        AnonymousId,
        UserId,
        SessionId,
        UserName,
    }

    public enum SecurityAction
    {
        Block,
        Track,
        Throttle
    }
}