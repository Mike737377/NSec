using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public interface IServiceBus
    {
        void Send<TMessage>(TMessage message) where TMessage : IMessage;

        void Reply<TMessage>(TMessage message) where TMessage : IMessage;
    }
}