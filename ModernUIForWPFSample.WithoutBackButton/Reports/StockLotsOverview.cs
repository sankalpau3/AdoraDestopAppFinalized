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
    public partial class StockLotsOverview : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;
        String from, to;

        // This constructor is excecuted when yearly report is generated
        public StockLotsOverview(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public StockLotsOverview(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        public StockLotsOverview(String iFrom, String iTo)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            from = iFrom;
            to = iTo;
            month = -1;
        }
        private void StockLotsOverview_Load(object sender, EventArgs e)
        {
            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the Purchasing Shipments data for year
                this.PurchasingShipmentsTableAdapter.Fill(this.DataSet1.PurchasingShipments, year);

                // Fill the Selling Shipments data for year
                this.BnSFrequencyTableAdapter.Fill(this.DataSet1.BnSFrequency,year);
            }

            // If user want to generate monthly report
            else if (month > 0)
            {
                // Fill the Purchasing Shipments data for month
                this.PurchasingShipmentsTableAdapter.Filltbl(this.DataSet1.PurchasingShipments, year, month);

                // Fill the Selling Shipments data for month
                this.BnSFrequencyTableAdapter.Filltbl(this.DataSet1.BnSFrequency,year,month);
            }

            else
            {
                DateTime fromDate = DateTime.ParseExact(from, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(to, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

                // Fill the Purchasing Shipments data for month
                this.PurchasingShipmentsTableAdapter.FillByRange(this.DataSet1.PurchasingShipments, fromDate, toDate);

                // Fill the Selling Shipments data for month
                this.BnSFrequencyTableAdapter.FillByRange(this.DataSet1.BnSFrequency, from, to);
            }

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
