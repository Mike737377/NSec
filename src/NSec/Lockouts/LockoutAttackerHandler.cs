using NSec.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Lockouts
{
    public class LockoutAttackerHandler : IHandler<LockoutAttacker>
    {
        public void Execute(LockoutAttacker message)
        {
            throw new NotImplementedException();
        }
    }
}