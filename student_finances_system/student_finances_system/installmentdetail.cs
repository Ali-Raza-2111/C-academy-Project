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

            
            dataGridView1.DefaultCellStyle.Font = arialBold8;

            
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = arialBold8;

            
            dataGridView1.RowHeadersDefaultCellStyle.Font = arialBold8;

            
            Color headerBackColor = Color.DodgerBlue;

           
            dataGridView1.EnableHeadersVisualStyles = false;

           
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor; 

            
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void LoadUnpaidByClassAndMonth()
        {
           
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

           
            dataGridView1.Rows.Clear();

           
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
