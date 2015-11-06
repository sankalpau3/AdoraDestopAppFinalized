using ModernUIForWPFSample.WithoutBackButton.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernUIForWPFSample.WithoutBackButton.Graphs.ViewModels
{
    public class ChartViewModel
    {
        // List structures for holding costs and revenue values by year
        public ObservableCollection<SalesSummaryByYear> Costs { get; private set; }
        public ObservableCollection<SalesSummaryByYear> Revenue { get; private set; }

        public ObservableCollection<SalesSummaryByMonth> CostsMonthly { get; private set; }
        public ObservableCollection<SalesSummaryByMonth> RevenueMonthly { get; private set; }

        public ObservableCollection<SalesSummaryByYear> CostsStock { get; private set; }
        public ObservableCollection<SalesSummaryByYear> RevenueStock { get; private set; }
        public ObservableCollection<SalesSummaryByYear> CostsFob { get; private set; }
        public ObservableCollection<SalesSummaryByYear> RevenueFob { get; private set; }
        public ObservableCollection<SalesSummaryByYear> NetProfit { get; private set; }

        GraphsDAO _dao;     // Variable to hold data access object for graphs

        public ChartViewModel(String type)
        {
            _dao = new GraphsDAO();         // Initialize data access object

            // If the chart type selected is stocklots sales by year
            if (type == "StockLotsSalesByYear")
            {
                // Initialize and load cost data
                Costs = new ObservableCollection<SalesSummaryByYear>();
                loadStockLotsCostData(Costs);

                // Initialize and load revenue data
                Revenue = new ObservableCollection<SalesSummaryByYear>();
                loadStockLotsRevenueData(Revenue);
            }

             // If the chart type selected is Fob sales by year
            else if (type == "FOBSalesByYear")
            {
                // Initialize and load cost data
                Costs = new ObservableCollection<SalesSummaryByYear>();
                loadFobCostData(Costs);

                // Initialize and load revenue data
                Revenue = new ObservableCollection<SalesSummaryByYear>();
                loadFobRevenueData(Revenue);
            }

            // If the chart type selected is Total summary by year
            else if (type == "TotalByYear")
            {
                // Initialize and load cost and revenue data for stock lots
                CostsStock = new ObservableCollection<SalesSummaryByYear>();
                loadStockLotsCostData(CostsStock);
                RevenueStock = new ObservableCollection<SalesSummaryByYear>();
                loadStockLotsRevenueData(RevenueStock);

                // Initialize and load cost and revenue data for FOB items
                CostsFob = new ObservableCollection<SalesSummaryByYear>();
                loadFobCostData(CostsFob);
                RevenueFob = new ObservableCollection<SalesSummaryByYear>();
                loadFobRevenueData(RevenueFob);
                
            }
            
            // If the chart type selected is Net profit by year
            else if (type == "NetProfitByYear")
            {
                // Initialize and load net profit data
                NetProfit = new ObservableCollection<SalesSummaryByYear>();
                loadNetProfitData(NetProfit);
                
            }
        }

        // This method gets the selected item from the chart type combo box available in FinalAnalysis.xaml
        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
            }
        }

        // This is the data structure which holds the cost and revenue data according to their years as objects
        public class SalesSummaryByYear
        {
            public int Year { get; set; }

            public decimal? Cost { get; set; }
        }

        // This is the data structure which holds the cost and revenue data according to their months as objects
        public class SalesSummaryByMonth
        {
            public String Month { get; set; }

            public decimal? Cost { get; set; }
        }

        /* This method returns the month name according to the month id
         * @param id : integer value which represents a month
         * @returns strMonthName : String name of the month for given id
         */
        public String getMonthByID(int id)
        {
            // Create a object to format the month id given
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName(id).ToString();  // Convert month id to month name

            return strMonthName;
        }

        /* This method load the cost data for stock lots
         * @param list : The list to which the data should be stored
         * @returns nothing
         */
        private void loadStockLotsCostData(ObservableCollection<SalesSummaryByYear> list)
        {
            // Get the stock lots cost data by year using GraphsDAO object and store them to IEnumerable list result
            IEnumerable<SalesSummaryDAO> result = _dao.getStockLotsCostDataByYear();

            // Add items in result list to the required list 
            foreach (var d in result)
                list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
        }

        /* This method load the revenue data for stock lots
         * @param list : The list to which the data should be stored
         * @returns nothing
         */
        private void loadStockLotsRevenueData(ObservableCollection<SalesSummaryByYear> list)
        {
            // Get the stock lots revenue data by year using GraphsDAO object and store them to IEnumerable list result
            IEnumerable<SalesSummaryDAO> result = _dao.getStockLotsRevenueDataByYear();

            // Add items in result list to the required list 
            foreach (var d in result)
                list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
        }

        /* This method load the cost data for fob items
         * @param list : The list to which the data should be stored
         * @returns nothing
         */
        private void loadFobCostData(ObservableCollection<SalesSummaryByYear> list)
        {
            // Get the FOB cost data for fabric and accessories separately by year using GraphsDAO object and store them to IEnumerable list result
            IEnumerable<SalesSummaryDAO> fabResult = _dao.getFabricCostDataByYear();
            IEnumerable<SalesSummaryDAO> accResult = _dao.getAccessoryCostDataByYear();

            int fabYears = fabResult.Count();       // Count the number of years in fabric list
            int accYears = accResult.Count();       // Count the number of years in accessories list

            // If the number of years in fabric is greater than accessories
            if (fabYears > accYears)
            {
                // For the same year join and sum the cost for fabric and accessories
                foreach (var d in fabResult)
                    foreach (var x in accResult)
                        if (d.Year == x.Year)
                            list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost + x.Cost });
                        else
                            list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
            }

            // If the number of years in fabric is less than accessories
            else
            {
                // For the same year join and sum the cost for fabric and accessories
                foreach (var d in accResult)
                    foreach (var x in fabResult)
                        if (d.Year == x.Year)
                            list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost + x.Cost });
                        else
                            list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
            }
        }

        /* This method load the revenue data for fob items
         * @param list : The list to which the data should be stored
         * @returns nothing
         */
        private void loadFobRevenueData(ObservableCollection<SalesSummaryByYear> list)
        {
            // Get the FOB revenue data using DAO object and store them in the IEnumerable list
            IEnumerable<SalesSummaryDAO> result = _dao.getFobRevenueDataByYear();

            // Add the items in result list to the required list
            foreach (var d in result)
            {
                list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
            }
        }

        /* This method load the net profit data
         * @param list : The list to which the data should be stored
         * @returns nothing
         */
        private void loadNetProfitData(ObservableCollection<SalesSummaryByYear> list)
        {
            // Get the net profit data using DAO object and store them in the IEnumerable list
            IEnumerable<SalesSummaryDAO> result = _dao.getNetProfitDataByYear();

            // Add the items in result list to the required list
            foreach (var d in result)
            {
                list.Add(new SalesSummaryByYear() { Year = d.Year, Cost = d.Cost });
            }
        }
    }
}
