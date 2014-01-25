using NSec.Infrastructure;
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
        }
    }
}