using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class Sales : Supervisor
    {
        public Sales(string name, DateTime date, int salary, IEnumerable<IStaff> subordinates) : 
            base(name, date, salary, subordinates)
        {
            MaxPersent = 35;
            YearPersent = 1;
            SubordinantPersent = 0.3f;
        }
    }
}