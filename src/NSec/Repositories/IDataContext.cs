using NSec.Lockouts;
using NSec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Repositories
{
    public interface IDataContext : IDisposable
    {
        IRepository<AttackerProfile> AttackerProfiles { get; }

        IRepository<SecurityEvent> SecurityEvents { get; }

        IRepository<Lockout> Lockouts { get; }
    }
}