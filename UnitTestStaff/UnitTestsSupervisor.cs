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
            var supervisorNullSubordinates = StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY);
            Assert.AreEqual(supervisorNullSubordinates.GetSalary(), BASE_SALARY);

            var supervisorEmptySubordinates =
                StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY, new IStaff[0]);
            Assert.AreEqual(supervisorEmptySubordinates.GetSalary(), BASE_SALARY);
        }

        [TestMethod]
        public void SupervisorOneSubordinateTest()
        {
            var subordinate = StaffFactory.Get(nameof(Employee), "User", DateTime.Now, BASE_SALARY);
            var supervisor = StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY, new IStaff[]{subordinate});
            Assert.AreEqual(supervisor.GetSalary(), ONE_SUBORDINATE_SALARY);
        }

        [TestMethod]
        public void SupervisorTwoSubordinatesTest()
        {
            var subordinateOne = StaffFactory.Get(nameof(Employee), "User", DateTime.Now, BASE_SALARY);
            var subordinateTwo = StaffFactory.Get(nameof(Employee), "User", DateTime.Now, BASE_SALARY);
            var supervisor = 
                StaffFactory.Get(nameof(Manager), "User", DateTime.Now, BASE_SALARY, new IStaff[] { subordinateOne, subordinateTwo });
            Assert.AreEqual(supervisor.GetSalary(), TWO_SUBORDINATES_SALARY);
        }

        [TestMethod]
        public void SupervisorHundredYearsWithOneSubordinateTest()
        {
            var subordinateOne = StaffFactory.Get(nameof(Employee), "User", DateTime.Now, BASE_SALARY);
            var supervisor =
                StaffFactory.Get(nameof(Manager), 
                    "User",
                    new DateTime(DateTime.Now.Year - 100, DateTime.Now.Month, DateTime.Now.Day - 1), 
                    BASE_SALARY, 
                    new IStaff[] { subordinateOne });
            Assert.AreEqual(supervisor.GetSalary(), MAX_SALARY_WITH_ONE_SUBORDIANTE);
        }
    }
}