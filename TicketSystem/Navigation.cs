using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        //connetionString = "Data Source=72.9.145.118;Initial Catalog=VM;User ID=lotusTest;Password=iliyana1997vera+";
        private void button1_Click(object sender, EventArgs e)
        {
            // Load the report file
            ReportDocument report = new ReportDocument();
            string reportFilePath = Path.Combine(Application.StartupPath, "Report", "CrystalReport3.rpt");
            report.Load(reportFilePath); // Replace with the path to your .rpt file

            // Set up database connection
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "72.9.145.118";
            connectionInfo.DatabaseName = "VM";
            connectionInfo.UserID = "lotusTest";
            connectionInfo.Password = "iliyana1997vera+";

            // Apply connection information to each table in the report
            foreach (Table table in report.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(table.LogOnInfo);
            }

            // Set parameters if needed
            ParameterFieldDefinition parameterField = report.DataDefinition.ParameterFields["BillId"];
            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = "882";
            parameterField.CurrentValues.Add(parameterValue);

            report.PrintOptions.PrinterName = new PrinterSettings().PrinterName;
            //report.PrintToPrinter(1, false, 0, 0);

            //// Set up print options
            //PrintOptions printOptions = report.PrintOptions;
            //printOptions.PrinterName = ""; // Use default printer

            //// Print the report directly to the default printer
            ////  report.PrintToPrinter(1, false, 0, 0);

            //// Dispose the report document after printing
            //report.Close();
            //report.Dispose();

            // // Set the report source and refresh
            //  crystalReportViewer1.ReportSource = report;
            //crystalReportViewer1.Refresh();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {

        }
    }
}
