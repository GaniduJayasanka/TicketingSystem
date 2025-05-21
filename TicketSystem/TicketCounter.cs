using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class TicketCounter : Form
    {
        string connetionString = null;
        private SqlConnection conn;

        public TicketCounter(string UserId, string UserName)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=User1;Password=iliyana1997vera++";
            //connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";

            conn = new SqlConnection(connetionString);
           
            LblLoggedUser.Text = UserName;            
            datagvBillDetails.AutoGenerateColumns = false;
            txtBarcodeNo.Focus();
        }

        private void TicketCounter_Load(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\TicketSystem\AlreadyScanned.wav");
            simpleSound.Play();
        }
        private void BtnEnter_Click(object sender, EventArgs e)
        {
            var number = txtBarcodeNo.Text;
            int length = number.Length;

            if (length == 10)
            {
                conn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand("exec [sp_GetBarcodeDetailsNInsert] '" + txtBarcodeNo.Text + "' ", conn);


                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblTicketLocation.Text = rdr["ProjectName"].ToString();
                    lblTicketNo.Text = rdr["TicketNo"].ToString();
                    lblTicketType.Text = rdr["TicketType"].ToString();
                    lblTicketActivity.Text = rdr["TActivity"].ToString();
                    //UnitPrice = rdr["UnitPrice"].ToString();
                }

                BindGridviewBillDetails();

                if (datagvBillDetails.Rows.Count > 1)
                {
                    this.BackColor = Color.Crimson;
                    lblMessage.Text = "Already Scanned";
                    playSimpleSound();
                }
                else
                {
                    this.BackColor = Color.Green;
                    lblMessage.Text = "Valid Entry";
                }

                txtBarcodeNo.Text = "";
                txtBarcodeNo.Focus();

            }

          
        }

        private void UpdateCheckedStatus(string ticketNo)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

                conn.Open();
                SqlCommand updateCmd = new SqlCommand("UPDATE [VM].[lotusTest].[BillDetail] SET CheckedStatus = '1' WHERE TicketNo = @TicketNo", conn);
                updateCmd.Parameters.AddWithValue("@TicketNo", ticketNo);
                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the checked status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form VisitorRegistration = new TicketMaster("-", "-");
            this.Hide();
            VisitorRegistration.Show();
        }

        private void txtBarcodeNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var number = txtBarcodeNo.Text;
                int length = number.Length;

                if (length == 10)
                {
                    conn = new SqlConnection(connetionString);
                    SqlCommand cmd = new SqlCommand("exec [sp_GetBarcodeDetailsNInsert] '" + txtBarcodeNo.Text + "' ", conn);


                    if (conn.State.ToString() == "Closed")
                    {
                        conn.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lblTicketLocation.Text = rdr["ProjectName"].ToString();
                        lblTicketNo.Text = rdr["TicketNo"].ToString();
                        lblTicketType.Text = rdr["TicketType"].ToString();
                        lblTicketActivity.Text = rdr["TActivity"].ToString();
                        //UnitPrice = rdr["UnitPrice"].ToString();
                    }

                    BindGridviewBillDetails();

                    if (datagvBillDetails.Rows.Count > 1)
                    {
                        this.BackColor = Color.Crimson;
                        lblMessage.Text = "Already Scanned";
                        playSimpleSound();
                    }
                    else
                    {
                        this.BackColor = Color.Green;
                        lblMessage.Text = "Valid Entry";
                    }

                    txtBarcodeNo.Text = "";
                    txtBarcodeNo.Focus();



                }

            }
        }


        protected void BindGridviewBillDetails()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;

            sql = "exec VM.[lotusTest].[SP_GetTicketUsageHistory] '" + txtBarcodeNo.Text + "'";


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
