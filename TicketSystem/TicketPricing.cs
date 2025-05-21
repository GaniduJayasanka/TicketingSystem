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
    public partial class TicketPricing : Form
    {
        string connetionString = null;
        SqlConnection conn;
        public TicketPricing()
        {
            InitializeComponent();
            datagvBillDetails.AutoGenerateColumns = false;
            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            conn = new SqlConnection(connetionString);

            dataGridViewDollarRate.AutoGenerateColumns = false;
            datagvBillDetails.AutoGenerateColumns = false;
            BindGridviewTicketPricingDetails();
            BindGridviewDollarExchangeRateDetails();
           
        }

       

        protected void BindGridviewTicketPricingDetails()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;
            sql = "exec VM.[lotusTest].[sp_GetTicketPrices]";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
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

        protected void BindGridviewDollarExchangeRateDetails()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;
            sql = "exec VM.[lotusTest].[sp_GetDollarExRateTrends]";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridViewDollarRate.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void TicketPricing_Load(object sender, EventArgs e)
        {
            dataGridViewDollarRate.AutoGenerateColumns = false;
            datagvBillDetails.AutoGenerateColumns = false;
        }
    }
}
