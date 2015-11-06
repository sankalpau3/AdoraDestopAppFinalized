using ModernUIForWPFSample.WithoutBackButton.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class FOBActualCostDAO
    {
        adoraDBContext _context = new adoraDBContext(); //create a new DB CONTEXT
        private DirAppend dirapnd = new DirAppend();

        //method to add log entry with method name and exception
        private void addException(Exception ex, string methodname)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                DirAppend.Log("____________________________________________________________________", w);
                DirAppend.Log("InvalidOperationException at FixdOverHeadDAO -> " + methodname + " " + DateTime.Now.ToString(), w);
                DirAppend.Log(ex.ToString(), w);
            }

        }

        //method a list of strings
        public List<string> getItems()
        {
            try
            {
                
                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.StockInHands
                                where e.ACostID == null
                                select new {e.ItemName, e.StockID}
                   ).Distinct().ToList();

                    List<string> rlist = new List<string>();

                    for (int i = 0; i < items.Count; i++)
                    {
                        rlist.Add(items[i].ItemName +" |" + items[i].StockID.ToString());
                    }
                    return rlist;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "getItems()");
                return null;
            }
        }

        //this method update stockin hand table when actual cost is calculated
        public bool updateStock(string id, string actId)
        {
            try{
                using (adoraDBContext a = new adoraDBContext())
                {
                    StockInHand stockObj = _context.StockInHands.First(i => i.StockID == id);
                    stockObj.ACostID = actId;
                    int chk = _context.SaveChanges();
                    if (chk != -1)
                        return true;
                    else
                        return false;
                }
            }
            catch (InvalidCastException invalidCastException)
            {
                addException(invalidCastException, "updateStock()");
                return false;
            }
 
        }
        //this method returns a list of fabric types
        public List<string> getFabTypes()
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.Fabrics

                                 select e.Category
                   ).Distinct().ToList();

                    return items;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "getFabTypes()");
                return null;
            }
        }

        //this method retures a list of accessory types
        public List<string> getAccTypes()
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.Accessories

                                 select e.Category
                   ).Distinct().ToList();

                    return items;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "getAccTypes()");
                return null;
            }
        }
        //this method add data to fabriccost table
        public bool addFabricCost(FabricCostData data)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    FabricCost actCost =  new FabricCost();

                    actCost.Type = data.Type;
                    actCost.Amount = (float)data.Amount;
                    actCost.Cost = (decimal)data.Cost;
                    actCost.ACostID = data.ACostID;
                    actCost.costPyard = (float)data.CostPyard;

                    a.FabricCosts.Add(actCost);
                    int done =  a.SaveChanges();

                    if (done != -1)
                        return true;
                    else
                        return false;   

                   
                }
            }
            catch (InvalidCastException invalidCastException)
            {
                addException(invalidCastException, "addFabricCost()");
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //this method add data to accessoryCost table
        public bool addAccessoryCost(AccessoryCostData data)
        {
            try
            {
               
                    AccessoryCost actCost = new AccessoryCost();
                    
                    actCost.Type = data.Type;
                    actCost.Amount = (float)data.Amount;
                    actCost.Cost = (decimal)data.Cost;
                    actCost.ACostID = data.AcostID;
                    actCost.wieghtPitem = (float)data.WeightPItem;
                    actCost.Unit = data.Unit;
                    actCost.costPerHundredgms = (float)data.Chg;

                   _context.AccessoryCosts.Add(actCost);
                   int done = _context.SaveChanges();

                   
                   if (done != -1)
                    return true;
                   else
                       return false;
                  
                   
                
            }
            catch (Exception e)
            {

                addException(e, "addAccessoryCost()");
                return false;
            }
        }

        //this method return the id of the last endered actual cost
        public string getLastActualCostId()
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = Convert.ToInt32((from e in a.ActualCosts
                                
                                 select e.ID                                 
                   ).Max().ToString());

                   

                    var id = (from e in a.ActualCosts
                              where e.ID == items
                              select e.ACostID
                   ).Single().ToString();
                    
                    return id;
                }
            }
            catch (Exception e)
            {
                addException(e, "getLastActualCostId()");
                return null;
            }
        }

        //this method update the actual cost field in the actual cost table
        public bool addActualCost(double total, string cm)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    ActualCost actCost = new ActualCost();

                    actCost.CM = cm;
                    actCost.TotalCost = Convert.ToDecimal(total);

                    a.ActualCosts.Add(actCost);
                    a.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                addException(e, "addActualCost()");
                return false;
            }
        }
        //this method update searchComboBox 
        public void updateSearchComboBox(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    String searchText = cmbBox.Text.ToString();

                    // Take all the records where Factory Name, Item name or description match with the user input (Search text)
                    var items = (from e in a.ActualCosts
                                       select e.ACostID
                   ).Distinct().ToList();
                    cmbBox.ItemsSource = items;
                    
                }
            }
            catch (Exception e)
            {
                addException(e, "updateSearchComboBox()");
            }
        }

        public void fillListFabs(ListBox id, ListBox type, ListBox consum, ListBox cost, ListBox costpy, string idString)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var ids = (from e in a.FabricCosts
                               where e.ACostID == idString 
                                 select e.FabCostID
                   ).ToList();

                     var types = (from e in a.FabricCosts
                                  where e.ACostID == idString 
                                 select e.Type
                   ).ToList();

                     var consums = (from e in a.FabricCosts
                                    where e.ACostID == idString 
                                 select e.Amount
                   ).ToList();

                     var costs = (from e in a.FabricCosts
                                  where e.ACostID == idString 
                                select e.Cost
                   ).ToList();

                     var costpys = (from e in a.FabricCosts
                                  where e.ACostID == idString
                                  select e.costPyard
                    ).ToList();

                     id.ItemsSource = ids;
                     type.ItemsSource = types;
                     consum.ItemsSource = consums;
                     cost.ItemsSource = costs;
                     costpy.ItemsSource = costpys;
                    
                }
            }
            catch (Exception e)
            {
                addException(e, "fillListFabs()");
                
            }
        }// fillafab method ends here

        //this method fill the data to listboxes
        public void fillListAccs(ListBox id, ListBox type, ListBox wpi, ListBox chg, ListBox amt,ListBox cost ,string idString)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var ids = (from e in a.AccessoryCosts
                               where e.ACostID == idString
                               select e.AccCostID
                   ).ToList();

                    var types = (from e in a.AccessoryCosts
                                 where e.ACostID == idString
                                 select e.Type
                  ).ToList();

                    var wpis = (from e in a.AccessoryCosts
                                   where e.ACostID == idString
                                   select e.wieghtPitem
                  ).ToList();

                    var chgs = (from e in a.AccessoryCosts
                                 where e.ACostID == idString
                                 select e.costPerHundredgms
                  ).ToList();

                    var amts = (from e in a.AccessoryCosts
                                   where e.ACostID == idString
                                   select e.Amount
                   ).ToList();
                    var costs = (from e in a.AccessoryCosts
                                where e.ACostID == idString
                                select e.Cost
                  ).ToList();

                    id.ItemsSource = ids;
                    type.ItemsSource = types;
                    wpi.ItemsSource = wpis;
                    cost.ItemsSource = costs;
                    chg.ItemsSource = chgs;
                    amt.ItemsSource = amts;

                }
            }
            catch (Exception e)
            {
                addException(e, "fillListAccs()");

            }
        }//fillacc method ends here
        private bool deleteActualCost(string id)
        {
            try
            {
                ActualCost fixDetl = _context.ActualCosts.FirstOrDefault(i => i.ACostID == id);
                _context.ActualCosts.Remove(fixDetl);
               // _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                addException(e, "deleteActualCost()");
                return false;
            }
        }//deleteActualCost methods ends
        private bool deleteAcutalCostDecendents(string id)
        {
            bool fabchk = true;
            bool accchk = true;
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    //int chk = -1;
                    var items = (from e in a.AccessoryCosts
                                 where e.ACostID == id
                                 select e.AccCostID
                   ).Distinct().ToList();

                    foreach (string s in items)
                    {
                        AccessoryCost acccost = _context.AccessoryCosts.FirstOrDefault(i => i.AccCostID == s);
                        _context.AccessoryCosts.Remove(acccost);
                        //chk = _context.SaveChanges();
                        //if (chk == -1)
                        //    accchk = false;
                    }
                }
            }
            catch (Exception e)
            {
                accchk = false;
                addException(e, "deleteAcutalCostDecendents()");
                
            }
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    //int chk;
                    var items = (from e in a.FabricCosts
                                 where e.ACostID == id
                                 select e.ACostID
                   ).Distinct().ToList();

                    foreach (string s in items)
                    {
                        FabricCost fabcost = _context.FabricCosts.FirstOrDefault(i => i.ACostID == s);
                        _context.FabricCosts.Remove(fabcost);
                       //chk = _context.SaveChanges();
                       //if (chk == -1)
                       //    fabchk = false;
                        
                    }
                }
            }
            catch (Exception e)
            {
               
                fabchk = false;
                addException(e, "deleteAcutalCostDecendents()");

            }

            return (fabchk && accchk);
        }//deleteAcutalCostDecendents ends
        
        public bool DeleteAllActCost(string id)
        {
            bool chk = true;
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    StockInHand stockObj = _context.StockInHands.First(i => i.ACostID == id);
                    stockObj.ACostID = null;
                    
                }
            }
            catch (Exception e)
            {
                chk = false;
                addException(e, "DeleteAllActCost()");
            }

            if (deleteAcutalCostDecendents(id) && deleteActualCost(id) && chk)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;


        }//DeleteAllActCost ends
        public bool deleteFromFab(string id)
        {
            
            try
            {

                if (id != "XXXX")
                {
                    FabricCost acccost = _context.FabricCosts.FirstOrDefault(i => i.FabCostID == id);
                    _context.FabricCosts.Remove(acccost);
                    int chk = _context.SaveChanges();
                    if (chk == -1)
                        return false;
                    else
                        return true;
                }
                else
                    return true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),id);
                addException(ex, "deleteFromFab()");
                return false;
            }
        
        }//deleteFromFab ends

        public bool deleteFromAcc(string id)
        {
            try
            {
                if (id != "XXXX")
                {
                    AccessoryCost acccost = _context.AccessoryCosts.FirstOrDefault(i => i.AccCostID == id);
                    _context.AccessoryCosts.Remove(acccost);
                    int chk = _context.SaveChanges();
                    if (chk == -1)
                        return false;
                    else
                        return true;
                }
                else
                    return true;

            }
            catch (Exception ex)
            {
                addException(ex, "deleteFromAcc()");
                return false;
            }
        }//deleteFromAcc ends

        public bool editActCost(string id, double cost, string cm)
        {
            try
            {
                ActualCost acccost = _context.ActualCosts.FirstOrDefault(i => i.ACostID == id);
                acccost.TotalCost = (decimal)cost;
                acccost.CM = cm;
               
                int chk = _context.SaveChanges();
                if (chk == -1)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                addException(ex, "editActCost()");
                return false;
            }
        }//editActCost ends

        public string getItemName(string id)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var item = ((from e in a.StockInHands
                                  where e.ACostID == id
                                select e.ItemName
                   ).FirstOrDefault().ToString());

                    return item;
                }
            }
            catch (ArgumentNullException argumentNullException)
            {
                addException(argumentNullException, "getItemName()");
                return null;
            }
            catch (NullReferenceException nullReferenceException)
            {
                addException(nullReferenceException, "getItemName()");
                return null;
            }
        }//get item names ends

        public void currency(ComboBox cmbbx)
        {
            try
            {

                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.CurCategories
                                
                                 select e.Category
                   ).Distinct().ToList();
                    cmbbx.ItemsSource= items;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "currency()");
                
            }
        }// currency method ends

        public string getuntype(string catagory)
        {
            try
            {

                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.Accessories
                                 where e.Category == catagory
                                 select e.UnitType
                   ).FirstOrDefault().ToString();
                    return items;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "getuntype()");
                return null;
            }
        }// getyntype ends
        public void setCm(ComboBox cm, string id)
        {
            try
            {

                using (adoraDBContext a = new adoraDBContext())
                {
                    var items = (from e in a.ActualCosts
                                 where e.ACostID == id
                                 select e.CM
                   ).FirstOrDefault().ToString();
                    cm.SelectedItem = items;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "setCm()");
            }
        }// setCm ends
        public void getTotal(string idx, Label cm, Label tott, bool add)
        {
            try
            {
                double trueValue = 0.0;
                if (idx != null || idx != "")
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var tot = Convert.ToDouble((from e in a.ActualCosts
                                                    where e.ACostID == idx
                                                    select e.TotalCost
                       ).FirstOrDefault().ToString());
                        var currency = (from e in a.ActualCosts
                                        where e.ACostID == idx
                                        select e.CM
                       ).FirstOrDefault().ToString();

                        if (currency != "LKR")
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
                            trueValue = tot / value;

                        }
                        else
                            trueValue = tot;

                        cm.Content = currency;
                        tott.Content = trueValue.ToString("0.00");
                        if (add)
                            MessageBox.Show("CM : " + currency + " and Total cost : " + trueValue.ToString("0.00"));
                    } 
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "getTotal()");
            }
        }
    }
}
