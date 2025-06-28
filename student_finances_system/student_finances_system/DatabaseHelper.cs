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


        public static AutoCompleteStringCollection GetStudentNameAutoCompleteCollection()
        {
            AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT FullName FROM StudentInfo";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nameCollection.Add(reader["FullName"].ToString());
                }

                reader.Close();
            }

            return nameCollection;
        }

        public static decimal GetTotalAmountPaid()
        {
            decimal totalAmount = 0;

            using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = "SELECT SUM(AmountPaid) FROM TransactionHistory";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalAmount = Convert.ToDecimal(result);
                }
            }

            return totalAmount;
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

        
        public static void UpdatePaymentDate(int transactionId)
        {
            const string sql = @"
        UPDATE TransactionHistory
        SET PaymentDate = GETDATE()
        WHERE TransactionID = @TransactionID;
    ";

            try
            {
                using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();  // runs the UPDATE :contentReference[oaicite:0]{index=0}
                    if (affected == 0)
                        MessageBox.Show($"No transaction found with ID {transactionId}.",
                                        "Update Payment Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error while updating payment date:\n{ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
