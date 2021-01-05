using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeePayrollUsingADOWithTDDApproach;

namespace EmployeePayrollUsingTDDTest
{
    [TestClass]
    public class MultiThreadingTest
    {
        /// <summary>
        /// Test case to check duration of execution while inserting in List as well as DB
        /// </summary>
        [TestMethod]
        public void GivenListANdDB_WhenInsert_ShouldRecordExecutionTime()
        {
            List<EmployeePayrollModel> employeeList = new List<EmployeePayrollModel>();
            employeeList.Add(new EmployeePayrollModel(employee_id: 101, employee_name: "Simran", job_description: "Tech", salary: 300000.00, new DateTime(2019-10-11), geneder: "F", companyId: 1, departmentId: 2, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 102, employee_name: "Adesh", job_description: "Support", salary: 400000.00, new DateTime(2019 - 11 - 11), geneder: "M", companyId: 3, departmentId: 3, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 103, employee_name: "Sandesh", job_description: "Production", salary: 300000.00, new DateTime(2019 - 10 - 11), geneder: "M", companyId: 3, departmentId: 1, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 104, employee_name: "Ruchita", job_description: "Management", salary: 400000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 2, departmentId: 3, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 105, employee_name: "Suchita", job_description: "Management", salary: 400000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 1, departmentId: 2, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 106, employee_name: "Shital", job_description: "Tech", salary: 300000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 1, departmentId: 2, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 107, employee_name: "Akash", job_description: "Support", salary: 400000.00, new DateTime(2019 - 11 - 11), geneder: "M", companyId: 3, departmentId: 3, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 108, employee_name: "Lalit", job_description: "Production", salary: 300000.00, new DateTime(2019 - 10 - 11), geneder: "M", companyId: 3, departmentId: 1, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 109, employee_name: "Rekha", job_description: "Management", salary: 400000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 2, departmentId: 3, is_employee_active: true));
            employeeList.Add(new EmployeePayrollModel(employee_id: 110, employee_name: "Rani", job_description: "Finance", salary: 400000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 1, departmentId: 1, is_employee_active: true));
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime startDataTime = DateTime.Now;
            employeePayrollOperations.addEmplyeeToPayroll(employeeList);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration for Insertion in List without thread : "+ (stopDateTime - startDataTime));
            EmployeePayroll employeePayroll = new EmployeePayroll();
            EmployeePayrollModel model = new EmployeePayrollModel()
            {
                employee_id = 20,
                employee_name = "Mahesh",
                job_description = "Finance",
                joining_date = new DateTime(2019, 02, 22),
                salary = 450000.00,
                geneder = "M",
                companyId = 3,
                departmentId = 3,
                is_employee_active = true
            };
            DateTime startDataTimeforDB = DateTime.Now;
            employeePayroll.AddNewEmployee(model);
            DateTime stopDateTimeforDB = DateTime.Now;
            Console.WriteLine("Duration for Insertion in DB without thread : " + (stopDateTimeforDB - startDataTimeforDB));
        }
    }
}
