using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUIForWPFSample.WithoutBackButton.Reports
{
    public partial class ReportInputs : Form
    {
        // Variable to hold the report Type
        String reportType = null;

        public ReportInputs(String type)
        {
            InitializeComponent();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // make the combo boxes non typeble
            dropYear.DropDownStyle=ComboBoxStyle.DropDownList;
            dropMonth.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add years from 2012 onwards till current year
            for (int i = 2012; i <= DateTime.Today.Year; i++)
            {
                dropYear.Items.Add(i);
            }

            // Initialize the report type variable
            reportType = type;

            if (type == "Analytical Summary" || type == "Fixed Overheads Summary" || type == "Accessories Purchases Summary" || type == "Fabric Purchases Summary" || type == "Fob Purchases Summary")
            {
                radioRange.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioMonthly_CheckedChanged(object sender, EventArgs e)
        {
            // Enable month selection combo box
            dropMonth.Enabled = true;
            dropYear.Enabled = true;
            fromDatePicker.Enabled = false;
            toDatePicker.Enabled = false;
        }

        private void radioYearly_CheckedChanged(object sender, EventArgs e)
        {
            // Disable month selection combo box
            dropYear.Enabled = true;
            dropMonth.Enabled = false;
            fromDatePicker.Enabled = false;
            toDatePicker.Enabled = false;
        }

        /* This method loads month according to the selected year
         * @param cmbYear : ComboBox instance which represents available years
         * @param cmbMonth : ComboBox instance which represents available months
         * @returns nothing
         */
        private void loadMonthsAccordingToYear(ComboBox cmbYear, ComboBox cmbMonth)
        {
            // Get Current Date and Time
            DateTime now = DateTime.Today;
            string[] monthsToCombobox = DateTimeFormatInfo.CurrentInfo.MonthNames;

            cmbMonth.Items.Clear();
            
            // If the selected year is current year
            if (cmbYear.SelectedItem.ToString() == now.Year.ToString())
            {
                for (int i = 0; i < now.Month; i++)
                {
                    cmbMonth.Items.Add(monthsToCombobox[i]);
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    cmbMonth.Items.Add(monthsToCombobox[i]);
                }
            }
        }

        private void dropYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMonthsAccordingToYear(dropYear, dropMonth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If the report generation type is monthly
            if (radioMonthly.Checked == true)
            {
                // If a year and a month is selected
                if (dropYear.SelectedIndex > -1 && dropMonth.SelectedIndex > -1)
                {
                    // Get the ID of the selected month name
                    int month = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(dropMonth.SelectedItem.ToString()) + 1;

                    if (reportType == "Stock Lots Sales")
                    {
                        StockLotsSalesSummary report = new StockLotsSalesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Stock Lots Purchases")
                    {
                        StockLotsPurchasesSummary report = new StockLotsPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Stock Lots Overview")
                    {
                        StockLotsOverview report = new StockLotsOverview(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Fabric Purchases Summary")
                    {
                        FabricPurchasesSummary report = new FabricPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Accessories Purchases Summary")
                    {
                        AccessoriesPurchasesSummary report = new AccessoriesPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Fob Purchases Summary")
                    {
                        FobPurchasesSummary report = new FobPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Fob Sales Summary")
                    {
                        FobSalesSummary report = new FobSalesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Fixed Overheads Summary")
                    {
                        FixedOverheadsSummary report = new FixedOverheadsSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Stock In Hand Summary")
                    {
                        StockInHandSummary report = new StockInHandSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    else if (reportType == "Analytical Summary")
                    {
                        AnalyticalSummary report = new AnalyticalSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()), month);
                        report.Show();
                    }
                    this.Dispose();
                }
            }

            // If the selected report generation type is yearly
            else if (radioYearly.Checked == true)
            {
                // If a year is selected from the combobox
                if (dropYear.SelectedIndex > -1)
                {
                    if (reportType == "Stock Lots Sales")
                    {
                        StockLotsSalesSummary report = new StockLotsSalesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Stock Lots Purchases")
                    {
                        StockLotsPurchasesSummary report = new StockLotsPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Stock Lots Overview")
                    {
                        StockLotsOverview report = new StockLotsOverview(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Fabric Purchases Summary")
                    {
                        FabricPurchasesSummary report = new FabricPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Accessories Purchases Summary")
                    {
                        AccessoriesPurchasesSummary report = new AccessoriesPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Fob Purchases Summary")
                    {
                        FobPurchasesSummary report = new FobPurchasesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Fob Sales Summary")
                    {
                        FobSalesSummary report = new FobSalesSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Fixed Overheads Summary")
                    {
                        FixedOverheadsSummary report = new FixedOverheadsSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Stock In Hand Summary")
                    {
                        StockInHandSummary report = new StockInHandSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    else if (reportType == "Analytical Summary")
                    {
                        AnalyticalSummary report = new AnalyticalSummary(System.Convert.ToInt32(dropYear.SelectedItem.ToString()));
                        report.Show();
                    }
                    this.Dispose();
                }
            }
            // If the selected report generation type is Range
                    else if (radioRange.Checked == true)
                    {
                        string from = fromDatePicker.Value.ToString("yyyy-MM-dd");
                        string to = toDatePicker.Value.ToString("yyyy-MM-dd");
                       
                        if (reportType == "Stock Lots Sales")
                        {
                            StockLotsSalesSummary report = new StockLotsSalesSummary(from,to);
                            report.Show();
                        }
                        else if (reportType == "Stock Lots Purchases")
                        {
                            StockLotsPurchasesSummary report = new StockLotsPurchasesSummary(from,to);
                            report.Show();
                        }
                        else if (reportType == "Stock Lots Overview")
                        {
                            StockLotsOverview report = new StockLotsOverview(from,to);
                            report.Show();
                        }
                        else if (reportType == "Fabric Purchases Summary")
                        {
                            //FabricPurchasesSummary report = new FabricPurchasesSummary(from,to);
                            //report.Show();
                        }
                        else if (reportType == "Accessories Purchases Summary")
                        {
                            //AccessoriesPurchasesSummary report = new AccessoriesPurchasesSummary(from,to);
                            //report.Show();
                        }
                        else if (reportType == "Fob Purchases Summary")
                        {
                            //FobPurchasesSummary report = new FobPurchasesSummary(from,to);
                            //report.Show();
                        }
                        else if (reportType == "Fob Sales Summary")
                        {
                            FobSalesSummary report = new FobSalesSummary(from,to);
                            report.Show();
                        }
                        else if (reportType == "Fixed Overheads Summary")
                        {
                            //FixedOverheadsSummary report = new FixedOverheadsSummary(from,to);
                            //report.Show();
                        }
                        else if (reportType == "Stock In Hand Summary")
                        {
                            StockInHandSummary report = new StockInHandSummary(from,to);
                            report.Show();
                        }
                        else if (reportType == "Analytical Summary")
                        {
                            //AnalyticalSummary report = new AnalyticalSummary(from,to);
                            //report.Show();
                        }

                        // Colse this form
                        this.Dispose();
                    }
                
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dropMonth.Enabled = false;
            dropYear.Enabled = false;
            fromDatePicker.Enabled = true;
            toDatePicker.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dropMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
