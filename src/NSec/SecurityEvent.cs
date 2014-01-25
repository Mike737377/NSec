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

        public AttackerProfile AttackerProfile { get; private set; }
    }

    public class AttackerProfile
    {
        public string IPAddress { get; private set; }

        public string UserAgent { get; private set; }

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
        RequestForgery
    }
}