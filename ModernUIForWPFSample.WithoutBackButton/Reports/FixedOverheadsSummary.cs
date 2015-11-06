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
    public partial class FixedOverheadsSummary : Form
    {
        // Variables to keep year and month
        int year;
        int month = 0;

        // This constructor is excecuted when yearly report is generated
        public FixedOverheadsSummary(int iYear)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year
            year = iYear;
        }

        // This constructor is excecuted when monthly report is generated
        public FixedOverheadsSummary(int iYear, int iMonth)
        {
            InitializeComponent();
            // Center the form in display
            this.CenterToScreen();

            // Initialize year and month
            year = iYear;
            month = iMonth;
        }

        private void FixedOverheadsSummary_Load(object sender, EventArgs e)
        {
            // If user want to generate yearly report
            if (month == 0)
            {
                // Fill the Fixed Overhead data for year
                this.FixedOverheadsTableAdapter.Fill(this.DataSet1.FixedOverheads, year);
            }

            // If user want to generate yearly report
            else
            {
                // Fill the Fixed Overhead data for month
                this.FixedOverheadsTableAdapter.Filltbl(this.DataSet1.FixedOverheads, year, month);
            }

            // Load and refresh the report
            this.reportViewer1.RefreshReport();
        }
    }
}
