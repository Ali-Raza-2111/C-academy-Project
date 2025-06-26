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
    public partial class installmentdetail : Form
    {
        public installmentdetail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void installmentdetail_Load(object sender, EventArgs e)
        {
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
        private void LoadUnpaidByClassAndMonth()
        {
            // 1. Read selections
            string selectedClass = classcombx.SelectedItem?.ToString();
            string selectedMonth = monthcombx.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedClass) || string.IsNullOrEmpty(selectedMonth))
            {
                MessageBox.Show(
                    "Please select both Class and Month.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. SQL: LEFT JOIN StudentInfo → TransactionHistory for that month,
            //    then show only where IsPaid = 0 OR no transaction exists
            string sql = @"
        SELECT
            s.StudentID,
            s.FullName        AS StudentName,
            s.Class           AS StudentClass,
            @Month            AS Month,
            'Not Paid'        AS Status
        FROM StudentInfo s
        LEFT JOIN TransactionHistory th
            ON s.StudentID = th.StudentID
           AND th.MonthName = @Month
        WHERE s.Class = @Class
          AND (th.IsPaid = 0 OR th.TransactionID IS NULL)
        ORDER BY s.FullName;
    ";

            // 3. Clear any existing rows
            dataGridView1.Rows.Clear();

            // 4. Execute and populate grid
            using (var con = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Class", selectedClass);
                cmd.Parameters.AddWithValue("@Month", selectedMonth);
                con.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(
                            dr.GetString(dr.GetOrdinal("StudentID")),
                            dr.GetString(dr.GetOrdinal("StudentName")),
                            dr.GetString(dr.GetOrdinal("StudentClass")),
                            dr.GetString(dr.GetOrdinal("Month")),
                            dr.GetString(dr.GetOrdinal("Status"))
                        );
                    }
                }
            }
        }
        private void monthTxtbx_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoadUnpaidByClassAndMonth();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "stdStatus" && e.Value != null)
            {
                string statusValue = e.Value.ToString();

                // Reuse the grid’s default cell font (Arial, 8pt, Bold)
                Font statusFont = dataGridView1.DefaultCellStyle.Font;

                if (statusValue == "Paid")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = statusFont;
                }
                else if (statusValue == "Not Paid")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = statusFont;
                }
            }
        }
    }
}
