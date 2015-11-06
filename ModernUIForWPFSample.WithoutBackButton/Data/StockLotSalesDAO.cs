using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.DAO
{
    class StockLotSalesDAO
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

        // This method returns shipmentNames as a list
        public List<String> getShipmentNames()
        {
            try
            {
                //LINQ query to retrieve currency types from DB
                var shipments = (from e in _context.PurchasingShipments
                                 select e.Title
                  ).Distinct().ToList();

                return shipments;

            }
            catch (ArgumentNullException e)
            {
                addException(e, "getShipmentNames");
                return null;
            }
        }

        // This method returns currency types available as a list
        public List<String> getCurrencyTypes()
        {

            try
            {
                //LINQ query to retrieve currency types from DB
                var types = (from e in _context.CurCategories
                                 select e.Category
                            ).Distinct().ToList();

                return types;
                
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getCurrencyTypes");
                return null;
            }
        }

        // This method returns Shipment dates available according to a given shipment Name as a list
        public List<DateTime> getShipmentDates(String shipmentName)
        {
            try
            {
                //LINQ query to retrieve shipment dates from DB
                var dates = (from e in _context.PurchasingShipments
                             where e.Title == shipmentName
                             select e.date
                       ).Distinct().ToList();

                List<DateTime> list1 = dates.Cast<DateTime>().ToList(); //convert the type of list to System.DateTime
                return list1;

            }
            catch (ArgumentNullException e)
            {
                addException(e, "getShipmentDates");
                return null;
            }
        }

        // This method returns number of pieces in a particular frequency as an INT
        public int getNoOfPieces(String shipmentName, DateTime date, int frequencyId)
        {
            try
                {
                   //get the shipment id according to inputs
                    String shipmentID = getShipmentID(shipmentName, date);
                        
                    //get the no of pieces
                    var num = (from e in _context.BnSFrequencies
                                     where (e.ShipmentID == shipmentID && e.FrequencyID == frequencyId)
                                     select e.NoOfPieces).SingleOrDefault();

                    return Convert.ToInt32(num);
                }
            catch (ArgumentNullException e)
                {
                    addException(e, "getNoOfPieces");
                    return 0;
                }
            catch (InvalidOperationException e)
                {
                    addException(e, "getNoOfPieces");
                    return 0;
                }
        }

        // This method returns the date of a particulat shipment as DATETIME
        public DateTime getDate(String shipmentName, DateTime date, int frequencyId)
        {
            try
            {
                //get the shipment id according to inputs
                String shipmentID = getShipmentID(shipmentName, date);

                // LINQ Query to get the frequency date
                var dateCal = (from e in _context.BnSFrequencies
                                     where (e.ShipmentID == shipmentID && e.FrequencyID == frequencyId)
                                    select e.Date).SingleOrDefault();

                return Convert.ToDateTime(dateCal);
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getDate");
                return Convert.ToDateTime(null);
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getDate");
                return Convert.ToDateTime(null);
            }
        }

        // This method returns the price per piece of a particular shipment as a double
        public double getPrice(String shipmentName, DateTime date, int frequencyId)
        {
            try
            {
                //get the shipment id according to inputs
                String shipmentID = getShipmentID(shipmentName, date);


                // LINQ Query to get the price
                var price = (from e in _context.BnSFrequencies
                                   where (e.ShipmentID == shipmentID && e.FrequencyID == frequencyId)
                                  select e.PricePerPiece).SingleOrDefault();

                return Convert.ToDouble(price);
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getPrice");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getPrice");
                return 0;
            }
        }

        // This method returns frequency numbers for particular shipment as a list
        public List<int> getFrequencyNumbers(String shipmentName, DateTime date)
        {
            try
            {
                String shipmentID = getShipmentID(shipmentName, date);  //get Shipment ID

                // Query and get frequency numbers for a given shipment ID using LINQ
                    var freNos = (from e in _context.BnSFrequencies
                                  where e.ShipmentID == shipmentID
                                  select e.FrequencyID
                   ).Distinct().ToList();

                    return freNos;
                
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getFrequencyNumbers");
                return null;
            }
        }

        // This method returns Shipment ID according to given inputs as a String
        public String getShipmentID(String shipmentName, DateTime date) 
        {
            try 
            {
                // Query and get the shipment id using LINQ
                var shipmentID = (from e in _context.PurchasingShipments
                                      where (e.Title == shipmentName && e.date == date)
                                      select e.ShipmentID).SingleOrDefault();

                return shipmentID;
            }
            catch(ArgumentNullException e) 
            {
                addException(e, "getShipmentID");
                return null;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getShipmentID");
                return null;
            }
        }

        // This method retuens cost per piece for a particular shipment as a double value
        public double getCostPerPiece(String shipmentName, DateTime date)
        {
            try
            {
                // Query and get cost per piece using LINQ
                var costPerPiece = (from e in _context.PurchasingShipments
                                    where (e.Title == shipmentName && e.date == date)
                                    select e.PricePerPiece).SingleOrDefault();

                return Convert.ToDouble(costPerPiece);
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getCostPerPiece");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getCostPerPiece");
                return 0;
            }
        }

        // This method returns the total number of pieces for a given shipment as an INT
        public int getTotalPieces(String shipmentName, DateTime date)
        {
            try
            {
                String shipmentID = getShipmentID(shipmentName, date);  // Get Shipment ID

                // Query and get the total number of pieces using LINQ
                var totalPieces = (from e in _context.PurchasingShipments
                                   where (e.Title == shipmentName && e.date == date)
                                   select e.NoOfPieces).SingleOrDefault();

                return Convert.ToInt32(totalPieces);
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getTotalPieces");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getTotalPieces");
                return 0;
            }
        }

        // This method returns the total number of pieces sold from a given shipment as an INT
        public int getTotalSoldPieces(String shipmentName, DateTime date)
        {
            try
            {
                String shipmentID = getShipmentID(shipmentName, date);  //get Shipment ID

                //Q uery and get the total number of pieces sold using LINQ
                var soldPieces = (from s in _context.BnSFrequencies
                                  where (s.ShipmentID == shipmentID)
                                  select s.NoOfPieces);

                return Convert.ToInt32(soldPieces.Sum());
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getTotalSoldPieces");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getTotalSoldPieces");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getTotalSoldPieces");
                return 0;
            }
        }

        // This method adds new frequency detail to the DB and returns true if the operation is succeeded
        public bool addNewFrequency(String shipmentID, int frequencyID, int noOfPieces, decimal pricePerPiece, DateTime date)
        {
            try
            {
                // Create a new frequency object
                var frequency = new BnSFrequency()
                {
                    ShipmentID = shipmentID,
                    FrequencyID = frequencyID,
                    NoOfPieces = noOfPieces,
                    PricePerPiece = pricePerPiece,
                    Date = date,
                };

                //Add to memory
                _context.BnSFrequencies.Add(frequency);

                //Save to database
                int done = _context.SaveChanges();

                // If the operation is sucessfull
                if (done != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                addException(e, "addNewFrequency");
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                addException(e, "addNewFrequency");
                return false;
            }
            catch (NotSupportedException e)
            {
                addException(e, "addNewFrequency");
                return false;
            }
            catch (ObjectDisposedException e)
            {
                addException(e, "addNewFrequency");
                return false;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "addNewFrequency");
                return false;
            }
        }

        // This method updates frequency details and return true if the operation is sucessfull
        public bool updateFrequency(String shipmentID, int frequencyID, int noOfPieces, decimal pricePerPiece, DateTime date)
        {
            try
            {
                // Get the Frequency detail which is needed to be updated
                var frequency = _context.BnSFrequencies.FirstOrDefault((bns) => bns.ShipmentID == shipmentID && bns.FrequencyID == frequencyID);
                frequency.NoOfPieces = noOfPieces;
                frequency.PricePerPiece = pricePerPiece;
                frequency.Date = date;

                // _context.BnSFrequencies.Load();
                int done = _context.SaveChanges();

                // If the operation is succeded
                if (done != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                addException(e, "updateFrequency");
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                addException(e, "updateFrequency");
                return false;
            }
            catch (NotSupportedException e)
            {
                addException(e, "updateFrequency");
                return false;
            }
            catch (ObjectDisposedException e)
            {
                addException(e, "updateFrequency");
                return false;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "updateFrequency");
                return false;
            }
        }

        // This method returns a frequency object according to the given details
        public BnSFrequency getFrequency(String shipId, int freqId, adoraDBContext _Context)
        {
            try
            {
                // LINQ query to get the required frequency object
                var freq = (from s1 in _Context.BnSFrequencies
                            where (s1.ShipmentID == shipId && s1.FrequencyID == freqId)
                            select s1).FirstOrDefault();

                return freq;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "updateFrequency");
                return null;
            }
        }

    }
}
