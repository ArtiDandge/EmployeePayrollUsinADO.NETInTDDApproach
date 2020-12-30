using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollUsingADOWithTDDApproach;
using System.Collections.Generic;
using System;

namespace EmployeePayrollUsingTDDTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test case to check  updated employee salary
        /// </summary>
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

        /// <summary>
        /// Test Case to get count of employee from perticular range
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenCount_ShouldReturnCount()
        {
            int expectedResult = 3;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            int result = employeePayroll.GetEmployeeBetweenPerticularDateRange();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Test case for aggregate function query
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenAggregateFunction_ShouldReturnResultAndMatchExpected()
        {
            List<string> expected = new List<string>();
            List<string> result = new List<string>();
            expected.Add("650000");
            expected.Add("100000");
            expected.Add("200000");
            expected.Add("650000");
            expected.Add("325000");
            EmployeePayroll employeePayroll = new EmployeePayroll();
            result = employeePayroll.GetAggregateFunctionResult();
            CollectionAssert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test case to insert value 
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsertInto_ShouldAbleToInsertValue()
        {
            bool expectedResult = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 6,
                employee_name = "Pooja",
                job_description = "Tech",
                joining_date = new DateTime(2019, 09, 12),
                salary = 200000.00,
                geneder = "F"
            };
            bool result = employeePayroll.AddNewEmployee(model);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
