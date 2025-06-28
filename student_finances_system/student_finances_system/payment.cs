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
            
            var arialBold8 = new Font("Arial", 8F, FontStyle.Bold);

           
            TransDataGrid.DefaultCellStyle.Font = arialBold8;
          

            TransDataGrid.ColumnHeadersDefaultCellStyle.Font = arialBold8;

           
            TransDataGrid.RowHeadersDefaultCellStyle.Font = arialBold8;

            
            Color headerBackColor = Color.DodgerBlue;

            
            TransDataGrid.EnableHeadersVisualStyles = false;

            
            TransDataGrid.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor;
            TransDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
            CASE WHEN th.IsPaid = 1 THEN 'Paid' ELSE 'Not Paid' END AS PaymentStatus,
            th.PaymentDate           AS PaymentDate
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
                    using (var reader = cmd.ExecuteReader())
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
                                reader["PaymentStatus"],
                                Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd")
                            );
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void displayAllGridData()
        {
            TransDataGrid.Rows.Clear();

            string sql = @"
        SELECT
            th.TransactionID,
            th.StudentID,
            si.FullName              AS StudentName,
            th.ConcessionPercent,
            th.AmountPaid,
            th.MonthName             AS Month,
            CASE WHEN th.IsPaid = 1 THEN 'Paid' ELSE 'Not Paid' END AS PaymentStatus,
            th.PaymentDate           AS PaymentDate
        FROM TransactionHistory th
        INNER JOIN StudentInfo  si ON th.StudentID = si.StudentID
        INNER JOIN FeeStructure fs ON th.FeeID     = fs.FeeID
        ORDER BY th.TransactionID;";

            try
            {
                using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
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
                                reader["PaymentStatus"],
                                Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd")
                            );
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResequenceTransactionIds()
        {
            
            string sql = @"
BEGIN TRANSACTION;

-- 1) Build temp table with fresh identity
CREATE TABLE #TempHistory
(
    TransactionID      INT IDENTITY(1,1) PRIMARY KEY,
    StudentID          VARCHAR(20),
    FeeID              INT,
    AmountPaid         DECIMAL(10,2),
    MonthName          VARCHAR(20),
    IsPaid             BIT,
    ConcessionPercent  DECIMAL(5,2)
);

INSERT INTO #TempHistory (StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent)
SELECT 
    StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent
FROM TransactionHistory
ORDER BY TransactionID;

-- 2) Wipe the real table clean
TRUNCATE TABLE TransactionHistory;

-- 3) Allow explicit identity inserts
SET IDENTITY_INSERT TransactionHistory ON;

INSERT INTO TransactionHistory
    (TransactionID, StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent)
SELECT
    TransactionID, StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent
FROM #TempHistory
ORDER BY TransactionID;

SET IDENTITY_INSERT TransactionHistory OFF;

-- 4) Tear down temp
DROP TABLE #TempHistory;

-- 5) Reseed to max new ID so future inserts continue at N+1
DECLARE @maxId INT = (SELECT MAX(TransactionID) FROM TransactionHistory);
DBCC CHECKIDENT('TransactionHistory', RESEED, @maxId);

COMMIT;
";

            try
            {
                using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Transaction IDs resequenced successfully.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error while resequencing: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void searchAllTransbtn_Click(object sender, EventArgs e)
        {
            displayAllGridData();
            
        }

        private void DeleteTransbtn_Click(object sender, EventArgs e)
        {
            if (TransDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            
            int transactionId = Convert.ToInt32(
                TransDataGrid.SelectedRows[0].Cells["Column1"].Value
            );

           
            if (MessageBox.Show(
                    "Are you sure you want to delete transaction #" + transactionId + "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes)
            {
                return;
            }

            
            string sql = "DELETE FROM TransactionHistory WHERE TransactionID = @TransactionID";
            using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                con.Open();
                cmd.ExecuteNonQuery(); 
            }


            TransDataGrid.Rows.Remove(TransDataGrid.SelectedRows[0]);

            ResequenceTransactionIds();
            displayAllGridData();
        }

        private void TransDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TransDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (TransDataGrid.Columns[e.ColumnIndex].Name == "paystatus" && e.Value != null)
            {
                string status = e.Value.ToString();

               
                if (status == "Paid")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (status == "Not Paid")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
