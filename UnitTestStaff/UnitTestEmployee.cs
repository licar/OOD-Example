using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStaff
{
    [TestClass]
    public class UnitTestEmployee
    {
        private const int BASE_SALARY = 1000;
        private const int ONE_YEAR_SALARY = 1030;
        private const int NINE_YEARS_SALARY = 1270;

        [TestMethod]
        public void EmployeeFirstYearSalaryTest()
        {
            var firstDayEmployee = new Employee("User", DateTime.Now, BASE_SALARY);
            Assert.AreEqual(firstDayEmployee.GetSalary(), BASE_SALARY);

            var firstYearEmployee = new Employee("User", DateTime.Now, BASE_SALARY);
            var employeeStub = new Employee("User", 
                new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day + 1),
                1000);
            Assert.AreEqual(firstDayEmployee.GetSalary(), BASE_SALARY);
        }

        [TestMethod]
        public void EmployeeMoreThanOneYearSalaryTest()
        {
            var employeeSecondYear = new Employee("User",
                new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day - 1), 1000);
            Assert.AreEqual(employeeSecondYear.GetSalary(), ONE_YEAR_SALARY);
        }

        [TestMethod]
        public void EmployeeNineYearsSalaryTest()
        {
            var employeeSecondYear = new Employee("User",
                new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day + 1), 1000);
            Assert.AreEqual(employeeSecondYear.GetSalary(), NINE_YEARS_SALARY);
        }
    }
}
