
namespace TicketSystem
{
    partial class BillDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTelNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.datagvBillDetails = new System.Windows.Forms.DataGridView();
            this.LblBillNo = new System.Windows.Forms.Label();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.lblBillId = new System.Windows.Forms.Label();
            this.lblCashier = new System.Windows.Forms.Label();
            this.LblNoOfTickets = new System.Windows.Forms.Label();
            this.LblTotBillAmount = new System.Windows.Forms.Label();
            this.BillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TKTQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 171);
            this.tabControl1.TabIndex = 125;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblTotBillAmount);
            this.tabPage1.Controls.Add(this.LblNoOfTickets);
            this.tabPage1.Controls.Add(this.lblCashier);
            this.tabPage1.Controls.Add(this.lblBillId);
            this.tabPage1.Controls.Add(this.lblBillDate);
            this.tabPage1.Controls.Add(this.LblBillNo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblTelNo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1008, 142);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bill Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 114;
            this.label7.Text = "Net Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 89;
            this.label2.Text = "Bill Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "No Of Tickets";
            // 
            // lblTelNo
            // 
            this.lblTelNo.AutoSize = true;
            this.lblTelNo.Location = new System.Drawing.Point(501, 38);
            this.lblTelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelNo.Name = "lblTelNo";
            this.lblTelNo.Size = new System.Drawing.Size(56, 17);
            this.lblTelNo.TabIndex = 110;
            this.lblTelNo.Text = "Cashier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 105;
            this.label4.Text = "Bill No";
            // 
            // datagvBillDetails
            // 
            this.datagvBillDetails.AllowDrop = true;
            this.datagvBillDetails.AllowUserToAddRows = false;
            this.datagvBillDetails.AllowUserToDeleteRows = false;
            this.datagvBillDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.datagvBillDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagvBillDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagvBillDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagvBillDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.datagvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillId,
            this.ProjectName,
            this.TicketType,
            this.TKTQTY,
            this.Amount});
            this.datagvBillDetails.Location = new System.Drawing.Point(9, 184);
            this.datagvBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.datagvBillDetails.Name = "datagvBillDetails";
            this.datagvBillDetails.ReadOnly = true;
            this.datagvBillDetails.RowHeadersWidth = 51;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.datagvBillDetails.Size = new System.Drawing.Size(1006, 291);
            this.datagvBillDetails.StandardTab = true;
            this.datagvBillDetails.TabIndex = 126;
            // 
            // LblBillNo
            // 
            this.LblBillNo.AutoSize = true;
            this.LblBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBillNo.Location = new System.Drawing.Point(145, 51);
            this.LblBillNo.Name = "LblBillNo";
            this.LblBillNo.Size = new System.Drawing.Size(16, 20);
            this.LblBillNo.TabIndex = 115;
            this.LblBillNo.Text = "-";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(145, 95);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(16, 20);
            this.lblBillDate.TabIndex = 116;
            this.lblBillDate.Text = "-";
            // 
            // lblBillId
            // 
            this.lblBillId.AutoSize = true;
            this.lblBillId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillId.Location = new System.Drawing.Point(327, 4);
            this.lblBillId.Name = "lblBillId";
            this.lblBillId.Size = new System.Drawing.Size(16, 20);
            this.lblBillId.TabIndex = 117;
            this.lblBillId.Text = "-";
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.Location = new System.Drawing.Point(653, 35);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(16, 20);
            this.lblCashier.TabIndex = 118;
            this.lblCashier.Text = "-";
            // 
            // LblNoOfTickets
            // 
            this.LblNoOfTickets.AutoSize = true;
            this.LblNoOfTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoOfTickets.Location = new System.Drawing.Point(653, 71);
            this.LblNoOfTickets.Name = "LblNoOfTickets";
            this.LblNoOfTickets.Size = new System.Drawing.Size(16, 20);
            this.LblNoOfTickets.TabIndex = 119;
            this.LblNoOfTickets.Text = "-";
            // 
            // LblTotBillAmount
            // 
            this.LblTotBillAmount.AutoSize = true;
            this.LblTotBillAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotBillAmount.Location = new System.Drawing.Point(653, 102);
            this.LblTotBillAmount.Name = "LblTotBillAmount";
            this.LblTotBillAmount.Size = new System.Drawing.Size(16, 20);
            this.LblTotBillAmount.TabIndex = 120;
            this.LblTotBillAmount.Text = "-";
            // 
            // BillId
            // 
            this.BillId.DataPropertyName = "BillId";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillId.DefaultCellStyle = dataGridViewCellStyle11;
            this.BillId.HeaderText = "Bill ID";
            this.BillId.MinimumWidth = 6;
            this.BillId.Name = "BillId";
            this.BillId.ReadOnly = true;
            this.BillId.Width = 90;
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.ProjectName.DefaultCellStyle = dataGridViewCellStyle12;
            this.ProjectName.HeaderText = "Ticket Location";
            this.ProjectName.MinimumWidth = 6;
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Width = 200;
            // 
            // TicketType
            // 
            this.TicketType.DataPropertyName = "TicketType";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.TicketType.DefaultCellStyle = dataGridViewCellStyle13;
            this.TicketType.HeaderText = "Ticket Type";
            this.TicketType.MinimumWidth = 6;
            this.TicketType.Name = "TicketType";
            this.TicketType.ReadOnly = true;
            this.TicketType.Width = 120;
            // 
            // TKTQTY
            // 
            this.TKTQTY.DataPropertyName = "TKTQTY";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.TKTQTY.DefaultCellStyle = dataGridViewCellStyle14;
            this.TKTQTY.HeaderText = "Qty";
            this.TKTQTY.MinimumWidth = 6;
            this.TKTQTY.Name = "TKTQTY";
            this.TKTQTY.ReadOnly = true;
            this.TKTQTY.Width = 90;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle15;
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // BillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 488);
            this.Controls.Add(this.datagvBillDetails);
            this.Controls.Add(this.tabControl1);
            this.Name = "BillDetail";
            this.Text = "BillDetail";
            this.Load += new System.EventHandler(this.BillDetail_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTelNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblBillNo;
        private System.Windows.Forms.DataGridView datagvBillDetails;
        private System.Windows.Forms.Label lblBillId;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.Label LblTotBillAmount;
        private System.Windows.Forms.Label LblNoOfTickets;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TKTQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}