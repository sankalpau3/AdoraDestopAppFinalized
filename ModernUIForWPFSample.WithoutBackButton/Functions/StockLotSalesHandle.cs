using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class StockLotSalesHandle
    {
        // This method calculates total price for given item and display it in a given currency type
        public double calctotalPrice(double pricePerPiece, int noOfPieces, String currency) 
        {
            double total = (pricePerPiece * noOfPieces);            // Calculates the total Price in LKR
            double trueValue = 0;

            // If the user selected currency type is not LKR
            if (currency != "LKR") 
            { 
                using (adoraDBContext a = new adoraDBContext())
                {
                    // Linq query to get the ID of the currency which is specified by the user
                    var id = (from e in a.CurCategories
                              where (e.Category == currency)
                              select e.CurCatID).SingleOrDefault();

                    // Linq query to get the value of the currency specified by the user
                    var val = (from s in a.Currencies
                               where s.CurrencyCategory == id
                               select s.Value).ToList();
                    // Convert the retrieved value to double
                    double value = Convert.ToDouble(val.Last());

                    // Convert the LKR to required currency type
                    trueValue = total / value;
                }
        }

        // If the selected currency is LKR
        else 
            {
                trueValue = total;
            }
            
            return trueValue;
        }
    }
}
