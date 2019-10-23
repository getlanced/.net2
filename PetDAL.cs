using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PMS
{
    public class PetDAL
    {
        private string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"]?.ConnectionString;

        public List<string> SearchByCustomerID(long id)
        {
            List<string> results = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Customer.SearchByCustomerID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("CustID", SqlDbType.BigInt).Value = id;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            results.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            return results;
        }

        public List<object> Modify(long custID, string petName)
        {
            List<object> results = new List<object>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("Customer.Modify", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("CustID", SqlDbType.BigInt).Value = custID;
                    command.Parameters.Add("PetName", SqlDbType.VarChar, 50).Value = petName;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                results.Add(reader.GetValue(i));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            return results;
        }
    }
}
