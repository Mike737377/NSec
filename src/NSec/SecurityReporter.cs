using NSec.Config;
using NSec.Infrastructure;
using NSec.Lockouts;
using NSec.Model;
using NSec.SecurityEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NSec
{
    public interface ISecurityReporter
    {
        void Report(EventType eventType);
        void UnlockCurrentProfile();
        void UnlockProfile(UnlockProfile profile);
    }

    public class SecurityReporter : ISecurityReporter
    {
        private readonly HttpContextBase httpContext;
        private readonly IServiceBus bus;

        public SecurityReporter(IServiceBus bus, HttpContextBase httpContext)
        {
            this.bus = bus;
            this.httpContext = httpContext;
        }

        public void Report(EventType eventType)
        {
            var userName = NSecConfiguration.GetCurrentUserName(httpContext);
            var securityEvent = new SecurityEvent()
            {
                Date = DateTime.UtcNow,
                AttackerProfile = new AttackerProfile()
                {
                    IPAddress = httpContext.Request.UserHostAddress,
                    UserAgent = httpContext.Request.UserAgent,
                    AnonymousUserId = httpContext.Request.AnonymousID,
                    UserName = userName
                },
                EventType = eventType,
            };

            bus.Send(new ReportSecurityEvent() { Event = securityEvent });
        }

        public void UnlockCurrentProfile()
        {
            var unlockProfile = new UnlockProfile()
            {
                IPAddress = httpContext.Request.UserHostAddress
            };

            bus.Send(unlockProfile);
        }

        public void UnlockProfile(UnlockProfile unlockProfile)
        {
            bus.Send(unlockProfile);
        }
    }
}
