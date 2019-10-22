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

        public static List<CustDetails> searchByCustomer(long id)
        {
            List<CustDetails> search = new List<CustDetails>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Customer.SearchByCustId", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cust_Id", id);

                    using (SqlDataReader reader =command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustDetails p = new CustDetails();
                            p.Cust_FirstName = reader.SafeGetString(0);
                            p.Cust_LastName = reader.SafeGetString(1);
                            p.Cust_Gender = reader.SafeGetString(2);
                            p.Cust_Address = reader.SafeGetString(3);
                            p.Cust_Contact_No = reader.GetInt64(4);
                            search.Add(p);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            return search;
        }
        public static void addCustomer (CustDetails obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Customer.AddCustomer", connection))
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
                    MessageBox.Show("Succesful Login Customer", "SUCCESFULL", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        public static void UpdateCustomer(CustDetails obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Customer.UpdateByCustomerId", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("Cust_Id", SqlDbType.Int).Value = obj.Cust_Id.ToDbParameter();
                    command.Parameters.Add("Cust_FirstName", SqlDbType.VarChar, 256).Value = obj.Cust_FirstName.ToDbParameter();
                    command.Parameters.Add("Cust_LastName", SqlDbType.VarChar, 50).Value = obj.Cust_LastName.ToDbParameter();
                    command.Parameters.Add("Cust_Gender", SqlDbType.VarChar, 1).Value = obj.Cust_Gender.ToDbParameter();
                    command.Parameters.Add("Cust_Address", SqlDbType.VarChar, 256).Value = obj.Cust_Address.ToDbParameter();                    
                    command.Parameters.Add("Cust_Contact_No", SqlDbType.BigInt).Value = obj.Cust_Contact_No.ToDbParameter();

                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Succesful Update Customer Details", "SUCCESFULL", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
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