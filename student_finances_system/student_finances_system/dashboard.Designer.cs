namespace student_finances_system
{
    partial class loginform
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.studentNameTextBox = new System.Windows.Forms.TextBox();
            this.Monthcmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ConcPercTxtbx = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "StudentID";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(423, 516);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(347, 63);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Make Payment";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Month";
            // 
            // StudentID
            // 
            this.StudentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.StudentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.StudentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.StudentID.Location = new System.Drawing.Point(460, 295);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(333, 23);
            this.StudentID.TabIndex = 7;
            this.StudentID.TextChanged += new System.EventHandler(this.StudentID_TextChanged);
            this.StudentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentID_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sudent\'s Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Amount";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(460, 436);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(137, 23);
            this.amountTextBox.TabIndex = 13;
            // 
            // studentNameTextBox
            // 
            this.studentNameTextBox.Location = new System.Drawing.Point(460, 344);
            this.studentNameTextBox.Name = "studentNameTextBox";
            this.studentNameTextBox.Size = new System.Drawing.Size(333, 23);
            this.studentNameTextBox.TabIndex = 14;
            // 
            // Monthcmbx
            // 
            this.Monthcmbx.FormattingEnabled = true;
            this.Monthcmbx.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.Monthcmbx.Location = new System.Drawing.Point(460, 386);
            this.Monthcmbx.Name = "Monthcmbx";
            this.Monthcmbx.Size = new System.Drawing.Size(333, 24);
            this.Monthcmbx.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(469, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fee Collection";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 32);
            this.label6.TabIndex = 17;
            this.label6.Text = "Concession\r\nPercent";
            // 
            // ConcPercTxtbx
            // 
            this.ConcPercTxtbx.Location = new System.Drawing.Point(711, 440);
            this.ConcPercTxtbx.Name = "ConcPercTxtbx";
            this.ConcPercTxtbx.Size = new System.Drawing.Size(91, 23);
            this.ConcPercTxtbx.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::student_finances_system.Properties.Resources.iconstd_finance_removebg_preview__3_;
            this.pictureBox1.Location = new System.Drawing.Point(470, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 128);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // loginform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ConcPercTxtbx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Monthcmbx);
            this.Controls.Add(this.studentNameTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.StudentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginform";
            this.Text = "dashboard";
            this.Load += new System.EventHandler(this.loginform_Load);
            this.Resize += new System.EventHandler(this.loginform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StudentID;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox studentNameTextBox;
        private System.Windows.Forms.ComboBox Monthcmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ConcPercTxtbx;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}