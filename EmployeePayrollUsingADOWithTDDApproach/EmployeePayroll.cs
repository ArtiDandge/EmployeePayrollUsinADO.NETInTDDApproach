using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollUsingADOWithTDDApproach
{
    public class EmployeePayroll
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=employee_payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        private static SqlConnection Connectionsetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=employee_payroll_service;Integrated Security=True");
        }

        public void GetData()
        {
            EmployeePayrollModel model = new EmployeePayrollModel();
            using (this.connection)
            {
                SqlCommand command = new SqlCommand("RetrieveData", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.employee_id = reader.GetInt32(0);
                        model.employee_name = reader.GetString(1);
                        model.job_description = reader.GetString(2);
                        model.salary = Convert.ToDouble(reader.GetDecimal(3));
                        model.joining_date = reader.GetDateTime(4);

                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", model.employee_id, model.employee_name, model.job_description, model.salary, model.joining_date);
                        Console.WriteLine("\n");
                    }
                }
                reader.Close();
                this.connection.Close();
            }
        }
    }
}
