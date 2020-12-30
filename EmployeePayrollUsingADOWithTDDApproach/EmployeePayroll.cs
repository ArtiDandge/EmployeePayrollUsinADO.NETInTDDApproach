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

        public double UpdateEmployeeSalary(EmployeePayrollModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpUpdateSalary", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Empname", model.employee_name);
                    command.Parameters.AddWithValue("@updateSalary", model.salary);
                    this.connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Salary Updated Successfully !");
                    this.connection.Close();
                }
                return model.salary;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int GetEmployeeBetweenPerticularDateRange()
        {
            int result = 0;
            try
            {
                EmployeePayrollModel model = new EmployeePayrollModel();
                using (this.connection)
                {
                    string query = @"select count(employee_id) from employee_payroll where joining_date between CAST('2018-12-25' as date) AND GETDATE();";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    result = (int)command.ExecuteScalar();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.employee_id = reader.GetInt32(0);
                            Console.WriteLine("{0}", model.employee_id);
                            Console.WriteLine("\n");
                        }
                    }
                    reader.Close();
                    this.connection.Close();
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
