using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public class SecurityEvent
    {
        public SecurityEvent()
        {
            AttackerProfile = new AttackerProfile();
        }

        public Guid SecurityEventId { get; private set; }

        public DateTime Date { get; set; }

        public EventType EventType { get; set; }

        public AttackerProfile AttackerProfile { get; set; }
    }

    public class AttackerProfile
    {
        public string AnonymousUserId;
        public string IPAddress { get; set; }

        public string UserAgent { get; set; }

        public int Fingerprint
        {
            get
            {
                return (IPAddress + UserAgent).GetHashCode();
            }
        }
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