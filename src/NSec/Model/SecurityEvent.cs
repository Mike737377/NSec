using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Model
{
    public class SecurityEvent
    {
        public SecurityEvent()
        {
            AttackerProfile = new AttackerProfile();
            SecurityEventId = Guid.NewGuid();
        }

        public Guid SecurityEventId { get; private set; }

        public DateTime Date { get; set; }

        public EventType EventType { get; set; }

        public AttackerProfile AttackerProfile { get; set; }
    }

    public enum EventType : int
    {
        InvalidResource,
        InsufficientSecurityPrivledges,
        DangerousHttpMethod,
        Spidering,
        RequestForgery,
        UnsuccessfulLoginAttempt
    }
}