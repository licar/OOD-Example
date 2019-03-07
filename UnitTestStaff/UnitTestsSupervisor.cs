using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestStaff
{
    [TestClass]
    public class UnitTestsSupervisor
    {
        private const int BASE_SALARY = 1000;
        private const int ONE_SUBORDINATE_SALARY = 1005;
        private const int TWO_SUBORDINATES_SALARY = 1010;
        private const int MAX_SALARY_WITH_ONE_SUBORDIANTE = 1405;

        [TestMethod]
        public void SupervisorWithoutSubordinatesTest()
        {
            var supervisorNullSubordinates = StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY);
            Assert.AreEqual(supervisorNullSubordinates.GetSalary(), BASE_SALARY);

            var supervisorEmptySubordinates =
                StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY, new IStaff[0]);
            Assert.AreEqual(supervisorEmptySubordinates.GetSalary(), BASE_SALARY);
        }

        [TestMethod]
        public void SupervisorOneSubordinateTest()
        {
            var subordinate = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var supervisor = StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY, new IStaff[]{subordinate});
            Assert.AreEqual(supervisor.GetSalary(), ONE_SUBORDINATE_SALARY);
        }

        [TestMethod]
        public void SupervisorTwoSubordinatesTest()
        {
            var subordinateOne = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var subordinateTwo = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var supervisor = 
                StaffFactory.Get(StaffFactory.MANAGER, "User", DateTime.Today, BASE_SALARY, new IStaff[] { subordinateOne, subordinateTwo });
            Assert.AreEqual(supervisor.GetSalary(), TWO_SUBORDINATES_SALARY);
        }

        [TestMethod]
        public void SupervisorHundredYearsWithOneSubordinateTest()
        {
            var subordinateOne = StaffFactory.Get(nameof(Employee), "User", DateTime.Today, BASE_SALARY);
            var supervisor =
                StaffFactory.Get(StaffFactory.MANAGER, 
                    "User",
                    new DateTime(DateTime.Today.Year - 100, DateTime.Today.Month, DateTime.Today.Day - 1), 
                    BASE_SALARY, 
                    new IStaff[] { subordinateOne });
            Assert.AreEqual(supervisor.GetSalary(), MAX_SALARY_WITH_ONE_SUBORDIANTE);
        }
    }
}