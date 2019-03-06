using System;

namespace Core
{
    public class Employee : IStaff
    {
        private readonly DateTime zeroTime;
        private int workedYears => (zeroTime + (DateTime.Now - Date)).Year - 1;
        private int salaryIncrease =>
            (workedYears * YearPersent > MaxPersent 
                ? Salary * MaxPersent 
                : Salary * YearPersent * workedYears) / 100;

        protected int MaxPersent = 30;
        protected int YearPersent = 3;

        protected int Salary { get; }
        public string Name { get; }
        public DateTime Date { get; }

        public Employee(string name, DateTime date, int salary)
        {
            Name = name;
            Date = date;
            Salary = salary;
            zeroTime = new DateTime(1, 1, 1);
        }

        public virtual int GetSalary()
        {
            return Salary + salaryIncrease;
        }
    }
}
