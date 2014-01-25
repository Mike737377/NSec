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
        private readonly IDataContext store;

        public ReportSecurityEventHandler(IServiceBus bus, IDataContext dataContext)
        {
            this.bus = bus;
            this.store = dataContext;
        }

        public void Execute(ReportSecurityEvent message)
        {
            store.Add(message.Event);

            //check thresholds
            //if > threshold then lockout
            var threshold = new Threshold[] { };

            threshold.ForEach(v =>
                {
                    var thresholdReached = v.Critera.Invoke(message.Event, store.SecurityEvents.Query);
                    if (thresholdReached)
                    {
                        v.Reactions.ForEach(x => bus.Send(new ThresholdReached() { SecurityEvent = message.Event, Reaction = x }));
                    }
                });
        }
    }
}