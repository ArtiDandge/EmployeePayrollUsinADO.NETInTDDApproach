using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollUsingADOWithTDDApproach
{
    public class EmployeePayroll
    {
        private static SqlConnection Connectionsetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=employee_payroll_service;Integrated Security=True");
        }
    }
}
