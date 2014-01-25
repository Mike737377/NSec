using NSec.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public class HandlerRegistry : IHandlerRegistry
    {
        public IHandler<TMessage> GetHandlerForMessage<TMessage>()
        {
            return ServiceFactory.GetInstance<IHandler<TMessage>>();
        }
    }
}