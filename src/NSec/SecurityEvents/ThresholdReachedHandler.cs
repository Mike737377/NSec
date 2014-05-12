using NSec.Config;
using NSec.Infrastructure;
using NSec.Lockouts;
using NSec.Model;
using NSec.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.SecurityEvents
{
    public class ThresholdReachedHandler : IHandler<ThresholdReached>
    {
        private readonly IDataContext dataContext;
        private readonly IServiceBus bus;

        public ThresholdReachedHandler(IServiceBus bus, IDataContext dataContext)
        {
            this.bus = bus;
            this.dataContext = dataContext;
        }

        public void Execute(ThresholdReached message)
        {
            bus.Send(new LockoutAttacker()
            {
                Action = message.Reaction.Action,
                MinimumPeriod = message.Reaction.Period,
                Type = message.Reaction.Comparison,
                AttackerDetail = GetAttackerDetail(message.Reaction.Comparison, message.SecurityEvent.AttackerProfile)
            });
        }

        private string GetAttackerDetail(AttackerComparison type, AttackerProfile profile)
        {
            switch (type)
            {
                case AttackerComparison.AnonymousId:
                    return profile.AnonymousUserId;

                case AttackerComparison.Fingerprint:
                    return profile.Fingerprint.ToString();

                case AttackerComparison.IPAddress:
                    return profile.IPAddress;

                case AttackerComparison.SessionId:
                    throw new NotImplementedException();

                case AttackerComparison.UserAgent:
                    return profile.UserAgent;

                case AttackerComparison.UserId:
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}