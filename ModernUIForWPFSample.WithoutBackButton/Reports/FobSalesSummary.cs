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
    public partial class FobSalesSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;
        String from, to;

        // This constructor is excecuted when yearly report is generated
        public FobSalesSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public FobSalesSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        public FobSalesSummary(String iFrom, String iTo)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            from = iFrom;
            to = iTo;
            month = -1;
        }

        private void FobSalesSummary_Load(object sender, EventArgs e)
        {
            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the FOB Slaes data for year
                this.FOBSalesFrequencyTableAdapter.Fill(this.DataSet1.FOBSalesFrequency,year);
            }

            // If user want to generate monthly report
            else if(month > 0)
            {
                // Fill the FOB Slaes data for month
                this.FOBSalesFrequencyTableAdapter.Filltbl(this.DataSet1.FOBSalesFrequency, year,month);
            }

            else 
            {
                // Fill the FOB Slaes data for month
                this.FOBSalesFrequencyTableAdapter.FillByRange(this.DataSet1.FOBSalesFrequency, from, to);
            }

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
