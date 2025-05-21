
namespace TicketSystem
{
    partial class FrmPassword
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtPasscode = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Lucida Bright", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(24, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 27);
            this.label14.TabIndex = 90;
            this.label14.Text = "Confirm Code :";
            // 
            // txtPasscode
            // 
            this.txtPasscode.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasscode.Location = new System.Drawing.Point(235, 45);
            this.txtPasscode.Name = "txtPasscode";
            this.txtPasscode.PasswordChar = '*';
            this.txtPasscode.Size = new System.Drawing.Size(421, 45);
            this.txtPasscode.TabIndex = 91;
            this.txtPasscode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasscode_KeyDown);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::TicketSystem.Properties.Resources.Cancel;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Location = new System.Drawing.Point(577, 126);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 89);
            this.btnLogout.TabIndex = 92;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 248);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtPasscode);
            this.Controls.Add(this.label14);
            this.Name = "FrmPassword";
            this.Text = "FrmPassword";
            this.Load += new System.EventHandler(this.FrmPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPasscode;
        private System.Windows.Forms.Button btnLogout;
    }
}