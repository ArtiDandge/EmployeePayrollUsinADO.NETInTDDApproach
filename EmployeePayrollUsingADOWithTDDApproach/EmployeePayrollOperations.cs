using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingADOWithTDDApproach
{
    public class EmployeePayrollOperations
    {
        public List<EmployeePayrollModel> employeeList = new List<EmployeePayrollModel>();
        /// <summary>
        /// Method to create list of all employee and see the employee added
        /// </summary>
        /// <param name="employeeList"></param>
        public void addEmplyeeToPayroll(List<EmployeePayrollModel> employeeList)
        {
            employeeList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added : "+ employeeData.employee_name);
                this.addEmplyeePayroll(employeeData);
                Console.WriteLine("Emplyee added"+ employeeData.employee_name);
            });
            Console.WriteLine(this.employeeList.ToString());
        }

        /// <summary>
        /// Add Employee with threading
        /// </summary>
        /// <param name="employeeList"></param>
        public void addEmplyeeToPayrollWithThread(List<EmployeePayrollModel> employeeList)
        {
            employeeList.ForEach(employeeData =>
             {
                 Task thread = new Task(() =>
                 {
                     Console.WriteLine("Employee being added "+ employeeData.employee_name);
                     this.addEmplyeePayroll(employeeData);
                     Console.WriteLine("Employee added "+ employeeData.employee_name);
                 });
                 thread.Start();
             });
            Console.WriteLine(this.employeeList.Count);
        }

        /// <summary>
        /// Method to add employee to the employee list
        /// </summary>
        /// <param name="emp"></param>
        private void addEmplyeePayroll(EmployeePayrollModel emp)
        {
            employeeList.Add(emp);
        }
    }
}
