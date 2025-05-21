using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class BillDetailPrint : Form
    {
        string connetionString = null;
        SqlConnection conn;
        public BillDetailPrint()
        {
            InitializeComponent();
            connetionString = "Data Source=172.188.50.9;Initial Catalog=VM;User ID=user1;Password=iliyana1997vera++";
            this.WindowState = FormWindowState.Maximized;

            datagvBillDetails.AutoGenerateColumns = false;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            BindGridviewPackingData();           
           
        }

        protected void BindGridviewPackingData()
        {
            // this.dataGridViewPackingDetail.DefaultCellStyle.Font = new Font("Tahoma", 14);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = null;

            sql = "exec sp_SearchDayBillNo '" + DPFromdate.Value + "','" + txtBillNo.Text + "'";


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

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }

        private void BillDetailPrint_Load(object sender, EventArgs e)
        {
            DPFromdate.Value = DateTime.Today;
           
        }

        private void datagvBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagvBillDetails.Columns[e.ColumnIndex].Name == "BtnPrint")
            {
                string BillID = datagvBillDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblBillID.Text = BillID.ToString();
                string BillNo = datagvBillDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblBillNo.Text = BillNo.ToString();
                string BillCashier = datagvBillDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                lblBillCashier.Text = BillCashier.ToString();
                string BillDate = datagvBillDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                lblBillDate.Text = BillDate.ToString();
                string BillTime = datagvBillDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                labelBillTime.Text = BillTime.ToString();

                string PaidAmount = datagvBillDetails.Rows[e.RowIndex].Cells[8].Value.ToString();
                lblPaidAmount.Text = PaidAmount.ToString();
                string Balance = datagvBillDetails.Rows[e.RowIndex].Cells[9].Value.ToString();
                lblBalance.Text = Balance.ToString();

                LoadBillingData(Convert.ToInt32(BillID));

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument1;
                previewDialog.ShowDialog();
                // MessageBox.Show("Test !");
            }

            if (datagvBillDetails.Columns[e.ColumnIndex].Name == "BillNo")
            {
                string BillID = datagvBillDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblBillID.Text = BillID.ToString();

                BillDetail frmBillDetail = new BillDetail(BillID);
                frmBillDetail.Show();

            }

        }

        public class BillingItem
        {
            public string ProjectName { get; set; }
            public string TicketType { get; set; }
            public decimal Amount { get; set; }
                       public int Quantity { get; set; }
        }

        private List<BillingItem> billingItems = new List<BillingItem>();
        private void LoadBillingData(int billId)
        {
            billingItems.Clear();


            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                string query = @"exec [Get_BillSummaryDetail] @BillId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BillId", billId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            billingItems.Add(new BillingItem
                            {
                                ProjectName = reader["ProjectName"].ToString(),
                                TicketType = reader["TicketType"].ToString(),
                                Amount = Convert.ToDecimal(reader["Amount"]),
                                Quantity = Convert.ToInt32(reader["TKTQTY"])
                            });
                        }
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set font and brush
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.Black;
            float yPos = 20; // Starting Y position
            float xPos = 10;  // Starting X position



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
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font NormalFont = new Font("Arial", 8, FontStyle.Regular);
            SizeF headerSize = e.Graphics.MeasureString(header, headerFont);
            float centerX = (e.PageBounds.Width - headerSize.Width) / 2;

            e.Graphics.DrawString(header, headerFont, brush, centerX, yPos);
            yPos += 20;
            e.Graphics.DrawString("No.320, D.R. Wijewardhana Mawatha, Colombo10.", NormalFont, brush, 15, yPos);
            yPos += 20;           
            e.Graphics.DrawString("Tel : +94 112 108 300 | email : info@colombolotustower.lk", NormalFont, brush, 5, yPos);
            yPos += 20;
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), NormalFont, brush, 75, yPos);
            yPos += 20;

            //Line
            float lineStartX = 10; // Same as your content start X
            float lineEndX = e.PageBounds.Width - 10; // Adjust based on desired right margin
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);
            // End Line


            yPos += 20;
            e.Graphics.DrawString("Bill No :" + lblBillNo.Text, new Font("Arial", 8, FontStyle.Regular), brush, xPos, yPos);
            yPos += 20;
            e.Graphics.DrawString("Bill Date :" + lblBillDate.Text, new Font("Arial", 8, FontStyle.Regular), brush, xPos, yPos);
            yPos += 20;
            e.Graphics.DrawString("Bill Time :" + labelBillTime.Text, new Font("Arial", 8, FontStyle.Regular), brush, xPos, yPos);
            yPos += 20;
            e.Graphics.DrawString("Cashier :" + lblBillCashier.Text, new Font("Arial", 8, FontStyle.Regular), brush, xPos, yPos);
            yPos += 20;


            //Line
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);
            // End Line
            yPos += 20;


            // Table column widths (adjust based on paper size)
            int colProjectWidth = 100;
            int colTypeWidth = 80;
            int colQtyWidth = 50;
            int colUnitPriceWidth = 60;
            int colAmountWidth = 60;

            // Table start position
            int tableStartX = (int)xPos;  // Keep same as xPos from earlier
            int rowHeight = 25;

            // Table headers
            e.Graphics.DrawString("Project Name", font, brush, tableStartX, yPos);
            e.Graphics.DrawString("Ticket Type", font, brush, tableStartX + colProjectWidth, yPos);
            e.Graphics.DrawString("Qty", font, brush, tableStartX + colProjectWidth + colTypeWidth, yPos);
            e.Graphics.DrawString("Unit Price", font, brush, tableStartX + colProjectWidth + colTypeWidth + colQtyWidth, yPos);
            e.Graphics.DrawString("Amount", font, brush, tableStartX + colProjectWidth + colTypeWidth + colQtyWidth  + colUnitPriceWidth, yPos);
            yPos += rowHeight;

            // Optional: underline headers
            e.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + colProjectWidth + colTypeWidth + colQtyWidth + colUnitPriceWidth + colAmountWidth, yPos);
            yPos += 5;

            decimal totalAmount = 0;
            int NoOFTkt = 0;
            
            // Table rows
            foreach (var item in billingItems)
            {

                string amountStr2 = $"Rs. {item.Amount * item.Quantity:N2}";
                SizeF amountSize = e.Graphics.MeasureString(amountStr2, font);
                float amountColX = tableStartX + colProjectWidth + colTypeWidth + colQtyWidth+colUnitPriceWidth;
                float rightAlignXX = amountColX + colAmountWidth - amountSize.Width;


                e.Graphics.DrawString(item.ProjectName, font, brush, tableStartX, yPos);
                e.Graphics.DrawString(item.TicketType, font, brush, tableStartX + colProjectWidth, yPos);
                e.Graphics.DrawString(item.Quantity.ToString(), font, brush, tableStartX + colProjectWidth + colTypeWidth, yPos);
                e.Graphics.DrawString(item.Amount.ToString(), font, brush, tableStartX + colProjectWidth + colTypeWidth+colQtyWidth, yPos);
                string amountStr = $"{item.Amount * item.Quantity:N2}";
                e.Graphics.DrawString(amountStr, font, brush, rightAlignXX, yPos);

                totalAmount += item.Amount * item.Quantity;
                NoOFTkt += item.Quantity;
                yPos += rowHeight;
            }

            // Optional: draw border (if you want to simulate a real table, use this loop to draw rectangles)
            int totalTableWidth = colProjectWidth + colTypeWidth + colQtyWidth + colAmountWidth;
            int numRows = billingItems.Count + 1; // +1 for headers
            float tableYStart = yPos - (numRows * rowHeight);

            for (int i = 0; i < numRows; i++)
            {
                float rowY = tableYStart + i * rowHeight;
               // e.Graphics.DrawRectangle(Pens.Crimson, tableStartX, rowY, totalTableWidth, rowHeight);
            }

            // Print total
            yPos += 10;

            //Line
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);
            // End Line

            yPos += 30;

            Font totalFont = new Font("Arial", 8, FontStyle.Bold);

            // Right-align the Total line
            string totalText = $"Total: Rs. {totalAmount:N2}";
            SizeF totalSize = e.Graphics.MeasureString(totalText, totalFont);
            float rightAlignX = e.PageBounds.Width - totalSize.Width - 30; // 10 is right margin
            e.Graphics.DrawString(totalText, totalFont, brush, rightAlignX, yPos);
            yPos += 25;

            // Right-align the Paid Amount line
            string PaidAmountText = $"Paid Amount:  {lblPaidAmount.Text:N2}";
            SizeF paidSize = e.Graphics.MeasureString(PaidAmountText, totalFont);
            float paidX = e.PageBounds.Width - paidSize.Width - 30;
            e.Graphics.DrawString(PaidAmountText, totalFont, brush, paidX, yPos);
            yPos += 25;

            // Right-align the Balance line
            string BalanceText = $"Balance:  {lblBalance.Text:N0}";
            SizeF balanceSize = e.Graphics.MeasureString(BalanceText, totalFont);
            float balanceX = e.PageBounds.Width - balanceSize.Width - 30;
            e.Graphics.DrawString(BalanceText, totalFont, brush, balanceX, yPos);
            yPos += 25;

            // Right-align the No. Of Tickets line
            string NoOfTktText = $"No. Of Tickets:  {NoOFTkt:N0}";
            SizeF ticketSize = e.Graphics.MeasureString(NoOfTktText, totalFont);
            float ticketX = e.PageBounds.Width - ticketSize.Width - 30;
            e.Graphics.DrawString(NoOfTktText, totalFont, brush, ticketX, yPos);
            yPos += 25;

            //Line
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPos, lineEndX, yPos);
            // End Line
            yPos += 15;

            // Center-align the Thank You message
            string thankYouText = "Thank You! Visit Again.";
            SizeF thankYouSize = e.Graphics.MeasureString(thankYouText, font);
            float centerXA = (e.PageBounds.Width - thankYouSize.Width) / 2;
            e.Graphics.DrawString(thankYouText, NormalFont, brush, centerXA, yPos);


            
        }
    }
}
