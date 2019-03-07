using System;

namespace Core
{
    public class Employee : IStaff
    {
        private readonly DateTime zeroTime;
        private readonly int maxPersent;
        private readonly int yearPersent;

        private int workedYears => (zeroTime + (DateTime.Today - Date)).Year - 1;
        protected int Salary { get; }
        public string Name { get; }
        public DateTime Date { get; }

        public Employee(string name, DateTime date, int salary, int yearPersent, int maxPersent)
        {
            Name = name;
            Date = date;
            Salary = salary;
            this.yearPersent = yearPersent;
            this.maxPersent = maxPersent;
            zeroTime = new DateTime(1, 1, 1);
        }

        public virtual int GetSalary()
        {
            var salaryIncrease = (workedYears * yearPersent > maxPersent 
                                    ? Salary * maxPersent
                                    : Salary * yearPersent * workedYears) / 100;
            return Salary + salaryIncrease;
        }
    }
}
