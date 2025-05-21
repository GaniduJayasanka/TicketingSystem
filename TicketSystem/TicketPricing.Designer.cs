
namespace TicketSystem
{
    partial class TicketPricing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagvBillDetails = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDollarRate = new System.Windows.Forms.DataGridView();
            this.LKRValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDollarRate)).BeginInit();
            this.SuspendLayout();
            // 
            // datagvBillDetails
            // 
            this.datagvBillDetails.AllowDrop = true;
            this.datagvBillDetails.AllowUserToAddRows = false;
            this.datagvBillDetails.AllowUserToDeleteRows = false;
            this.datagvBillDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagvBillDetails.BackgroundColor = System.Drawing.Color.Lavender;
            this.datagvBillDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagvBillDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectName,
            this.TicketType,
            this.UnitPrice});
            this.datagvBillDetails.GridColor = System.Drawing.Color.Lavender;
            this.datagvBillDetails.Location = new System.Drawing.Point(9, 36);
            this.datagvBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.datagvBillDetails.Name = "datagvBillDetails";
            this.datagvBillDetails.ReadOnly = true;
            this.datagvBillDetails.RowHeadersVisible = false;
            this.datagvBillDetails.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.datagvBillDetails.Size = new System.Drawing.Size(513, 410);
            this.datagvBillDetails.StandardTab = true;
            this.datagvBillDetails.TabIndex = 95;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.dataGridViewDollarRate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(547, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(534, 588);
            this.groupBox2.TabIndex = 95;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dollar Exchange Rate Trends";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.datagvBillDetails);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(534, 589);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ticket Price Details";
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProjectName.HeaderText = "Project Name";
            this.ProjectName.MinimumWidth = 6;
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Width = 150;
            // 
            // TicketType
            // 
            this.TicketType.DataPropertyName = "TicketType";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketType.DefaultCellStyle = dataGridViewCellStyle4;
            this.TicketType.HeaderText = "Ticket Type";
            this.TicketType.MinimumWidth = 6;
            this.TicketType.Name = "TicketType";
            this.TicketType.ReadOnly = true;
            this.TicketType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TicketType.Width = 120;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 90;
            // 
            // dataGridViewDollarRate
            // 
            this.dataGridViewDollarRate.AllowDrop = true;
            this.dataGridViewDollarRate.AllowUserToAddRows = false;
            this.dataGridViewDollarRate.AllowUserToDeleteRows = false;
            this.dataGridViewDollarRate.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDollarRate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewDollarRate.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridViewDollarRate.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDollarRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDollarRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDollarRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LKRValue,
            this.UpdatedUser,
            this.UpdatedDate});
            this.dataGridViewDollarRate.GridColor = System.Drawing.Color.Lavender;
            this.dataGridViewDollarRate.Location = new System.Drawing.Point(11, 41);
            this.dataGridViewDollarRate.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDollarRate.Name = "dataGridViewDollarRate";
            this.dataGridViewDollarRate.ReadOnly = true;
            this.dataGridViewDollarRate.RowHeadersVisible = false;
            this.dataGridViewDollarRate.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDollarRate.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewDollarRate.Size = new System.Drawing.Size(507, 398);
            this.dataGridViewDollarRate.StandardTab = true;
            this.dataGridViewDollarRate.TabIndex = 96;
            // 
            // LKRValue
            // 
            this.LKRValue.DataPropertyName = "LKRValue";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LKRValue.DefaultCellStyle = dataGridViewCellStyle9;
            this.LKRValue.HeaderText = "LKR Value (Per $)";
            this.LKRValue.MinimumWidth = 6;
            this.LKRValue.Name = "LKRValue";
            this.LKRValue.ReadOnly = true;
            this.LKRValue.Width = 90;
            // 
            // UpdatedUser
            // 
            this.UpdatedUser.DataPropertyName = "UserName";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatedUser.DefaultCellStyle = dataGridViewCellStyle10;
            this.UpdatedUser.HeaderText = "Updated User";
            this.UpdatedUser.MinimumWidth = 6;
            this.UpdatedUser.Name = "UpdatedUser";
            this.UpdatedUser.ReadOnly = true;
            this.UpdatedUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UpdatedUser.Width = 120;
            // 
            // UpdatedDate
            // 
            this.UpdatedDate.DataPropertyName = "UpdatedDate";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle11.Format = "G";
            dataGridViewCellStyle11.NullValue = null;
            this.UpdatedDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.UpdatedDate.HeaderText = "Updated Date";
            this.UpdatedDate.MinimumWidth = 6;
            this.UpdatedDate.Name = "UpdatedDate";
            this.UpdatedDate.ReadOnly = true;
            this.UpdatedDate.Width = 120;
            // 
            // TicketPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 603);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "TicketPricing";
            this.Text = "Ticket Pricing";
            this.Load += new System.EventHandler(this.TicketPricing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDollarRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagvBillDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridView dataGridViewDollarRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LKRValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedDate;
    }
}