using NSec.Config;
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
        public SecurityAction Action { get; set; }
        public AttackerComparison Type { get; set; }
        public string AttackerDetail { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Period { get; set; }
    }
}