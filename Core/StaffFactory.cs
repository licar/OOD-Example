using System;
using System.Collections.Generic;

namespace Core
{
    public class StaffFactory
    {
        public const string MANAGER = "Manager";
        public const string SALES = "Sales";

        /// <exception cref="System.ArgumentException">Thrown when invalid employee type</exception>
        public static IStaff Get(string type, string name, DateTime date, int salary, IEnumerable<IStaff> subordinates = null)
        {
            switch (type)
            {
                case nameof(Employee):
                    return new Employee(name, date, salary, 3, 30);
                case SALES:
                    return new Supervisor(name, date, salary, subordinates, 1, 35, 0.3f);
                case MANAGER:
                    return  new Supervisor(name, date, salary, subordinates, 5, 40, 0.5f);
            }

            throw new ArgumentException("Invalid employee type");
        }
    }
}