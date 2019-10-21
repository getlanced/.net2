using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PMS
{
    class CustomerDAL
    {

        private static string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"]?.ConnectionString;

        public static void addCustomer (EmpDetails obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("AddCustomer", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("Cust_FirstName", SqlDbType.VarChar, 256).Value = obj.Cust_FirstName.ToDbParameter();
                    command.Parameters.Add("Cust_LastName", SqlDbType.VarChar, 50).Value = obj.Cust_LastName.ToDbParameter();
                    command.Parameters.Add("Cust_Gender", SqlDbType.VarChar, 1).Value = obj.Cust_Gender.ToDbParameter();
                    command.Parameters.Add("Cust_Address", SqlDbType.VarChar, 256).Value = obj.Cust_Address.ToDbParameter();
                    command.Parameters.Add("Cust_Contact_No", SqlDbType.BigInt).Value = obj.Cust_Contact_No.ToDbParameter();

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }


        }


        public CustomerDAL()
        {
            
        }
    }
}
