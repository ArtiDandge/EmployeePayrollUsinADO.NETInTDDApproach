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

        /// <summary>
        /// UC10 : Ensure Retrieval Query is working on new DB structure
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenSelect_ShouldRetrieveAllData()
        {
            int expectedRetrieveResult = 17;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            int result = employeePayroll.GetData();
            Assert.AreEqual(expectedRetrieveResult, result);
        }

        /// <summary>
        /// UC 10 : Ensure working of update query to check  updated employee salary in new db structure
        /// </summary>
        [TestMethod]
        public void GivenQuery_ShouldUpdateSalaryInNewDBStructure()
        {
            double expectedResult = 400000.00;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_name = "Sujecha",
                salary = 400000.00
            };
            double salary = employeePayroll.UpdateEmployeeSalary(model);

            Assert.AreEqual(expectedResult, salary);
        }

        /// <summary>
        /// UC 10 : Ensure working of retrieve perticular employeee data query in new db structure
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenCount_ShouldReturnCountFromNewDB()
        {
            int expectedResult = 12;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            int result = employeePayroll.GetEmployeeBetweenPerticularDateRange();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// UC 10 : Ensure working of aggregate function on employeee data in new db structure are working
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenAggregateFunction_ShouldReturnResultAndMatchExpectedFromNewDB()
        {
            List<string> expected = new List<string>();
            List<string> result = new List<string>();
            expected.Add("2590000");
            expected.Add("100000");
            expected.Add("500000");
            expected.Add("2830000");
            expected.Add("353750");
            EmployeePayroll employeePayroll = new EmployeePayroll();
            result = employeePayroll.GetAggregateFunctionResult();
            CollectionAssert.AreEqual(expected, result);
        }

        /// <summary>
        /// UC 10 : Ensure UC 7 i.e. Insertion of new  Employee Data in new DB structure as per ER Diagram is working
        /// </summary>
        [TestMethod]
        public void GiveQuery_WhenInsert_ShouldPerformInsertion()
        {
            bool expectedInsertResult = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 17,
                employee_name = "Juili",
                job_description = "Finance",
                joining_date = new DateTime(2019, 11, 22),
                salary = 240000.00,
                geneder = "F",
                companyId = 2,
                departmentId = 3
            };
            bool insertResult = employeePayroll.AddNewEmployee(model);
            Assert.AreEqual(expectedInsertResult, insertResult);
        }


        /// <summary>
        /// UC 11 : Insertion of new  Employee Data in new DB structure
        /// </summary>
        [TestMethod]
        public void GiveQuery_WhenInsert_ShouldPerformInsertionASInNewDBStructure()
        {
            bool expectedInsertResult = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 18,
                employee_name = "Mohit",
                job_description = "Support",
                joining_date = new DateTime(2019, 02, 22),
                salary = 350000.00,
                geneder = "M",
                companyId = 1,
                departmentId = 3
            };
            bool insertResult = employeePayroll.AddNewEmployee(model);
            Assert.AreEqual(expectedInsertResult, insertResult);
        }

        /// <summary>
        /// Test case to retrieve only active employees when we inactive a employee
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenEmpIdSetToFalse_ReturnOnlyActiveEmployee()
        {
            int expectedResult = 16;        
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 8
            };
            int result = employeePayroll.CheckEmployeeISActive(model);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
