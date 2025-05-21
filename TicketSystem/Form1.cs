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
using System.Net;

namespace TicketSystem
{
    public partial class Form1 : Form
    {
        string connetionString = null;
        SqlConnection conn;
        string userid = "";
        string UserName = "";
        public Form1()
        {
            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=User1;Password=iliyana1997vera++";
            InitializeComponent();
            txtPassword.PasswordChar = '*';

            string ipAddress = GetLocalIPAddress();
            lblIPAddress.Text = ipAddress;
        }

        private string GetLocalIPAddress()
        {
            // Get the host name
            string hostName = Dns.GetHostName();

            // Get the IP addresses associated with the host
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            // Find the first IPv4 address (skip IPv6)
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }

            // If no IPv4 address is found, return a message
            return "No IPv4 address found";
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtUsername.Text.Trim()) ? txtUsername.Text.Trim() : "") != "" && (!string.IsNullOrEmpty(txtPassword.Text.Trim()) ? txtPassword.Text.Trim() : "") != "")
            {
                if (CheckBarcodeUser(txtUsername.Text.Trim()))
                {
                    insertLogDetails(userid);
                  //  Form VisitorRegistration = new TicketCounter(UserName, userid);
                    Form VisitorRegistration = new TicketMaster(UserName, userid);
                    this.Hide();
                    VisitorRegistration.Show();
                  //  GenerateQualityCheckMain();

                    //TourGuide FormTourGuide = new TourGuide(UserName, userid);
                    //this.Hide();
                    //FormTourGuide.Show();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Incorrect login credentials !!";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please fill login details !!";
            }
        }

        public void insertLogDetails(string UserID)
        {
            String query = "exec VM.[lotusTest].INSERT_UserLogDetails '" + UserID + "','"+ lblIPAddress.Text+ "'" ;

            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlCommand command = new SqlCommand(query, conn);
            
            command.ExecuteNonQuery();
           // MessageBox.Show("Successfully Saved", "Alert");
            

            conn.Close();
        }
        private bool CheckBarcodeUser(string bcode)
        {
            bool exists = false;
            conn = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("SELECT [SUId],[UserName],[Password],[ActiveStatus],[CreateDate],[CreateUser]  FROM [VM].[dbo].[SystemUser] Where UserName='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "' ", conn);

            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if ((!string.IsNullOrEmpty(reader["SUId"].ToString()) ? reader["SUId"].ToString() : "0") != "0"
                        && (!string.IsNullOrEmpty(reader["UserName"].ToString()) ? reader["UserName"].ToString() : "") != ""
                       )
                    {
                        userid = reader["SUId"].ToString();
                        UserName = reader["UserName"].ToString();

                        if (userid != "" && UserName != "")
                        {
                            exists = true;
                        }
                    }
                }
            }
            else
            {
                exists = false;
            }

            conn.Close();
            reader.Close();

            return exists;
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((!string.IsNullOrEmpty(txtUsername.Text.Trim()) ? txtUsername.Text.Trim() : "") != "" && (!string.IsNullOrEmpty(txtPassword.Text.Trim()) ? txtPassword.Text.Trim() : "") != "")
                {
                    if (CheckBarcodeUser(txtUsername.Text.Trim()))
                    {
                        insertLogDetails(userid);
                        Form VisitorRegistration = new TicketMaster(UserName, userid);
                        //// Form VisitorRegistration = new TicketCounter(UserName, userid);
                        //this.Hide();
                        //VisitorRegistration.Show();
                        ////GenerateQualityCheckMain();
                        TourGuide FormTourGuide = new TourGuide(UserName, userid);
                        this.Hide();
                        FormTourGuide.Show();
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Incorrect login credentials !!";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please fill login details !!";
                }
            }


         }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
