using System;
using System.Collections.Generic;

namespace Core
{
    public class StaffFactory
    {
        /// <exception cref="System.ArgumentException">Thrown when invalid employee type</exception>
        public static IStaff Get(string type, string name, DateTime date, int salary, IEnumerable<IStaff> subordinates = null)
        {
            switch (type)
            {
                case nameof(Employee):
                    return new Employee(name, date, salary);
                case nameof(Sales):
                    return new Sales(name, date, salary, subordinates);
                case nameof(Manager):
                    return  new Manager(name, date, salary, subordinates);
            }

            throw new ArgumentException("Invalid employee type");
        }
    }
}