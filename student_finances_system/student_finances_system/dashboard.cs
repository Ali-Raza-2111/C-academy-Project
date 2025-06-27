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
        
       
        public loginform()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // 1. Read & validate inputs
            string connectionString = DatabaseHelper.GetConnectionString();
            string studentID = StudentID.Text.Trim();
            string fullName = studentNameTextBox.Text.Trim();
            string monthName = Monthcmbx.SelectedItem?.ToString();
            decimal amount;
            decimal concessionPercent = 0m;

            if (string.IsNullOrEmpty(studentID)
                || string.IsNullOrEmpty(fullName)
                || string.IsNullOrEmpty(monthName))
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

            decimal netAmount = amount - (amount * concessionPercent / 100m);

            // 2. Capture the payment date (just date portion)
            DateTime paymentDate = DateTime.Now.Date;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // (a) Insert into FeeStructure & get FeeID
                        const string insertFeeSql = @"
                    INSERT INTO FeeStructure (Amount)
                    VALUES (@Amount);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int feeID;
                        using (var feeCmd = new SqlCommand(insertFeeSql, conn, tx))
                        {
                            feeCmd.Parameters.AddWithValue("@Amount", amount);
                            feeID = (int)feeCmd.ExecuteScalar();  // :contentReference[oaicite:0]{index=0}
                        }

                        // (b) Ensure the student exists
                        const string checkStudentSql = @"
                    SELECT COUNT(*) FROM StudentInfo WHERE StudentID = @StudentID;";

                        int exists;
                        using (var chkCmd = new SqlCommand(checkStudentSql, conn, tx))
                        {
                            chkCmd.Parameters.AddWithValue("@StudentID", studentID);
                            exists = (int)chkCmd.ExecuteScalar();
                        }

                        if (exists == 0)
                        {
                            const string insertStudentSql = @"
                        INSERT INTO StudentInfo (StudentID, FullName, FatherName, Class)
                        VALUES (@StudentID, @FullName, '', '');";

                            using (var insStdCmd = new SqlCommand(insertStudentSql, conn, tx))
                            {
                                insStdCmd.Parameters.AddWithValue("@StudentID", studentID);
                                insStdCmd.Parameters.AddWithValue("@FullName", fullName);
                                insStdCmd.ExecuteNonQuery();
                            }
                        }

                        // (c) Insert into TransactionHistory with PaymentDate
                        const string insertTransSql = @"
                    INSERT INTO TransactionHistory
                        (StudentID, FeeID, AmountPaid, MonthName, IsPaid, ConcessionPercent, PaymentDate)
                    VALUES
                        (@StudentID, @FeeID, @AmountPaid, @MonthName, @IsPaid, @ConcessionPercent, @PaymentDate);";

                        using (var transCmd = new SqlCommand(insertTransSql, conn, tx))
                        {
                            transCmd.Parameters.AddWithValue("@StudentID", studentID);
                            transCmd.Parameters.AddWithValue("@FeeID", feeID);
                            transCmd.Parameters.AddWithValue("@AmountPaid", netAmount);
                            transCmd.Parameters.AddWithValue("@MonthName", monthName);
                            transCmd.Parameters.AddWithValue("@IsPaid", true);
                            transCmd.Parameters.AddWithValue("@ConcessionPercent", concessionPercent);
                            transCmd.Parameters.AddWithValue("@PaymentDate", paymentDate);

                            transCmd.ExecuteNonQuery();
                        }

                        // Commit all three operations as one atomic unit
                        tx.Commit();
                        MessageBox.Show("Payment recorded successfully.");
                        StudentID.Text = "";
                        studentNameTextBox.Text = "";
                        amountTextBox.Text = "";
                        Monthcmbx.Text = "";
                        conAmountTxtbx.Text = "";
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving transaction: " + ex.Message);
                    }
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

            StudentID.AutoCompleteCustomSource=DatabaseHelper.GetStudentIdAutoCompleteCollection();
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
