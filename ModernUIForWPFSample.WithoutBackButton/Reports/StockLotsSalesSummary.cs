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
    public partial class StockLotsSalesSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;
        String to, from;

        public StockLotsSalesSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        public StockLotsSalesSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        public StockLotsSalesSummary(String iFrom, String iTo)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            to = iTo;
            from = iFrom;
            month = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void StockLotsSalesSummary_Load(object sender, EventArgs e)
        {
            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the Selling Shipments data for year
                this.BnSFrequencyTableAdapter.Fill(this.DataSet1.BnSFrequency, year);
            }

            // If user want to generate monthly report
            else if (month > 0)
            {
                // Fill the Selling Shipments data for month
                this.BnSFrequencyTableAdapter.Filltbl(this.DataSet1.BnSFrequency, year,month);
            }

            else
            {
                // Fill the Selling Shipments data for month
                this.BnSFrequencyTableAdapter.FillByRange(this.DataSet1.BnSFrequency, from,to);
            }
            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
