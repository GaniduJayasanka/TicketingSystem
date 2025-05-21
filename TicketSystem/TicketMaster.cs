using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using System.Net;
using QRCoder;
using System.Runtime.InteropServices;

namespace TicketSystem
{
    public partial class TicketMaster : Form
    {
        string connetionString = null;
        SqlConnection conn;
        int headerId;
        int UserId = 0;
        string headerData = "Header Data";
        string detailData = "Detail Data";

        public TicketMaster(string UserName, string UserID)
        {
             connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
           // connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            InitializeComponent();
            lblBalance.TextAlign = ContentAlignment.MiddleRight;
            txtPassword.PasswordChar = '*';
            //lblCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            // txtBarcodeNo.KeyUp += txtBarcodeNo_KeyUp;
            LblLoggedUser.Text = UserName;
            UserId = Convert.ToInt32(UserID);
             conn = new SqlConnection(connetionString);
            

            string ipAddress = GetLocalIPAddress();
            ipAddressLabel.Text =  ipAddress;

            GetLastLogDetails(UserID, ipAddressLabel.Text);
            GETVisitorCount();

            btnCash.FlatStyle = FlatStyle.Flat;
            btnCash.FlatAppearance.BorderSize = 2;
            btnCash.FlatAppearance.BorderColor = Color.Red;

            lblPaymentMethodID.Text = "1";
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

        private void GETVisitorCount()
        {
            lblAquaBayVisitorCount.Text = String.Empty;
            lblObservationDCount.Text = String.Empty;
            lblPixelBloomCount.Text = String.Empty;

            conn = new SqlConnection(connetionString);
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand command = new SqlCommand("exec [sp_ProjectWiseVisitorCount] ", conn);
           

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblAquaBayVisitorCount.Text = reader["AquaBayCount"].ToString();
                lblObservationDCount.Text = reader["ObservationDCount"].ToString();
                lblPixelBloomCount.Text = reader["PixelBloomCount"].ToString();
            }
            conn.Close();

            int pixelCount = int.Parse(lblPixelBloomCount.Text);

            if (pixelCount > 200)
            {
                groupBox7.BackColor = Color.Red;
            }

        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            var number = txtBarcodeNo.Text;
            int length = number.Length;

            if (length == 10)
            {

                conn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand("exec sp_GetBarcodeDetails '" + txtBarcodeNo.Text + "' ", conn);
                string TicketType = "";
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
                    ProjectName = rdr["ProjectName"].ToString();
                    TicketNo = rdr["TicketNo"].ToString();
                    TicketType = rdr["TicketType"].ToString();
                    TActivity = rdr["TActivity"].ToString();
                    UnitPrice = rdr["UnitPrice"].ToString();
                    SaleCount = rdr["TicketSaleCount"].ToString();
                }

                if (Convert.ToInt32(SaleCount) > 0)
                {
                    System.Windows.MessageBox.Show("Item already exists.");
                    return;
                }
                else
                {
                    ////----------------------  ///// Assuming listView1 is your ListView control

                    string newItemText = TicketNo;

                    // Check if the item already exists
                    bool itemExists = false;
                    foreach (ListViewItem item in listViewTktDetails.Items)
                    {
                        if (item.SubItems[0].Text == newItemText)
                        {
                            itemExists = true;
                            break;
                        }
                    }

                    if (itemExists)
                    {

                        //string message = "Item already exists.";
                        //string title = "Message Box";
                        //MessagePanel customMessageBox = new MessagePanel(message, title);
                        //customMessageBox.ShowDialog();

                        System.Windows.MessageBox.Show("Item already exists.");
                        return;
                    }
                    else if (itemExists == false)
                    {
                        // Create a new ListViewItem object with the desired text
                        ListViewItem newItem = new ListViewItem(new string[] { TicketNo, UnitPrice });

                        listViewTktDetails.Items.Add(newItem);


                        conn.Close();
                        if (dataGridView1.Rows.Count > 0)
                        {
                            bool valueExists = false;

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value != null)
                                {
                                    string Project = row.Cells[0].Value.ToString();
                                    string TktType = row.Cells[1].Value.ToString();
                                    string TktActivity = row.Cells[2].Value.ToString();
                                    string TktCount = row.Cells[3].Value.ToString();

                                    if (ProjectName == Project && TicketType == TktType && TActivity == TktActivity)
                                    {
                                        row.Cells[3].Value = (Convert.ToInt32(TktCount) + 1).ToString();
                                        row.Cells[6].Value = ((Convert.ToInt32(TktCount) + 1) * (Convert.ToDecimal(UnitPrice))).ToString();
                                        lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                                        valueExists = true;
                                        break;
                                    }

                                }
                            }
                            if (!valueExists)
                            {
                                this.dataGridView1.Rows.Add(ProjectName, TicketType, TActivity, 1, UnitPrice, 0, UnitPrice);
                                lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                            }
                        }
                        else
                        {
                            this.dataGridView1.Rows.Add(ProjectName, TicketType, TActivity, 1, UnitPrice, 0, UnitPrice);
                            lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                        }

                        decimal sum = 0;
                        int QtySum = 0;

                        // Check if the DataGridView has rows
                        if (dataGridView1.Rows.Count > 0)
                        {
                            // Iterate over each row
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                // Check if the cell value is not null and the cell index is valid
                                if (row.Cells.Count > 6 && row.Cells[6].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                                {
                                    sum += Convert.ToDecimal(row.Cells[6].Value);
                                }

                                if (row.Cells.Count > 3 && row.Cells[3].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                                {
                                    QtySum += Convert.ToInt32(row.Cells[3].Value);
                                }
                            }
                        }

                        // Update labels with calculated values
                        lblTotAmount.Text = sum.ToString();
                        lblNoOfQtySold.Text = QtySum.ToString();

                        if (txtPaidAmount.Text != "")
                        {
                            lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
                        }

                    }
                    txtBarcodeNo.Clear();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Incorrect Barcode Length !");
            }
        }


            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
            private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA pDocInfo);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", SetLastError = true)]
            private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            [StructLayout(LayoutKind.Sequential)]
            private struct DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;

                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;

                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }

        public static void OpenCashDrawer()
        {
            string printerName = new PrinterSettings().PrinterName;
            IntPtr hPrinter;

            if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
            {
                System.Windows.MessageBox.Show("Failed to open printer.");
                return;
            }

            try
            {
                DOCINFOA docInfo = new DOCINFOA
                {
                    pDocName = "Open Cash Drawer",
                    pDataType = "RAW"
                };

                if (StartDocPrinter(hPrinter, 1, ref docInfo))
                {
                    StartPagePrinter(hPrinter);

                    byte[] openDrawerCommand = new byte[] { 0x1B, 0x70, 0x00, 0x19, 0xFA }; // ESC p 0 25 250
                    IntPtr pBytes = Marshal.AllocCoTaskMem(openDrawerCommand.Length);
                    Marshal.Copy(openDrawerCommand, 0, pBytes, openDrawerCommand.Length);

                    WritePrinter(hPrinter, pBytes, openDrawerCommand.Length, out _);

                    Marshal.FreeCoTaskMem(pBytes);
                    EndPagePrinter(hPrinter);
                    EndDocPrinter(hPrinter);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                ClosePrinter(hPrinter);
            }

        }

        //public void OpenCashDrawer()
        //{
        //    try
        //    {
        //        string defaultPrinterName = null;
        //        foreach (string printer in PrinterSettings.InstalledPrinters)
        //        {
        //            if (new PrinterSettings { PrinterName = printer }.IsDefaultPrinter)
        //            {
        //                defaultPrinterName = printer;
        //                break;
        //            }
        //        }

        //        if (defaultPrinterName == null)
        //        {
        //            System.Windows.MessageBox.Show("No default printer found.");
        //            return;
        //        }

        //        PrintDocument pd = new PrintDocument();
        //        pd.PrinterSettings.PrinterName = defaultPrinterName;
        //        pd.PrintController = new StandardPrintController();
        //        string commandSequence = "\x1B\x70\x00\x19\xFA";
        //        pd.PrintPage += (sender1, e1) => { };
        //        pd.Print();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show("Error opening cash drawer: " + ex.Message);
        //    }
        //}
        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();

            //}
        }

        public class BillData
        {
            public string BillNo { get; set; }
            public decimal BillAmount { get; set; }
            public decimal DiscountPercentage { get; set; }
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
                if(decimal.Parse(lblBalance.Text) < 0)
                {
                    return;
                }

                //try
                //{
                    using (SqlConnection connection = new SqlConnection(connetionString))
                    {
                        connection.Open();

                        // Insert bill header and retrieve the headerId
                        string insertHeaderQuery = "EXEC sp_InsertBillHeader @QtySold, @UserId, @TotalAmount, @Discount, @DiscountPercentage, @TotBillAmount,@PaidAmount,@Balance,@BillType; SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(insertHeaderQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@QtySold", lblNoOfQtySold.Text);
                            cmd.Parameters.AddWithValue("@UserId", UserId);
                            cmd.Parameters.AddWithValue("@TotalAmount", lblTotAmount.Text);
                            cmd.Parameters.AddWithValue("@Discount", 0);
                            cmd.Parameters.AddWithValue("@DiscountPercentage", 0);
                            cmd.Parameters.AddWithValue("@TotBillAmount", lblTotAmount.Text);
                        cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@Balance", lblBalance.Text);
                        cmd.Parameters.AddWithValue("@BillType", 1);

                        headerId = Convert.ToInt32(cmd.ExecuteScalar());

                        }


                    // Insert data into detail table using headerId
                    foreach (ListViewItem item in listViewTktDetails.Items)
                    {
                        string TicketNo = item.SubItems[0].Text;
                        string TktValue = item.SubItems[1].Text;

                        string insertDetailQuery = "EXEC sp_InsertBillDetail @HeaderId, @TicketNo, @TktValue,'0','0','0',@TGID";
                        using (SqlCommand cmd = new SqlCommand(insertDetailQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@HeaderId", headerId);
                            cmd.Parameters.AddWithValue("@TicketNo", TicketNo);
                            cmd.Parameters.AddWithValue("@TktValue", TktValue);
                            cmd.Parameters.AddWithValue("@TGID", lblTGId.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    
                    foreach (DataGridViewRow row in dataGridViewSettlement.Rows)
                    {
                        if (!row.IsNewRow) // Avoid the empty new row
                        {
                            string paymentMethod = row.Cells["PaymentMethod"].Value?.ToString();
                            string amount = row.Cells["SettleAmount"].Value?.ToString();
                            string cardNo = row.Cells["Remark"].Value?.ToString();

                           string insertDetailQueri = "EXEC sp_InsertBillPaymentTypes @BillId, @PaymentType, @Amount,@CardNo";
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
                    string selectBillDataQuery = "SELECT BillNo, BillAmount, DiscountPercentage, TotBillAmount FROM lotustest.BillHeader WHERE BillId = @BillId";
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

                    lblNoOfTktType.Text = "0";
                    lblBalance.Text = "0";
                    lblNoOfQtySold.Text = "0";
                    txtPaidAmount.Text = "0";
                    lblTotAmount.Text = "0";
                    listViewTktDetails.Items.Clear();
                    txtBarcodeNo.Focus();
                    OpenCashDrawer();
                    // LoadDataToDataGridView1();
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
        }

        public void PrintCustomerBillReport()
        {
         //   ReportDocument reportDocument = new ReportDocument();
         //   string reportFilePath = Path.Combine(Application.StartupPath, "Report", "Invoice.rpt");
         //   reportDocument.Load(reportFilePath);
         //reportDocument.SetParameterValue("@BillId","882");

         //   // Set up print options
         //   PrintOptions printOptions = reportDocument.PrintOptions;
         //   printOptions.PrinterName = ""; // Use default printer

         //   // Print the report directly to the default printer
         //   reportDocument.PrintToPrinter(1, false, 0, 0);

         //   // Dispose the report document after printing
         //   reportDocument.Close();
         //   reportDocument.Dispose();
        }
        private void PrintTicketBillReport(string billNo, decimal billAmount, decimal discountPercentage, decimal totBillAmount, string username)
        {

            //try
            //{
            //    // Construct the desired string format
            //    string formattedData = "";
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        DataGridViewRow row = dataGridView1.Rows[i];
            //        // Ensure that each cell value is not null
            //        if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
            //        {
            //            formattedData += $"{row.Cells[0].Value}{Environment.NewLine}";
            //            formattedData += $"{row.Cells[2].Value}    {row.Cells[1].Value}    {row.Cells[3].Value}    {row.Cells[4].Value}{Environment.NewLine}";
            //            formattedData += $"{Environment.NewLine}";
            //        }
            //        else
            //        {
            //            // Log or handle the error if any cell value is null
            //            Console.WriteLine("Error: Cell value is null");
            //        }
            //    }

            //    // Load the Crystal Report document
            //    ReportDocument reportDocument = new ReportDocument();
            //    string reportFilePath = Path.Combine(Application.StartupPath, "Report", "CrystalReport3.rpt");
            //    reportDocument.Load(reportFilePath);

            //    // Set parameters for the report
            //    reportDocument.SetParameterValue("@BillNo", billNo);
            //    reportDocument.SetParameterValue("@BillAmount", billAmount);
            //    reportDocument.SetParameterValue("@DiscountPercentage", discountPercentage);
            //    reportDocument.SetParameterValue("@TotBillAmount", totBillAmount);
            //    reportDocument.SetParameterValue("@DataGridView1Data", formattedData);
            //    reportDocument.SetParameterValue("@Username", username);
            //    reportDocument.SetParameterValue("@BillId", headerId.ToString());
            //    // **Formula for Image Field:**
            //    reportDocument.SetParameterValue("@barcode", billNo);

            //    // Set up print options
            //    PrintOptions printOptions = reportDocument.PrintOptions;
            //    printOptions.PrinterName = ""; // Use default printer

            //    // Print the report directly to the default printer
            //    reportDocument.PrintToPrinter(1, false, 0, 0);

            //    // Dispose the report document after printing
            //    reportDocument.Close();
            //    reportDocument.Dispose();
            //}
            //catch (NullReferenceException ex)
            //{
            //    MessageBox.Show("Null reference exception occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void LoadDataToDataGridView1()
        {
            // Your code to load data into dataGridView1
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

      //  string TicketNo = "D101000092";
        private void BtnClear_Click_1(object sender, EventArgs e)
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

            // Set focus back to Barcode textbox
            txtBarcodeNo.Focus();


            //// Check if any row is selected
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    // Get the selected row
            //    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            //    // Remove the selected row
            //    dataGridView1.Rows.Remove(selectedRow);

            //    // Update the total amount
            //    UpdateTotalAmount();
            //}

            //foreach (ListViewItem listItem in listViewTktDetails.Items)
            //{
            //    if (listItem.Text == TicketNo)
            //    {
            //        // Step 3: Remove the item once found
            //        listViewTktDetails.Items.Remove(listItem);
            //        break; // Break out of the loop after removing the item
            //    }
            //}
        }

        private void UpdateTotalAmount()
        {
            decimal sum = 0;

            // Check if the DataGridView has rows
            if (dataGridView1.Rows.Count > 0)
            {
                // Iterate over each row
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Check if the cell value is not null and the cell index is valid
                    if (row.Cells.Count > 6 && row.Cells[6].Value != null)
                    {
                        sum += Convert.ToDecimal(row.Cells[6].Value);
                    }
                }
            }

            // Update the label with the calculated total amount
            lblTotAmount.Text = sum.ToString();
            if (txtPaidAmount.Text != "")
            {
                lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            TicketMasterSecond TicketMasterSecondForm = new TicketMasterSecond(LblLoggedUser.Text,UserId.ToString());
            TicketMasterSecondForm.Show();
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
                    SqlCommand cmd = new SqlCommand("exec sp_GetBarcodeDetails '" + txtBarcodeNo.Text + "' ", conn);
                    string TicketType = "";
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
                        ProjectName = rdr["ProjectName"].ToString();
                        TicketNo = rdr["TicketNo"].ToString();
                        TicketType = rdr["TicketType"].ToString();
                        TActivity = rdr["TActivity"].ToString();
                        UnitPrice = rdr["UnitPrice"].ToString();
                        SaleCount = rdr["TicketSaleCount"].ToString();
                    }
                    if (Convert.ToInt32(SaleCount) > 0)
                    {
                        System.Windows.MessageBox.Show("Item already exists.");
                        this.WindowState = FormWindowState.Maximized;
                        return;
                    }
                    else
                    {
                        ////----------------------  ///// Assuming listView1 is your ListView control

                        string newItemText = TicketNo;

                        // Check if the item already exists
                        bool itemExists = false;
                        foreach (ListViewItem item in listViewTktDetails.Items)
                        {
                            if (item.SubItems[0].Text == newItemText)
                            {
                                itemExists = true;
                                break;
                            }
                        }

                        if (itemExists)
                        {
                            System.Windows.MessageBox.Show("Item already exists.");
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else if (itemExists == false)
                        {
                            // Create a new ListViewItem object with the desired text
                            ListViewItem newItem = new ListViewItem(new string[] { TicketNo, UnitPrice });

                            listViewTktDetails.Items.Add(newItem);


                            conn.Close();
                            if (dataGridView1.Rows.Count > 0)
                            {
                                bool valueExists = false;

                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[0].Value != null)
                                    {
                                        string Project = row.Cells[0].Value.ToString();
                                        string TktType = row.Cells[1].Value.ToString();
                                        string TktActivity = row.Cells[2].Value.ToString();
                                        string TktCount = row.Cells[3].Value.ToString();

                                        if (ProjectName == Project && TicketType == TktType && TActivity == TktActivity)
                                        {
                                            row.Cells[3].Value = (Convert.ToInt32(TktCount) + 1).ToString();
                                            row.Cells[6].Value = ((Convert.ToInt32(TktCount) + 1) * (Convert.ToDecimal(UnitPrice))).ToString();
                                            lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                                            valueExists = true;
                                            break;
                                        }

                                    }
                                }
                                if (!valueExists)
                                {
                                    this.dataGridView1.Rows.Add(ProjectName, TicketType, TActivity, 1, UnitPrice, 0, UnitPrice);
                                    lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                                }
                            }
                            else
                            {
                                this.dataGridView1.Rows.Add(ProjectName, TicketType, TActivity, 1, UnitPrice, 0, UnitPrice);
                                lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
                            }

                            decimal sum = 0;
                            int QtySum = 0;

                            // Check if the DataGridView has rows
                            if (dataGridView1.Rows.Count > 0)
                            {
                                // Iterate over each row
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    // Check if the cell value is not null and the cell index is valid
                                    if (row.Cells.Count > 6 && row.Cells[6].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                                    {
                                        sum += Convert.ToDecimal(row.Cells[6].Value);
                                    }

                                    if (row.Cells.Count > 3 && row.Cells[3].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                                    {
                                        QtySum += Convert.ToInt32(row.Cells[3].Value);
                                    }
                                }
                            }

                            // Update labels with calculated values
                            lblTotAmount.Text = sum.ToString();
                            lblNoOfQtySold.Text = QtySum.ToString();
                            if (txtPaidAmount.Text != "")
                            {
                                lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
                            }
                        }
                        
                        txtBarcodeNo.Clear();
                        e.Handled = true;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Incorrect Barcode Length !");
                    
                }
                }
           
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            Form BillVoid = new BillVoid(LblLoggedUser.Text, UserId.ToString());
           // this.Hide();
            BillVoid.Show();


            //this.Hide();
            //VoidBill voidBillForm = new VoidBill();
            //voidBillForm.Show();
        }

       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LblLoggedUser_Click(object sender, EventArgs e)
        {

        }

        List<string> enteredValues = new List<string>();

        private void txtBarcodeNo_TextChanged(object sender, EventArgs e)
        {
            //string enteredValue = txtBarcodeNo.Text;
            //if (!string.IsNullOrEmpty(enteredValue))
            //{
            //    enteredValues.Add(enteredValue);
            //}
        }

      

     
      

        private void button8_Click(object sender, EventArgs e)
        {
            TourGuide TourGuideForm = new TourGuide(LblLoggedUser.Text,UserId.ToString());
            TourGuideForm.Show();

            //dataGridView1.Rows.Clear();
            //lblNoOfTktType.Text = "0";
            //lblBalance.Text = "0";
            //lblNoOfQtySold.Text = "0";
            //txtPaidAmount.Text = "0";
            //lblTotAmount.Text = "0";
            //listViewTktDetails.Items.Clear();
            //txtBarcodeNo.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // OpenCashDrawer();
            BillDetailPrint BillDetailPrintForm = new BillDetailPrint();
            BillDetailPrintForm.Show();


            //try
            //{
            //    // Load the Crystal Report document
            //    ReportDocument reportDocument = new ReportDocument();
            //    string reportFilePath = Path.Combine(Application.StartupPath, "Report", "TicketBill.rpt");
            //    reportDocument.Load(reportFilePath);

            //    // Set up print options
            //    PrintOptions printOptions = reportDocument.PrintOptions;
            //    printOptions.PrinterName = ""; // Use default printer

            //    // Print the report directly to the default printer
            //    reportDocument.PrintToPrinter(1, false, 0, 0);

            //    // Dispose the report document after printing
            //    reportDocument.Close();
            //    reportDocument.Dispose();
            //}
            //catch (NullReferenceException ex)
            //{
            //    MessageBox.Show("Null reference exception occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketCounter ticketCounterForm = new TicketCounter(UserId.ToString(),LblLoggedUser.Text);
            ticketCounterForm.Show();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Load the Crystal Report document
            //    ReportDocument reportDocument = new ReportDocument();
            //    string reportFilePath = Path.Combine(System.Net.Mime.MediaTypeNames.Application.StartupPath, "Report", "TKTBarcode.rpt");
            //    reportDocument.Load(reportFilePath);

            //    // Set up print options
            //    PrintOptions printOptions = reportDocument.PrintOptions;
            //    printOptions.PrinterName = ""; // Use default printer

            //    // Use a HashSet to store printed values (efficient for duplicate checking)
            //    HashSet<string> printedValues = new HashSet<string>();

            //    // Loop through each entered value
            //    foreach (string enteredValue in enteredValues)
            //    {
            //        // Check if value length is 10 characters and not already printed
            //        if (enteredValue.Length == 10 && !printedValues.Contains(enteredValue))
            //        {
            //            // Prepare the data to pass to the report
            //            reportDocument.SetParameterValue("@TicketNo", enteredValue);

            //            // Print the report directly to the default printer
            //            reportDocument.PrintToPrinter(1, false, 0, 0);

            //            // **Reset report document data after printing**
            //            reportDocument.SetParameterValue("@TicketNo", "");  // Clear the parameter

            //            // Add printed value to the HashSet
            //            printedValues.Add(enteredValue);
            //        }
            //    }

            //    // Inform the user that all reports have been printed
            //    System.Windows.MessageBox.Show("All reports have been printed.", "Information");
            //    //MessageBox.Show("All reports have been printed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (NullReferenceException ex)
            //{
            //    System.Windows.MessageBox.Show("Null reference exception occurred: ");
            //   // MessageBox.Show("Null reference exception occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show("An error occurred: " + ex.Message, "Error");
            //   // MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void TicketMaster_Load(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
            //btnBillEnter.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = (2 * 60 * 1000); // 2 * 60 secs  - 2 minitutes
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GETVisitorCount();
        }

            public void GetLastLogDetails(string UserID,string IPAdrz)
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            string query = "exec Get_UserLogDetails '" + UserID+"','"+IPAdrz+"'";
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
                    lblCurrentCounter.Text = reader["CurrentCounter"].ToString();
                }
                reader.Close();
            }

            conn.Close();
        }

        private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaidAmount.Text != "")
                {
                    lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
                }


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelEntryPoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TicketCounter ticketCounterForm = new TicketCounter(UserId.ToString(),LblLoggedUser.Text);
            ticketCounterForm.Show();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            TicketPricing TktPrice = new TicketPricing();
            TktPrice.Show();
        }

        private void BtnDayEnd_Click(object sender, EventArgs e)
        {
            DayEnd DayEnd = new DayEnd();
            DayEnd.Show();
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

        private void btnClearSingle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                    string ProjectName = row.Cells[0].Value?.ToString();
                    string TKTType = row.Cells[1].Value?.ToString();
                    string Activity = row.Cells[2].Value?.ToString();
                    string NoOfTicket = row.Cells[3].Value?.ToString();
                    string TKTFrontFourNo = "";
                    dataGridView1.Rows.Remove(row);


                    if (conn.State.ToString() == "Closed")
                    {
                        conn.Open();
                    }
                    SqlCommand command = new SqlCommand("exec [sp_ChecksimilarTickets] '"+ ProjectName + "','"+TKTType+"','"+ Activity + "'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TKTFrontFourNo = reader["TKTFrontFour"].ToString();
                      
                    }
                    conn.Close();

                    foreach (ListViewItem item in listViewTktDetails.Items)
                    {
                        string text = item.SubItems[0].Text;
                        string firstFourDigits = text.Length >= 4 ? text.Substring(0, 4) : text;

                        if (firstFourDigits == TKTFrontFourNo) // Adjust index as needed
                        {
                            listViewTktDetails.Items.Remove(item);
                           
                        }
                    }
                }


            }

            decimal sum = 0;
            int QtySum = 0;

            // Check if the DataGridView has rows
            //if (dataGridView1.Rows.Count > 0)
            //{
                // Iterate over each row
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Check if the cell value is not null and the cell index is valid
                    if (row.Cells.Count > 6 && row.Cells[6].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                    {
                        sum += Convert.ToDecimal(row.Cells[6].Value);
                    }

                    if (row.Cells.Count > 3 && row.Cells[3].Value != null && row.Cells.Count > 6 && row.Cells[6].Value != "")
                    {
                        QtySum += Convert.ToInt32(row.Cells[3].Value);
                    }
                }

                lblNoOfTktType.Text = dataGridView1.Rows.Count.ToString();
          //  }

            // Update labels with calculated values
            lblTotAmount.Text = sum.ToString();
            lblNoOfQtySold.Text = QtySum.ToString();

            if (txtPaidAmount.Text != "")
            {
                lblBalance.Text = (Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(lblTotAmount.Text)).ToString();
            }

            //// Remove selected item from ListView
            //if (listViewTktDetails.SelectedItems.Count > 0)
            //{
            //    foreach (ListViewItem item in listViewTktDetails.SelectedItems)
            //    {
            //        listViewTktDetails.Items.Remove(item);
            //    }
            //}
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

            SqlCommand command = new SqlCommand("exec [sp_SearchTourGuide]'"+textBoxTGContactNo.Text+"'", conn);

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
        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void buttonFindTG_Click(object sender, EventArgs e)
        {
            GETTourGuideDetails();
        }

        private void BtnTGClear_Click(object sender, EventArgs e)
        {
            lblTGComanyName.Text = String.Empty;
            lblTGId.Text = String.Empty;
            lblTGName.Text = String.Empty;
            lblTGNIC.Text = String.Empty;
            lblTourGuideNo.Text = String.Empty;
        }

        string TicketNo = "";
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in listViewTktDetails.Items)
            {
                string text = item.SubItems[0].Text;

                TicketNo = text;

                getTicketDetails(TicketNo);

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument1;
               // previewDialog.ShowDialog();
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
            Font MediumFont = new Font("Arial", 9, System.Drawing.FontStyle.Regular);
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

            // Centered content lines
            string[] ticketDetails = {
    "Ticket Location: " + lblProjectName.Text,
    "Ticket Type: " + lblTicketType.Text,
    "Ticket Activity: " + lblTActivity.Text,
    "Ticket Price: " + lblUnitPrice.Text
};

            foreach (string detail in ticketDetails)
            {
                Font currentFont = detail.StartsWith("Ticket Location") ? MediumFont : NormalFont;
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

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}