﻿using System;

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
        }
    }
}
