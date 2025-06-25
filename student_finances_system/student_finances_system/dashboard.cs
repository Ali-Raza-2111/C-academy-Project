using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_finances_system
{
    
    public partial class loginform : Form
    {
        
        private void LoadAutoCompleteData()
        {
            AutoCompleteStringCollection idCollection = new AutoCompleteStringCollection();

            using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
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

            StudentID.AutoCompleteCustomSource = idCollection;
        }
        public loginform()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            string connectionString = DatabaseHelper.GetConnectionString();

            string studentID = StudentID.Text.Trim();
            string fullName = studentNameTextBox.Text.Trim();
            string monthName = Monthcmbx.SelectedItem?.ToString();
            decimal amount;
            decimal concessionPercent = 0;

            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(monthName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            
            if (!string.IsNullOrEmpty(ConcPercTxtbx.Text))
            {
                if (!decimal.TryParse(ConcPercTxtbx.Text, out concessionPercent))
                {
                    MessageBox.Show("Please enter a valid concession percent.");
                    return;
                }

                if (concessionPercent < 0 || concessionPercent > 100)
                {
                    MessageBox.Show("Concession percent must be between 0 and 100.");
                    return;
                }
            }

           
            decimal netAmount = amount - (amount * concessionPercent / 100);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert into FeeStructure
                    string insertFeeQuery = "INSERT INTO FeeStructure (Amount) VALUES (@Amount); SELECT SCOPE_IDENTITY();";
                    SqlCommand feeCmd = new SqlCommand(insertFeeQuery, conn, transaction);
                    feeCmd.Parameters.AddWithValue("@Amount", amount);
                    int feeID = Convert.ToInt32(feeCmd.ExecuteScalar());

                    // 2. Check if Student exists in StudentInfo
                    string checkStudentQuery = "SELECT COUNT(*) FROM StudentInfo WHERE StudentID = @StudentID";
                    SqlCommand checkStudentCmd = new SqlCommand(checkStudentQuery, conn, transaction);
                    checkStudentCmd.Parameters.AddWithValue("@StudentID", studentID);
                    int studentExists = (int)checkStudentCmd.ExecuteScalar();

                    if (studentExists == 0)
                    {
                        // Optionally add new StudentInfo if not exists
                        string insertStudentQuery = "INSERT INTO StudentInfo (StudentID, FullName, FatherName, Class) VALUES (@StudentID, @FullName, '', '')";
                        SqlCommand insertStudentCmd = new SqlCommand(insertStudentQuery, conn, transaction);
                        insertStudentCmd.Parameters.AddWithValue("@StudentID", studentID);
                        insertStudentCmd.Parameters.AddWithValue("@FullName", fullName);
                        insertStudentCmd.ExecuteNonQuery();
                    }

                    // 3. Insert into TransactionHistory
                    string insertTransactionQuery = @"
            INSERT INTO TransactionHistory (StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent)
            VALUES (@StudentID, @FeeID, @AmountPaid, @MonthName, @IsPaid, @ConcessionPercent)";

                    SqlCommand transactionCmd = new SqlCommand(insertTransactionQuery, conn, transaction);
                    transactionCmd.Parameters.AddWithValue("@StudentID", studentID);
                    transactionCmd.Parameters.AddWithValue("@FeeID", feeID);
                    transactionCmd.Parameters.AddWithValue("@AmountPaid", netAmount);
                    transactionCmd.Parameters.AddWithValue("@MonthName", monthName);
                    transactionCmd.Parameters.AddWithValue("@IsPaid", true);
                    transactionCmd.Parameters.AddWithValue("@ConcessionPercent", concessionPercent);

                    transactionCmd.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Transaction successfully saved with concession.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        List<string> allMonths = new List<string>
{
    "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
};
        private void LoadAvailableMonths(string studentID)
        {
            List<string> availableMonths = new List<string>(allMonths);

            string connectionString = DatabaseHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MonthName FROM TransactionHistory WHERE StudentID = @StudentID AND IsPaid = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string paidMonth = reader["MonthName"].ToString();
                    availableMonths.Remove(paidMonth); // Remove paid months
                }
                reader.Close();
            }

            Monthcmbx.Items.Clear();
            Monthcmbx.Items.AddRange(availableMonths.ToArray());
        }


        private void loginform_Load(object sender, EventArgs e)
        {
            
            LoadAutoCompleteData();
        }

        private void StudentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = "SELECT FullName FROM StudentInfo WHERE StudentID = @StudentID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID.Text.Trim());

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        studentNameTextBox.Text = result.ToString();
                        // Load months when student found
                        LoadAvailableMonths(StudentID.Text.Trim());
                    }
                    else
                    {
                        studentNameTextBox.Text = "Student not found";
                        Monthcmbx.Items.Clear(); // Clear if not found
                    }
                }

                // Prevent 'ding' sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void StudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConcPercTxtbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void conAmountTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(amountTextBox.Text, out decimal amount) &&
            decimal.TryParse(conAmountTxtbx.Text, out decimal concession) &&
            amount != 0)
            {
                decimal percentage = (concession / amount) * 100;
                ConcPercTxtbx.Text = percentage.ToString("0.00");
            }
            else
            {
                ConcPercTxtbx.Text = string.Empty;
            }
        }

        private void Monthcmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
