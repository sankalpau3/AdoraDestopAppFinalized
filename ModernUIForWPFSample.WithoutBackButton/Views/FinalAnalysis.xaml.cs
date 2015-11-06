using FirstFloor.ModernUI.Windows.Controls;
using ModernUIForWPFSample.WithoutBackButton.Data;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using ModernUIForWPFSample.WithoutBackButton.Graphs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for FinalAnalysis.xaml
    /// </summary>
    /// 

    public partial class FinalAnalysis : UserControl
    {

        adoraDBContext _context;                // Variable to hold DB Context
        FinalAnalysisDAO _dao;                  // Variable to hold data access object
        LoginDetails _userType = new LoginDetails(); //Access Privilages handler

        public FinalAnalysis()
        {
            InitializeComponent();
            _context = new adoraDBContext();                 // Initialize DB Context
            _dao = new FinalAnalysisDAO();                   // Initialize Data access object

            // Set the ChartController class as the dataContext for this class
            DataContext = new ChartController();

            // Yearly radio button is checked defaultly
            radioYearly.IsChecked = true;

            // Yearly radio button in tabular format is checked defaultly
            radioYearly1.IsChecked = true;
           

            // Add years from 2012 onwards till current year
            for (int i = 2012; i <= DateTime.Today.Year; i++)
            {
                dropYear.Items.Add(i);
                dropYear1.Items.Add(i);
            }

            // Select Current Year and month defaultly
            dropYear1.SelectedIndex = dropYear1.Items.Count -1;
            dropMonth1.SelectedIndex = DateTime.Now.Month -1;

            // Populate statistical data
            populateData();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void radioGenerate1_Checked(object sender, RoutedEventArgs e)
        {
          
        }

        private void radioPattern_Checked(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void radioPattern1_Checked(object sender, RoutedEventArgs e)
        {
            
         
        }

        private void radioGenerate_Checked(object sender, RoutedEventArgs e)
        {
            

        }

        private void radioPattern2_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void dropProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void radioPattern2_Checked_1(object sender, RoutedEventArgs e)
        {
         
        }

        private void radioPattern2_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // If the yearly radio button is checked and type is stock lots sales summary
            if (dropChartType.SelectedIndex == 0 && radioYearly.IsChecked == true)
            { 
                // Set the data context to chartController class with chart type stocklots sales by year
                DataContext = new ChartController("StockLotsSalesByYear"); 
            }
            else if (dropChartType.SelectedIndex == 1 && radioYearly.IsChecked == true)
            {
                DataContext = new ChartController("FOBSalesByYear");
            }
            else if (dropChartType.SelectedIndex == 2 && radioYearly.IsChecked == true)
            {
                DataContext = new ChartController("TotalByYear");
            }
            else if (dropChartType.SelectedIndex == 3 && radioYearly.IsChecked == true)
            {
                DataContext = new ChartController("NetProfitByYear");
            }
            
        }

        private void dropYear_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If the generate type is for specific product
            if (dropChartType.SelectedIndex == 4 || dropChartType.SelectedIndex == 5)
            {
                // Enable the product combobox to select products
                dropProduct.IsEnabled = true;
            }
            else
            {
                dropProduct.IsEnabled = false;
            }
        }

        private void radioYearly_Checked(object sender, RoutedEventArgs e)
        {
            // Disable year selection combobox
            dropYear.IsEnabled = false;

        }

        private void radioMonthly_Checked(object sender, RoutedEventArgs e)
        {
            // Enable year selection combobox
            dropYear.IsEnabled = true;
        }

        private void dropYear1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadMonthsAccordingToYear(dropYear1, dropMonth1);
            populateData();
        }

        private void dropYear2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // This method loads months according to selected year
        private void loadMonthsAccordingToYear(ComboBox cmbYear, ComboBox cmbMonth)
        {
            // Get the current date and time
            DateTime now = DateTime.Today;

            // Get the list of month names
            string[] monthsToCombobox = DateTimeFormatInfo.CurrentInfo.MonthNames;

            // Clear the month selection combobox
            cmbMonth.Items.Clear();

            // If the selected year is current year
            if (cmbYear.SelectedItem.ToString() == now.Year.ToString())
            {
                for (int i = 0; i < now.Month; i++)
                {
                    cmbMonth.Items.Add(monthsToCombobox[i]);
                }
            }

            // If the selected year is not the current year
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    cmbMonth.Items.Add(monthsToCombobox[i]);
                }
            }
        }

        // This method displays statistical data if the yearly radio button is selected according to the selected year
        private void displayYealyData(ComboBox cmbYear)
        {
            // If a year is selected
            if (cmbYear.SelectedIndex > -1)
            {
                // Convert and get the selected year
                int year = System.Convert.ToInt32(cmbYear.SelectedValue.ToString());

                // Fill text boxes using Data access objects
                tb11.Text = _dao.getStockLotsCostbyYear(year).ToString("F");
                tb12.Text = _dao.getFobCostbyYear(year).ToString("F");
                tb13.Text = (_dao.getFobCostbyYear(year) + _dao.getStockLotsCostbyYear(year)).ToString("F");

                tb21.Text = _dao.getStockLotsRevenuebyYear(year).ToString("F");
                tb22.Text = _dao.getFobRevenuebyYear(year).ToString("F");
                tb23.Text = (_dao.getFobRevenuebyYear(year) + _dao.getStockLotsRevenuebyYear(year)).ToString("F");

                tb31.Text = (System.Convert.ToDouble(tb21.Text) - System.Convert.ToDouble(tb11.Text)).ToString("F");
                tb32.Text = (System.Convert.ToDouble(tb22.Text) - System.Convert.ToDouble(tb12.Text)).ToString("F");
                tb33.Text = (System.Convert.ToDouble(tb23.Text) - System.Convert.ToDouble(tb13.Text)).ToString("F");

                tb1.Text = tb23.Text;
                tb2.Text = tb13.Text;
                tb3.Text = tb33.Text;
                tb4.Text = _dao.getFixedOverheadsCostbyYear(year).ToString("F");
                tb5.Text = (System.Convert.ToDouble(tb1.Text) - System.Convert.ToDouble(tb4.Text)).ToString("F");
                tb6.Text = (System.Convert.ToDouble(tb5.Text) - _dao.getRentNTaxbyYear(year)).ToString("F");
            }
        }

        // This method displays statistical data if the monthly radio button is selected according to the selected year and month
        private void displayMonthlyData(ComboBox cmbYear, ComboBox cmbMonth)
        {
            // If an year and a month is selected
            if (cmbYear.SelectedIndex > -1 && cmbMonth.SelectedIndex > -1)
            {
                // Convert and get the selected year and the month
                int year = System.Convert.ToInt32(cmbYear.SelectedValue.ToString());
                int month = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(cmbMonth.SelectedValue.ToString()) + 1;

                // Fill text boxes using Data access objects
                tb11.Text = _dao.getStockLotsCostbyMonth(year, month).ToString("F");
                tb12.Text = _dao.getFobCostbyMonth(year, month).ToString("F");
                tb13.Text = (_dao.getFobCostbyMonth(year, month) + _dao.getStockLotsCostbyMonth(year, month)).ToString("F");

                tb21.Text = _dao.getStockLotsRevenuebyMonth(year, month).ToString("F");
                tb22.Text = _dao.getFobRevenuebyMonth(year, month).ToString("F");
                tb23.Text = (_dao.getFobRevenuebyMonth(year, month) + _dao.getStockLotsRevenuebyMonth(year, month)).ToString("F");

                tb31.Text = (System.Convert.ToDouble(tb21.Text) - System.Convert.ToDouble(tb11.Text)).ToString("F");
                tb32.Text = (System.Convert.ToDouble(tb22.Text) - System.Convert.ToDouble(tb12.Text)).ToString("F");
                tb33.Text = (System.Convert.ToDouble(tb23.Text) - System.Convert.ToDouble(tb13.Text)).ToString("F");

                tb1.Text = tb23.Text;
                tb2.Text = tb13.Text;
                tb3.Text = tb33.Text;
                tb4.Text = _dao.getFixedOverheadsCostbyMonth(year, month).ToString("F");
                tb5.Text = (System.Convert.ToDouble(tb1.Text) - System.Convert.ToDouble(tb4.Text)).ToString("F");
                tb6.Text = (System.Convert.ToDouble(tb5.Text) - _dao.getRentNTaxbyMonth(year, month)).ToString("F");
            }
        }

        private void displayYealyFinal(ComboBox cmbYear)
        {

        }

        private void displayMonthlyFinal(ComboBox cmbYear, ComboBox cmbMonth)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void radioYearly1_Checked(object sender, RoutedEventArgs e)
        {
            dropMonth1.IsEnabled = false;

            if (dropYear1.SelectedIndex > -1)
            {
                populateData();
            }
        }

        private void radioMonthly1_Checked(object sender, RoutedEventArgs e)
        {
            dropMonth1.IsEnabled = true;

            if (dropYear1.SelectedIndex > -1 && dropMonth1.SelectedIndex > -1)
            {
                populateData();
            }
        }

        private void radioYearly2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioMonthly2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void populateData()
        {
            if (radioMonthly1.IsChecked == true)
            {
                displayMonthlyData(dropYear1,dropMonth1);
            }
            else
            {
                displayYealyData(dropYear1);
            }
        }


        private void dropMonth1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                pDialog.PrintVisual(this.FrameTest, "User Control Printing."); 
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_userType.getUserLevel() != 1)
            {
                BBCodeBlock bs = new BBCodeBlock();
                try
                {
                    bs.LinkNavigator.Navigate(new Uri("/Views/firstOpen.xaml", UriKind.Relative), this);
                    ModernDialog.ShowMessage("You are not privilaged to access this page", "Access Denied!", MessageBoxButton.OK);
                }
                catch (Exception error)
                {
                    ModernDialog.ShowMessage(error.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
                }
            }
        }
    }
       
}
