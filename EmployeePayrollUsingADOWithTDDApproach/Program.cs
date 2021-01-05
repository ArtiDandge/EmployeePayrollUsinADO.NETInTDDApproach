using System;
using System.Collections.Generic;

namespace EmployeePayrollUsingADOWithTDDApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Project with ADO solved using TDD Approach");
            EmployeePayroll employeePayroll = new EmployeePayroll();
            //employeePayroll.GetData();

            EmployeePayrollModel model = new EmployeePayrollModel();
            model.employee_name = "Barkha";
            model.salary = 300000.00;
            //employeePayroll.UpdateEmployeeSalary(model);

            //employeePayroll.GetEmployeeBetweenPerticularDateRange();
            //employeePayroll.GetAggregateFunctionResult();

            EmployeePayrollModel employee = new EmployeePayrollModel();
            //employeePayroll.AddNewEmployee(employee);

            /*model.employee_id = 9;
            model.employee_name = "Rama";
            model.job_description = "Construction";
            model.joining_date = new DateTime(2020, 01, 20);
            model.salary = 450000.00;
            model.geneder = "F";*/
            model.employee_id = 6;
            employeePayroll.CheckEmployeeISActive(model);

            List<EmployeePayrollModel> employeeList = new List<EmployeePayrollModel>();
            employeeList.Add(new EmployeePayrollModel(employee_id: 101, employee_name: "Simran", job_description: "Tech", salary: 300000.00, new DateTime(2019 - 10 - 11), geneder: "F", companyId: 1, departmentId: 2, is_employee_active: true));
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
            Console.WriteLine("Duration for Insertion in List without thread : " + (stopDateTime - startDataTime));
            DateTime startDataTimeThread = DateTime.Now;
            employeePayrollOperations.addEmplyeeToPayrollWithThread(employeeList);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration for Insertion in List with thread : " + (stopDateTimeThread - startDataTimeThread));
        }


    }
}
