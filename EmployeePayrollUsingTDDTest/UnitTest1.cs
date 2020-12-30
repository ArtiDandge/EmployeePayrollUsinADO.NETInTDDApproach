using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollUsingADOWithTDDApproach;

namespace EmployeePayrollUsingTDDTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenQuery_ShouldUpdateSalary()
        {
            double expectedResult = 400000.00;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_name = "Samir",
                salary = 400000.00
            };
            double salary = employeePayroll.UpdateEmployeeSalary(model);

            Assert.AreEqual(expectedResult, salary);
        }
    }
}
