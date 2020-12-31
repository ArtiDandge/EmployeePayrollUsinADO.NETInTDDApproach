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

        public List<string> GetAggregateFunctionResult()
        {
            List<string> str = new List<string>();
            try
            {
                EmployeePayrollModel employeeModel = new EmployeePayrollModel();
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT SUM(salary) FROM employee_payroll WHERE gender = 'F' GROUP BY gender;
                        SELECT MIN(salary) FROM employee_payroll WHERE gender = 'F' GROUP BY gender;
                        SELECT MAX(salary) FROM employee_payroll WHERE gender = 'F' GROUP BY gender;
                        SELECT COUNT(employee_id) FROM employee_payroll WHERE gender = 'F';
                        SELECT SUM(salary) FROM employee_payroll WHERE gender = 'M' GROUP BY gender;
                        SELECT AVG(salary) FROM employee_payroll WHERE gender = 'M' GROUP BY gender; 
                        SELECT COUNT(employee_id) FROM employee_payroll WHERE gender = 'M';", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\n---------------Aggregate Function Operation on Female Employee---------------");
                            while (reader.Read())
                            {
                                employeeModel.salary = Convert.ToDouble(reader.GetDecimal(0));
                                str.Add(employeeModel.salary.ToString());
                                Console.WriteLine("Overall Sum of Basic Pay of Female Employee is : {0}", employeeModel.salary);
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.salary = Convert.ToDouble(reader.GetDecimal(0));
                                    str.Add(employeeModel.salary.ToString());
                                    Console.WriteLine("Minimum of Basic Pay of Female Employee is : {0}", employeeModel.salary);
                                }
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.salary = Convert.ToDouble(reader.GetDecimal(0));
                                    str.Add(employeeModel.salary.ToString());
                                    Console.WriteLine("Maximum of Basic Pay of Female Employee is : {0}", employeeModel.salary);
                                }
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.employee_id = reader.GetInt32(0);
                                    Console.WriteLine("Number of Female Employee present : {0}", employeeModel.employee_id);
                                }
                            }
                            Console.WriteLine("\n---------------Aggregate Function Operation on Male Employee---------------");
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.salary = Convert.ToDouble(reader.GetDecimal(0));
                                    str.Add(employeeModel.salary.ToString());
                                    Console.WriteLine("Overall Sum of Basic Pay of Male Employee is : {0}", employeeModel.salary);
                                }
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.salary = Convert.ToDouble(reader.GetDecimal(0));
                                    str.Add(employeeModel.salary.ToString());
                                    Console.WriteLine("Average of Basic Pay of Male Employee is : {0}", employeeModel.salary);
                                }
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    employeeModel.employee_id = reader.GetInt32(0);
                                    Console.WriteLine("Number of Male Employee present : {0}", employeeModel.employee_id);
                                }
                            }
                        }
                    }
                }
                return str;
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

        public bool AddNewEmployee(EmployeePayrollModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("InsertInto", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", model.employee_id);
                command.Parameters.AddWithValue("@EmpName", model.employee_name);
                command.Parameters.AddWithValue("@JobDescription", model.job_description);
                command.Parameters.AddWithValue("@Salary", model.salary);
                command.Parameters.AddWithValue("@JoiningDate", model.joining_date);
                command.Parameters.AddWithValue("@Geneder", model.geneder);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();

                int employee_id = model.employee_id;
                double deduction = model.salary * 0.2;
                double taxable_pay = model.salary - deduction;
                double tax = taxable_pay * 0.1;
                double net_salary = model.salary - tax;
                SqlCommand sqlCommand = new SqlCommand("InsertIntoAlongWithSalaryDetails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@empId", (model.employee_id));
                sqlCommand.Parameters.AddWithValue("@deduction", (model.salary * 0.2));
                sqlCommand.Parameters.AddWithValue("@taxable_pay", (model.salary - deduction));
                sqlCommand.Parameters.AddWithValue("@tax", (taxable_pay * 0.1));
                sqlCommand.Parameters.AddWithValue("@net_salary", (model.salary - tax));
                this.connection.Open();
                var result1 = sqlCommand.ExecuteNonQuery();
                this.connection.Close();
                if (result1 == 0)
                {
                    return false;
                }
                return true;
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

        public bool AddNewEmployeeDEmo(EmployeePayrollModel model, EmployeeCompanyModel companyModel)
        {
            try
            {
                SqlCommand command = new SqlCommand("InsertInto", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", model.employee_id);
                command.Parameters.AddWithValue("@EmpName", model.employee_name);
                command.Parameters.AddWithValue("@JobDescription", model.job_description);
                command.Parameters.AddWithValue("@Salary", model.salary);
                command.Parameters.AddWithValue("@JoiningDate", model.joining_date);
                command.Parameters.AddWithValue("@Geneder", model.geneder);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();

                int employee_id = model.employee_id;
                double deduction = model.salary * 0.2;
                double taxable_pay = model.salary - deduction;
                double tax = taxable_pay * 0.1;
                double net_salary = model.salary - tax;
                SqlCommand sqlCommand = new SqlCommand("InsertIntoAlongWithSalaryDetails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@empId", (model.employee_id));
                sqlCommand.Parameters.AddWithValue("@deduction", (model.salary * 0.2));
                sqlCommand.Parameters.AddWithValue("@taxable_pay", (model.salary - deduction));
                sqlCommand.Parameters.AddWithValue("@tax", (taxable_pay * 0.1));
                sqlCommand.Parameters.AddWithValue("@net_salary", (model.salary - tax));
                this.connection.Open();
                var result1 = sqlCommand.ExecuteNonQuery();
                this.connection.Close();

                SqlCommand companySqlCommand = new SqlCommand("InsertCompanyDetails", connection);
                companySqlCommand.CommandType = CommandType.StoredProcedure;
                companySqlCommand.Parameters.AddWithValue("@EmpId", companyModel.company_id);
                companySqlCommand.Parameters.AddWithValue("@ComapnyName",companyModel.company_name);
                this.connection.Open();
                var result2 = companySqlCommand.ExecuteNonQuery();
                this.connection.Close();
                if (result2 == 0)
                {
                    return false;
                }
                return true;
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
