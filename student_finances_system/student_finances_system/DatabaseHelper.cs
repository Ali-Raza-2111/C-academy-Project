using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_finances_system
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return "Data Source=BARYAR\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";
        }

        public static AutoCompleteStringCollection GetStudentIdAutoCompleteCollection()
        {
            AutoCompleteStringCollection idCollection = new AutoCompleteStringCollection();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT StudentID FROM StudentInfo";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idCollection.Add(reader["StudentID"].ToString());
                }

                reader.Close();
            }

            return idCollection;
        }
    }
}
