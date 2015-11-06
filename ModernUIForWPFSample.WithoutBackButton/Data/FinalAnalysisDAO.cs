using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class FinalAnalysisDAO
    {
        adoraDBContext _context = new adoraDBContext(); //create a new DB CONTEXT

        // This methods logs the exception details using DirAppend class
        private void addException(Exception ex, string methodname)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                DirAppend.Log("____________________________________________________________________", w);
                DirAppend.Log("Error at FinalAnalysis -> " + methodname + " " + DateTime.Now.ToString(), w);
                DirAppend.Log(ex.ToString(), w);
            }
        }

        /* This method query the db and return stock lots cost details for given month as an double value
         * @ param year : integer variable to hold required year
         * @ param month : integer variable to hold required month
         * @returns double which contains stock lots cost for the given year and month
         */
        public double getStockLotsCostbyMonth(int year, int month) 
        {
            try
            {
                // Linq query to get the cost details for given month
                var iCost = (from e in _context.PurchasingShipments
                             where e.date.Value.Year == year && e.date.Value.Month == month
                             select e.NoOfPieces * e.PricePerPiece + e.Micelleneous + e.TransportCost + e.SupplierCommission
                         );

                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getStockLotsCostbyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getStockLotsCostbyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getStockLotsCostbyMonth");
                return 0;
            }
        }

        /* This method query the db and return stock lots cost details for given year as an double value
        * @ param year : integer variable to hold required year
        * @returns double which contains stock lots cost for the given year 
        */
        public double getStockLotsCostbyYear(int year)
        {
            try
            {
                // Linq query to get the cost details for given year
                var iCost = (from e in _context.PurchasingShipments
                             where e.date.Value.Year == year
                             select e.NoOfPieces * e.PricePerPiece + e.Micelleneous + e.TransportCost + e.SupplierCommission
                        );

                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getStockLotsCostbyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getStockLotsCostbyYear");
                return 0;
            }
        }

        /* This method query the db and return FOB cost details for given month as an double value
        * @ param year : integer variable to hold required year
        * @ param month : integer variable to hold required month
        * @returns double which contains FOB cost for the given year and month
        */
        public double getFobCostbyMonth(int year, int month)
        {
            try
            {
                // Linq query to get Fabric cost details for given month
                var iFabCost = (from e in _context.Fabrics
                                where e.Date.Value.Year == year && e.Date.Value.Month == month
                                select e.PricePerYard * (int)e.Yardage + e.TransportCost
                        );

                // Convert the retrieved value to double
                double FabCost = System.Convert.ToDouble(iFabCost.Sum());

                // Linq query to get Accessory cost details for given month
                var iAccCost = (from e in _context.Accessories
                                where e.Date.Value.Year == year && e.Date.Value.Month == month
                                select e.PricePerUnit * (int)e.NoOfUnits + e.TransportCost
                       );

                // Convert the retrieved value to double
                double AccCost = System.Convert.ToDouble(iAccCost.Sum());

                // Get the total FOB cost by adding accessory and Fabric costs
                double cost = AccCost + FabCost;

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getFobCostbyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFobCostbyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFobCostbyMonth");
                return 0;
            }
        }

        /* This method query the db and return stock lots cost details for given year as an double value
        * @ param month : integer variable to hold required month
        * @returns double which contains stock lots cost for the given year
        */
        public double getFobCostbyYear(int year)
        {
            try
            {
                // Linq query to get Fabri cost details for given year
                var iFabCost = (from e in _context.Fabrics
                                where e.Date.Value.Year == year
                                select e.PricePerYard * (int)e.Yardage + e.TransportCost
                        );

                // Convert the retrieved data to double
                double FabCost = System.Convert.ToDouble(iFabCost.Sum());

                // Linq query to get Accesory cost details for given year
                var iAccCost = (from e in _context.Accessories
                                where e.Date.Value.Year == year
                                select e.PricePerUnit * (int)e.NoOfUnits + e.TransportCost
                       );

                // Convert the retrueved data to double
                double AccCost = System.Convert.ToDouble(iAccCost.Sum());

                // Get the total FOB cost by adding accessory and Fabric costs
                double cost = AccCost + FabCost;

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getFobCostbyYear");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFobCostbyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFobCostbyYear");
                return 0;
            }
        }

        /* This method query the db and return Stock Lots Revenue details for given month as an double value
        * @ param year : integer variable to hold required year
        * @ param month : integer variable to hold required month
        * @returns double which contains Stock Lots Revenue for the given year and month
        */
        public double getStockLotsRevenuebyMonth(int year, int month)
        {
            try
            {
                // Linq query to get Stock Lots revenue data for given month
                var iRevenue = (from e in _context.BnSFrequencies
                                where e.Date.Value.Year == year && e.Date.Value.Month == month
                                select e.NoOfPieces * e.PricePerPiece
                        );

                // Convert the retrieved value to double
                double revenue = System.Convert.ToDouble(iRevenue.Sum());

                return revenue;
            }
            catch (FormatException e)
            {
                addException(e, "getStockLotsRevenuebyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getStockLotsRevenuebyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getStockLotsRevenuebyMonth");
                return 0;
            }
        }

        /* This method query the db and return Stock Lots Revenue details for given year as an double value
        * @ param year : integer variable to hold required year
        * @returns double which contains Stock Lots Revenue for the given year
        */
        public double getStockLotsRevenuebyYear(int year)
        {
            try
            {
                // Linq query to get Stock Lots revenue data for given year
                var iRevenue = (from e in _context.BnSFrequencies
                                where e.Date.Value.Year == year
                                select e.NoOfPieces * e.PricePerPiece
                        );

                // Convert the retrieved value to double
                double revenue = System.Convert.ToDouble(iRevenue.Sum());

                return revenue;
            }
            catch (FormatException e)
            {
                addException(e, "getStockLotsRevenuebyYear");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getStockLotsRevenuebyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getStockLotsRevenuebyYear");
                return 0;
            }
        }

        /* This method query the db and return FOB Revenue details for given month as an double value
        * @ param year : integer variable to hold required year
        * @ param month : integer variable to hold required month
        * @returns double which contains FOB Revenue for the given year and month
        */
        public double getFobRevenuebyMonth(int year, int month)
        {
            try
            {
                // Linq query to get FOB Revenue details for given month
                var iRevenue = (from e in _context.FOBSalesFrequencies
                                where e.Date.Value.Year == year && e.Date.Value.Month == month
                                select e.NoOfPieces * e.PricePerPiece
                       );

                // Convert the retrieved value to double
                double revenue = System.Convert.ToDouble(iRevenue.Sum());

                return revenue;
            }
            catch (FormatException e)
            {
                addException(e, "getFobRevenuebyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFobRevenuebyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFobRevenuebyMonth");
                return 0;
            }
        }

        /* This method query the db and return FOB Revenue details for given year as an double value
        * @ param year : integer variable to hold required year
        * @returns double which contains Stock Lots Revenue for the given year
        */
        public double getFobRevenuebyYear(int year)
        {
            try
            {
                // Linq query to get FOB Revenue details for given year
                var iRevenue = (from e in _context.FOBSalesFrequencies
                                where e.Date.Value.Year == year
                                select e.NoOfPieces * e.PricePerPiece
                      );

                // Convert the retrieved value to double
                double revenue = System.Convert.ToDouble(iRevenue.Sum());

                return revenue;
            }
            catch (FormatException e)
            {
                addException(e, "getFobRevenuebyYear");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFobRevenuebyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFobRevenuebyYear");
                return 0;
            }
        }

        /* This method query the db and return Fixed overheads cost details for given year as an double value
       * @ param year : integer variable to hold required year
       * @returns double which contains Fixed overhead cost for the given year
       */
        public double getFixedOverheadsCostbyYear(int year)
        {
            try
            {
                // Linq query to get Fixed overhead cost details for given year
                var iCost = (from e in _context.FixedOverheads
                             where e.Year == year
                             select e.Electricity + e.Water + e.Salary + e.Fuel + e.PhoneAnInternet + e.Ot + e.Misc
                      );

                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getFixedOverheadsCostbyYear");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFixedOverheadsCostbyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFixedOverheadsCostbyYear");
                return 0;
            }
        }

        /* This method query the db and return Fixed overheads cost details for given month as an double value
       * @ param year : integer variable to hold required year
       * @ parm month : integer variable to hold required month 
       * @returns double which contains Fixed overhead cost for the given year
       */
        public double getFixedOverheadsCostbyMonth(int year, int month)
        {
            try
            {
                // Linq query to get Fixed overhead cost details for given year and month
                var iCost = (from e in _context.FixedOverheads
                             where e.Year == year && e.Month == month
                             select e.Electricity + e.Water + e.Salary + e.Fuel + e.PhoneAnInternet + e.Ot + e.Misc
                      );

                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getFixedOverheadsCostbyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getFixedOverheadsCostbyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getFixedOverheadsCostbyMonth");
                return 0;
            }
        }

        /* This method query the db and return Rent and Tax cost details for given month as an double value
       * @ param year : integer variable to hold required year
       * @ parm month : integer variable to hold required month 
       * @returns double which contains Rent and Tax cost for the given year
       */
        public double getRentNTaxbyMonth(int year, int month) 
        {
            try
            {
                // Linq query to get Rent and Tax cost details for given year and month
                var iCost = (from e in _context.FixedOverheads
                             where e.Year == year && e.Month == month
                             select e.RentOrMortgage + e.Tax
                      );

                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getRentNTaxbyMonth");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getRentNTaxbyMonth");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getRentNTaxbyMonth");
                return 0;
            }

        }

        /* This method query the db and return Rent and Tax cost details for given year as an double value
       * @ param year : integer variable to hold required year
       * @returns double which contains Rent and Tax cost for the given month
       */
        public double getRentNTaxbyYear(int year)
        {
            try
            {
                // Linq query to get Rent and Tax cost details for given year
                var iCost = (from e in _context.FixedOverheads
                             where e.Year == year
                             select e.RentOrMortgage + e.Tax
                      );
                // Convert the retrieved value to double
                double cost = System.Convert.ToDouble(iCost.Sum());

                return cost;
            }
            catch (FormatException e)
            {
                addException(e, "getRentNTaxbyYear");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getRentNTaxbyYear");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getRentNTaxbyYear");
                return 0;
            }

        }
    }
}
