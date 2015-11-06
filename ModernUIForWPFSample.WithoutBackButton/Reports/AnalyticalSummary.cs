using Microsoft.Reporting.WinForms;
using ModernUIForWPFSample.WithoutBackButton.Data;
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
    public partial class AnalyticalSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;

        // Data Access Object is created to retrieve required da
        FinalAnalysisDAO _dao = new FinalAnalysisDAO();

        // This constructor is excecuted when yearly report is generated
        public AnalyticalSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public AnalyticalSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        private void AnalyticalSummary_Load(object sender, EventArgs e)
        {
            // variables to pass as parameters to the report
            // This set of variables are to hold data for each category
            double? stkCost = 0;
            double? fobCost = 0;
            
            double? stkRevenue = 0;
            double? fobRevenue = 0;

            double? fohCost = 0;
            double? rentCost = 0;

            // If user want to generate yearly report
            if (month == 0)
            {
                // Get and store data for each category through the Data Access Object
                stkCost = _dao.getStockLotsCostbyYear(year);
                fobCost = _dao.getFobCostbyYear(year);
                stkRevenue = _dao.getStockLotsRevenuebyYear(year);
                fobRevenue = _dao.getFobRevenuebyYear(year);
                fohCost = _dao.getFixedOverheadsCostbyYear(year);
                rentCost = _dao.getRentNTaxbyYear(year);
            }

            // If user want to generate monthly report
            else
            {
                // Get and store data for each category through the Data Access Object
                stkCost = _dao.getStockLotsCostbyMonth(year,month);
                fobCost = _dao.getFobCostbyMonth(year,month);
                stkRevenue = _dao.getStockLotsRevenuebyMonth(year,month);
                fobRevenue = _dao.getFobRevenuebyMonth(year,month);
                fohCost = _dao.getFixedOverheadsCostbyMonth(year,month);
                rentCost = _dao.getRentNTaxbyMonth(year,month);
            }

            // If database does not return values for each category, make the total cost zero
            if (stkCost == null)
                stkCost = 0;
            if (fobCost == null)
                fobCost = 0;
            if (stkRevenue == null)
                stkRevenue = 0;
            if (fobRevenue == null)
                fobRevenue = 0;
            if (fohCost == null)
                fohCost = 0;
            if (rentCost == null)
                rentCost = 0;

            // Create an Array to hold report parameters
            ReportParameter[] parameters = new ReportParameter[6];

            // Define Parameters to be passed to the report
            parameters[0] = new ReportParameter("StkCost", stkCost.ToString());
            parameters[1] = new ReportParameter("FobCost", fobCost.ToString());
            parameters[2] = new ReportParameter("StkRevenue", stkRevenue.ToString());
            parameters[3] = new ReportParameter("FobRevenue", fobRevenue.ToString());
            parameters[4] = new ReportParameter("FohCost", fohCost.ToString());
            parameters[5] = new ReportParameter("RentCost", rentCost.ToString());

            // Send the defined parameters to the report
            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
