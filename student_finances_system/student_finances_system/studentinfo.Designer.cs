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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StudentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.btnAllRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdClasss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdConcessionP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdAmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(1, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1249, 345);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StudentID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Searchbtn);
            this.panel1.Controls.Add(this.btnAllRecord);
            this.panel1.Location = new System.Drawing.Point(12, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 107);
            this.panel1.TabIndex = 8;
            // 
            // StudentID
            // 
            this.StudentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.StudentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.StudentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.StudentID.Location = new System.Drawing.Point(261, 46);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(271, 28);
            this.StudentID.TabIndex = 13;
            this.StudentID.TextChanged += new System.EventHandler(this.StudentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Student ID";
            // 
            // Searchbtn
            // 
            this.Searchbtn.BackColor = System.Drawing.Color.Black;
            this.Searchbtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbtn.ForeColor = System.Drawing.Color.White;
            this.Searchbtn.Location = new System.Drawing.Point(583, 30);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(201, 59);
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
            this.btnAllRecord.Location = new System.Drawing.Point(810, 30);
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
            this.label1.Location = new System.Drawing.Point(283, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(90, 40, 35, 20);
            this.label1.Size = new System.Drawing.Size(631, 99);
            this.label1.TabIndex = 7;
            this.label1.Text = "ALL STUDENT FEE RECORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // studentinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 657);
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
    }
}