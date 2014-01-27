using NSec.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Lockouts
{
    public class LockoutAttacker : IMessage
    {
        public Guid AttackerGuid { get; set; }
    }
}