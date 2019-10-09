using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PMS
{
    public static class DBUtils   // database fetch usable methods (for nullable rows)
    {
        public static string SafeGetString(this SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            return string.Empty;
        }

        public static DateTime? SafeGetDateTime(this SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetDateTime(index);
            return null;
        }
        public static object ToDbParameter<T>(this T? value)
        where T : struct
        {
            object dbValue = value;
            if (dbValue == null)
            {
                dbValue = DBNull.Value;
            }
            return dbValue;
        }
        public static object ToDbParameter(this object value)
        {
            object dbValue = value;
            if (dbValue == null)
            {
                dbValue = DBNull.Value;
            }
            return dbValue;
        }
    }

    class EmpDetails
    {
        public long EmployeeID { get; set; }
        public string Emp_FirstName { get; set; }
        public string Emp_LastName { get; set; }
        public int Emp_GenderID { get; set; }
        public string Emp_AddLine1 { get; set; }
        public string Emp_AddLine2 { get; set; }
        public long Emp_MobileNo { get; set; }
        public long Emp_HouseNo { get; set; }
        public bool Emp_PrivelegeID { get; set; }
        public string Emp_Password { get; set; }
        public DateTime? Emp_LastLogin { get; set; }  // nullable datetime data type

        ~EmpDetails()
        {
        }
    }
    class Objects
    {
    }
}
