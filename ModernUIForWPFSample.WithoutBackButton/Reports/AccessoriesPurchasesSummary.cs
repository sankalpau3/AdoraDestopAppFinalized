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
    public partial class AccessoriesPurchasesSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;

        // This constructor is excecuted when yearly report is generated
        public AccessoriesPurchasesSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public AccessoriesPurchasesSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        private void AccessoriesPurchasesSummary_Load(object sender, EventArgs e)
        {
            // variables to pass as parameters to the report
            // This set of variables are to hold number of units for each category
            double? islets = 0;
            double? buttons = 0;
            double? zippers = 0;
            double? thread = 0;

            // This set of variables are to hold total cost for each category
            double? isletsSum = 0;
            double? buttonsSum = 0;
            double? zippersSum = 0;
            double? threadSum = 0;

            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the accessories data for year
                this.AccessoriesTableAdapter.Fill(this.DataSet1.Accessories, year);

                // Get and store No of units data for each category through the table adapters
                islets = this.AccessoriesTableAdapter.YearlyByType(year, "Islets (Grams)");
                buttons = this.AccessoriesTableAdapter.YearlyByType(year, "Buttons (Grams)");
                zippers = this.AccessoriesTableAdapter.YearlyByType(year, "Zippers (No.s)");
                thread = this.AccessoriesTableAdapter.YearlyByType(year, "Thread (Yards)");

                // Get and store Total Cost data for each category through the table adapters
                isletsSum = this.AccessoriesTableAdapter.YearlySum(year, "Islets (Grams)");
                buttonsSum = this.AccessoriesTableAdapter.YearlySum(year, "Buttons (Grams)");
                zippersSum = this.AccessoriesTableAdapter.YearlySum(year, "Zippers (No.s)");
                threadSum = this.AccessoriesTableAdapter.YearlySum(year, "Thread (Yards)");

            }
            
            // If user want to generate monthly report
            else
            {
                // Fill the accessories data for month
                this.AccessoriesTableAdapter.Filltbl(this.DataSet1.Accessories, year,month);

                // Get and store No of units data for each category through the table adapters
                islets = this.AccessoriesTableAdapter.Monthly(year, month, "Islets (Grams)");
                buttons = this.AccessoriesTableAdapter.Monthly(year, month,"Buttons (Grams)");
                zippers = this.AccessoriesTableAdapter.Monthly(year, month, "Zippers (No.s)");
                thread = this.AccessoriesTableAdapter.Monthly(year, month, "Thread (Yards)");

                // Get and store Total Cost data for each category through the table adapters
                isletsSum = this.AccessoriesTableAdapter.MonthlySum(year,month, "Islets (Grams)");
                buttonsSum = this.AccessoriesTableAdapter.MonthlySum(year,month ,"Buttons (Grams)");
                zippersSum = this.AccessoriesTableAdapter.MonthlySum(year,month, "Zippers (No.s)");
                threadSum = this.AccessoriesTableAdapter.MonthlySum(year,month, "Thread (Yards)");
            }

            // If database does not return values for each category, make the total cost zero
            if (isletsSum == null)
                isletsSum = 0;
            if (buttonsSum == null)
                buttonsSum = 0;
            if (zippersSum == null)
                zippersSum = 0;
            if (threadSum == null)
                threadSum = 0;

            // Create an Array to hold report parameters
            ReportParameter[] parameters = new ReportParameter[8];

            // Define Parameters to be passed to the report
            parameters[0] = new ReportParameter("Islets", islets.ToString());
            parameters[1] = new ReportParameter("Buttons", buttons.ToString());
            parameters[2] = new ReportParameter("Zippers", zippers.ToString());
            parameters[3] = new ReportParameter("Thread", thread.ToString());

            parameters[4] = new ReportParameter("IsletsSum", isletsSum.ToString());
            parameters[5] = new ReportParameter("ButtonsSum", buttonsSum.ToString());
            parameters[6] = new ReportParameter("ZippersSum", zippersSum.ToString());
            parameters[7] = new ReportParameter("ThreadSum", threadSum.ToString());

            // Send the defined parameters to the report
            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
