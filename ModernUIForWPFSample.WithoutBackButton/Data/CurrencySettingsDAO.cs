using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class CurrencySettingsDAO
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

        // This method returns available currency types as a List of strings
        public List<String> getCurrencyTypes()
        {
            try
            {
                // LInq query to get currency types available
                    var types = (from e in _context.CurCategories
                                 where e.Category != "LKR"
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

        // This method returns Currency ID as a string for a given currency type
        public String getCurrencyID(String type)
        {
            try
            {
                // Linq query to return the currency id for given type
                var id = (from e in _context.CurCategories
                          where (e.Category == type)
                          select e.CurCatID).SingleOrDefault();

                return id;
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getCurrencyID");
                return null;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "getCurrencyID");
                return null;
            }
        }

        // This method returns the current value for  a given currency id
        public double getValue(String id)
        {
            try
            {
                // Linq query to get the value
                var val = (from s in _context.Currencies
                           where s.CurrencyCategory == id
                           select s.Value).ToList();
             
                // Convert the value to double
                return System.Convert.ToDouble(val.Last());
            }
            catch (ArgumentNullException e)
            {
                addException(e, "getValue");
                return 0;
            }
            catch (FormatException e)
            {
                addException(e, "getValue");
                return 0;
            }
            catch (InvalidCastException e)
            {
                addException(e, "getValue");
                return 0;
            }
            catch (OverflowException e)
            {
                addException(e, "getValue");
                return 0;
            }
        }

        // This method adds a new currency type and return its success as an integer
        public int addNewType(String type)
        {
            try
            {
                // Create new currency category
                var category = new CurCategory()
                {
                    Category = type,
                };

                //Add to memory
                _context.CurCategories.Add(category);

                //Save to database
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                addException(e, "addNewType");
                return 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                addException(e, "addNewType");
                return 0;
            }
            catch (NotSupportedException e)
            {
                addException(e, "addNewType");
                return 0;
            }
            catch (ObjectDisposedException e)
            {
                addException(e, "addNewType");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "addNewType");
                return 0;
            }
        }

        // This method adds a new currency value and return its success as an integer
        public int addNewCurrencyValue(String type, decimal value)
        {
            try
            {
                // Linq query to get the categoryID
                var catID = (from s in _context.CurCategories
                             where (s.Category == type)
                             select s.CurCatID).SingleOrDefault();

                // Create new currency entry
                var cur = new Currency()
                {
                    Value = value,
                    CurrencyCategory = catID,
                };
                //Add to memory
                _context.Currencies.Add(cur);
                //Save to database
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                addException(e, "addNewCurrencyValue");
                return 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                addException(e, "addNewCurrencyValue");
                return 0;
            }
            catch (NotSupportedException e)
            {
                addException(e, "addNewCurrencyValue");
                return 0;
            }
            catch (ObjectDisposedException e)
            {
                addException(e, "addNewCurrencyValue");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "addNewCurrencyValue");
                return 0;
            }
        }

        // This method Updates currency value and return its success as an integer
        public int updateCurrency(String type, decimal value)
        {
            try
            {
                // Search and get the relevent row to update
                var Bns = _context.CurCategories.FirstOrDefault((bns) => bns.Category == type);
                String id = Bns.CurCatID;

                // Create new currency entry
                var cur = new Currency()
                {
                    Value = value,
                    CurrencyCategory = id,
                };
                _context.Currencies.Add(cur);
       
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                addException(e, "updateCurrency");
                return 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                addException(e, "updateCurrency");
                return 0;
            }
            catch (NotSupportedException e)
            {
                addException(e, "updateCurrency");
                return 0;
            }
            catch (ObjectDisposedException e)
            {
                addException(e, "updateCurrency");
                return 0;
            }
            catch (InvalidOperationException e)
            {
                addException(e, "updateCurrency");
                return 0;
            }
        }
    }
}
