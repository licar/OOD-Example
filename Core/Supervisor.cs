using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class Supervisor : Employee
    {
        protected IEnumerable<IStaff> Subordinates { get; }
        protected float SubordinantPersent { get; set; }

        protected Supervisor(string name, DateTime date, int salary, IEnumerable<IStaff> subordinates) 
            : base(name, date, salary)
        {
            Subordinates = subordinates;
        }

        public override int GetSalary()
        {
            return (int)(base.GetSalary() + Subordinates.Sum(s => s.GetSalary()) * SubordinantPersent / 100);
        }
    }
}