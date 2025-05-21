
namespace TicketSystem
{
    partial class DayEnd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagvBillDetails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.DPFromdate = new System.Windows.Forms.DateTimePicker();
            this.User = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.lblBillID = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotAmountWithVoid = new System.Windows.Forms.Label();
            this.lblTotalAmountWithoutVoid = new System.Windows.Forms.Label();
            this.PlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TotBillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyTargetQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoidStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotNoOfTicketWithoutVOid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotNoOfTicketWithVOid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.TotBillAmount,
            this.DailyTargetQty,
            this.UserName,
            this.CreateDate,
            this.BillTime,
            this.VoidStatus});
            this.datagvBillDetails.Location = new System.Drawing.Point(5, 222);
            this.datagvBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.datagvBillDetails.Name = "datagvBillDetails";
            this.datagvBillDetails.ReadOnly = true;
            this.datagvBillDetails.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.datagvBillDetails.Size = new System.Drawing.Size(1079, 372);
            this.datagvBillDetails.StandardTab = true;
            this.datagvBillDetails.TabIndex = 95;
            this.datagvBillDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvBillDetails_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBoxUser);
            this.groupBox1.Controls.Add(this.DPFromdate);
            this.groupBox1.Controls.Add(this.User);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.lblBillID);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1079, 206);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search User Wise Sale";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(493, 46);
            this.comboBoxUser.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(176, 46);
            this.comboBoxUser.TabIndex = 28;
            // 
            // DPFromdate
            // 
            this.DPFromdate.CustomFormat = "YYYY/MM/DD";
            this.DPFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPFromdate.Location = new System.Drawing.Point(115, 47);
            this.DPFromdate.Margin = new System.Windows.Forms.Padding(4);
            this.DPFromdate.MaxDate = new System.DateTime(9990, 8, 31, 0, 0, 0, 0);
            this.DPFromdate.MinDate = new System.DateTime(1950, 10, 1, 0, 0, 0, 0);
            this.DPFromdate.Name = "DPFromdate";
            this.DPFromdate.Size = new System.Drawing.Size(224, 45);
            this.DPFromdate.TabIndex = 27;
            this.DPFromdate.Value = new System.DateTime(2021, 11, 7, 14, 34, 9, 0);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.Location = new System.Drawing.Point(411, 52);
            this.User.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(74, 32);
            this.User.TabIndex = 26;
            this.User.Text = "User";
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Gold;
            this.buttonReset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(920, 37);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(141, 55);
            this.buttonReset.TabIndex = 22;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.Location = new System.Drawing.Point(771, 37);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(141, 55);
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
            this.label5.Size = new System.Drawing.Size(75, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "Date";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.lblTotNoOfTicketWithVOid);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblTotNoOfTicketWithoutVOid);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotalAmountWithoutVoid);
            this.groupBox2.Controls.Add(this.lblTotAmountWithVoid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 112);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1063, 86);
            this.groupBox2.TabIndex = 95;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 96;
            this.label1.Text = "Total Amount (With Void) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 25);
            this.label2.TabIndex = 97;
            this.label2.Text = "Total Amount (Without Void) :";
            // 
            // lblTotAmountWithVoid
            // 
            this.lblTotAmountWithVoid.AutoSize = true;
            this.lblTotAmountWithVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAmountWithVoid.Location = new System.Drawing.Point(263, 16);
            this.lblTotAmountWithVoid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotAmountWithVoid.Name = "lblTotAmountWithVoid";
            this.lblTotAmountWithVoid.Size = new System.Drawing.Size(24, 32);
            this.lblTotAmountWithVoid.TabIndex = 96;
            this.lblTotAmountWithVoid.Text = "-";
            // 
            // lblTotalAmountWithoutVoid
            // 
            this.lblTotalAmountWithoutVoid.AutoSize = true;
            this.lblTotalAmountWithoutVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountWithoutVoid.Location = new System.Drawing.Point(293, 50);
            this.lblTotalAmountWithoutVoid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmountWithoutVoid.Name = "lblTotalAmountWithoutVoid";
            this.lblTotalAmountWithoutVoid.Size = new System.Drawing.Size(24, 32);
            this.lblTotalAmountWithoutVoid.TabIndex = 98;
            this.lblTotalAmountWithoutVoid.Text = "-";
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
            // TotBillAmount
            // 
            this.TotBillAmount.DataPropertyName = "TotBillAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.TotBillAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotBillAmount.HeaderText = "Total Bill Amount";
            this.TotBillAmount.MinimumWidth = 6;
            this.TotBillAmount.Name = "TotBillAmount";
            this.TotBillAmount.ReadOnly = true;
            this.TotBillAmount.Width = 90;
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
            // VoidStatus
            // 
            this.VoidStatus.DataPropertyName = "VoidStatus";
            this.VoidStatus.HeaderText = "Void Status";
            this.VoidStatus.MinimumWidth = 6;
            this.VoidStatus.Name = "VoidStatus";
            this.VoidStatus.ReadOnly = true;
            this.VoidStatus.Width = 60;
            // 
            // lblTotNoOfTicketWithoutVOid
            // 
            this.lblTotNoOfTicketWithoutVOid.AutoSize = true;
            this.lblTotNoOfTicketWithoutVOid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotNoOfTicketWithoutVOid.Location = new System.Drawing.Point(922, 49);
            this.lblTotNoOfTicketWithoutVOid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotNoOfTicketWithoutVOid.Name = "lblTotNoOfTicketWithoutVOid";
            this.lblTotNoOfTicketWithoutVOid.Size = new System.Drawing.Size(24, 32);
            this.lblTotNoOfTicketWithoutVOid.TabIndex = 100;
            this.lblTotNoOfTicketWithoutVOid.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(580, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 25);
            this.label4.TabIndex = 99;
            this.label4.Text = "Total No of Tickets (Without Void) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(580, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 25);
            this.label6.TabIndex = 101;
            this.label6.Text = "Total No of Tickets (With Void) :";
            // 
            // lblTotNoOfTicketWithVOid
            // 
            this.lblTotNoOfTicketWithVOid.AutoSize = true;
            this.lblTotNoOfTicketWithVOid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotNoOfTicketWithVOid.Location = new System.Drawing.Point(922, 9);
            this.lblTotNoOfTicketWithVOid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotNoOfTicketWithVOid.Name = "lblTotNoOfTicketWithVOid";
            this.lblTotNoOfTicketWithVOid.Size = new System.Drawing.Size(24, 32);
            this.lblTotNoOfTicketWithVOid.TabIndex = 102;
            this.lblTotNoOfTicketWithVOid.Text = "-";
            // 
            // DayEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 603);
            this.Controls.Add(this.datagvBillDetails);
            this.Controls.Add(this.groupBox1);
            this.Name = "DayEnd";
            this.Text = "DayEnd";
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagvBillDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DPFromdate;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label lblBillID;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalAmountWithoutVoid;
        private System.Windows.Forms.Label lblTotAmountWithVoid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDate;
        private System.Windows.Forms.DataGridViewLinkColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotBillAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyTargetQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoidStatus;
        private System.Windows.Forms.Label lblTotNoOfTicketWithoutVOid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotNoOfTicketWithVOid;
        private System.Windows.Forms.Label label6;
    }
}