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
    public partial class TourGuidePointDetail : Form
    {
        string connetionString = null;
        private SqlConnection conn;
        public TourGuidePointDetail(string TGID, string UserName, string UserID)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=User1;Password=iliyana1997vera++";
            LblLoggedUser.Text = UserName;
            lblTGId.Text = TGID;
            GETTourGuideDetails();
            BindGridviewPackingData();


        }

        protected void BindGridviewPackingData()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;
            sql = "exec sp_TourGuidePointBills '" + lblTGId.Text + "'";

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


        private void GETTourGuideDetails()
        {
           
            conn = new SqlConnection(connetionString);
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand command = new SqlCommand("exec [sp_SearchTourGuideDetails]'" + lblTGId.Text + "'", conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblTGComanyName.Text = reader["CompanyName"].ToString();
                lblTGId.Text = reader["TGHid"].ToString();
                lblTGName.Text = reader["GuideName"].ToString();
                lblTGNIC.Text = reader["NICNo"].ToString();
                lblTourGuideNo.Text = reader["TourGuideNo"].ToString();
            }
            conn.Close();
            reader.Close();


        }
        private void TourGuidePointDetail_Load(object sender, EventArgs e)
        {

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {

        }
    }
}
