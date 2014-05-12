using NSec.Infrastructure;
using NSec.Model;
using NSec.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Lockouts
{
    public class LockoutAttackerHandler : IHandler<LockoutAttacker>
    {
        private readonly IDataContext dataContext;
        private readonly IServiceBus bus;

        public LockoutAttackerHandler(IServiceBus bus, IDataContext dataContext)
        {
            this.bus = bus;
            this.dataContext = dataContext;
        }

        public void Execute(LockoutAttacker message)
        {
            var lockout = new Lockout()
            {
                Date = SystemTime.UtcNow,
                EndDate = SystemTime.UtcNow.Add(message.MinimumPeriod),
                Type = message.Type,
                AttackerDetail = message.AttackerDetail
            };

            dataContext.Lockouts.Add(lockout);
        }
    }
}