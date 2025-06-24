namespace student_finances_system
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexist = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnstudentinfo = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btninstallment = new System.Windows.Forms.Button();
            this.displaypanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnexist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 33);
            this.panel1.TabIndex = 0;
            // 
            // btnexist
            // 
            this.btnexist.BackColor = System.Drawing.Color.Black;
            this.btnexist.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexist.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnexist.Location = new System.Drawing.Point(883, 0);
            this.btnexist.Name = "btnexist";
            this.btnexist.Size = new System.Drawing.Size(49, 33);
            this.btnexist.TabIndex = 6;
            this.btnexist.Text = "X";
            this.btnexist.UseVisualStyleBackColor = false;
            this.btnexist.Click += new System.EventHandler(this.btnexist_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Controls.Add(this.btnDashboard);
            this.mainPanel.Controls.Add(this.btnstudentinfo);
            this.mainPanel.Controls.Add(this.btnPayment);
            this.mainPanel.Controls.Add(this.btninstallment);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainPanel.Location = new System.Drawing.Point(0, 33);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(202, 524);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.BackColor = System.Drawing.Color.Black;
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(199, 74);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Fee Submission";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnstudentinfo
            // 
            this.btnstudentinfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstudentinfo.BackColor = System.Drawing.Color.Black;
            this.btnstudentinfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnstudentinfo.Location = new System.Drawing.Point(3, 83);
            this.btnstudentinfo.Name = "btnstudentinfo";
            this.btnstudentinfo.Size = new System.Drawing.Size(199, 86);
            this.btnstudentinfo.TabIndex = 3;
            this.btnstudentinfo.Text = "Student Infomation";
            this.btnstudentinfo.UseVisualStyleBackColor = false;
            this.btnstudentinfo.Click += new System.EventHandler(this.btnstudentinfo_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.BackColor = System.Drawing.Color.Black;
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPayment.Location = new System.Drawing.Point(3, 175);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(199, 78);
            this.btnPayment.TabIndex = 4;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.button3_Click);
            // 
            // btninstallment
            // 
            this.btninstallment.BackColor = System.Drawing.Color.Black;
            this.btninstallment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btninstallment.Location = new System.Drawing.Point(3, 259);
            this.btninstallment.Name = "btninstallment";
            this.btninstallment.Size = new System.Drawing.Size(199, 86);
            this.btninstallment.TabIndex = 5;
            this.btninstallment.Text = "Installment Detail";
            this.btninstallment.UseVisualStyleBackColor = false;
            this.btninstallment.Click += new System.EventHandler(this.btninstallment_Click);
            // 
            // displaypanel
            // 
            this.displaypanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displaypanel.Location = new System.Drawing.Point(202, 33);
            this.displaypanel.Name = "displaypanel";
            this.displaypanel.Size = new System.Drawing.Size(730, 524);
            this.displaypanel.TabIndex = 2;
            this.displaypanel.Paint += new System.Windows.Forms.PaintEventHandler(this.displaypanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 557);
            this.Controls.Add(this.displaypanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnstudentinfo;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btninstallment;
        private System.Windows.Forms.Panel displaypanel;
        private System.Windows.Forms.Button btnexist;
    }
}

