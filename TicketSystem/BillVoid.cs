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

    public partial class BillVoid : Form
    {
        string connetionString = null;
        SqlConnection conn;
        int UserId = 0;
        public BillVoid(string UserName, string UserID)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            conn = new SqlConnection(connetionString);
            datagvBillDetails.AutoGenerateColumns = false;
           
            
        }

     
        private void BillVoid_Load(object sender, EventArgs e)
        {
            DPFromdate.Value = DateTime.Today;
            DPTodate.Value = DateTime.Today;
            lblMsg.Visible = false;
        }

        protected void BindGridviewPackingData()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;           

                sql = "exec [VM].[lotusTest].sp_SearchBill '"+ DPFromdate.Value+ "','" + DPTodate.Value + "'";
           
           
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

        private void buttonFind_Click(object sender, EventArgs e)
        {
            BindGridviewPackingData();
           
           // datagvBillDetails.RowPrePaint += datagvBillDetails_RowPrePaint;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DPFromdate.Value = DateTime.Today;
            DPTodate.Value = DateTime.Today;
        }

        private void datagvBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagvBillDetails.Columns[e.ColumnIndex].Name == "BtnVoid")
            {
                FrmPassword frmPst = new FrmPassword("VOID");
                if(frmPst.ShowDialog() ==DialogResult.OK)
                {

                    string BillID = datagvBillDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                    lblBillID.Text = BillID.ToString();

                    string BillNo = datagvBillDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                    

                    if (conn.State.ToString() == "Closed")
                    {
                        conn.Open();
                    }
                    string insertDetailQuery = "EXEC sp_UpdateBillHeader @BillID";
                    using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BillID", lblBillID.Text);
                        

                        cmd.ExecuteNonQuery();
                    }

                    BindGridviewPackingData();
                    
                    lblMsg.Visible = true;
                    lblMsg.Text = BillNo+ " Successfully Canceled ";
                }

            }

            if (datagvBillDetails.Columns[e.ColumnIndex].Name == "BillNo")
            {
                string BillID = datagvBillDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblBillID.Text = BillID.ToString();

                BillDetail frmBillDetail= new BillDetail(BillID);
                frmBillDetail.Show();
                
            }

                }

       // private void ChangeRowColorBasedOnCondition()
        //{
            //foreach (DataGridViewRow row in datagvBillDetails.Rows)
            //{
            //    //string one = row.Cells[2].Value.ToString();
            //    //string three = row.Cells[3].Value.ToString();
            //    //string six = row.Cells[6].Value.ToString();

            //    // You can replace it with the index of the column you want to check
            //    if (row.Cells[7].Value != null)
            //    {
            //        // Replace "condition" with your actual condition
            //        if (row.Cells[8].Value == "1")
            //        {
            //            // Change the row color to your desired color
            //            row.DefaultCellStyle.BackColor = Color.Red; // For example, change to Red
            //        }
            //        else
            //        {
            //            // Change the row color back to the default color
            //            row.DefaultCellStyle.BackColor = datagvBillDetails.DefaultCellStyle.BackColor;
            //        }
            //    }
            //}
        //}

        private void datagvBillDetails_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assuming column index 2 (third column) contains the value to check
            // You can replace it with the index of the column you want to check
            if (datagvBillDetails.Rows[e.RowIndex].Cells[7].Value != null)
            {
                if (datagvBillDetails.Rows[e.RowIndex].Cells[7].Value.ToString() == "1")
                {
                    datagvBillDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed; // For example, change to Red
                }
            }
        }
    }
}
