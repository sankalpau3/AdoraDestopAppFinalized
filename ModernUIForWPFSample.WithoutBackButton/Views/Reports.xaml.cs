using FirstFloor.ModernUI.Windows.Controls;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using ModernUIForWPFSample.WithoutBackButton.Reports;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        LoginDetails _userType = new LoginDetails();

        public Reports()
        {
            InitializeComponent();    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs StockLotsSales = new ReportInputs("Stock Lots Sales");
            StockLotsSales.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs StockLotsPurchases = new ReportInputs("Stock Lots Purchases");
            StockLotsPurchases.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs StockLotsOverview = new ReportInputs("Stock Lots Overview");
            StockLotsOverview.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs FabricPurchasingSummary = new ReportInputs("Fabric Purchases Summary");
            FabricPurchasingSummary.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs AccessoriesPurchasingSummary = new ReportInputs("Accessories Purchases Summary");
            AccessoriesPurchasingSummary.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs FobPurchasingSummary = new ReportInputs("Fob Purchases Summary");
            FobPurchasingSummary.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs FobSalesSummary = new ReportInputs("Fob Sales Summary");
            FobSalesSummary.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs FixedOverheadsSummary = new ReportInputs("Fixed Overheads Summary");
            FixedOverheadsSummary.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs StockInHandSummary = new ReportInputs("Stock In Hand Summary");
            StockInHandSummary.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            // Create a instance of ReportInputs class to get use inputs to customize the report
            ReportInputs AnalyticalSummary = new ReportInputs("Analytical Summary");
            AnalyticalSummary.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
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
