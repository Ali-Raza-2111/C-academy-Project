namespace student_finances_system
{
    partial class studentinfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentinfo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdClasss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdConcessionP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdAmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.StudentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.btnAllRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdID,
            this.stdName,
            this.stdClasss,
            this.stdMonth,
            this.stdConcessionP,
            this.stdAmountPaid,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 357);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1187, 364);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // stdID
            // 
            this.stdID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdID.HeaderText = "StudentID ";
            this.stdID.MinimumWidth = 8;
            this.stdID.Name = "stdID";
            this.stdID.ReadOnly = true;
            // 
            // stdName
            // 
            this.stdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdName.HeaderText = "Student Name";
            this.stdName.MinimumWidth = 8;
            this.stdName.Name = "stdName";
            this.stdName.ReadOnly = true;
            // 
            // stdClasss
            // 
            this.stdClasss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdClasss.HeaderText = "class";
            this.stdClasss.MinimumWidth = 8;
            this.stdClasss.Name = "stdClasss";
            this.stdClasss.ReadOnly = true;
            // 
            // stdMonth
            // 
            this.stdMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdMonth.HeaderText = "Month";
            this.stdMonth.MinimumWidth = 8;
            this.stdMonth.Name = "stdMonth";
            this.stdMonth.ReadOnly = true;
            // 
            // stdConcessionP
            // 
            this.stdConcessionP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdConcessionP.HeaderText = "Concession Percentage";
            this.stdConcessionP.MinimumWidth = 8;
            this.stdConcessionP.Name = "stdConcessionP";
            this.stdConcessionP.ReadOnly = true;
            // 
            // stdAmountPaid
            // 
            this.stdAmountPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stdAmountPaid.HeaderText = "Amount Paid";
            this.stdAmountPaid.MinimumWidth = 8;
            this.stdAmountPaid.Name = "stdAmountPaid";
            this.stdAmountPaid.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 88;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.StudentID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Searchbtn);
            this.panel1.Controls.Add(this.btnAllRecord);
            this.panel1.Location = new System.Drawing.Point(12, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 107);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 59);
            this.button1.TabIndex = 14;
            this.button1.Text = "Print Voucher";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StudentID
            // 
            this.StudentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.StudentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.StudentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.StudentID.Location = new System.Drawing.Point(149, 47);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(271, 28);
            this.StudentID.TabIndex = 13;
            this.StudentID.TextChanged += new System.EventHandler(this.StudentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Student ID";
            // 
            // Searchbtn
            // 
            this.Searchbtn.BackColor = System.Drawing.Color.Black;
            this.Searchbtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbtn.ForeColor = System.Drawing.Color.White;
            this.Searchbtn.Location = new System.Drawing.Point(446, 39);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(119, 43);
            this.Searchbtn.TabIndex = 11;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = false;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // btnAllRecord
            // 
            this.btnAllRecord.BackColor = System.Drawing.Color.Black;
            this.btnAllRecord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllRecord.ForeColor = System.Drawing.Color.White;
            this.btnAllRecord.Location = new System.Drawing.Point(589, 28);
            this.btnAllRecord.Name = "btnAllRecord";
            this.btnAllRecord.Size = new System.Drawing.Size(201, 59);
            this.btnAllRecord.TabIndex = 10;
            this.btnAllRecord.Text = "All Record";
            this.btnAllRecord.UseVisualStyleBackColor = false;
            this.btnAllRecord.Click += new System.EventHandler(this.btnAllRecord_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(90, 40, 35, 20);
            this.label1.Size = new System.Drawing.Size(631, 99);
            this.label1.TabIndex = 7;
            this.label1.Text = "ALL STUDENT FEE RECORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::student_finances_system.Properties.Resources.logo__1_;
            this.pictureBox1.Location = new System.Drawing.Point(447, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // studentinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 752);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "studentinfo";
            this.Text = "studentinfo";
            this.Load += new System.EventHandler(this.studentinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox StudentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Searchbtn;
        private System.Windows.Forms.Button btnAllRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdClasss;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdConcessionP;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdAmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
    }
}