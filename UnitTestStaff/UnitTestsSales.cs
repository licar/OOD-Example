using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStaff
{
    [TestClass]
    public class UnitTestsSales
    {
        private const int BASE_SALARY = 1000;
        private const int ONE_YEAR_SALARY = 1010;
        private const int ONE_SUBORDINATE_ONE_YEAR_SALARY = 1003;
        private const int THIRTY_FOUR_YEARS_SALARY = 1340;
        private const int MAX_SALARY = 1350;


        [TestMethod]
        public void SalesYearsSalaryTest()
        {
            var firstYearSales = StaffFactory.Get(StaffFactory.SALES, "User", DateTime.Today, BASE_SALARY);
            Assert.AreEqual(BASE_SALARY, firstYearSales.GetSalary());

            var secondYearSales = StaffFactory.Get(StaffFactory.SALES,
                "User",
                new DateTime(DateTime.Today.Year - 1, DateTime.Today.Month, DateTime.Today.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(ONE_YEAR_SALARY, secondYearSales.GetSalary());

            var thirtyFourYearsSales = StaffFactory.Get(StaffFactory.SALES,
                "User",
                new DateTime(DateTime.Today.Year - 35, DateTime.Today.Month, DateTime.Today.Day + 1),
                BASE_SALARY);
            Assert.AreEqual(THIRTY_FOUR_YEARS_SALARY, thirtyFourYearsSales.GetSalary());

            var hundredYearsSales = StaffFactory.Get(StaffFactory.SALES,
                "User",
                new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day - 1),
                BASE_SALARY);
            Assert.AreEqual(MAX_SALARY, hundredYearsSales.GetSalary());
        }

        [TestMethod]
        public void SalesOneSubordinateTest()
        {
            var subordinate = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var managerFirstYear = StaffFactory.Get(StaffFactory.SALES, "User", DateTime.Today, BASE_SALARY, new IStaff[] { subordinate });
            Assert.AreEqual(ONE_SUBORDINATE_ONE_YEAR_SALARY, managerFirstYear.GetSalary());
        }
    }
}
