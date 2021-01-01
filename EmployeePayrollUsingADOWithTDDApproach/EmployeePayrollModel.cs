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
    }
}
