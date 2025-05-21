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
    public partial class DayEnd : Form
    {
        string connetionString = null;
        SqlConnection conn;
        decimal total = 0;
        decimal totalWithoutVoid = 0;

        public DayEnd()
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            conn = new SqlConnection(connetionString);
            LoadUser();
            DPFromdate.Value = DateTime.Today;
            datagvBillDetails.AutoGenerateColumns = false;
        }


        private void LoadUser()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[lotusTest].sp_getTktSystemUsers";
           
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
                comboBoxUser.DataSource = ds.Tables[0];
                comboBoxUser.ValueMember = "SUId";
                comboBoxUser.DisplayMember = "UserName";
               // comboBoxUser.SelectedItem = null;
               // comboBoxUser.SelectedText = "--select--";
                // comboBoxUser.Items.Add("0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

           
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void datagvBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            lblTotAmountWithVoid.Text = "0";
            lblTotalAmountWithoutVoid.Text = "0"; 

            BindGridviewDaySale();
            GetColumnTotal();
        }

       
        public void GetColumnTotal()
        {

            conn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("exec [Sp_GetTotalSummarySale] '" + DPFromdate.Value + "','" + comboBoxUser.SelectedValue + "' ", conn);


            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblTotAmountWithVoid.Text = rdr["TotBillAmountwithVOid"].ToString();
                lblTotalAmountWithoutVoid.Text = rdr["TotBillAmount"].ToString();
                lblTotNoOfTicketWithoutVOid.Text = rdr["TotalNoofTickets"].ToString();
                lblTotNoOfTicketWithVOid.Text = rdr["TOtalNoofTicketsWithVoid"].ToString();
                //UnitPrice = rdr["UnitPrice"].ToString();
            }


            //total = 0;
            //totalWithoutVoid = 0;
            //foreach (DataGridViewRow row in datagvBillDetails.Rows)
            //{
            //    // Check if the cell value is not null and is a valid integer
            //    if (row.Cells["TotBillAmount"].Value != null &&  decimal.TryParse(row.Cells["TotBillAmount"].Value.ToString(), out decimal value))
            //    {
            //        // Add the cell value to the total
            //        total += value;
            //    }

            //    if (row.Cells["TotBillAmount"].Value != null && row.Cells["VoidStatus"].Value != "1") 
            //    {

            //            string cellValueAsString = row.Cells["TotBillAmount"].Value.ToString(); 
            //        totalWithoutVoid += Convert.ToDecimal(cellValueAsString);

            //    }
            //}

            //lblTotAmountWithVoid.Text = total.ToString();
            //lblTotalAmountWithoutVoid.Text = totalWithoutVoid.ToString();


        }

        protected void BindGridviewDaySale()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;

            sql = "exec [VM].[lotusTest].sp_SearchUserBill '" + DPFromdate.Value + "','" + comboBoxUser.SelectedValue + "'";


            using (SqlConnection con = new SqlConnection(connetionString))
            {
                //[RMID],[OrderNo],[BPOID],[Ratio],
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagvBillDetails.DataSource = dt;
                        }
                    }
                }
            }


        }
    }
}
