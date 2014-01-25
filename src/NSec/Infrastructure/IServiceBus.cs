using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public interface IServiceBus
    {
        void Send<TMessage>(TMessage message);
        void Reply<TMessage>(TMessage message);
    }
}
