using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStaff
{
    [TestClass]
    public class UnitTestsEmployee
    {
        private const int ZERO_SALARY = 0;
        private const int BASE_SALARY = 1000;
        private const int ONE_YEAR_SALARY = 1030;
        private const int NINE_YEARS_SALARY = 1270;
        private const int MAX_SALARY = 1300;


        [TestMethod]
        public void EmployeeZeroSalaryTest()
        {
            var employeeZeroSalary = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, ZERO_SALARY);
            Assert.AreEqual(ZERO_SALARY, employeeZeroSalary.GetSalary());

            var employeeZeroSalaryHundredYears = StaffFactory.Get(
                nameof(Employee),
                "User",
                new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day - 1),
                ZERO_SALARY);
            Assert.AreEqual(ZERO_SALARY, employeeZeroSalaryHundredYears.GetSalary());
        }

        [TestMethod]
        public void EmployeeFirstYearSalaryTest()
        {
            var firstDayEmployee = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            Assert.AreEqual(BASE_SALARY, firstDayEmployee.GetSalary());
        }

        [TestMethod]
        public void EmployeeMoreThanOneYearSalaryTest()
        {
            var secondYearEmployee = StaffFactory.Get(nameof(Employee), "User",
                new DateTime(DateTime.Today.Year - 1, DateTime.Now.Month, DateTime.Today.Day - 1), BASE_SALARY);
            Assert.AreEqual(ONE_YEAR_SALARY, secondYearEmployee.GetSalary());
        }

        [TestMethod]
        public void EmployeeNineYearsSalaryTest()
        {
            var nineYearsEmployee = StaffFactory.Get(nameof(Employee), "User",
                new DateTime(DateTime.Today.Year - 10, DateTime.Now.Month, DateTime.Today.Day + 1), BASE_SALARY);
            Assert.AreEqual(NINE_YEARS_SALARY, nineYearsEmployee.GetSalary());
        }

        [TestMethod]
        public void EmployeeTenYearsAndMoreSalaryTest()
        {
            var tenYearsEmployee = StaffFactory.Get(nameof(Employee), "User",
                new DateTime(DateTime.Today.Year - 10, DateTime.Now.Month, DateTime.Today.Day - 1), BASE_SALARY);
            Assert.AreEqual(MAX_SALARY, tenYearsEmployee.GetSalary());

            var hundredYearsEmployee = StaffFactory.Get(nameof(Employee), "User",
                new DateTime(DateTime.Today.Year - 10, DateTime.Now.Month, DateTime.Today.Day - 1), BASE_SALARY);
            Assert.AreEqual(MAX_SALARY, hundredYearsEmployee.GetSalary());
        }
    }
}
