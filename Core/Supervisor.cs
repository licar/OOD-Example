using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public sealed class Supervisor : Employee, ISupervisor
    {
        public IEnumerable<IStaff> Subordinates { get; set; }
        private readonly float subordinantPersent; 

        public Supervisor(string name, DateTime date, int salary, IEnumerable<IStaff> subordinates,
            int yearPersent, int maxPersent, float subordinantPersent) 
            : base(name, date, salary, yearPersent, maxPersent)
        {
            Subordinates = subordinates;
            this.subordinantPersent = subordinantPersent;
        }

        public override int GetSalary()
        {
            return (int)(base.GetSalary() + (Subordinates?.Sum(s => s.GetSalary()) ?? 0) * subordinantPersent / 100);
        }
    }
}