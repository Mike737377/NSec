﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public interface IHandler<TMessage>
        where TMessage : IMessage
    {
        void Execute(TMessage message);
    }
}