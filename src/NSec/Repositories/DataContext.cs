using NSec.Infrastructure;
using NSec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Repositories
{
    public class DataContext : IDataContext
    {
        public DataContext()
        {
            AttackerProfiles = ServiceFactory.GetInstance<IRepository<AttackerProfile>>();
            SecurityEvents = ServiceFactory.GetInstance<IRepository<SecurityEvent>>();
            Lockouts = ServiceFactory.GetInstance<IRepository<Lockout>>();
        }

        public IRepository<AttackerProfile> AttackerProfiles { get; private set; }

        public IRepository<SecurityEvent> SecurityEvents { get; private set; }

        public IRepository<Lockout> Lockouts { get; private set; }

        public void Dispose()
        {
            //shouldn't need to worry about it
        }
    }
}