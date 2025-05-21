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
using QRCoder;
using System.Runtime.InteropServices;
using System.IO;

namespace TicketSystem
{
    public partial class TicketMasterSecond : Form
    {
        string connetionString = null;
        SqlConnection conn;
        string UserName = "User1";
        string UserID = "4";
        int UserId = 0;
        int headerId;
        public TicketMasterSecond(string UserName, string UserID)
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=STVMS;User ID=user1;Password=iliyana1997vera++";         

            LblLoggedUser.Text = UserName;
            labelLogUser.Text = UserName;
            UserId = Convert.ToInt32(UserID);


            // connetionString = "Data Source=192.168.80.151;Initial Catalog=VM;User ID=sa;Password=iliyana1997vera+";
            conn = new SqlConnection(connetionString);
            LoadTicketTypesOD();
            LoadTicketTypesPB();
            LoadTicketTypesODPB();

            string ipAddress = GetLocalIPAddress();
            ipAddressLabel.Text = ipAddress;

            GetLastLogDetails(UserID, ipAddressLabel.Text);
          
        }

        public void GetLastLogDetails(string UserID, string IPAdrz)
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            string query = "exec Get_UserLogDetails '" + UserID + "','" + IPAdrz + "'";
            string billNo = "";
            decimal billAmount = 0;
            decimal discountPercentage = 0;
            decimal totBillAmount = 0;
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblLoggedTime.Text = reader["LoggedDateTime"].ToString();
                    lblTicketCounter.Text = reader["TicketCounter"].ToString();
                   
                }
                reader.Close();
            }

            conn.Close();
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

        private void LoadTicketTypesOD()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[dbo].sp_getTktTypes";

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
                comboBoxODTicketType.DataSource = ds.Tables[0];
                comboBoxODTicketType.ValueMember = "TTypeid";
                comboBoxODTicketType.DisplayMember = "TicketType";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

            conn.Close();
        }

        private void LoadTicketTypesPB()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[dbo].sp_getTktTypes";

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

                comboBoxPBTicketType.DataSource = ds.Tables[0];
                comboBoxPBTicketType.ValueMember = "TTypeid";
                comboBoxPBTicketType.DisplayMember = "TicketType";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

            conn.Close();
        }

        private void LoadTicketTypesODPB()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;

            sql = "EXEC  VM.[dbo].sp_getTktTypes";

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

                comboBoxODPBTicketType.DataSource = ds.Tables[0];
                comboBoxODPBTicketType.ValueMember = "TTypeid";
                comboBoxODPBTicketType.DisplayMember = "TicketType";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

            conn.Close();

        }

        private void BtnODAdd_Click(object sender, EventArgs e)
        {
            AddItem("3", comboBoxODTicketType.SelectedValue.ToString(), "Observation Deck",comboBoxODTicketType.Text, "",txtODQty.Text);
        }

        private void BtnPBAdd_Click(object sender, EventArgs e)
        {
            AddItem("4",comboBoxPBTicketType.SelectedValue.ToString(),"Pixel Bloom", comboBoxPBTicketType.Text, "",txtPBQty.Text);
        }

        private void BtnODPBAdd_Click(object sender, EventArgs e)
        {
            AddItem("5",comboBoxODTicketType.SelectedValue.ToString(),"Pixel + Observation", comboBoxODPBTicketType.Text, "",txtODPBQty.Text);
        }

        public void AddItem(string ProjectID,string TypeID, string ProjectName, string TicketType, string TActivity,string TktNos)
        {
            string TotalPrice = "";
            //string TicketNo = "";
            //string TActivity = "";
            //string ProjectName = "";
            //string UnitPrice = "0.00";
            //string SaleCount = "0";
            GETUnitPrice(ProjectID,TypeID);

            TotalPrice = (Convert.ToDecimal(TktNos) * Convert.ToDecimal(lblUnitPrice.Text)).ToString();

            if (Convert.ToDecimal(lblUnitPrice.Text) == 0)
            {
                MessageBox.Show("Invalid Ticket Type, Please check the Ticket Prices !");
                return;
            }
            else
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    bool valueExists = false;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string Project = row.Cells[0].Value.ToString();
                            string TktType = row.Cells[1].Value.ToString();
                            // string TktActivity = row.Cells[2].Value.ToString();
                            string TktCount = row.Cells[3].Value.ToString();

                            if (ProjectName == Project && TicketType == TktType)
                            {
                                dataGridView1.Rows.Remove(row);
                                this.dataGridView1.Rows.Add(ProjectName, TicketType, TktNos, lblUnitPrice.Text, TotalPrice,  ProjectID, TypeID);
                                lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                                valueExists = true;
                                break;
                            }

                        }
                    }
                    if (!valueExists)
                    {
                        this.dataGridView1.Rows.Add(ProjectName, TicketType, TktNos, lblUnitPrice.Text, TotalPrice,  ProjectID, TypeID);
                        lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                        UpdateTotalPrice();
                    }
                }
                else
                {
                    this.dataGridView1.Rows.Add(ProjectName, TicketType, TktNos, lblUnitPrice.Text, TotalPrice,  ProjectID, TypeID);
                    lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                    UpdateTotalPrice();
                }

                if (txtPaidAmount.Text != "")
                {
                    lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
                }

            }
            //decimal sum = 0;
            //int QtySum = 0;

            //// Check if the DataGridView has rows
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    // Iterate over each row
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        // Check if the cell value is not null and the cell index is valid
            //        if (row.Cells.Count > 6 && row.Cells[6].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
            //        {
            //            sum += Convert.ToDecimal(row.Cells[6].Value);
            //        }

            //        if (row.Cells.Count > 3 && row.Cells[3].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
            //        {
            //            QtySum += Convert.ToInt32(row.Cells[3].Value);
            //        }
            //    }
            //}

            //// Update labels with calculated values
            //lblTotAmount.Text = sum.ToString();
            //lblNoOfQtySold.Text = QtySum.ToString();

            //if (txtPaidAmount.Text != "")
            //{
            //    lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
            //}

        }


        decimal sum = 0;
        int QtySum = 0;

        private void UpdateTotalPrice()
        {

            sum = 0;
            QtySum = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Check if the cell value is not null and the cell index is valid
                if (row.Cells.Count > 4 && row.Cells[4].Value != null && row.Cells.Count > 4 && row.Cells[4].Value != "")
                {
                    sum += Convert.ToDecimal(row.Cells[4].Value);
                }

                if (row.Cells.Count > 2 && row.Cells[2].Value != null && row.Cells.Count > 2 && row.Cells[2].Value != "")
                {
                    QtySum += Convert.ToInt32(row.Cells[2].Value);
                }
            }
        

        // Update labels with calculated values
        lblTotAmount.Text = sum.ToString();
        lblNoOfQtySold.Text = QtySum.ToString();

        }

        private void GETUnitPrice(string ProjectID, string TypeId)
        {
            lblUnitPrice.Text = String.Empty;
            

            conn = new SqlConnection(connetionString);
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand command = new SqlCommand("exec [sp_GetUnitPrice] '"+ProjectID+"','"+TypeId+"'", conn);


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblUnitPrice.Text = reader["UnitPrice"].ToString();
               
            }
            conn.Close();

            
        }

        private bool IsRecordExists(DataGridView dataGridView, string PaymentMethodID)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if (row.Cells[1].Value.ToString() == PaymentMethodID)
                    {
                        dataGridViewSettlement.Rows.Remove(row);
                        return true;

                    }
                }
            }
            return false;
        }

        private decimal GetColumnTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewSettlement.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    decimal value;
                    if (decimal.TryParse(row.Cells[3].Value.ToString(), out value))
                    {
                        total += value;
                    }
                }
            }

            txtPaidAmount.Text = total.ToString();

            if (txtPaidAmount.Text != "")
            {
                lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
            }
            return total;
        }
        private void btnCash_Click(object sender, EventArgs e)
        {
            if (txtSettlementAmount.Text != "" && txtSettlementAmount.Text != "0.00" && txtSettlementAmount.Text != "0")
            {
                lblPaymentMethodID.Text = "1";

                if (!IsRecordExists(dataGridViewSettlement, lblPaymentMethodID.Text))
                {
                    btnCash.FlatStyle = FlatStyle.Flat;
                    btnCash.FlatAppearance.BorderSize = 2;
                    btnCash.FlatAppearance.BorderColor = Color.Red; // Highlight with red border

                    BtnVisaMaster.FlatStyle = FlatStyle.Standard; // Reset to default style
                    BtnVisaMaster.FlatAppearance.BorderSize = 1; // Default border size
                    BtnVisaMaster.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    BtnVisaMaster.UseVisualStyleBackColor = true; // Reset background color

                    btnAmex.FlatStyle = FlatStyle.Standard; // Reset to default style
                    btnAmex.FlatAppearance.BorderSize = 1; // Default border size
                    btnAmex.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    btnAmex.UseVisualStyleBackColor = true; // Reset background color

                    btnFrimi.FlatStyle = FlatStyle.Standard; // Reset to default style
                    btnFrimi.FlatAppearance.BorderSize = 1; // Default border size
                    btnFrimi.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    btnFrimi.UseVisualStyleBackColor = true; // Reset background color


                    this.dataGridViewSettlement.Rows.Add("Cash", 1, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
                else
                {
                    this.dataGridViewSettlement.Rows.Add("Cash", 1, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
            }

        }

        private void btnAmex_Click(object sender, EventArgs e)
        {
            if (txtSettlementAmount.Text != "" && txtSettlementAmount.Text != "0.00" && txtSettlementAmount.Text != "0")
            {
                lblPaymentMethodID.Text = "3";

                if (!IsRecordExists(dataGridViewSettlement, lblPaymentMethodID.Text))
                {
                    if (txtRemark.Text != "")
                    {
                        btnAmex.FlatStyle = FlatStyle.Flat;
                        btnAmex.FlatAppearance.BorderSize = 2;
                        btnAmex.FlatAppearance.BorderColor = Color.Red;

                        btnCash.FlatStyle = FlatStyle.Standard; // Reset to default style
                        btnCash.FlatAppearance.BorderSize = 1; // Default border size
                        btnCash.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        btnCash.UseVisualStyleBackColor = true; // Reset background color

                        btnFrimi.FlatStyle = FlatStyle.Standard; // Reset to default style
                        btnFrimi.FlatAppearance.BorderSize = 1; // Default border size
                        btnFrimi.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        btnAmex.UseVisualStyleBackColor = true; // Reset background color

                        BtnVisaMaster.FlatStyle = FlatStyle.Standard; // Reset to default style
                        BtnVisaMaster.FlatAppearance.BorderSize = 1; // Default border size
                        BtnVisaMaster.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        BtnVisaMaster.UseVisualStyleBackColor = true; // Reset background color


                        this.dataGridViewSettlement.Rows.Add("Amex", 3, txtRemark.Text, txtSettlementAmount.Text);
                        GetColumnTotal();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Card No / Remark Not Entered !");
                    }
                }
                else
                {
                    this.dataGridViewSettlement.Rows.Add("Amex", 3, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
            }

        }

        private void BtnVisaMaster_Click(object sender, EventArgs e)
        {
            if (txtSettlementAmount.Text != "" && txtSettlementAmount.Text != "0.00" && txtSettlementAmount.Text != "0")
            {
                lblPaymentMethodID.Text = "2";

                if (!IsRecordExists(dataGridViewSettlement, lblPaymentMethodID.Text))
                {
                    if (txtRemark.Text != "")
                    {
                        BtnVisaMaster.FlatStyle = FlatStyle.Flat;
                        BtnVisaMaster.FlatAppearance.BorderSize = 2;
                        BtnVisaMaster.FlatAppearance.BorderColor = Color.Red;

                        btnCash.FlatStyle = FlatStyle.Standard; // Reset to default style
                        btnCash.FlatAppearance.BorderSize = 1; // Default border size
                        btnCash.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        btnCash.UseVisualStyleBackColor = true; // Reset background color

                        btnAmex.FlatStyle = FlatStyle.Standard; // Reset to default style
                        btnAmex.FlatAppearance.BorderSize = 1; // Default border size
                        btnAmex.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        btnAmex.UseVisualStyleBackColor = true; // Reset background color

                        btnFrimi.FlatStyle = FlatStyle.Standard; // Reset to default style
                        btnFrimi.FlatAppearance.BorderSize = 1; // Default border size
                        btnFrimi.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                        btnFrimi.UseVisualStyleBackColor = true; // Reset background color


                        this.dataGridViewSettlement.Rows.Add("Visa/Master", 2, txtRemark.Text, txtSettlementAmount.Text);
                        GetColumnTotal();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Card No / Remark Not Entered !");

                    }
                }
                else
                {
                    this.dataGridViewSettlement.Rows.Add("Visa/Master", 2, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
            }

        }

        private void btnFrimi_Click(object sender, EventArgs e)
        {
            if (txtSettlementAmount.Text != "" && txtSettlementAmount.Text != "0.00" && txtSettlementAmount.Text != "0")
            {
                lblPaymentMethodID.Text = "4";

                if (!IsRecordExists(dataGridViewSettlement, lblPaymentMethodID.Text))
                {
                    btnFrimi.FlatStyle = FlatStyle.Flat;
                    btnFrimi.FlatAppearance.BorderSize = 2;
                    btnFrimi.FlatAppearance.BorderColor = Color.Red;

                    btnCash.FlatStyle = FlatStyle.Standard; // Reset to default style
                    btnCash.FlatAppearance.BorderSize = 1; // Default border size
                    btnCash.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    btnCash.UseVisualStyleBackColor = true; // Reset background color

                    btnAmex.FlatStyle = FlatStyle.Standard; // Reset to default style
                    btnAmex.FlatAppearance.BorderSize = 1; // Default border size
                    btnAmex.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    btnAmex.UseVisualStyleBackColor = true; // Reset background color

                    BtnVisaMaster.FlatStyle = FlatStyle.Standard; // Reset to default style
                    BtnVisaMaster.FlatAppearance.BorderSize = 1; // Default border size
                    BtnVisaMaster.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    BtnVisaMaster.UseVisualStyleBackColor = true; // Reset background color

                    btnAmex.FlatStyle = FlatStyle.Standard; // Reset to default style
                    btnAmex.FlatAppearance.BorderSize = 1; // Default border size
                    btnAmex.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark; // Default border color
                    btnAmex.UseVisualStyleBackColor = true; // Reset background color


                    this.dataGridViewSettlement.Rows.Add("Frimi", 4, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
                else
                {
                    this.dataGridViewSettlement.Rows.Add("Frimi", 4, txtRemark.Text, txtSettlementAmount.Text);
                    GetColumnTotal();
                }
            }

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listViewTktDetails.Items.Clear();

            // Reset text fields
            txtPaidAmount.Text = "0.00";
            lblBalance.Text = "0";
            lblNoOfQtySold.Text = "0";
            lblTotAmount.Text = "0";
            lblNoOfTktType.Text = "0";



            // Clear DataGridView
            dataGridViewSettlement.Rows.Clear();
            dataGridViewSettlement.Refresh();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            TicketPricing TktPrice = new TicketPricing();
            TktPrice.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BillDetailPrint BillDetailPrintForm = new BillDetailPrint();
            BillDetailPrintForm.Show();
        }

        private void btnBillEnter_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridViewSettlement.Rows.Count > 0)
            {
                if (txtPaidAmount.Text == "")
                {
                    return;
                }
                if (txtPaidAmount.Text == "0.00")
                {
                    return;
                }
                if (decimal.Parse(lblBalance.Text) < 0)
                {
                    return;
                }

               
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();

                    // Insert bill header and retrieve the headerId
                    string insertHeaderQuery = "EXEC STVMS.dbo.[sp_InsertBillHeader] @QtySold, @UserId, @TotalAmount, @Discount, @DiscountPercentage, @TotBillAmount,@PaidAmount,@Balance,@BillType; SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(insertHeaderQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@QtySold", lblNoOfQtySold.Text);
                        cmd.Parameters.AddWithValue("@UserId", UserID);
                        cmd.Parameters.AddWithValue("@TotalAmount", lblTotAmount.Text);
                        cmd.Parameters.AddWithValue("@Discount", 0);
                        cmd.Parameters.AddWithValue("@DiscountPercentage", 0);
                        cmd.Parameters.AddWithValue("@TotBillAmount", lblTotAmount.Text);
                        cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@Balance", lblBalance.Text);
                        cmd.Parameters.AddWithValue("@BillType", 2);

                        headerId = Convert.ToInt32(cmd.ExecuteScalar());

                    }


                    // Insert data into detail table using headerId
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string ProjectID = row.Cells[5].Value.ToString();
                            string TypeID = row.Cells[6].Value.ToString();
                            string NoOfTicket = row.Cells[2].Value.ToString();
                            string UnitPrice = row.Cells[3].Value.ToString();



                            string insertDetailQuery = "EXEC STVMS.dbo.[sp_InsertBillDetail_BillType2]  '"+ headerId + "','"+ ProjectID + "', '"+ TypeID + "',1,'"+ NoOfTicket + "','"+ UnitPrice + "','0','0','0','"+ lblTGId.Text+ "'";
                            using (SqlCommand cmd = new SqlCommand(insertDetailQuery, connection))
                            {
                                //cmd.Parameters.AddWithValue("@BillId", headerId);
                                //cmd.Parameters.AddWithValue("@TicketProjectID", ProjectID);
                                //cmd.Parameters.AddWithValue("@TicketTypeID", TypeID);
                                //cmd.Parameters.AddWithValue("@TicketActivityID", "1");
                                //cmd.Parameters.AddWithValue("@NoOfTicket", NoOfTicket);
                                //cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                                //cmd.Parameters.AddWithValue("@TGID", lblTGId.Text);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }


                    foreach (DataGridViewRow row in dataGridViewSettlement.Rows)
                    {
                        if (!row.IsNewRow) // Avoid the empty new row
                        {
                            string paymentMethod = row.Cells["PaymentMethod"].Value?.ToString();
                            string amount = row.Cells["SettleAmount"].Value?.ToString();
                            string cardNo = row.Cells["Remark"].Value?.ToString();

                            string insertDetailQueri = "EXEC STVMS.dbo.sp_InsertBillPaymentTypes @BillId, @PaymentType, @Amount,@CardNo";
                            using (SqlCommand cmd = new SqlCommand(insertDetailQueri, connection))
                            {
                                cmd.Parameters.AddWithValue("@BillId", headerId);
                                cmd.Parameters.AddWithValue("@PaymentType", paymentMethod);
                                cmd.Parameters.AddWithValue("@Amount", amount);
                                cmd.Parameters.AddWithValue("@CardNo", cardNo);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }


                    // Fetch the bill number and other relevant data from the database based on headerId
                    string selectBillDataQuery = "SELECT BillNo, BillAmount, DiscountPercentage, TotBillAmount FROM  STVMS.[dbo].BillHeader WHERE BillId = @BillId";
                    string billNo = "";
                    decimal billAmount = 0;
                    decimal discountPercentage = 0;
                    decimal totBillAmount = 0;
                    using (SqlCommand cmd = new SqlCommand(selectBillDataQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@BillId", headerId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblLastBillNo.Text = reader["BillNo"].ToString();
                            billNo = reader["BillNo"].ToString();
                            billAmount = Convert.ToDecimal(reader["BillAmount"]);
                            discountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]);
                            totBillAmount = Convert.ToDecimal(reader["TotBillAmount"]);

                          
                        }
                        reader.Close();
                        PrintTickets(headerId);
                    }

                    // Print the report
                    //PrintCustomerBillReport();
                    // PrintTicketBillReport(billNo, billAmount, discountPercentage, totBillAmount, LblLoggedUser.Text);

                    //MessageBox.Show("Bill added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; // Clear the DataGridView data
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridViewSettlement.Rows.Clear();
                    dataGridViewSettlement.Refresh();



                    txtSettlementAmount.Text = "";
                    txtRemark.Text = "";


                    lblTGComanyName.Text = String.Empty;
                    lblTGId.Text = String.Empty;
                    lblTGName.Text = String.Empty;
                    lblTGNIC.Text = String.Empty;
                    lblTourGuideNo.Text = String.Empty;

                    txtODQty.Text = String.Empty;
                    txtPBQty.Text = String.Empty;
                    txtODPBQty.Text = String.Empty;

                    lblNoOfTktType.Text = "0";
                    lblBalance.Text = "0";
                    lblNoOfQtySold.Text = "0";
                    txtPaidAmount.Text = "0";
                    lblTotAmount.Text = "0";
                    listViewTktDetails.Items.Clear();
                    //txtBarcodeNo.Focus();
                  //  OpenCashDrawer();
                    // LoadDataToDataGridView1();
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }

        }

        string TicketNo = "";
        private void PrintTickets(int BillId)
        {
            string query = "SELECT TicketNo FROM [STVMS].[dbo].[BillDetail] WHERE BillId = '" + BillId + "'";
            SqlCommand command = new SqlCommand(query, conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            List<string> ticketNumbers = new List<string>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ticketNumbers.Add(reader["TicketNo"].ToString());
                }
            } // reader is automatically closed here

            foreach (var ticketNo in ticketNumbers)
            {
                TicketNo = ticketNo;
                getTicketDetails(ticketNo);

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument1;
                // previewDialog.ShowDialog();
                printDocument1.Print();
            }
        }

        //private void PrintTickets(int BillId)
        //{
        //    string query = "SELECT TicketNo FROM [STVMS].[dbo].[BillDetail] WHERE BillId = '"+ BillId + "'";

        //    SqlCommand command = new SqlCommand(query, conn);
        //    if (conn.State.ToString() == "Closed")
        //    {
        //        conn.Open();
        //    }

        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            string ticketNo = reader["TicketNo"].ToString();
        //        getTicketDetails(ticketNo);

        //        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        //        previewDialog.Document = printDocument1;
        //        // previewDialog.ShowDialog();
        //        printDocument1.Print();
        //        }

        //        reader.Close();
        //    }
        //}

        private void getTicketDetails(string TKTNO)
        {
            SqlCommand cmd = new SqlCommand("exec sp_GetBarcodeDetails '" + TKTNO + "' ", conn);

            lblProjectName.Text = "";
            string TicketNo = "";
            string TActivity = "";
            string ProjectName = "";
            string UnitPrice = "0.00";
            string SaleCount = "0";

            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblProjectName.Text = rdr["ProjectName"].ToString();
                lblTicketType.Text = rdr["TicketType"].ToString();
                lblTActivity.Text = rdr["TActivity"].ToString();
                lblUnitPrice.Text = rdr["UnitPrice"].ToString();

            }
            conn.Close();
            rdr.Close();

        }


        private void buttonFindTG_Click(object sender, EventArgs e)
        {
            GETTourGuideDetails();
        }

        private void GETTourGuideDetails()
        {
            lblTGComanyName.Text = String.Empty;
            lblTGId.Text = String.Empty;
            lblTGName.Text = String.Empty;
            lblTGNIC.Text = String.Empty;
            lblTourGuideNo.Text = String.Empty;

            conn = new SqlConnection(connetionString);
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand command = new SqlCommand("exec [sp_SearchTourGuide]'" + textBoxTGContactNo.Text + "'", conn);

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

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void linkLabelEntryPoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TicketCounter ticketCounterForm = new TicketCounter(UserId.ToString(), LblLoggedUser.Text);
            ticketCounterForm.Show();
        }

        private void TicketMasterSecond_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set font and brush
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.Black;
            float yPos = 20; // Starting Y position
            float xPos = 10;  // Starting X position
            float xPosCenter = 100;  // Starting X position



            // Print Header

            // Load and draw the logo at the top center
            string logoPath = @"C:\TicketSystem\CLTLogo.png"; // Replace with actual path
            if (File.Exists(logoPath))
            {
                using (Image logo = Image.FromFile(logoPath))
                {
                    int logoWidth = 80;
                    int logoHeight = 80;
                    float logoX = (e.PageBounds.Width - logoWidth) / 2;
                    e.Graphics.DrawImage(logo, logoX, yPos, logoWidth, logoHeight);
                }
                yPos += 85; // Adjust Y position after the logo
            }

            // Centered Header: "COLOMBO LOTUS TOWER"
            string header = "COLOMBO LOTUS TOWER";
            Font headerFont = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
            Font NormalFont = new Font("Arial", 8, System.Drawing.FontStyle.Regular);
            Font MediumFont = new Font("Arial", 12, System.Drawing.FontStyle.Regular);
            SizeF headerSize = e.Graphics.MeasureString(header, headerFont);
            float centerX = (e.PageBounds.Width - headerSize.Width) / 2;

            e.Graphics.DrawString(header, headerFont, brush, centerX, yPos);
            yPos += 20;
            e.Graphics.DrawString("No.320, D.R. Wijewardhana Mawatha, Colombo10.", NormalFont, brush, 15, yPos);
            yPos += 20;
            e.Graphics.DrawString("Tel:+94 112 108 300 | email:info@colombolotustower.lk", NormalFont, brush, 5, yPos);
            yPos += 20;
            e.Graphics.DrawString("website: www.colombolotustower.lk", NormalFont, brush, 60, yPos);
            yPos += 20;
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), NormalFont, brush, 75, yPos);
            yPos += 15;

            //Line
            float lineStartX = 10; // Same as your content start X
            float lineEndX = e.PageBounds.Width - 10; // Adjust based on desired right margin
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);
            yPos += 15;
            // End Line


            Font projectNameFont = new Font(NormalFont.FontFamily, NormalFont.Size + 4, FontStyle.Bold);

            // Centered content lines
            string[] ticketDetails = {
    "" + lblProjectName.Text,
    "" + lblTicketType.Text,
    "" + lblTActivity.Text,
    "Ticket Price: " + lblUnitPrice.Text
};

            foreach (string detail in ticketDetails)
            {
                // Set the font based on whether the detail is the Project Name
                Font currentFont = (detail == lblProjectName.Text) ? new Font(NormalFont, FontStyle.Bold) : NormalFont;

                SizeF textSize = e.Graphics.MeasureString(detail, currentFont);
                float detailX = (e.PageBounds.Width - textSize.Width) / 2;
                e.Graphics.DrawString(detail, currentFont, brush, detailX, yPos);
                yPos += 25;
            }

            //e.Graphics.DrawString("Ticket Location: " + lblProjectName.Text, MediumFont, brush, xPosCenter, yPos);
            //yPos += 25;
            //e.Graphics.DrawString("Ticket Type: " + lblTicketType.Text, NormalFont, brush, xPosCenter, yPos);
            //yPos += 25;
            //e.Graphics.DrawString("Ticket Activity: " + lblTActivity.Text, NormalFont, brush, xPosCenter, yPos);
            //yPos += 25;
            //e.Graphics.DrawString("Ticket Price: " + lblUnitPrice.Text, NormalFont, brush, xPosCenter, yPos);
            //yPos += 25;

            // ✅ Generate QR Code for TicketNo
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(TicketNo, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        using (Bitmap qrCodeImage = qrCode.GetGraphic(5))
                        {
                            // Define where to draw QR code
                            Rectangle qrRect = new Rectangle((int)xPosCenter, (int)yPos, 100, 100);
                            e.Graphics.DrawImage(qrCodeImage, qrRect);
                        }
                    }
                }
            }



            // Optional: Print Ticket Number below QR
            yPos += 110;
            string TKTNoText = "Thank You! Visit Again.";
            SizeF TicketNoSize = e.Graphics.MeasureString(TKTNoText, NormalFont);
            float centerXB = (e.PageBounds.Width - TicketNoSize.Width) / 2;
            e.Graphics.DrawString("Ticket No: " + TicketNo, NormalFont, brush, centerXB, yPos);
            yPos += 25;
            e.Graphics.DrawString("Bill No: " + lblLastBillNo.Text, NormalFont, brush, centerXB, yPos);

            //Line
            yPos += 25;
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);

            // End Line
            yPos += 15;
            // Center-align the Thank You message
            string thankYouText = "Thank You! Visit Again.";
            SizeF thankYouSize = e.Graphics.MeasureString(thankYouText, NormalFont);
            float centerXA = (e.PageBounds.Width - thankYouSize.Width) / 2;

            // float detailX = (e.PageBounds.Width - textSize.Width) / 2;
            e.Graphics.DrawString(thankYouText, NormalFont, brush, centerXA, yPos);
        }




    }
}
