using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public interface IHandlerRegistry
    {
        IHandler<TMessage> GetHandlerForMessage<TMessage>() where TMessage : IMessage;
    }
}