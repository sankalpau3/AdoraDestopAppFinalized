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
    public partial class StockInHandSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;
        String from, to;

        // This constructor is excecuted when yearly report is generated
        public StockInHandSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public StockInHandSummary(int iYear, int iMonth)
        {
            InitializeComponent();

            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        public StockInHandSummary(string iFrom, string iTo)
        {
            InitializeComponent();

            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            from = iFrom;
            to = iTo;
            month = -1;
        }

        private void StockInHandSummary_Load(object sender, EventArgs e)
        {  
            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the Stock In Hand data for year
                this.StockInHandTableAdapter.Fill(this.DataSet1.StockInHand, year);
            }

             // If user want to generate monthly report
            else if (month > 0)
            {
                // Fill the Stock In Hand data for month
                this.StockInHandTableAdapter.Filltbl(this.DataSet1.StockInHand, year,month);
            }
            else 
            {
                DateTime fromDate = DateTime.ParseExact(from, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(to, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                // Fill the Stock In Hand data for month
                this.StockInHandTableAdapter.FillByRange(this.DataSet1.StockInHand, fromDate, toDate);
            }

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
