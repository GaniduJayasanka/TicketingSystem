
namespace TicketSystem
{
    partial class TicketCounter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblLoggedUser = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.txtBarcodeNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTicketActivity = new System.Windows.Forms.Label();
            this.lblTicketType = new System.Windows.Forms.Label();
            this.lblTicketLocation = new System.Windows.Forms.Label();
            this.lblTicketNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datagvBillDetails = new System.Windows.Forms.DataGridView();
            this.TicketNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.LblLoggedUser);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.BtnEnter);
            this.groupBox2.Controls.Add(this.txtBarcodeNo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(4, 875);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(2050, 91);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            // 
            // LblLoggedUser
            // 
            this.LblLoggedUser.AutoSize = true;
            this.LblLoggedUser.BackColor = System.Drawing.Color.Transparent;
            this.LblLoggedUser.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLoggedUser.ForeColor = System.Drawing.Color.Black;
            this.LblLoggedUser.Location = new System.Drawing.Point(171, 65);
            this.LblLoggedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLoggedUser.Name = "LblLoggedUser";
            this.LblLoggedUser.Size = new System.Drawing.Size(12, 17);
            this.LblLoggedUser.TabIndex = 90;
            this.LblLoggedUser.Text = "-";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(20, 64);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 17);
            this.label24.TabIndex = 89;
            this.label24.Text = "Logged User";
            // 
            // BtnEnter
            // 
            this.BtnEnter.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnEnter.Font = new System.Drawing.Font("Lucida Fax", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnter.Location = new System.Drawing.Point(544, 12);
            this.BtnEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(229, 39);
            this.BtnEnter.TabIndex = 88;
            this.BtnEnter.Text = "Enter";
            this.BtnEnter.UseVisualStyleBackColor = false;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // txtBarcodeNo
            // 
            this.txtBarcodeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeNo.Location = new System.Drawing.Point(172, 12);
            this.txtBarcodeNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcodeNo.Name = "txtBarcodeNo";
            this.txtBarcodeNo.Size = new System.Drawing.Size(349, 34);
            this.txtBarcodeNo.TabIndex = 53;
            this.txtBarcodeNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeNo_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(17, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 23);
            this.label13.TabIndex = 52;
            this.label13.Text = "Barcode No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(59, 545);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 23);
            this.label2.TabIndex = 51;
            this.label2.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1633, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "---";
            this.label9.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(48, 736);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(349, 34);
            this.textBox1.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(44, 709);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Barcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 52);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 17);
            this.label11.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1461, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "---";
            this.label12.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.Controls.Add(this.lblTicketActivity);
            this.groupBox4.Controls.Add(this.lblTicketType);
            this.groupBox4.Controls.Add(this.lblTicketLocation);
            this.groupBox4.Controls.Add(this.lblTicketNo);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 638);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1020, 231);
            this.groupBox4.TabIndex = 84;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ticket Info";
            // 
            // lblTicketActivity
            // 
            this.lblTicketActivity.AutoSize = true;
            this.lblTicketActivity.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketActivity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketActivity.ForeColor = System.Drawing.Color.Black;
            this.lblTicketActivity.Location = new System.Drawing.Point(233, 175);
            this.lblTicketActivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketActivity.Name = "lblTicketActivity";
            this.lblTicketActivity.Size = new System.Drawing.Size(17, 23);
            this.lblTicketActivity.TabIndex = 99;
            this.lblTicketActivity.Text = "-";
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketType.ForeColor = System.Drawing.Color.Black;
            this.lblTicketType.Location = new System.Drawing.Point(233, 131);
            this.lblTicketType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(17, 23);
            this.lblTicketType.TabIndex = 98;
            this.lblTicketType.Text = "-";
            // 
            // lblTicketLocation
            // 
            this.lblTicketLocation.AutoSize = true;
            this.lblTicketLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketLocation.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketLocation.ForeColor = System.Drawing.Color.Black;
            this.lblTicketLocation.Location = new System.Drawing.Point(233, 89);
            this.lblTicketLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketLocation.Name = "lblTicketLocation";
            this.lblTicketLocation.Size = new System.Drawing.Size(17, 23);
            this.lblTicketLocation.TabIndex = 97;
            this.lblTicketLocation.Text = "-";
            // 
            // lblTicketNo
            // 
            this.lblTicketNo.AutoSize = true;
            this.lblTicketNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketNo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketNo.ForeColor = System.Drawing.Color.Black;
            this.lblTicketNo.Location = new System.Drawing.Point(233, 49);
            this.lblTicketNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketNo.Name = "lblTicketNo";
            this.lblTicketNo.Size = new System.Drawing.Size(17, 23);
            this.lblTicketNo.TabIndex = 96;
            this.lblTicketNo.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 23);
            this.label5.TabIndex = 95;
            this.label5.Text = "Ticket Activity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 23);
            this.label4.TabIndex = 94;
            this.label4.Text = "Ticket Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 23);
            this.label3.TabIndex = 93;
            this.label3.Text = "Ticket Location :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 92;
            this.label1.Text = "Ticket No :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.datagvBillDetails);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(1033, 636);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1020, 231);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scan History";
            // 
            // datagvBillDetails
            // 
            this.datagvBillDetails.AllowDrop = true;
            this.datagvBillDetails.AllowUserToAddRows = false;
            this.datagvBillDetails.AllowUserToDeleteRows = false;
            this.datagvBillDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.datagvBillDetails.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.datagvBillDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagvBillDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagvBillDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.datagvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNo,
            this.LogDate});
            this.datagvBillDetails.GridColor = System.Drawing.Color.LightSteelBlue;
            this.datagvBillDetails.Location = new System.Drawing.Point(19, 39);
            this.datagvBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.datagvBillDetails.Name = "datagvBillDetails";
            this.datagvBillDetails.ReadOnly = true;
            this.datagvBillDetails.RowHeadersWidth = 51;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagvBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.datagvBillDetails.Size = new System.Drawing.Size(533, 159);
            this.datagvBillDetails.StandardTab = true;
            this.datagvBillDetails.TabIndex = 127;
            // 
            // TicketNo
            // 
            this.TicketNo.DataPropertyName = "TicketNo";
            this.TicketNo.HeaderText = "Ticket No";
            this.TicketNo.MinimumWidth = 6;
            this.TicketNo.Name = "TicketNo";
            this.TicketNo.ReadOnly = true;
            this.TicketNo.Width = 125;
            // 
            // LogDate
            // 
            this.LogDate.DataPropertyName = "LogDate";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle35.Format = "F";
            dataGridViewCellStyle35.NullValue = null;
            this.LogDate.DefaultCellStyle = dataGridViewCellStyle35;
            this.LogDate.HeaderText = "Log Date";
            this.LogDate.MinimumWidth = 6;
            this.LogDate.Name = "LogDate";
            this.LogDate.ReadOnly = true;
            this.LogDate.Width = 200;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Lucida Bright", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(900, 352);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(47, 68);
            this.lblMessage.TabIndex = 90;
            this.lblMessage.Text = "-";
            // 
            // TicketCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicketCounter";
            this.Text = "TicketCounter";
            this.Load += new System.EventHandler(this.TicketCounter_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagvBillDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblLoggedUser;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.TextBox txtBarcodeNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTicketActivity;
        private System.Windows.Forms.Label lblTicketType;
        private System.Windows.Forms.Label lblTicketLocation;
        private System.Windows.Forms.Label lblTicketNo;
        private System.Windows.Forms.DataGridView datagvBillDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDate;
        private System.Windows.Forms.Label lblMessage;
    }
}