using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class Manager : Supervisor
    {
        public Manager(string name, DateTime date, int salary, IEnumerable<IStaff> subordinates) 
            : base(name, date, salary, subordinates)
        {
            MaxPersent = 40;
            YearPersent = 5;
            SubordinantPersent = 0.5f;
        }
    }
}