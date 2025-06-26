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

                foreach (string month in months)
                {
                    string transactionQuery = "SELECT AmountPaid, IsPaid, ConcessionPercent FROM TransactionHistory " +
                                              "WHERE StudentID = @StudentID AND MonthName = @MonthName";
                    SqlCommand transactionCmd = new SqlCommand(transactionQuery, con);
                    transactionCmd.Parameters.AddWithValue("@StudentID", studentId);
                    transactionCmd.Parameters.AddWithValue("@MonthName", month);
                    SqlDataReader transactionReader = transactionCmd.ExecuteReader();

                    decimal amountPaid = 0;
                    decimal concessionPercent = 0;
                    string status = "Not Paid";

                    if (transactionReader.Read())
                    {
                        amountPaid = Convert.ToDecimal(transactionReader["AmountPaid"]);
                        concessionPercent = Convert.ToDecimal(transactionReader["ConcessionPercent"]);
                        status = (bool)transactionReader["IsPaid"] ? "Paid" : "Not Paid";
                    }
                    transactionReader.Close();

                    
                    dataGridView1.Rows.Add(
                        studentId,
                        studentName,
                        studentClass,
                        month,
                        concessionPercent,
                        amountPaid,
                        status
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
                        
                        string transactionQuery = "SELECT AmountPaid, IsPaid, ConcessionPercent FROM TransactionHistory " +
                                                  "WHERE StudentID = @StudentID AND MonthName = @MonthName";
                        SqlCommand transactionCmd = new SqlCommand(transactionQuery, con);
                        transactionCmd.Parameters.AddWithValue("@StudentID", studentId);
                        transactionCmd.Parameters.AddWithValue("@MonthName", month);
                        SqlDataReader transactionReader = transactionCmd.ExecuteReader();

                        decimal amountPaid = 0;
                        decimal concessionPercent = 0;
                        string status = "Not Paid";

                        if (transactionReader.Read())
                        {
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
                                status
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
    }
}
