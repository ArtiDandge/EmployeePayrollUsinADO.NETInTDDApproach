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
            int expectedResult = 6;
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
            expected.Add("890000");
            expected.Add("296666.6666");
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
                employee_id = 8,
                employee_name = "Rohit",
                job_description = "Support",
                joining_date = new DateTime(2018, 10, 22),
                salary = 240000.00,
                geneder = "M"
            };
            bool result = employeePayroll.AddNewEmployee(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Test case to insert value 
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsertInto_ShouldAbleToInsertIntoTwoTable()
        {
            bool expectedResult = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 12,
                employee_name = "Prakhar",
                job_description = "DevOps",
                joining_date = new DateTime(2019, 09, 17),
                salary = 450000.00,
                geneder = "M"
            };
            bool result = employeePayroll.AddNewEmployee(model);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenQuery_WhenInsertInto_ShouldAbleToInsertIntoTwoTableDemo()
        {
            bool expectedResult = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 16,
                employee_name = "Pratik",
                job_description = "Finance",
                joining_date = new DateTime(2017, 11, 11),
                salary = 600000.00,
                geneder = "M",
                company = 1
            };
            EmployeeCompanyModel companyModel = new EmployeeCompanyModel()
            {
                company_id = model.employee_id,
                company_name = "IBM"
            };
            //bool result = employeePayroll.AddNewEmployee(model);
            bool result = employeePayroll.AddNewEmployeeDEmo(model, companyModel);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
