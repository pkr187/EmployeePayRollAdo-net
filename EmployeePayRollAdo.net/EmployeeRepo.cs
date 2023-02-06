using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollAdo.net
{
    internal class EmployeeRepo
    {
        public static string connectionstring = "C:\\Dotnet\\EmployeePayRollAdo.net\\SQLQuery1.sql";
        SqlConnection connection = new SqlConnection(connectionstring);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeemodel = new EmployeeModel();
                using (this.connection)
                {
                    //string query = @"select EmployeeID,EmployeeName,PhoneNo,Address,Department,Gender,BasicPay,Deduction,Taxable,Tax,NetPay,StartDate,City,Country from employee_payroll";
                    string query = @"select * from employee_payroll";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeemodel.EmployeeID = dr.GetInt32(0);
                            employeemodel.EmployeeName = dr.GetString(1);
                            employeemodel.Phoneno = dr.GetString(2);
                            employeemodel.Address = dr.GetString(3);
                            employeemodel.Department = dr.GetString(4);
                            employeemodel.Gender = Convert.ToChar(dr.GetString(5));
                            employeemodel.BasicPay = dr.GetDouble(6);
                            employeemodel.Deduction = dr.GetDouble(7);
                            employeemodel.TaxablePay = dr.GetDouble(8);
                            employeemodel.Tax = dr.GetDouble(9);
                            employeemodel.NetPay = dr.GetDouble(10);
                            employeemodel.StartDate = dr.GetDateTime(11);
                            employeemodel.City = dr.GetString(12);
                            employeemodel.Country = dr.GetString(13);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", employeemodel.EmployeeID, employeemodel.EmployeeName, employeemodel.Phoneno, employeemodel.Address, employeemodel.Department, employeemodel.Gender, employeemodel.BasicPay
                                , employeemodel.Deduction, employeemodel.TaxablePay, employeemodel.Tax, employeemodel.NetPay, employeemodel.StartDate, employeemodel.City, employeemodel.Country);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no data found");
                    }
                    dr.Close();
                    this.connection.Close();

                }

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
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@Phoneno", model.Phoneno);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@Netpay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;

                    }
                    return false;
                }
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
    

