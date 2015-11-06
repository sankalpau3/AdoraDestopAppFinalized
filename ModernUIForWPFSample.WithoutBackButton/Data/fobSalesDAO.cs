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
using System.Text.RegularExpressions;
using System.IO;
using ModernUIForWPFSample.WithoutBackButton;
using ModernUIForWPFSample.WithoutBackButton.Views;
using System.Data.Entity;

namespace ModernUIForWPFSample.WithoutBackButton.DAO
{
    class fobSalesDAO
    {

        // This section is use to populate the searchbar with all data, This return a List
        public List<string> populateSearchBarWithAllData()
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    // retriving factory name, item name and description from the database and saving it in a list
                    var factoryName = (from e in a.StockInHands
                                       select new { e.FactoryName, e.ItemName, e.descript }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    // pulling retrived data from the list and setting them in the combo box record
                    for (int i = 0; i < factoryName.Count; i++)
                    {
                        String n = factoryName[i].FactoryName.ToString();
                        String m = factoryName[i].ItemName.ToString();
                        String l = factoryName[i].descript.ToString();

                        String nm = n + "  ->  " + m + "  ->  " + l;
                        nList.Add(nm);
                    }

                    // Returning the List
                    return nList;
                }
            }
            catch(ArgumentNullException)
            {
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }



        // This section is use to update the search combo box
        public List<String> updateSearchComboBox(String searchText)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    

