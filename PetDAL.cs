using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PMS
{
    public class PetDAL
    {
        public PetDetails petDetails = new PetDetails();
        private string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"]?.ConnectionString;

        public PetDetails LoadToPetComboBox()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@",);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

            return petDetails;
        }
    }
}
