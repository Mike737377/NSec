using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public class PoorMansServiceBus : IServiceBus
    {
        private readonly IHandlerRegistry handlerRegistry;

        public PoorMansServiceBus(IHandlerRegistry handlerRegistry)
        {
            this.handlerRegistry = handlerRegistry;
        }

        public void Send<TMessage>(TMessage message)
        {
            var handler = handlerRegistry.GetHandlerForMessage<TMessage>();
            handler.Execute(message);
        }

        public void Reply<TMessage>(TMessage message)
        {
            throw new NotImplementedException();
        }
    }
}