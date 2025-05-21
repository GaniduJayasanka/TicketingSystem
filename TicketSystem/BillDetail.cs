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
    public partial class BillDetail : Form
    {
        string connetionString = null;
        SqlConnection conn;
        int UserId = 0;
        public BillDetail(string BillId)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            conn = new SqlConnection(connetionString);
            datagvBillDetails.AutoGenerateColumns = false;
            lblBillId.Text = BillId;
            GetBillHederDetails(BillId);
            BindGridviewBillDetails();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void GetBillHederDetails(string BillId)
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            string query = "exec sp_GetBillHeaderDetails '" + BillId + "'";
            
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LblBillNo.Text = reader["BillNo"].ToString();
                    LblTotBillAmount.Text = reader["TotBillAmount"].ToString();
                    LblNoOfTickets.Text = reader["NoOfTickets"].ToString();
                    lblCashier.Text = reader["UserName"].ToString();
                    lblBillDate.Text = reader["BilldateNTime"].ToString();
                }
                reader.Close();
            }

            conn.Close();
        }

        protected void BindGridviewBillDetails()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;

            sql = "exec VM.[lotusTest].[Get_BillSummaryDetail] '" + lblBillId.Text + "'";


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

        private void BillDetail_Load(object sender, EventArgs e)
        {
            BindGridviewBillDetails();
        }
    }
}
