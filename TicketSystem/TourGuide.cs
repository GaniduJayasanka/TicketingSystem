using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class TourGuide : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        string connetionString = null;
        private SqlConnection conn;
        int headerId;
        string userID;
        public TourGuide(string UserName, string UserID)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=User1;Password=iliyana1997vera++";
            BindGridviewPackingData();
            LblLoggedUser.Text = UserName;
            userID = UserID;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            isValid &= ValidateTextBox(txtGuideName, "Guide Number is required.");
           // isValid &= ValidateTextBox(txtCompany, "Company Name is required.");
            isValid &= ValidateTextBox(txtAddress, "Address is required.");
            isValid &= ValidateNIC(txtNICNo);
            isValid &= ValidateContact(txtContactNo1);

            //if (!string.IsNullOrWhiteSpace(txtContactNo2.Text))
            //{
            //    isValid &= ValidateContact(txtContactNo2);
            //}

            isValid &= ValidateTextBox(txtAccountHolderName, "Account Holder Name is required.");
            isValid &= ValidateTextBox(txtAccountNo, "Account Name is required.");
            isValid &= ValidateTextBox(txtBankName, "Bank Name is required.");
            isValid &= ValidateTextBox(txtBranchNo, "Branch Name is required.");

            if (isValid)
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();

                    // Insert bill header and retrieve the headerId
                    string insertHeaderQuery = "EXEC sp_InsertTourGuideHeader @NICNo, @GuideName, @CompanyName, @GAddress, @ContactNo1, @ContactNo2,@BAccountHolderName,@AccountNo,@BankName,@BranchName, @CreateUser ; SELECT SCOPE_IDENTITY()";


                    using (SqlCommand cmd = new SqlCommand(insertHeaderQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@NICNo", txtNICNo.Text);
                        cmd.Parameters.AddWithValue("@GuideName", txtGuideName.Text);
                        cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text);
                        cmd.Parameters.AddWithValue("@GAddress", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@ContactNo1", txtContactNo1.Text);
                        cmd.Parameters.AddWithValue("@ContactNo2", txtContactNo2.Text);
                        
                        cmd.Parameters.AddWithValue("@BAccountHolderName", txtAccountHolderName.Text);
                        cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                        cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
                        cmd.Parameters.AddWithValue("@BranchName", txtBranchNo.Text);
                        cmd.Parameters.AddWithValue("@CreateUser", userID);

                        headerId = Convert.ToInt32(cmd.ExecuteScalar());
                        BindGridviewPackingData();

                    }
                }
                }
            else
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        protected void BindGridviewPackingData()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;
            sql = "exec sp_GetTourGuideHeader '"+txtGuideName.Text+"','"+txtCompany.Text+"','"+txtAddress.Text+"','"+txtContactNo1.Text+"','"+txtContactNo2.Text+"','"+txtNICNo.Text+"'";

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


        private bool ValidateTextBox(TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, errorMessage);
                return false;
            }
            else
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
        }

        private bool ValidateNIC(TextBox textBox)
        {
            string nicPattern = @"^\d{9}[VvXx]$|^\d{12}$"; // Supports old and new NIC formats
            if (!Regex.IsMatch(textBox.Text, nicPattern))
            {
                errorProvider.SetError(textBox, "Invalid NIC Number format.");
                return false;
            }
            errorProvider.SetError(textBox, "");
            return true;
        }

        private bool ValidateContact(TextBox textBox)
        {
            string phonePattern = @"^0\d{9}$"; // 10-digit Sri Lankan phone number
            if (!Regex.IsMatch(textBox.Text, phonePattern))
            {
                errorProvider.SetError(textBox, "Invalid contact number. Must be 10 digits and start with 0.");
                return false;
            }
            errorProvider.SetError(textBox, "");
            return true;
        }

        private bool ValidateAccountNumber(TextBox textBox)
        {
            string accountPattern = @"^\d{10,16}$"; // Account numbers between 10-16 digits
            if (!Regex.IsMatch(textBox.Text, accountPattern))
            {
                errorProvider.SetError(textBox, "Invalid Account Number. Must be between 10-16 digits.");
                return false;
            }
            errorProvider.SetError(textBox, "");
            return true;
        }

        private bool ValidateBranchNumber(TextBox textBox)
        {
            string branchPattern = @"^\d{4,6}$"; // Assuming branch codes are 4-6 digits
            if (!Regex.IsMatch(textBox.Text, branchPattern))
            {
                errorProvider.SetError(textBox, "Invalid Branch Number. Must be 4-6 digits.");
                return false;
            }
            errorProvider.SetError(textBox, "");
            return true;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            BindGridviewPackingData();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtGuideName.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtNICNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContactNo1.Text = string.Empty;
            txtContactNo2.Text = string.Empty;

            txtAccountHolderName.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBranchNo.Text = string.Empty;
        }

        private void datagvBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagvBillDetails.Columns[e.ColumnIndex].Name == "TourGuideNo")
            {
                string TGHid = datagvBillDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTGId.Text = TGHid.ToString();

                TourGuidePointDetail frmTourGuidePointDetail = new TourGuidePointDetail(lblTGId.Text,LblLoggedUser.Text, userID);
                frmTourGuidePointDetail.Show();

            }
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TicketMaster TicketMasterForm = new TicketMaster(LblLoggedUser.Text, userID);
            TicketMasterForm.Show();
        }

        private void TourGuide_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
