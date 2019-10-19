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

        public AdminDAL()
        {
        }
    }
}
