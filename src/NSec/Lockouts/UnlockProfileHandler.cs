using NSec.Infrastructure;
using NSec.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FubuCore;

namespace NSec.Lockouts
{
    public class UnlockProfileHandler : IHandler<UnlockProfile>
    {
        private readonly IDataContext dataContext;

        public UnlockProfileHandler(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Execute(UnlockProfile message)
        {
            var lockoutsQuery = dataContext.Lockouts.Query.Where(x => x.EndDate >= SystemTime.UtcNow);

            if (!message.IPAddress.IsEmpty())
            {
                lockoutsQuery = lockoutsQuery.Where(x => x.Type == Config.AttackerComparison.IPAddress && x.AttackerDetail.Equals(message.IPAddress));
            }

            if (!message.AnonymousUserId.IsEmpty())
            {
                lockoutsQuery = lockoutsQuery.Where(x => x.Type == Config.AttackerComparison.AnonymousId && x.AttackerDetail.Equals(message.AnonymousUserId));
            }

            if (!message.Fingerprint.IsEmpty())
            {
                lockoutsQuery = lockoutsQuery.Where(x => x.Type == Config.AttackerComparison.Fingerprint && x.AttackerDetail.Equals(message.Fingerprint));
            }

            if (!message.UserName.IsEmpty())
            {
                lockoutsQuery = lockoutsQuery.Where(x => x.Type == Config.AttackerComparison.UserName && x.AttackerDetail.Equals(message.UserName));
            }

            var cancelledLockouts = lockoutsQuery.ToList();

            cancelledLockouts.Each(v => dataContext.Lockouts.Remove(v));
        }
    }
}
