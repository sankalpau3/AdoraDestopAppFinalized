using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class GraphsDAO
    {
        adoraDBContext _context = new adoraDBContext(); //create a new DB CONTEXT

        // This method logs error exceptions using DirAppend class
        private void addException(Exception ex, string methodname)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                DirAppend.Log("____________________________________________________________________", w);
                DirAppend.Log("Error at CurrencySettings -> " + methodname + " " + DateTime.Now.ToString(), w);
                DirAppend.Log(ex.ToString(), w);
            }
        }

        /* This method query the db and return stock lots cost details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and stock lots cost details for that year
         */
        public IEnumerable<SalesSummaryDAO> getStockLotsCostDataByYear()
        {
            try
            {
                // Linq query to get the cost details year wise
                var result = (from ps in _context.PurchasingShipments
                              group ps by ps.date.Value.Year into grp
                              select new SalesSummaryDAO
                             {
                                 Year = grp.Key,                // Group resluts by year
                                 Cost = grp.Sum(x => x.NoOfPieces * x.PricePerPiece + x.Micelleneous + x.TransportCost + x.SupplierCommission)  // Get all the cost values and sum them up
                             }).ToList();

                return result;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getStockLotsCostDataByYear");
                return null;
            }
        }

        /* This method query the db and return stock lots revenue details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and stock lots revenue details for that year
         */
        public IEnumerable<SalesSummaryDAO> getStockLotsRevenueDataByYear()
        {
            try
            {
                // Linq query to get the cost details year wise
                var result = (from bns in _context.BnSFrequencies
                              group bns by bns.Date.Value.Year into grp
                              select new SalesSummaryDAO
                              {
                                  Year = grp.Key,           // Group results by year
                                  Cost = grp.Sum(x => x.NoOfPieces * x.PricePerPiece)   // Get all revenue values and do some maths on them to get total
                              }).ToList();

                return result;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getStockLotsRevenueDataByYear");
                return null;
            }
        }

        /* This method query the db and return Fabric cost details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and fabric cost details for that year
         */
        public IEnumerable<SalesSummaryDAO> getFabricCostDataByYear()
        {
            try
            {
                // Linq query to get fabric cost details
                var fabResult = (from ps in _context.Fabrics
                                 group ps by ps.Date.Value.Year into grp
                                 select new SalesSummaryDAO
                                 {
                                     Year = grp.Key,        // Group by year
                                     Cost = grp.Sum(x => x.PricePerYard * (int)(x.Yardage) + x.TransportCost)       // Get all cost details and do some maths on them to get the total
                                 }).ToList();

                return fabResult;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getFabricCostDataByYear");
                return null;
            }
        }

        /* This method query the db and return Accessories cost details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and accessory cost details for that year
         */
        public IEnumerable<SalesSummaryDAO> getAccessoryCostDataByYear()
        {
            try
            {
                // Linq query to get accessory details
                var accResult = (from ps in _context.Accessories
                                 group ps by ps.Date.Value.Year into grp
                                 select new SalesSummaryDAO
                                 {
                                     Year = grp.Key,            // Group by year
                                     Cost = grp.Sum(x => x.PricePerUnit * (int)(x.NoOfUnits) + x.TransportCost)     // Get all accessory cost details and do some maths on them to get the total
                                 }).ToList();

                return accResult;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getAccessoryCostDataByYear");
                return null;
            }
        }

        /* This method query the db and return FOB revenue details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and FOB revenue details for that year
         */
        public IEnumerable<SalesSummaryDAO> getFobRevenueDataByYear()
        {
            try
            {
                // Linq query to get FOB revenue details
                var result = (from ps in _context.FOBSalesFrequencies
                              group ps by ps.Date.Value.Year into grp
                              select new SalesSummaryDAO
                              {
                                  Year = grp.Key,           // Group by year
                                  Cost = grp.Sum(x => x.NoOfPieces * x.PricePerPiece)   // Get all revenue data and do some maths on them to get the total
                              }).ToList();

                return result;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getFobRevenueDataByYear");
                return null;
            }
        }

        /* This method query the db and return net profit details as an IEnumerable list
         * @returns list of IEnumerable<SalesSummaryDAO> which contains year and net profit details for that year
         */
        public IEnumerable<SalesSummaryDAO> getNetProfitDataByYear()
        {
            // Create and initialize IEnumerable type lists to store data required for net profit calculation
            IEnumerable<SalesSummaryDAO> FabricCost = getFabricCostDataByYear();
            IEnumerable<SalesSummaryDAO> AccessoryCost = getAccessoryCostDataByYear();
            IEnumerable<SalesSummaryDAO> FOBRevenue = getFobRevenueDataByYear();
            IEnumerable<SalesSummaryDAO> StockCost = getStockLotsCostDataByYear();
            IEnumerable<SalesSummaryDAO> StockRevenue = getStockLotsRevenueDataByYear();

            try
            {
                // Linq query to get the fixed overhead cost 
                var fixedCost = (from fo in _context.FixedOverheads
                                 group fo by fo.Year into grp
                                 select new SalesSummaryDAO
                                 {
                                     Year = grp.Key.Value,              // Group by year
                                     // Get the all overhead values for particular year and do some maths on them to get the total
                                     Cost = grp.Sum(x => x.Electricity + x.Tax + x.Water + x.Salary + x.RentOrMortgage + x.PhoneAnInternet + x.Fuel + x.Misc + x.Ot + x.Other)
                                 }).ToList();

                IEnumerable<SalesSummaryDAO> FixedCost = fixedCost;

                // Make all the cost values negative so that the calculation becomes easier
                foreach (var f in FabricCost)
                    f.Cost = f.Cost * (-1);
                foreach (var a in AccessoryCost)
                    a.Cost = a.Cost * (-1);
                foreach (var s in StockCost)
                    s.Cost = s.Cost * (-1);
                foreach (var f in FixedCost)
                    f.Cost = f.Cost * (-1);

                // Merge all cost and revenue details by their year and get the net profit year wise
                var resultList = FabricCost.Concat(AccessoryCost)
                               .Concat(FOBRevenue)
                               .Concat(StockCost)
                               .Concat(StockRevenue)
                               .Concat(FixedCost)
                               .GroupBy(x => x.Year)
                               .Select(g => new SalesSummaryDAO()
                               {
                                   Year = g.Key,
                                   Cost = g.Sum(x => x.Cost)
                               })
                               .ToList();

                IEnumerable<SalesSummaryDAO> Result = resultList;           // Save the result into an IEnumerable list
                var sortedResult = Result.OrderBy(c => c.Year);            // Sort the list by year
                return sortedResult;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getNetProfitDataByYear");
                return null;
            }
        }


    }

    // Data structure to keep sales details which is year and the cost
    public class SalesSummaryDAO {
        public int Year {get;set;}
        public decimal? Cost {get;set;}
    }
}
