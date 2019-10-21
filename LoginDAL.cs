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
    public class LoginDAL
    {
        private string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"]?.ConnectionString;
        public long EmpId { get; set; }  //Last Login Requirement
        public bool EmpPrivelege { get; set; }

        public LoginDAL()
        {
        }
        public bool VerifyLogin(int empID, string pass)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Employee.SelectLoginCredentials", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", empID);
                cmd.Parameters.AddWithValue("@Pass", pass);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    EmpId = dr.GetInt64(0);
                    EmpPrivelege = dr.GetBoolean(4);
                    return true;
                }
                else
                    return false;
            }
        }
        public void UpdateLastLogin()
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Employee.UpdateLastLogin",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",EmpId);
                cmd.ExecuteNonQuery();
            }
        }
        ~LoginDAL()
        {
        }
    }
}
