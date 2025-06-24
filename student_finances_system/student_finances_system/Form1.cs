using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_finances_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void loadform(object form)
        {
            if (this.displaypanel.Controls.Count > 0) 
            this.displaypanel.Controls.RemoveAt(0);
            Form f = form as Form;
                f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.displaypanel.Controls.Add(f);
            this.displaypanel.Tag = f;
            f.Show();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new loginform());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new payment());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnstudentinfo_Click(object sender, EventArgs e)
        {
            loadform(new studentinfo());
        }

        private void btninstallment_Click(object sender, EventArgs e)
        {
            loadform(new installmentdetail());
        }

        private void btnexist_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void displaypanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
