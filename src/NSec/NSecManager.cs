using NSec.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public static class NSecManager
    {
        private static readonly IServiceBus bus;

        static NSecManager()
        {
            bus = ServiceFactory.GetInstance<IServiceBus>();
        }

        public static void ReportSecurityEvent(SecurityEvent securityEvent)
        {
            bus.Send(securityEvent);
        }
    }
}