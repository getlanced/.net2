using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace PMS
{
    
    class AdminDAL
    {
        private string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"]?.ConnectionString;

        public EmpDetails SearchByEmpID(long searchID)
        {
            EmpDetails resultDet = new EmpDetails();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Employee.SearchByEmpID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", searchID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultDet.EmployeeID = reader.GetInt64(0);
                            resultDet.Emp_FirstName = reader.GetString(1);
                            resultDet.Emp_LastName = reader.SafeGetString(2);
                            resultDet.Emp_GenderID = reader.GetInt32(3);
                            resultDet.Emp_AddLine1 = reader.GetString(4);
                            resultDet.Emp_AddLine2 = reader.SafeGetString(5);
                            resultDet.Emp_MobileNo = reader.GetInt64(6);
                            resultDet.Emp_HouseNo = reader.GetInt64(7);
                            resultDet.Emp_PrivelegeID = reader.GetBoolean(8);
                            resultDet.Emp_Password = reader.GetString(9);
                            resultDet.Emp_LastLogin = reader.SafeGetDateTime(10);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            return resultDet;
        }

        public bool AddNewEmployee(EmpDetails newRecord)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("AddNewEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("FirstName", SqlDbType.VarChar, 256).Value = newRecord.Emp_FirstName.ToDbParameter();
                    command.Parameters.Add("LastName", SqlDbType.VarChar, 256).Value = newRecord.Emp_LastName.ToDbParameter();
                    command.Parameters.Add("GenderID", SqlDbType.Int).Value = newRecord.Emp_GenderID.ToDbParameter();
                    command.Parameters.Add("AddLine1", SqlDbType.VarChar, int.MaxValue).Value = newRecord.Emp_AddLine1;
                    command.Parameters.Add("AddLine2", SqlDbType.VarChar, int.MaxValue).Value = newRecord.Emp_AddLine2.ToDbParameter();
                    command.Parameters.Add("Mobile", SqlDbType.BigInt).Value = newRecord.Emp_MobileNo;
                    command.Parameters.Add("HouseNo", SqlDbType.BigInt).Value = newRecord.Emp_HouseNo.ToDbParameter();
                    command.Parameters.Add("PrivelegeID", SqlDbType.Bit).Value = newRecord.Emp_PrivelegeID;
                    command.Parameters.Add("Password", SqlDbType.VarChar, 256).Value = newRecord.Emp_Password.ToDbParameter();
                    command.Parameters.Add("LastLogin", SqlDbType.DateTime).Value = newRecord.Emp_LastLogin.ToDbParameter();
                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            return false;
        }

        public AdminDAL()
        {
        }
    }
}