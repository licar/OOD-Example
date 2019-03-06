using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStaff
{
    [TestClass]
    public class UnitTestsManager
    {
        private const int BASE_SALARY = 1000;
        private const int ONE_YEAR_SALARY = 1050;
        private const int ONE_SUBORDINATE_ONE_YEAR_SALARY = 1005;
        private const int SEVEN_YEARS_SALARY = 1350;
        private const int MAX_SALARY = 1400;


        [TestMethod]
        public void ManagerYearsSalaryTest()
        {
            var firstYearManager = StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY);
            Assert.AreEqual(firstYearManager.GetSalary(), BASE_SALARY);

            var secondYearManager = StaffFactory.Get(nameof(Manager),
                "User",
                new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(secondYearManager.GetSalary(), ONE_YEAR_SALARY);

            var tenYearsManager = StaffFactory.Get(nameof(Manager),
                "User",
                new DateTime(DateTime.Now.Year - 8, DateTime.Now.Month, DateTime.Now.Day + 1),
                BASE_SALARY);
            Assert.AreEqual(tenYearsManager.GetSalary(), SEVEN_YEARS_SALARY);

            var hundredYearsManager = StaffFactory.Get(nameof(Manager),
                "User",
                new DateTime(DateTime.Now.Year - 100, DateTime.Now.Month, DateTime.Now.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(hundredYearsManager.GetSalary(), MAX_SALARY);
        }

        [TestMethod]
        public void ManagerOneSubordinateTest()
        {
            var subordinate = StaffFactory.Get(nameof(Employee), "User", DateTime.Now, BASE_SALARY);
            var managerFirstYear = StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY, new IStaff[] { subordinate });
            Assert.AreEqual(managerFirstYear.GetSalary(), ONE_SUBORDINATE_ONE_YEAR_SALARY);

            var managerSecondYear = StaffFactory.Get(
                nameof(Manager), 
                "User",
                new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day + 1), 
                BASE_SALARY, 
                new IStaff[] { subordinate });
            Assert.AreEqual(managerSecondYear.GetSalary(), ONE_SUBORDINATE_ONE_YEAR_SALARY);
        }
    }
}
