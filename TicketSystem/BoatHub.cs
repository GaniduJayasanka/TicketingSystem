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
    public partial class BoatHub : Form
    {
        string connetionString = null;
        SqlConnection conn;
        public BoatHub()
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            conn = new SqlConnection(connetionString);
            LoadBoats();
            LoadMenus();
        }

        private void LoadBoats()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[dbo].sp_GetBoatDetails";

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                command = new SqlCommand(sql, conn); adapter.SelectCommand = command;
                adapter.Fill(ds); adapter.Dispose();
                command.Dispose();
                conn.Close();
                comboBoxBoat.DataSource = ds.Tables[0];
                comboBoxBoat.ValueMember = "BMid";
                comboBoxBoat.DisplayMember = "BoatName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
        }

        private void LoadMenus()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[dbo].sp_GetMenuMasterDetails";

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                command = new SqlCommand(sql, conn); adapter.SelectCommand = command;
                adapter.Fill(ds); adapter.Dispose();
                command.Dispose();
                conn.Close();
               comboBoxMenu.DataSource = ds.Tables[0];
                comboBoxMenu.ValueMember = "MMid";
                comboBoxMenu.DisplayMember = "MenuName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
        }
        private void comboBoxBoat_SelectedValueChanged(object sender, EventArgs e)
        {
            //GetNoOfPax();
        }

        public void GetNoOfPax()
        {
            SqlCommand cmd = null;
            var value = comboBoxBoat.SelectedValue;

            if (comboBoxBoat.SelectedValue == null)
            {
                 cmd = new SqlCommand("exec VM.[dbo].[sp_GetBoatNoOfPax] '1' ", conn);
            }
            if (comboBoxBoat.SelectedValue != null)
            {
                cmd = new SqlCommand("exec VM.[dbo].[sp_GetBoatNoOfPax] '" + Convert.ToInt32(comboBoxBoat.SelectedValue) + "' ", conn);
            }

            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblNoofSeating.Text = rdr["NoofSeating"].ToString();
            }
            rdr.Close();


        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            GetNoOfPax();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
