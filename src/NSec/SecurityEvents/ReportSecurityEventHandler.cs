using NSec.Config;
using NSec.Infrastructure;
using NSec.Lockouts;
using NSec.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.SecurityEvents
{
    public class ReportSecurityEventHandler : IHandler<ReportSecurityEvent>
    {
        private readonly IServiceBus bus;
        private readonly IDataContext dataContext;

        public ReportSecurityEventHandler(IServiceBus bus, IDataContext dataContext)
        {
            this.bus = bus;
            this.dataContext = dataContext;
        }

        public void Execute(ReportSecurityEvent message)
        {
            dataContext.SecurityEvents.Add(message.Event);

            var threshold = new Threshold[] { };

            threshold.ForEach(v =>
                {
                    var thresholdQuery = dataContext.SecurityEvents.Query.Where(sql => sql.EventType == v.Conditions.EventType);

                    if (v.Conditions.Period != TimeSpan.Zero)
                    {
                        var afterDate = SystemTime.UtcNow.Subtract(v.Conditions.Period);
                        thresholdQuery.Where(sql => sql.Date >= afterDate);
                    }

                    var matchedEvents = thresholdQuery.Count();
                    if (matchedEvents >= v.Conditions.MinimumSecurityEvents)
                    {
                        v.Reactions.ForEach(x => bus.Send(new ThresholdReached() { SecurityEvent = message.Event, Reaction = x }));
                    }
                });
        }
    }
}