                    // Take all the records where Factory Name, Item name or description match with the user input (Search text)
                    var factoryName = (from e in a.StockInHands
                                       where e.FactoryName.Contains(searchText) || e.ItemName.Contains(searchText) || e.descript.Contains(searchText)
                                       select new { e.FactoryName, e.ItemName, e.descript }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    // setting retrived data in the list and adding them to the combo drop down box
                    for (int i = 0; i < factoryName.Count; i++)
                    {
                        String n = factoryName[i].FactoryName.ToString();
                        String m = factoryName[i].ItemName.ToString();
                        String l = factoryName[i].descript.ToString();

                        String nm = n + "  ->  " + m + "  ->  " + l;
                        nList.Add(nm);
                    }
                    // Returning the List 
                    return nList;
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        //This section is use to delete the current frequency
        public bool deleteCurrentFrequency(String shipmentId, int freqID)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    // getting the deleting frequency object according to the shipment ID and frequncy ID
                    var deletingFrequencyObj = a.FOBSalesFrequencies.FirstOrDefault((sf) => sf.ShipmentID == shipmentId && sf.FrequencyID == freqID);

                    // deleting the selected object
                    a.FOBSalesFrequencies.Remove(deletingFrequencyObj);

                    // saving the changes to the database
                    int done = a.SaveChanges();

                    // If the operation is succeded retuen true, Otherwise return false
                    if (done != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }


        // This section is use to populate the other all textboxes according to the selection in main combo box
        public Dictionary<String, String> populateAllOtherTextbox(String fullString)
        {
                Dictionary<String, String> selectedRecord = new Dictionary<string, string>();

                try
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        
                        String[] facNameAndItemNameArray = Regex.Split(fullString, "  ->  ");
                        String factoryName = facNameAndItemNameArray[0];
                        String itemName = facNameAndItemNameArray[1];


                        // adding factory Name and item name to the dictionary
                        selectedRecord.Add("factoryName", factoryName);
                        selectedRecord.Add("itemName", itemName);


                        // retriving descrption data from the database and populating the description text box
                        var DescriptionDetails = (from e in a.StockInHands
                                                  where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                  select e.descript
                                                 ).ToList();

                        // adding description details to the dictionary
                        selectedRecord.Add("descriptionDetails", DescriptionDetails.First().ToString());


                        // retriving no of pieces details from the database and populating the no of pieces details text box
                        var noOfPiecesDetails = (from e in a.StockInHands
                                                 where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                 select e.NoOfItems
                       ).ToList();

                        // adding noOfPiecesDetails details to the dictionary
                        selectedRecord.Add("noOfPiecesDetails", noOfPiecesDetails.First().ToString());
                       

                        try
                        {
                            // retriving cost per piece details from the database and populating the cost per piece details text box
                            var CostPerPieceDetails = (from e in a.StockInHands
                                                       join b in a.ActualCosts on e.ACostID equals b.ACostID
                                                       where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                       select b.TotalCost
                           ).ToList();

                            // adding CostPerPieceDetails details to the dictionary
                            selectedRecord.Add("CostPerPieceDetails", CostPerPieceDetails.First().ToString());
                        }
                        catch (Exception)
                        {
                            // if the cost per piece not available for a record This error message will add to the dictionary
                            selectedRecord.Add("CostPerPieceDetails", "<< Cost per piece for this item not available >>");
                        }
                    }
                }
                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }
                catch(ArgumentException)
                {
                    return null;
                }
                catch(Exception)
                {
                    return null;
                }
                // returning the dictionary with data
                return selectedRecord;
        }


        // This section is use to get No Of pieces available in stock in hand table
        public String getNoOfPiecesAvailable(String stockID)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var noOfPiecesDetails = (from e in a.StockInHands
                                             where (e.StockID == stockID)
                                             select e.NoOfItems
                               ).First();

                    String noOfPiecesAvail = noOfPiecesDetails.ToString();

                    return noOfPiecesAvail;
                }
            }
            catch(ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(InvalidOperationException e)
            {
                return null;
            }
        }

        // This section is use to get number of pieces available in the currently selected frequency
        public String getNoOfPiecesCurrentlyInThatFreqency(String stockID, int freqID)
        {
            try
            {
              using (adoraDBContext a = new adoraDBContext())
                {
                    var noOfPiecesDetails = (from e in a.FOBSalesFrequencies
                                             where (e.ShipmentID == stockID && e.FrequencyID == freqID)
                                             select e.NoOfPieces
                               ).First();

                    String noOfPiecesAvail = noOfPiecesDetails.ToString();

                    return noOfPiecesAvail;
                }
            }
            catch(ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(InvalidOperationException)
            {
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }


        // This section is use to get shipment ID using factoryName, itemName and Description
        public String getShipmentID(String factoryName, String itemName, String description)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    // Take all the records where Factory Name, Item name or description match with the user input (Search text)
                    var stockID = (from e in a.StockInHands
                                   where e.FactoryName == factoryName && e.ItemName == itemName && e.descript == description
                                   select e.StockID).ToList();

                    return stockID.First().ToString();
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // This section use to get No of items in fob stock in Hand using the stock ID
        public String getNoOfItemsInFobStockInHand(String stockID)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    // Take all the records where Factory Name, Item name or description match with the user input (Search text)
                    var noOfItemsInStockInHand = (from e in a.StockInHands
                                   where e.StockID == stockID
                                   select e.NoOfItems).ToList();

                    return noOfItemsInStockInHand.First().ToString();
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // This section returns the get frequency Numbers as a list using the shipment id
        public List<int> getFrequencyNumbers(String shipmentID)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    
                    // Query and get frequency numbers for a given shipment ID using LINQ
                    var frequencyNumberList = (from e in a.FOBSalesFrequencies
                                  where e.ShipmentID == shipmentID
                                  select e.FrequencyID
                   ).Distinct().ToList();

                   return frequencyNumberList;
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // this section is use to add New Frequency 
        public bool addNewFrequency(String shipmentID, int frequencyID, int noOfPieces, decimal pricePerPiece, DateTime date)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var frequency = new FOBSalesFrequency();

                    frequency.FrequencyID = frequencyID;
                    frequency.ShipmentID = shipmentID;
                    frequency.NoOfPieces = noOfPieces;
                    frequency.PricePerPiece = pricePerPiece;
                    frequency.Date = date;

                    //Add to memory
                    a.FOBSalesFrequencies.Add(frequency);

                    //Save to database
                    int done = a.SaveChanges();

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
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException)
            {
                return false;
            }
            catch(System.NotSupportedException)
            {
                return false;
            }
            catch(System.ObjectDisposedException)
            {
                return false;
            }
            catch(System.InvalidOperationException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        // This section is use to update update frequency
        public bool updateFrequency(String shipmentID, int frequencyID, int noOfPieces, decimal pricePerPiece, DateTime date)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var frequency = a.FOBSalesFrequencies.FirstOrDefault((sf) => sf.ShipmentID == shipmentID && sf.FrequencyID == frequencyID);

                    frequency.NoOfPieces = noOfPieces;
                    frequency.PricePerPiece = pricePerPiece;
                    frequency.Date = date;

                    // _context.BnSFrequencies.Load();
                    int done = a.SaveChanges();

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
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return false;
            }
            catch (System.NotSupportedException)
            {
                return false;
            }
            catch (System.ObjectDisposedException)
            {
                return false;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // This section is use to populate frequency data using shiment ID and frequency ID
        // This section returns a dictionary
        public Dictionary<String, String> populateFrequencyData(String shipmentID,String freqID)
        {
            try
            {
                Dictionary<String,String> newDictionary = new Dictionary<string,string>();
                using (adoraDBContext a = new adoraDBContext())
                {
                    int freqIDint = Int32.Parse(freqID);
                    var NoOfPiecesDetails = (from e in a.FOBSalesFrequencies
                                              where (e.ShipmentID == shipmentID && e.FrequencyID == freqIDint)
                                              select e.NoOfPieces
                                                 ).ToList();

                    newDictionary.Add("NoOfPiecesDetails", NoOfPiecesDetails.First().ToString());

                    var pricePerPieceDetails = (from e in a.FOBSalesFrequencies
                                             where (e.ShipmentID == shipmentID && e.FrequencyID == freqIDint)
                                             select e.PricePerPiece
                                                 ).ToList();

                    newDictionary.Add("pricePerPieceDetails", pricePerPieceDetails.First().ToString());

                    var dateDetails = (from e in a.FOBSalesFrequencies
                                             where (e.ShipmentID == shipmentID && e.FrequencyID == freqIDint)
                                             select e.Date
                                                 ).ToList();

                    newDictionary.Add("date", dateDetails.First().ToString());

                    // Return a dictionary with data
                    return newDictionary;
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            catch(ArgumentException)
            {
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // this section is use to update stock in hand item amount using shipment ID and total number of left
        public bool updateStockInHandAmountOfItems(String shipmentID,int noOfPiecesLeft)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {

                    var stockInHandObj = a.StockInHands.FirstOrDefault((sh) => sh.StockID == shipmentID);

                    stockInHandObj.NoOfItems = noOfPiecesLeft;

                    
                    int done = a.SaveChanges();

                    
                    if (done != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return false;
            }
            catch (System.NotSupportedException)
            {
                return false;
            }
            catch (System.ObjectDisposedException)
            {
                return false;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
