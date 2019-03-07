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
            var firstYearManager = StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY);
            Assert.AreEqual(firstYearManager.GetSalary(), BASE_SALARY);

            var secondYearManager = StaffFactory.Get(StaffFactory.MANAGER,
                "User",
                new DateTime(DateTime.Today.Year - 1, DateTime.Today.Month, DateTime.Today.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(secondYearManager.GetSalary(), ONE_YEAR_SALARY);

            var tenYearsManager = StaffFactory.Get(StaffFactory.MANAGER,
                "User",
                new DateTime(DateTime.Today.Year - 8, DateTime.Today.Month, DateTime.Today.Day + 1),
                BASE_SALARY);
            Assert.AreEqual(tenYearsManager.GetSalary(), SEVEN_YEARS_SALARY);

            var hundredYearsManager = StaffFactory.Get(StaffFactory.MANAGER,
                "User",
                new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(hundredYearsManager.GetSalary(), MAX_SALARY);
        }

        [TestMethod]
        public void ManagerOneSubordinateTest()
        {
            var subordinate = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var managerFirstYear = StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY, new IStaff[] { subordinate });
            Assert.AreEqual(managerFirstYear.GetSalary(), ONE_SUBORDINATE_ONE_YEAR_SALARY);

            var managerSecondYear = StaffFactory.Get(
                StaffFactory.MANAGER, 
                "User",
                new DateTime(DateTime.Today.Year - 1, DateTime.Today.Month, DateTime.Today.Day + 1), 
                BASE_SALARY, 
                new IStaff[] { subordinate });
            Assert.AreEqual(managerSecondYear.GetSalary(), ONE_SUBORDINATE_ONE_YEAR_SALARY);
        }
    }
}
