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
    public partial class studentinfo : Form
    {


        private void SearchStudentFeeDetails()
        {
            string studentId = StudentID.Text.Trim();

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a Student ID.");
                return;
            }

            using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                con.Open();

                string studentQuery = "SELECT FullName, Class FROM StudentInfo WHERE StudentID = @StudentID";
                SqlCommand studentCmd = new SqlCommand(studentQuery, con);
                studentCmd.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataReader reader = studentCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("No student found with this ID.");
                    return;
                }

                string studentName = "";
                string studentClass = "";
                while (reader.Read())
                {
                    studentName = reader["FullName"].ToString();
                    studentClass = reader["Class"].ToString();
                }
                reader.Close();

                List<string> months = new List<string>
        {
            "January","February","March","April","May","June",
            "July","August","September","October","November","December"
        };

                dataGridView1.Rows.Clear();

                // Add TransactionID column if it doesn't exist
                if (!dataGridView1.Columns.Contains("TransactionID"))
                {
                    dataGridView1.Columns.Add("TransactionID", "TransactionID");
                    dataGridView1.Columns["TransactionID"].Visible = false;
                }

                foreach (string month in months)
                {
                    string transactionQuery = "SELECT TransactionID, AmountPaid, IsPaid, ConcessionPercent FROM TransactionHistory " +
                                              "WHERE StudentID = @StudentID AND MonthName = @MonthName";
                    SqlCommand transactionCmd = new SqlCommand(transactionQuery, con);
                    transactionCmd.Parameters.AddWithValue("@StudentID", studentId);
                    transactionCmd.Parameters.AddWithValue("@MonthName", month);
                    SqlDataReader transactionReader = transactionCmd.ExecuteReader();

                    decimal amountPaid = 0;
                    decimal concessionPercent = 0;
                    string status = "Not Paid";
                    string transactionId = ""; // New line to hold TransactionID

                    if (transactionReader.Read())
                    {
                        transactionId = transactionReader["TransactionID"].ToString(); // fetch TransactionID
                        amountPaid = Convert.ToDecimal(transactionReader["AmountPaid"]);
                        concessionPercent = Convert.ToDecimal(transactionReader["ConcessionPercent"]);
                        status = (bool)transactionReader["IsPaid"] ? "Paid" : "Not Paid";
                    }
                    transactionReader.Close();

                    // Add row with TransactionID at the end
                    dataGridView1.Rows.Add(
                        studentId,
                        studentName,
                        studentClass,
                        month,
                        concessionPercent,
                        amountPaid,
                        status,
                        transactionId // TransactionID in last cell
                    );
                }
                con.Close();
            }
        }


        private void LoadPaidFeeRecords()
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                con.Open();

                // Get list of StudentIDs who have at least one Paid transaction
                string paidStudentsQuery = "SELECT DISTINCT StudentID FROM TransactionHistory WHERE IsPaid = 1";
                SqlCommand paidCmd = new SqlCommand(paidStudentsQuery, con);
                SqlDataReader paidReader = paidCmd.ExecuteReader();

                List<string> paidStudentIds = new List<string>();

                while (paidReader.Read())
                {
                    paidStudentIds.Add(paidReader["StudentID"].ToString());
                }
                paidReader.Close();

                dataGridView1.Rows.Clear();

                // Add TransactionID column if it doesn't exist
                if (!dataGridView1.Columns.Contains("TransactionID"))
                {
                    dataGridView1.Columns.Add("TransactionID", "TransactionID");
                    dataGridView1.Columns["TransactionID"].Visible = false;
                }

                if (paidStudentIds.Count == 0)
                {
                    MessageBox.Show("No students have paid fees.");
                    con.Close();
                    return;
                }

                List<string> months = new List<string>
        {
            "January","February","March","April","May","June",
            "July","August","September","October","November","December"
        };

                foreach (string studentId in paidStudentIds)
                {
                    string studentQuery = "SELECT FullName, Class FROM StudentInfo WHERE StudentID = @StudentID";
                    SqlCommand studentCmd = new SqlCommand(studentQuery, con);
                    studentCmd.Parameters.AddWithValue("@StudentID", studentId);
                    SqlDataReader studentReader = studentCmd.ExecuteReader();

                    string studentName = "";
                    string studentClass = "";
                    if (studentReader.Read())
                    {
                        studentName = studentReader["FullName"].ToString();
                        studentClass = studentReader["Class"].ToString();
                    }
                    studentReader.Close();

                    foreach (string month in months)
                    {
                        string transactionQuery = "SELECT TransactionID, AmountPaid, IsPaid, ConcessionPercent FROM TransactionHistory " +
                                                  "WHERE StudentID = @StudentID AND MonthName = @MonthName";
                        SqlCommand transactionCmd = new SqlCommand(transactionQuery, con);
                        transactionCmd.Parameters.AddWithValue("@StudentID", studentId);
                        transactionCmd.Parameters.AddWithValue("@MonthName", month);
                        SqlDataReader transactionReader = transactionCmd.ExecuteReader();

                        decimal amountPaid = 0;
                        decimal concessionPercent = 0;
                        string status = "Not Paid";
                        string transactionId = "";

                        if (transactionReader.Read())
                        {
                            transactionId = transactionReader["TransactionID"].ToString();
                            amountPaid = Convert.ToDecimal(transactionReader["AmountPaid"]);
                            concessionPercent = Convert.ToDecimal(transactionReader["ConcessionPercent"]);
                            status = (bool)transactionReader["IsPaid"] ? "Paid" : "Not Paid";
                        }
                        transactionReader.Close();

                        if (status == "Paid")
                        {
                            dataGridView1.Rows.Add(
                                studentId,
                                studentName,
                                studentClass,
                                month,
                                concessionPercent,
                                amountPaid,
                                status,
                                transactionId  // add TransactionID as last cell
                            );
                        }
                    }
                }
                con.Close();
            }
        }





        public studentinfo()
        {
            InitializeComponent();
            
            StudentID.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchStudentFeeDetails();
                }
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentinfo_Load(object sender, EventArgs e)
        {
            button1.BackColor = btnAllRecord.BackColor;
            button1.ForeColor = btnAllRecord.ForeColor;
            button1.Font = btnAllRecord.Font;
            button1.FlatStyle = btnAllRecord.FlatStyle;
            button1.FlatAppearance.BorderColor = btnAllRecord.FlatAppearance.BorderColor;
            button1.FlatAppearance.BorderSize = btnAllRecord.FlatAppearance.BorderSize;

            StudentID.AutoCompleteCustomSource = DatabaseHelper.GetStudentIdAutoCompleteCollection();
            var arialBold8 = new Font("Arial", 8F, FontStyle.Bold);

            // 2. Apply to all data cells
            dataGridView1.DefaultCellStyle.Font = arialBold8;

            // 3. (Optional) Apply to column headers
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = arialBold8;

            // 4. (Optional) Apply to row headers
            dataGridView1.RowHeadersDefaultCellStyle.Font = arialBold8;

            // 1. Pick a contrasting color
            Color headerBackColor = Color.DodgerBlue;

            // 2. Turn off visual styles so your settings take effect
            dataGridView1.EnableHeadersVisualStyles = false;

            // 3. Apply the background color to column headers
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor;  // :contentReference[oaicite:0]{index=0}

            // 4. Ensure header text is visible (white on blue)
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.printDocument1.PrintPage += printDocument1_PrintPage;

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            SearchStudentFeeDetails();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string statusValue = e.Value.ToString();

                if (statusValue == "Paid")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else if (statusValue == "Not Paid")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
            }
        }

        private void btnAllRecord_Click(object sender, EventArgs e)
        {
            LoadPaidFeeRecords();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _rowsToPrint = dataGridView1.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index).ToList();

            if (_rowsToPrint.Count == 0)
            {
                MessageBox.Show("Please select at least one row to print.");
                return;
            }

            // For now, only pick first selected row
            selectedStudentID = _rowsToPrint[0].Cells["stdID"].Value.ToString();
            selectedTransactionID = _rowsToPrint[0].Cells["TransactionID"].Value.ToString();

            // Wire up PrintPreview
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.UseAntiAlias = true;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;

            // Set zoom
            foreach (Control control in printPreviewDialog1.Controls)
            {
                if (control is PrintPreviewControl previewControl)
                {
                    previewControl.Zoom = 1.5;
                    break;
                }
            }

            // Show dialog
            printPreviewDialog1.ShowDialog();
        }

        private List<DataGridViewRow> _rowsToPrint;
        private string selectedTransactionID;
        private string selectedStudentID;


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Fonts, pens, brushes
            var titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            var labelFont = new Font("Segoe UI", 11, FontStyle.Bold);
            var valueFont = new Font("Segoe UI", 11);
            var blackPen = new Pen(Color.Black, 1);
            var brush = Brushes.Black;

            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int pageWidth = e.MarginBounds.Width;

            int y = top;

            // Title
            string title = "Payment Voucher";
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            e.Graphics.DrawString(title, titleFont, brush, left + (pageWidth - titleSize.Width) / 2, y);
            y += (int)titleSize.Height + 20;

            int x = left;

            // Static Pv No.
            e.Graphics.DrawString("Pv No:", labelFont, brush, x, y);
            e.Graphics.DrawString("0001", valueFont, brush, x + 65, y);
            y += 30;

            // Fetch Data From Database (Single Example Record)
            string studentID = selectedStudentID; // for now — you can pass this dynamically

            string studentName = "";
            string fatherName = "";
            string studentClass = "";
            string amountPaid = "";
            string monthName = "";
            string paymentDate = "";

            using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                con.Open();

                string query = @"
        SELECT s.FullName, s.FatherName, s.Class, t.AmountPaid, t.MonthName, t.PaymentDate
        FROM StudentInfo s
        JOIN TransactionHistory t ON s.StudentID = t.StudentID
        WHERE s.StudentID = @StudentID AND t.TransactionID = @TransactionID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    studentName = reader["FullName"].ToString();
                    fatherName = reader["FatherName"].ToString();
                    studentClass = reader["Class"].ToString();
                    amountPaid = reader["AmountPaid"].ToString();
                    monthName = reader["MonthName"].ToString();
                    paymentDate = Convert.ToDateTime(reader["PaymentDate"]).ToString("dd-MM-yyyy");
                }
                reader.Close();
            }

            int tableWidth = 500;
            int cellHeight = 30;

            // Amount & Date
            e.Graphics.DrawRectangle(blackPen, x, y, 250, cellHeight);
            e.Graphics.DrawString("Amount:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString(amountPaid + " PKR", valueFont, brush, x + 100, y + 5);

            e.Graphics.DrawRectangle(blackPen, x + 250, y, 250, cellHeight);
            e.Graphics.DrawString("Date:", labelFont, brush, x + 255, y + 5);
            e.Graphics.DrawString(paymentDate, valueFont, brush, x + 320, y + 5);
            y += cellHeight;

            // Method of Payment
            e.Graphics.DrawRectangle(blackPen, x, y, 500, cellHeight);
            e.Graphics.DrawString("Method Of Payment:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString("Cash", valueFont, brush, x + 200, y + 5);
            y += cellHeight;

            // Cash & Check#
            e.Graphics.DrawRectangle(blackPen, x, y, 250, cellHeight);
            e.Graphics.DrawString("Cash:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString(amountPaid, valueFont, brush, x + 100, y + 5);

            e.Graphics.DrawRectangle(blackPen, x + 250, y, 250, cellHeight);
            e.Graphics.DrawString("Check#:", labelFont, brush, x + 255, y + 5);
            e.Graphics.DrawString("N/A", valueFont, brush, x + 330, y + 5);
            y += cellHeight;

            // To
            e.Graphics.DrawRectangle(blackPen, x, y, 500, cellHeight);
            e.Graphics.DrawString("To:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString(studentName, valueFont, brush, x + 100, y + 5);
            y += cellHeight;

            // The Sum Of
            e.Graphics.DrawRectangle(blackPen, x, y, 500, cellHeight);
            e.Graphics.DrawString("The Sum Of:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString(amountPaid + " PKR", valueFont, brush, x + 150, y + 5);
            y += cellHeight;

            // Being & Payee
            e.Graphics.DrawRectangle(blackPen, x, y, 370, 90);
            e.Graphics.DrawString("Being:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawString("Fee for " + monthName, valueFont, brush, x + 5, y + 35);

            e.Graphics.DrawRectangle(blackPen, x + 370, y, 130, 90);
            e.Graphics.DrawString("Payee:", labelFont, brush, x + 375, y + 5);
            e.Graphics.DrawString(studentName, valueFont, brush, x + 375, y + 35);
            y += 90;

            // Approved By, Paid By, Signature
            e.Graphics.DrawRectangle(blackPen, x, y, 166, cellHeight);
            e.Graphics.DrawString("Approved By:", labelFont, brush, x + 5, y + 5);
            e.Graphics.DrawRectangle(blackPen, x + 166, y, 166, cellHeight);
            e.Graphics.DrawString("Paid By:", labelFont, brush, x + 171, y + 5);
            e.Graphics.DrawRectangle(blackPen, x + 332, y, 168, cellHeight);
            e.Graphics.DrawString("Signature:", labelFont, brush, x + 337, y + 5);

            // Clean up
            titleFont.Dispose();
            labelFont.Dispose();
            valueFont.Dispose();
            blackPen.Dispose();


        }
    }
}
