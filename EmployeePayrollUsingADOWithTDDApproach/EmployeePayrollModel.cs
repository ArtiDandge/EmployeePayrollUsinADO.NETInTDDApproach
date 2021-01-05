using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollUsingADOWithTDDApproach
{
    public class EmployeePayrollModel
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string job_description { get; set; }
        public double salary { get; set; }
        public DateTime joining_date { get; set; }
        public string geneder { get; set; }
        public int company { get; set; }
        public int companyId { get; set; }
        public int departmentId { get; set; }
        public bool is_employee_active { get; set; }

        public EmployeePayrollModel()
        {

        }
        public EmployeePayrollModel(int employee_id, string employee_name, string job_description, double salary, DateTime joining_date,
                            string geneder, int companyId, int departmentId, bool is_employee_active)
        {
            this.employee_id = employee_id;
            this.employee_name = employee_name;
            this.job_description = job_description;
            this.salary = salary;
            this.joining_date = joining_date;
            this.geneder = geneder;
            this.companyId = companyId;
            this.departmentId = departmentId;
            this.is_employee_active = is_employee_active;
        }
    }
}
