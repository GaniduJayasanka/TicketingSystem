
namespace TicketSystem
{
    partial class BillVoid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DPTodate = new System.Windows.Forms.DateTimePicker();
            this.DPFromdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.lblBillID = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datagvBillDetails = new System.Windows.Forms.DataGridView();
            this.PlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyTargetQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Void = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnVoid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.DPTodate);
            this.groupBox1.Controls.Add(this.DPFromdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.lblBillID);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1276, 120);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Bill Details & Void Option";
            // 
            // DPTodate
            // 
            this.DPTodate.CustomFormat = "YYYY/MM/DD";
            this.DPTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPTodate.Location = new System.Drawing.Point(579, 47);
            this.DPTodate.Margin = new System.Windows.Forms.Padding(4);
            this.DPTodate.MaxDate = new System.DateTime(9990, 8, 31, 0, 0, 0, 0);
            this.DPTodate.MinDate = new System.DateTime(1950, 10, 1, 0, 0, 0, 0);
            this.DPTodate.Name = "DPTodate";
            this.DPTodate.Size = new System.Drawing.Size(224, 45);
            this.DPTodate.TabIndex = 28;
            this.DPTodate.Value = new System.DateTime(2021, 11, 7, 14, 34, 9, 0);
            // 
            // DPFromdate
            // 
            this.DPFromdate.CustomFormat = "YYYY/MM/DD";
            this.DPFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPFromdate.Location = new System.Drawing.Point(171, 42);
            this.DPFromdate.Margin = new System.Windows.Forms.Padding(4);
            this.DPFromdate.MaxDate = new System.DateTime(9990, 8, 31, 0, 0, 0, 0);
            this.DPFromdate.MinDate = new System.DateTime(1950, 10, 1, 0, 0, 0, 0);
            this.DPFromdate.Name = "DPFromdate";
            this.DPFromdate.Size = new System.Drawing.Size(240, 45);
            this.DPFromdate.TabIndex = 27;
            this.DPFromdate.Value = new System.DateTime(2021, 11, 7, 14, 34, 9, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "To Date";
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Gold;
            this.buttonReset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(1047, 32);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(160, 60);
            this.buttonReset.TabIndex = 22;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.Location = new System.Drawing.Point(879, 32);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(160, 60);
            this.buttonFind.TabIndex = 21;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // lblBillID
            // 
            this.lblBillID.AutoSize = true;
            this.lblBillID.Location = new System.Drawing.Point(263, 92);
            this.lblBillID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillID.Name = "lblBillID";
            this.lblBillID.Size = new System.Drawing.Size(15, 20);
            this.lblBillID.TabIndex = 15;
            this.lblBillID.Text = "-";
            this.lblBillID.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(735, 88);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(16, 20);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "From Date";
            // 
            // datagvBillDetails
            // 
            this.datagvBillDetails.AllowDrop = true;
            this.datagvBillDetails.AllowUserToAddRows = false;
            this.datagvBillDetails.AllowUserToDeleteRows = false;
            this.datagvBillDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagvBillDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagvBillDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagvBillDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagvBillDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlanDate,
            this.BillNo,
            this.Line,
            this.DailyTargetQty,
            this.UserName,
            this.CreateDate,
            this.BillTime,
            this.Void,
            this.BtnVoid});
            this.datagvBillDetails.Location = new System.Drawing.Point(7, 132);
            this.datagvBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.datagvBillDetails.Name = "datagvBillDetails";
            this.datagvBillDetails.ReadOnly = true;
            this.datagvBillDetails.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.datagvBillDetails.Size = new System.Drawing.Size(1273, 658);
            this.datagvBillDetails.StandardTab = true;
            this.datagvBillDetails.TabIndex = 93;
            this.datagvBillDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvBillDetails_CellClick);
            this.datagvBillDetails.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.datagvBillDetails_RowPrePaint_1);
            // 
            // PlanDate
            // 
            this.PlanDate.DataPropertyName = "BillId";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.PlanDate.HeaderText = "Bill ID";
            this.PlanDate.MinimumWidth = 6;
            this.PlanDate.Name = "PlanDate";
            this.PlanDate.ReadOnly = true;
            this.PlanDate.Width = 60;
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.BillNo.HeaderText = "Bill No";
            this.BillNo.MinimumWidth = 6;
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            this.BillNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BillNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BillNo.Width = 90;
            // 
            // Line
            // 
            this.Line.DataPropertyName = "TotBillAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Line.DefaultCellStyle = dataGridViewCellStyle5;
            this.Line.HeaderText = "Total Bill Amount";
            this.Line.MinimumWidth = 6;
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.Width = 90;
            // 
            // DailyTargetQty
            // 
            this.DailyTargetQty.DataPropertyName = "NoofTickets";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.DailyTargetQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.DailyTargetQty.HeaderText = "No Of Tickets";
            this.DailyTargetQty.MinimumWidth = 6;
            this.DailyTargetQty.Name = "DailyTargetQty";
            this.DailyTargetQty.ReadOnly = true;
            this.DailyTargetQty.Width = 80;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Cashier";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 60;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "BilldateNTime";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.CreateDate.HeaderText = "Bill Date";
            this.CreateDate.MinimumWidth = 6;
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 89;
            // 
            // BillTime
            // 
            this.BillTime.DataPropertyName = "Time";
            this.BillTime.HeaderText = "Bill TIme";
            this.BillTime.MinimumWidth = 6;
            this.BillTime.Name = "BillTime";
            this.BillTime.ReadOnly = true;
            this.BillTime.Width = 90;
            // 
            // Void
            // 
            this.Void.DataPropertyName = "VoidStatus";
            this.Void.HeaderText = "Void Status";
            this.Void.MinimumWidth = 6;
            this.Void.Name = "Void";
            this.Void.ReadOnly = true;
            this.Void.Width = 60;
            // 
            // BtnVoid
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.NullValue = "Void";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.IndianRed;
            this.BtnVoid.DefaultCellStyle = dataGridViewCellStyle8;
            this.BtnVoid.HeaderText = "Void";
            this.BtnVoid.MinimumWidth = 6;
            this.BtnVoid.Name = "BtnVoid";
            this.BtnVoid.ReadOnly = true;
            this.BtnVoid.Text = "Void";
            this.BtnVoid.Width = 125;
            // 
            // BillVoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 803);
            this.Controls.Add(this.datagvBillDetails);
            this.Controls.Add(this.groupBox1);
            this.Name = "BillVoid";
            this.Text = "Bill Details";
            this.Load += new System.EventHandler(this.BillVoid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label lblBillID;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DPTodate;
        private System.Windows.Forms.DateTimePicker DPFromdate;
        private System.Windows.Forms.DataGridView datagvBillDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDate;
        private System.Windows.Forms.DataGridViewLinkColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyTargetQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Void;
        private System.Windows.Forms.DataGridViewButtonColumn BtnVoid;
    }
}