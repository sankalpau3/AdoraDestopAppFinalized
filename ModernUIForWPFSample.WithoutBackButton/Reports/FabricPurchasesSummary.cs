using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    public partial class FabricPurchasesSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;

        // This constructor is excecuted when yearly report is generated
        public FabricPurchasesSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public FabricPurchasesSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        private void FabricPurchasesSummary_Load(object sender, EventArgs e)
        {
            // variables to pass as parameters to the report
            // This set of variables are to hold total Yardage for each category
            double? cotton = 0;
            double? poly =0;
            double? nylone =0;
            double? pont = 0;

            // This set of variables are to hold total cost for each category
            double? cottonSum = 0;
            double? polySum = 0;
            double? nyloneSum = 0;
            double? pontSum = 0;

            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the Fabrics data for year
                this.FabricTableAdapter.Fill(this.DataSet1.Fabric, year);

                // Get and store Yardage data for each category through the table adapters
                cotton = this.FabricTableAdapter.YearlyByType(year,"Cotton");
                poly = this.FabricTableAdapter.YearlyByType(year,"Polyester");
                nylone = this.FabricTableAdapter.YearlyByType(year,"Nylon");
                pont = this.FabricTableAdapter.YearlyByType(year,"Ponteroma");

                // Get and store Total Cost data for each category through the table adapters
                cottonSum = this.FabricTableAdapter.MonthlySum(year, "Cotton");
                polySum = this.FabricTableAdapter.MonthlySum(year, "Polyester");
                nyloneSum = this.FabricTableAdapter.MonthlySum(year, "Nylon");
                pontSum = this.FabricTableAdapter.MonthlySum(year, "Ponteroma");
            }

            // If user want to generate monthly report
            else
            {
                this.FabricTableAdapter.Filltbl(this.DataSet1.Fabric, year,month);

                // Get and store Yardage data for each category through the table adapters
                cotton = this.FabricTableAdapter.MonthlyByType(year,month,"Cotton");
                poly = this.FabricTableAdapter.MonthlyByType(year,month,"Polyester");
                nylone = this.FabricTableAdapter.MonthlyByType(year,month,"Nylon");
                pont = this.FabricTableAdapter.MonthlyByType(year,month,"Ponteroma");

                // Get and store Total Cost data for each category through the table adapters
                cottonSum = this.FabricTableAdapter.YearlySum(year, month, "Cotton");
                polySum = this.FabricTableAdapter.YearlySum(year, month, "Polyester");
                nyloneSum = this.FabricTableAdapter.YearlySum(year, month, "Nylon");
                pontSum = this.FabricTableAdapter.YearlySum(year, month, "Ponteroma");
            }

            // If database does not return values for each category, make the total cost zero
            if (pontSum == null)
                pontSum = 0;
            if (cottonSum == null)
                cottonSum = 0;
            if (nyloneSum == null)
                nyloneSum = 0;
            if (polySum == null)
                polySum = 0;

            // Create an Array to hold report parameters
            ReportParameter[] parameters = new ReportParameter[8];

            // Define Parameters to be passed to the report
            parameters[0] = new ReportParameter("Cotton", cotton.ToString());
            parameters[1] = new ReportParameter("Polyester",poly.ToString());
            parameters[2] = new ReportParameter("Nylone",nylone.ToString());
            parameters[3] = new ReportParameter("Ponteroma",pont.ToString());

            parameters[4] = new ReportParameter("CottonSum", cottonSum.ToString());
            parameters[5] = new ReportParameter("PolyesterSum", polySum.ToString());
            parameters[6] = new ReportParameter("NyloneSum", nyloneSum.ToString());
            parameters[7] = new ReportParameter("PonteromaSum", pontSum.ToString());

            // Send the defined parameters to the report
            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
