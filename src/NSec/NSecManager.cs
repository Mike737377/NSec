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
    public class NSecManager
    {
        private static readonly IServiceBus bus;

        private NSecManager()
        { }

        static NSecManager()
        {
            bus = ServiceFactory.GetInstance<IServiceBus>();
        }

        private static ISecurityReporter GetReporter()
        {
            return ServiceFactory.GetInstance<ISecurityReporter>();
        }

        public static void ReportSecurityEvent(EventType eventType)
        {
            GetReporter().Report(eventType);
        }

        public static void UnlockCurrentProfile()
        {
            GetReporter().UnlockCurrentProfile();
        }

        public static void UnlockProfile(UnlockProfile profile)
        {
            GetReporter().UnlockProfile(profile);
        }

    }
}