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
    public partial class Subject_wise_Teacher_Salary : Form
    {
        private DataTable CreateFeeDistributionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID", typeof(string));
            dt.Columns.Add("Academy Share (40%)", typeof(decimal));
            dt.Columns.Add("Teachers Share (60%)", typeof(decimal));
            dt.Columns.Add("Biology", typeof(decimal));
            dt.Columns.Add("Comp", typeof(decimal));
            dt.Columns.Add("Math", typeof(decimal));
            dt.Columns.Add("Chemistry", typeof(decimal));
            dt.Columns.Add("Physics", typeof(decimal));
            dt.Columns.Add("English", typeof(decimal));
            dt.Columns.Add("Urdu", typeof(decimal));
            dt.Columns.Add("IS/PS", typeof(decimal));
            dt.Columns.Add("T.Q", typeof(decimal));
            return dt;
        }
        public Subject_wise_Teacher_Salary()
        {
            InitializeComponent();
        }

        private void Subject_wise_Teacher_Salary_Load(object sender, EventArgs e)
        {
            button1.Font = button2.Font;
        }

        private void CalculateSubjectDistribution(
     string studentClass, string studentGroup, decimal teacherShare,
     ref decimal bio, ref decimal comp, ref decimal math, ref decimal chem,
     ref decimal physics, ref decimal english, ref decimal urdu, ref decimal isps, ref decimal tq)
        {
            int subjectCount = 0;
            List<string> subjects = new List<string>();

            // Determine subjects based on class and group
            if (studentClass == "9th" || studentClass == "10th")
            {
                if (studentGroup == "Bio")
                {
                    subjects = new List<string> { "Biology", "Math", "Chemistry", "Physics", "English", "Urdu", "Combined" };
                }
                else if (studentGroup == "Comp")
                {
                    subjects = new List<string> { "Comp", "Math", "Chemistry", "Physics", "English", "Urdu", "Combined" };
                }
            }
            else if (studentClass == "11th" || studentClass == "12th")
            {
                switch (studentGroup)
                {
                    case "Medical":
                        subjects = new List<string> { "Biology", "Chemistry", "Physics", "English", "Urdu", "Combined" };
                        break;
                    case "Non-Medical":
                        subjects = new List<string> { "Math", "Chemistry", "Physics", "English", "Urdu", "Combined" };
                        break;
                    case "ICS":
                        subjects = new List<string> { "Comp", "Math", "Physics", "English", "Urdu", "Combined" };
                        break;
                }
            }

            subjectCount = subjects.Count;
            if (subjectCount == 0) return;

            decimal perSubjectAmount = teacherShare / subjectCount;

            foreach (string subject in subjects)
            {
                switch (subject)
                {
                    case "Biology": bio += perSubjectAmount; break;
                    case "Comp": comp += perSubjectAmount; break;
                    case "Math": math += perSubjectAmount; break;
                    case "Chemistry": chem += perSubjectAmount; break;
                    case "Physics": physics += perSubjectAmount; break;
                    case "English": english += perSubjectAmount; break;
                    case "Urdu": urdu += perSubjectAmount; break;
                    case "Combined":
                        isps += perSubjectAmount / 2;
                        tq += perSubjectAmount / 2;
                        break;
                }
            }
        }

        private void ShowSubjectTotals()
        {
            if (Monthcmbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a month first.");
                return;
            }

            string selectedMonth = Monthcmbx.SelectedItem.ToString();
            string connectionString = DatabaseHelper.GetConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT AcademyShareTotal, TeacherShareTotal, BiologyTotal, CompTotal, MathTotal, 
                       ChemistryTotal, PhysicsTotal, EnglishTotal, UrduTotal, IS_PSTotal, TQTotal
                FROM MonthlyFeeSummary
                WHERE MonthName = @MonthName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MonthName", selectedMonth);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string message = $"📊 Fee Summary for {selectedMonth}\n\n" +
                                         $"Academy Share: {Convert.ToDecimal(reader["AcademyShareTotal"]):N2}\n" +
                                         $"Teachers' Share: {Convert.ToDecimal(reader["TeacherShareTotal"]):N2}\n\n" +
                                         $"Biology: {Convert.ToDecimal(reader["BiologyTotal"]):N2}\n" +
                                         $"Comp: {Convert.ToDecimal(reader["CompTotal"]):N2}\n" +
                                         $"Math: {Convert.ToDecimal(reader["MathTotal"]):N2}\n" +
                                         $"Chemistry: {Convert.ToDecimal(reader["ChemistryTotal"]):N2}\n" +
                                         $"Physics: {Convert.ToDecimal(reader["PhysicsTotal"]):N2}\n" +
                                         $"English: {Convert.ToDecimal(reader["EnglishTotal"]):N2}\n" +
                                         $"Urdu: {Convert.ToDecimal(reader["UrduTotal"]):N2}\n" +
                                         $"IS/PS: {Convert.ToDecimal(reader["IS_PSTotal"]):N2}\n" +
                                         $"T.Q: {Convert.ToDecimal(reader["TQTotal"]):N2}";

                        MessageBox.Show(message, "Monthly Subject Fee Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"No summary found for {selectedMonth}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormatDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["Academy Share (40%)"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Teachers Share (60%)"].DefaultCellStyle.Format = "N2";

            // Format all subject columns (Biology onwards)
            for (int i = 3; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = "N2";
            }

            dataGridView1.Columns[0].Frozen = true; // Freeze StudentID column
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (Monthcmbx.SelectedItem == null)
            {
                MessageBox.Show("Please select a month first");
                return;
            }

            string selectedMonth = Monthcmbx.SelectedItem.ToString();

            try
            {
                DataTable dt = CreateFeeDistributionTable();
                string connectionString = DatabaseHelper.GetConnectionString();

                // Initialize totals
                decimal academyTotal = 0;
                decimal teacherTotal = 0;
                decimal bioTotal = 0, compTotal = 0, mathTotal = 0, chemTotal = 0,
                        physicsTotal = 0, englishTotal = 0, urduTotal = 0, ispsTotal = 0, tqTotal = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Load student transactions
                    string query = @"
            SELECT t.StudentID, t.AmountPaid, s.Class, s.StudentGroup 
            FROM TransactionHistory t
            INNER JOIN StudentInfo s ON t.StudentID = s.StudentID
            WHERE t.MonthName = @MonthName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MonthName", selectedMonth);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string studentID = reader["StudentID"].ToString();
                        decimal amountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                        string studentClass = reader["Class"].ToString();
                        string studentGroup = reader["StudentGroup"].ToString();

                        decimal academyShare = 0.4m * amountPaid;
                        decimal teacherShare = 0.6m * amountPaid;

                        decimal bio = 0, comp = 0, math = 0, chem = 0,
                                physics = 0, english = 0, urdu = 0, isps = 0, tq = 0;

                        CalculateSubjectDistribution(
                            studentClass, studentGroup, teacherShare,
                            ref bio, ref comp, ref math, ref chem,
                            ref physics, ref english, ref urdu, ref isps, ref tq
                        );

                        // Accumulate totals
                        academyTotal += academyShare;
                        teacherTotal += teacherShare;
                        bioTotal += bio;
                        compTotal += comp;
                        mathTotal += math;
                        chemTotal += chem;
                        physicsTotal += physics;
                        englishTotal += english;
                        urduTotal += urdu;
                        ispsTotal += isps;
                        tqTotal += tq;

                        dt.Rows.Add(
                            studentID, academyShare, teacherShare,
                            bio, comp, math, chem, physics, english, urdu, isps, tq
                        );
                    }
                    reader.Close();

                    // Save summary to database
                    string summaryQuery = @"
            MERGE INTO MonthlyFeeSummary AS target
            USING (VALUES (@MonthName)) AS source (MonthName)
            ON target.MonthName = source.MonthName
            WHEN MATCHED THEN
                UPDATE SET 
                    AcademyShareTotal = @AcademyShareTotal,
                    TeacherShareTotal = @TeacherShareTotal,
                    BiologyTotal = @BiologyTotal,
                    CompTotal = @CompTotal,
                    MathTotal = @MathTotal,
                    ChemistryTotal = @ChemistryTotal,
                    PhysicsTotal = @PhysicsTotal,
                    EnglishTotal = @EnglishTotal,
                    UrduTotal = @UrduTotal,
                    IS_PSTotal = @IS_PSTotal,
                    TQTotal = @TQTotal
            WHEN NOT MATCHED THEN
                INSERT (MonthName, AcademyShareTotal, TeacherShareTotal, 
                        BiologyTotal, CompTotal, MathTotal, ChemistryTotal, 
                        PhysicsTotal, EnglishTotal, UrduTotal, IS_PSTotal, TQTotal)
                VALUES (@MonthName, @AcademyShareTotal, @TeacherShareTotal, 
                        @BiologyTotal, @CompTotal, @MathTotal, @ChemistryTotal, 
                        @PhysicsTotal, @EnglishTotal, @UrduTotal, @IS_PSTotal, @TQTotal);";

                    SqlCommand summaryCmd = new SqlCommand(summaryQuery, conn);
                    summaryCmd.Parameters.AddWithValue("@MonthName", selectedMonth);
                    summaryCmd.Parameters.AddWithValue("@AcademyShareTotal", academyTotal);
                    summaryCmd.Parameters.AddWithValue("@TeacherShareTotal", teacherTotal);
                    summaryCmd.Parameters.AddWithValue("@BiologyTotal", bioTotal);
                    summaryCmd.Parameters.AddWithValue("@CompTotal", compTotal);
                    summaryCmd.Parameters.AddWithValue("@MathTotal", mathTotal);
                    summaryCmd.Parameters.AddWithValue("@ChemistryTotal", chemTotal);
                    summaryCmd.Parameters.AddWithValue("@PhysicsTotal", physicsTotal);
                    summaryCmd.Parameters.AddWithValue("@EnglishTotal", englishTotal);
                    summaryCmd.Parameters.AddWithValue("@UrduTotal", urduTotal);
                    summaryCmd.Parameters.AddWithValue("@IS_PSTotal", ispsTotal);
                    summaryCmd.Parameters.AddWithValue("@TQTotal", tqTotal);

                    summaryCmd.ExecuteNonQuery();
                }

                dataGridView1.DataSource = dt;
                FormatDataGridView();

                MessageBox.Show($"Summary saved for {selectedMonth}!\n" +
                                $"Academy Total: {academyTotal:N2}\n" +
                                $"Teachers Total: {teacherTotal:N2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSubjectTotals();
        }
    }
}
