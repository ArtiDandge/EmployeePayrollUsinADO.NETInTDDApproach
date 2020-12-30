using System;

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
            employeePayroll.UpdateEmployeeSalary(model);
        }
    }
}
