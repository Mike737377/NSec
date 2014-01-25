using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public interface IHandler<TMessage>
    {
        void Execute(TMessage message);
    }
}
