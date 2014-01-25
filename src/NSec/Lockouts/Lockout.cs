using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public class Lockout
    {

        public Lockout()
        {
            LockoutId = Guid.NewGuid();
        }

        public Lockout(Guid lockoutId)
        {
            LockoutId = lockoutId;
        }

        public Guid LockoutId { get; private set; }
        public DateTime Date { get; set; }
        public Guid AttackerId { get; set; }
        public Guid ThresholdId { get; set; }

    }
}
