using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class FrmPassword : Form
    {
        string vFormType;
        string connetionString = null;
        SqlConnection conn;
        public FrmPassword(string FormType)
        {
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            //connetionString = "Data Source=72.9.145.118;Initial Catalog=VM;User ID=lotusTest;Password=iliyana1997vera+";
            InitializeComponent();
            vFormType = FormType;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            txtPasscode.Focus();
        }

        private void txtPasscode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) 
            {
            if(GetPasswordDetails(vFormType,txtPasscode.Text) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Dont Have Permission for this Task !");
                }
            
            }
        }

        public bool GetPasswordDetails(string Mode, string VoidPassword)
        {
            try
            {
                conn = new SqlConnection(connetionString);
                SqlCommand command = new SqlCommand("Exec sp_chkVoidPassword '"+VoidPassword+"'", conn);

                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
