using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace student_finances_system
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void payment_Load(object sender, EventArgs e)
        {
            StudentID.AutoCompleteCustomSource = DatabaseHelper.GetStudentIdAutoCompleteCollection();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void displayGridData()
        {
            string studentId = StudentID.Text.Trim();
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a Student ID.");
                return;
            }

            TransDataGrid.Rows.Clear();

            string sql = @"
        SELECT
            th.TransactionID,
            th.StudentID,
            si.FullName              AS StudentName,
            th.ConcessionPercent,
            th.AmountPaid,
            th.MonthName             AS Month,
            CASE WHEN th.IsPaid = 1 THEN 'Paid' ELSE 'Not Paid' END AS PaymentStatus
        FROM TransactionHistory th
        INNER JOIN StudentInfo  si ON th.StudentID = si.StudentID
        INNER JOIN FeeStructure fs ON th.FeeID     = fs.FeeID
        WHERE th.StudentID = @StudentID
        ORDER BY th.TransactionID;";

            try
            {
                using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())  // :contentReference[oaicite:0]{index=0}
                    {
                        while (reader.Read())
                        {
                            TransDataGrid.Rows.Add(
                                reader["TransactionID"],
                                reader["StudentID"],
                                reader["StudentName"],
                                reader["ConcessionPercent"],
                                reader["AmountPaid"],
                                reader["Month"],
                                reader["PaymentStatus"]
                            );
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }
        }

        private void searchTransbtn_Click(object sender, EventArgs e)
        {
            displayGridData();
        }

        private void StudentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;       
                e.SuppressKeyPress = true;
                displayGridData();
            }
        }
    }
}
