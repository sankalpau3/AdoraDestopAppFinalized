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
    class FixedOverHeadDAO
    {
        //the adoraDBcontext object is created here
        adoraDBContext _context = new adoraDBContext();

        //method to add log entry with method name and exception
        private void addException(Exception ex, string methodname)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
                {
                    DirAppend.Log("____________________________________________________________________", w);
                    DirAppend.Log("InvalidOperationException at FixdOverHeadDAO -> "+methodname+" " + DateTime.Now.ToString(), w);
                    DirAppend.Log(ex.ToString(), w);
                }

        }
        //method to add fixed overhead detaisl returne true if successfull els false
        public bool addFixedOverHead(FixedOverHeadData fixOh)//this method adds data to fixed overhead db table
        {
            try
            {
                FixedOverhead fixadd = new FixedOverhead();
                fixadd.Year = fixOh.Year;
                fixadd.Month = fixOh.Month;
                fixadd.Electricity = (decimal)fixOh.Elect;
                fixadd.Tax = (decimal)fixOh.Tax;
                fixadd.Water = (decimal)fixOh.Water;
                fixadd.Salary = (decimal)fixOh.Salary;
                fixadd.RentOrMortgage = (decimal)fixOh.Rent;
                fixadd.PhoneAnInternet = (decimal)fixOh.PhInt;
                fixadd.Fuel = (decimal)fixOh.Fule;
                fixadd.Misc = (decimal)fixOh.Mess;
                fixadd.Ot = (decimal)fixOh.Ot;
                fixadd.Other = (decimal)fixOh.Other;

                _context.FixedOverheads.Add(fixadd);
                int chk = _context.SaveChanges();

                if (chk >= 0)
                    return true;
                else
                    return false;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                addException(invalidOperationException,  "addFixedOverHead");
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEntityValidationException)
            {
                addException(dbEntityValidationException, "addFixedOverHead()");
                return false;
            }

        }//addFixedOverHead method ends

        //this returns the month if it is already in the fixed overhead table eles returs null
        public string getmonth(int month, int year)
        {

            string fixID = "";

            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var mnth = (from ea in a.FixedOverheads
                                where (ea.Year == year && ea.Month == month)
                                select ea.FixID
                  ).ToList();

                    if (mnth.Count() > 0)
                    {

                        fixID = mnth.First();
                    }
                    else
                        fixID = null;
                    return fixID;
                }

            }
            catch (Exception ex)
            {
                addException(ex, "getmonth");
                return null;
            }
        }//getmonth methods ends

        //this method updates fixed overhead details and return true if success else return false
        public bool updateFixData(FixedOverHeadData data)
        {
            try
            {
                FixedOverhead fixedEdit = _context.FixedOverheads.FirstOrDefault(i => i.FixID == data.Id);

                fixedEdit.Year = data.Year;
                fixedEdit.Month = data.Month;
                fixedEdit.Electricity = (decimal)data.Elect;
                fixedEdit.Tax = (decimal)data.Tax;
                fixedEdit.Water = (decimal)data.Water;
                fixedEdit.Salary = (decimal)data.Salary;
                fixedEdit.RentOrMortgage = (decimal)data.Rent;
                fixedEdit.PhoneAnInternet = (decimal)data.Rent;
                fixedEdit.Fuel = (decimal)data.Fule;
                fixedEdit.Misc = (decimal)data.Mess;
                fixedEdit.Ot = (decimal)data.Ot;
                fixedEdit.Other = (decimal)data.Other;

                int chk = _context.SaveChanges();

                if (chk >= 0)
                    return true;
                else
                    return false;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                addException(invalidOperationException, "updateFixData()");
                return false;
            }


        }//updateFixData method ends

        //this method return the fixed ID when the month and year
        public string getIdByMonthNYear(int month, int year)
        {
            using (adoraDBContext a = new adoraDBContext())
            {
                var fid = (from ea in a.FixedOverheads
                           where (ea.Year == year && ea.Month == month)
                           select ea.FixID
              ).ToList();
                return fid.First();

            }
        }//getIdByMonthNYear mothod ends
        public bool deleteFixOH(string fixID)
        {
            try
            {
                FixedOverhead fixDetl = _context.FixedOverheads.FirstOrDefault(i => i.FixID == fixID);
                _context.FixedOverheads.Remove(fixDetl);
                int chk = _context.SaveChanges();

                if (chk >= 0)
                    return true;
                else
                    return false;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                addException(invalidOperationException, "deleteFixOH()");
                return false;
            }
        }//deleteFixOH method ends

        public List<int?> getMonthByYear(int year)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var mnth = (from e in a.FixedOverheads
                                where e.Year == year
                                select e.Month
                   ).Distinct().ToList();

                    return mnth; 
                }
            }
            catch (Exception eb)
            {
                addException(eb, "getMonthByYear()");
                return null; 
            }
        }//getmonthebyyear method ends

        public void populateYears(ComboBox cmbBox, ComboBox cmbFOHEditMonth)
        {
            cmbBox.SelectedIndex = -1;
            cmbFOHEditMonth.SelectedIndex = -1;
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var year = (from e in a.FixedOverheads select e.Year).Distinct().ToList();
                    cmbBox.ItemsSource = year;
                }
            }
            catch (ArgumentException argumentException)
            {
                addException(argumentException, "populateYears()");
            }
        }//populateYears method ends

       
    }
}
