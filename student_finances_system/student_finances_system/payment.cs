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
            CASE WHEN th.IsPaid = 1 THEN 'Paid' ELSE 'Not Paid' END AS PaymentStatus
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


        private void ResequenceTransactionIds()
        {
            // This batch:
            // 1) Copies all rows (in old-ID order) into a temp table with a new IDENTITY column
            // 2) Truncates the real table
            // 3) Inserts back from the temp table (including the new IDs)
            // 4) Drops the temp table
            // 5) Reseeds the identity to the max new ID
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

            // grab the TransactionID of the first selected row
            int transactionId = Convert.ToInt32(
                TransDataGrid.SelectedRows[0].Cells["Column1"].Value
            );

            // confirm with the user
            if (MessageBox.Show(
                    "Are you sure you want to delete transaction #" + transactionId + "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes)
            {
                return;
            }

            // delete from database
            string sql = "DELETE FROM TransactionHistory WHERE TransactionID = @TransactionID";
            using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                con.Open();
                cmd.ExecuteNonQuery();  // executes the DELETE statement :contentReference[oaicite:1]{index=1}
            }

            // remove the row from the grid
            TransDataGrid.Rows.Remove(TransDataGrid.SelectedRows[0]);

            ResequenceTransactionIds();
            displayAllGridData();
        }
    }
}
