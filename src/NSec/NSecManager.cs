using NSec.Infrastructure;
using NSec.SecurityEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NSec
{
    public class NSecManager
    {
        private static readonly IServiceBus bus;

        private NSecManager()
        { }

        static NSecManager()
        {
            bus = ServiceFactory.GetInstance<IServiceBus>();
        }

        public static void ReportSecurityEvent(EventType eventType)
        {
            ServiceFactory.GetInstance<ISecurityReporter>().Report(eventType);
        }

        public interface ISecurityReporter
        {
            void Report(EventType eventType);
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
                var securityEvent = new SecurityEvent()
                {
                    Date = DateTime.UtcNow,
                    AttackerProfile = new AttackerProfile()
                    {
                        IPAddress = httpContext.Request.UserHostAddress,
                        UserAgent = httpContext.Request.UserAgent,
                        AnonymousUserId = httpContext.Request.AnonymousID,
                    },
                    EventType = eventType,
                };

                bus.Send(new ReportSecurityEvent() { Event = securityEvent });
            }
        }
    }
}