using System;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Linq;
using ModernUIForWPFSample.WithoutBackButton.Data;
using ModernUIForWPFSample.WithoutBackButton.DataModels;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using FirstFloor.ModernUI.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for FixedOverHead.xaml
    /// </summary>
    /// 

     
    public partial class FixedOverHead : UserControl
    {
        //Objeccts of db context , fixed overhead DAO   and validation are created globly 
        adoraDBContext _context = new adoraDBContext();
        FixedOverHeadDAO fixDAO = new FixedOverHeadDAO();
        private Validations valid = new Validations();
        private KeyFunc keyf = new KeyFunc();
        LoginDetails _userType = new LoginDetails();
       
        //default constructor for the fixed overhead
        public FixedOverHead()
        {
            InitializeComponent();
           DateTime now = DateTime.Today;
            for (int i =2012; i <= now.Year ; i++)
            {
                cmbFOHForMonthYear.Items.Add(i.ToString());
            }
            cmbFOHForMonthYear.SelectedItem = now.Year.ToString();
        }

        //method to populate 
        private void populateMonths(ComboBox month, ComboBox year)
        {
            String years = "";
            if ((year.SelectedItem) != null)
            {
                years = year.Text;
                int year1 = Convert.ToInt32(cmbFOHEditYear.SelectedValue.ToString());

                month.ItemsSource = fixDAO.getMonthByYear(year1);
            }

        }

        private void btnFOHAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (getvalidationsEmptyFields())
                System.Windows.MessageBox.Show("Need to fill all the fields", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                FixedOverHeadDAO fixdao = new FixedOverHeadDAO();
                FixedOverHeadData fixdata = new FixedOverHeadData();
                //check for the values exisit in the tabel
                int mx = 0;
                string fixID = "";
                int mont = cmbFOHmonthComboBox.SelectedIndex + 1;
                int year1 = Convert.ToInt32(cmbFOHForMonthYear.SelectedValue.ToString());
                                                                                       
                fixID = fixdao.getmonth(mont, year1);
                if (fixID != null)
                    mx = 1;
                //end of check
                //parsig values to fixed overhead data objec

                fixdata.Year = Convert.ToInt32(cmbFOHForMonthYear.Text);
                fixdata.Month = cmbFOHmonthComboBox.SelectedIndex + 1;
                fixdata.Elect = Convert.ToDouble(txtFOHAddElectricityCost.Text);
                fixdata.Tax = Convert.ToDouble(txtFOHAddTaxCost.Text);
                fixdata.Water = Convert.ToDouble(txtFOHAddWaterCost.Text);
                fixdata.Salary = Convert.ToDouble(txtFOHAddSalaryCost.Text);
                fixdata.Rent = Convert.ToDouble(txtFOHAddRentMortgageLeaseLoanCost.Text);
                fixdata.PhInt = Convert.ToDouble(txtFOHAddPhoneInternetCost.Text);
                fixdata.Fule = Convert.ToDouble(txtFOHAddFuleCost.Text);
                fixdata.Mess = Convert.ToDouble(txtFOHAddMiscellaneousCost.Text);
                fixdata.Ot = Convert.ToDouble(txtFOHAddOTCost.Text);
                decimal other;

                //other field is allowed be blanked. if field is blank then the value is taken as 0
                if (string.IsNullOrEmpty(txtFOHAddOther.Text) || string.IsNullOrWhiteSpace(txtFOHAddOther.Text))
                    other = 0;
                else
                    other = Convert.ToDecimal(txtFOHAddOther.Text);
                fixdata.Other = (double)other;

                //fixed overhead add
                //
                if (btnFOHAdd.Content.ToString() == "Add")
                {
                    //check whether the fid overhead data for the perticular month is entered
                    if (mx == 0)
                    {
                        //fix overhead data in not available
                        if (fixdao.addFixedOverHead(fixdata))
                        { 
                            this.fixedOverheadDataGrid.Items.Refresh();
                            _context.FixedOverheads.Load();
                            fixDAO.populateYears(cmbFOHEditYear, cmbFOHEditMonth);
                            System.Windows.MessageBox.Show("Succesfully Added", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                            resetAll();
                        }
                        else
                            System.Windows.MessageBox.Show("Faild to Add", "Faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    }
                    else if (mx > 0)
                    {
                        //fix overhead data available 
                        //suggest to edit fix overhead data foe the perticualar month
                        MessageBoxResult msgresul = MessageBox.Show("Fixed Overheads details For this month are alredy exist do you want to update?", "Already exist", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        //get the confimation by the user to edit data
                        if (msgresul == MessageBoxResult.Yes)
                        {
                            //fill values to the month table
                            fillvalsToTextfohStriing(fixID);
                        }
                    }
                    else
                    {

                    }
                }
                else //fixed overhead edit function
                {
                    
                   
                    fixdata.Id = lbleditFOHID.Content.ToString();
                        
                    
                    try
                    {
                        if (fixdao.updateFixData(fixdata))
                        {
                            this.fixedOverheadDataGrid.Items.Refresh();
                            _context.FixedOverheads.Load();

                            System.Windows.MessageBox.Show("Succesfully updated", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                           // resetAll();
                        }
                        else
                            System.Windows.MessageBox.Show("Faild to update", "Faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Exception");
                    }
                }
            }
        }
        private void fillvalsToTextfoh(ComboBox mnt, ComboBox yr)
        {
            if (mnt.SelectedItem != null)
            {
                try
                {
                    int mnthx = Convert.ToInt32(mnt.Text);
                    int yearx = Convert.ToInt32(yr.Text);
                    String fixid;

                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var fid = (from ea in a.FixedOverheads
                                   where (ea.Year == yearx && ea.Month == mnthx)
                                   select ea.FixID
                      ).ToList();
                      fixid = fid.First();
                      lbleditFOHID.Content = fixid;
                    }

                    using (adoraDBContext a = new adoraDBContext())
                    {

                        var month = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Month).SingleOrDefault();
                        var year = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Year).SingleOrDefault();
                        var electricity = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Electricity).SingleOrDefault();
                        var water = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Water).SingleOrDefault();
                        var salary = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Salary).SingleOrDefault();
                        var fuel = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Fuel).SingleOrDefault();
                        var phone = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.PhoneAnInternet).SingleOrDefault();
                        var ot = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Ot).SingleOrDefault();
                        var misc = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Misc).SingleOrDefault();
                        var rent = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.RentOrMortgage).SingleOrDefault();
                        var other = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Other).SingleOrDefault();
                        var tax = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Tax).SingleOrDefault();

                        cmbFOHForMonthYear.SelectedItem = year.ToString();
                        cmbFOHmonthComboBox.SelectedIndex = Convert.ToInt32(month) - 1;
                        txtFOHAddElectricityCost.Text = Convert.ToDouble(electricity).ToString("0.00");
                        txtFOHAddWaterCost.Text = Convert.ToDouble(water).ToString("0.00");
                        txtFOHAddSalaryCost.Text = Convert.ToDouble(salary).ToString("0.00");
                        txtFOHAddFuleCost.Text = Convert.ToDouble(fuel).ToString("0.00");
                        txtFOHAddPhoneInternetCost.Text = Convert.ToDouble(phone).ToString("0.00");
                        txtFOHAddOTCost.Text = Convert.ToDouble(ot).ToString("0.00");
                        txtFOHAddMiscellaneousCost.Text = Convert.ToDouble(misc).ToString("0.00");
                        txtFOHAddRentMortgageLeaseLoanCost.Text = Convert.ToDouble(rent).ToString("0.00");
                        txtFOHAddTaxCost.Text = Convert.ToDouble(tax).ToString("0.00");
                        txtFOHAddOther.Text = Convert.ToDouble(other).ToString("0.00");

                        calOhTotal();

                        btnFOHAdd.Content = "Update";

                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.ToString());
                }
            }
        }
        private void fillvalsToTextfohStriing(string fixid)
        {
                try
                {
                    lbleditFOHID.Content = fixid;
                    using (adoraDBContext a = new adoraDBContext())
                    {

                        var month = (from e in a.FixedOverheads
                                     where (e.FixID == fixid)
                                     select e.Month).SingleOrDefault();
                        var year = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Year).SingleOrDefault();
                        var electricity = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Electricity).SingleOrDefault();
                        var water = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Water).SingleOrDefault();
                        var salary = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Salary).SingleOrDefault();
                        var fuel = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Fuel).SingleOrDefault();
                        var phone = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.PhoneAnInternet).SingleOrDefault();
                        var ot = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Ot).SingleOrDefault();
                        var misc = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Misc).SingleOrDefault();
                        var rent = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.RentOrMortgage).SingleOrDefault();
                        var other = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Other).SingleOrDefault();
                        var tax = (from e in a.FixedOverheads
                                    where (e.FixID == fixid)
                                    select e.Tax).SingleOrDefault();

                        cmbFOHForMonthYear.SelectedItem = year.ToString();
                        cmbFOHmonthComboBox.SelectedIndex = Convert.ToInt32(month) - 1;
                        txtFOHAddElectricityCost.Text = Convert.ToDouble(electricity).ToString("0.00");
                        txtFOHAddWaterCost.Text = Convert.ToDouble(water).ToString("0.00");
                        txtFOHAddSalaryCost.Text = Convert.ToDouble(salary).ToString("0.00");
                        txtFOHAddFuleCost.Text = Convert.ToDouble(fuel).ToString("0.00");
                        txtFOHAddPhoneInternetCost.Text = Convert.ToDouble(phone).ToString("0.00");
                        txtFOHAddOTCost.Text = Convert.ToDouble(ot).ToString("0.00");
                        txtFOHAddMiscellaneousCost.Text = Convert.ToDouble(misc).ToString("0.00");
                        txtFOHAddRentMortgageLeaseLoanCost.Text = Convert.ToDouble(rent).ToString("0.00");
                        txtFOHAddTaxCost.Text = Convert.ToDouble(tax).ToString("0.00");
                        txtFOHAddOther.Text = Convert.ToDouble(other).ToString("0.00");

                        calOhTotal();
                        btnFOHAdd.Content = "Update";

                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.ToString());
                }
            
        }
        private bool getvalidationsEmptyFields()
        {
            bool valresult1 = false;
            bool valresult2 = false;
            
            Validations val =  new Validations();
                      
            if (!val.emptyFieldValbyId(cmbFOHmonthComboBox, lblFOHErrForMonth))
            {
                lblFOHErrForMonth.Visibility = System.Windows.Visibility.Visible;
                valresult1 = true;
            }
            if (!val.emptyFieldValbyId(cmbFOHForMonthYear, lblFOHErrForMonth))
            {
                lblFOHErrForMonth.Visibility = System.Windows.Visibility.Visible;
                valresult2 = true;
            }
            return valresult1 && valresult2;
        }
        

        private bool isVisbleTrueErr()
        {
            bool a = lblFOHErrElectricityCost.IsVisible;
            bool b = lblFOHErrWaterCost.IsVisible;
            bool c = lblFOHErrSalatyCost.IsVisible;
            bool d = lblFOHErrFuleCost.IsVisible;
            bool e = lblFOHErrPhoneInternetCost.IsVisible;
            bool f = lblFOHErrMiscellaneousCost.IsVisible;
            bool g = lblFOHErrRentMortgageLeaseLoanCost.IsVisible;
            bool h = lblFOHErrTaxCost.IsVisible;
            bool i = lblFOHErrOTCost.IsVisible;
          //  bool j = lblFOHErrOther.IsVisible;

            if (a || b || c || d || e || f || g || h || i )
                return true;

            return false;
        }

        private void calOhTotal()
        {
            

                double elect = 0;
                double water = 0;
                double salary = 0;
                double fule = 0;
                double phInt = 0;
                double ot = 0;
                double mess = 0;
                double rent = 0;
                double tax = 0;
                double other = 0.0;

                if (txtFOHAddElectricityCost.Text != "")
                     elect = Convert.ToDouble(txtFOHAddElectricityCost.Text);
                else
                     txtFOHAddElectricityCost.Text = "0.00";

                if (txtFOHAddWaterCost.Text != "")
                    water = Convert.ToDouble(txtFOHAddWaterCost.Text);
                else
                     txtFOHAddWaterCost.Text = "0.00";

                if (txtFOHAddSalaryCost.Text != "")
                     salary = Convert.ToDouble(txtFOHAddSalaryCost.Text);
                else
                     txtFOHAddSalaryCost.Text = "0.00";

                if (txtFOHAddFuleCost.Text != "")
                     fule = Convert.ToDouble(txtFOHAddFuleCost.Text);
                else
                      txtFOHAddFuleCost.Text = "0.00";

                if (txtFOHAddPhoneInternetCost.Text != "")
                     phInt = Convert.ToDouble(txtFOHAddPhoneInternetCost.Text);
                else
                     txtFOHAddPhoneInternetCost.Text = "0.00";

                if (txtFOHAddOTCost.Text != "")
                     ot = Convert.ToDouble(txtFOHAddOTCost.Text);
                else
                     txtFOHAddOTCost.Text = "0.00";
               
                if (txtFOHAddMiscellaneousCost.Text != "")
                    mess = Convert.ToDouble(txtFOHAddMiscellaneousCost.Text);
                else
                     txtFOHAddMiscellaneousCost.Text = "0.00";
              
                if (txtFOHAddRentMortgageLeaseLoanCost.Text != "")
                    rent = Convert.ToDouble(txtFOHAddRentMortgageLeaseLoanCost.Text);
                else
                      txtFOHAddRentMortgageLeaseLoanCost.Text = "0.00";

                if (txtFOHAddTaxCost.Text != "")
                    tax = Convert.ToDouble(txtFOHAddTaxCost.Text);
                else
                    txtFOHAddTaxCost.Text = "0.00";

                if (txtFOHAddOther.Text != "")
                    other = Convert.ToDouble(txtFOHAddOther.Text);
                else
                    txtFOHAddOther.Text = "0.00";                

                double total = elect + water + salary + fule + phInt + ot + mess + rent + tax + other;

                string s = total.ToString("0.00");
                txtFOHToataOHCost.Text = s;
            
        }
        
      
        private void txtFOHAddElectricityCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            valid.emptyFieldVal(txtFOHAddElectricityCost, lblFOHErrElectricityCost);
            valid.numberFormatVal(txtFOHAddElectricityCost, lblFOHErrElectricityCost);
           
              
        }

        private void txtFOHAddWaterCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddWaterCost, lblFOHErrWaterCost); 
           valid.numberFormatVal(txtFOHAddWaterCost, lblFOHErrWaterCost);
         
        }

        private void txtFOHAddSalaryCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddSalaryCost, lblFOHErrSalatyCost);
           valid.numberFormatVal(txtFOHAddSalaryCost, lblFOHErrSalatyCost);
           
        }

        private void txtFOHAddFuleCost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFOHAddPhoneInternetCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            valid.emptyFieldVal(txtFOHAddPhoneInternetCost, lblFOHErrPhoneInternetCost);
            valid.numberFormatVal(txtFOHAddPhoneInternetCost, lblFOHErrPhoneInternetCost);
           
        }

        private void txtFOHAddOTCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddOTCost, lblFOHErrOTCost);
           valid.numberFormatVal(txtFOHAddOTCost, lblFOHErrOTCost);
          
        }

        private void txtFOHAddMiscellaneousCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddMiscellaneousCost, lblFOHErrMiscellaneousCost);
           valid.numberFormatVal(txtFOHAddMiscellaneousCost, lblFOHErrMiscellaneousCost);
          
        }

        private void txtFOHAddRentMortgageLeaseLoanCost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFOHAddTaxCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddTaxCost, lblFOHErrTaxCost);
           valid.numberFormatVal(txtFOHAddTaxCost, lblFOHErrTaxCost);
           
        }

        private void txtFOHAddRentMortgageLeaseLoanCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           valid.emptyFieldVal(txtFOHAddRentMortgageLeaseLoanCost, lblFOHErrRentMortgageLeaseLoanCost);
           valid.numberFormatVal(txtFOHAddRentMortgageLeaseLoanCost, lblFOHErrRentMortgageLeaseLoanCost);
           
        }

        private void txtFOHAddFuleCost_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            valid.emptyFieldVal(txtFOHAddFuleCost, lblFOHErrFuleCost);
            valid.numberFormatVal(txtFOHAddFuleCost, lblFOHErrFuleCost);
            
        }

       

       

        private void resetAll()
        {
            lblFOHErrElectricityCost.Visibility = Visibility.Hidden;
            lblFOHErrForMonth.Visibility = Visibility.Hidden;
            lblFOHErrFuleCost.Visibility = Visibility.Hidden;
            lblFOHErrMiscellaneousCost.Visibility = Visibility.Hidden;
            lblFOHErrOTCost.Visibility = Visibility.Hidden;
            lblFOHErrPhoneInternetCost.Visibility = Visibility.Hidden;
            lblFOHErrRentMortgageLeaseLoanCost.Visibility = Visibility.Hidden;
            lblFOHErrSalatyCost.Visibility = Visibility.Hidden;
            lblFOHErrTaxCost.Visibility = Visibility.Hidden;
            lblFOHErrWaterCost.Visibility = Visibility.Hidden;
            lblFOHErrForMonth.Visibility = Visibility.Hidden;

            txtFOHAddElectricityCost.Text = "";
            txtFOHAddFuleCost.Text = "";
            txtFOHAddMiscellaneousCost.Text = "";
            txtFOHAddPhoneInternetCost.Text = "";
            txtFOHAddRentMortgageLeaseLoanCost.Text = "";
            txtFOHAddSalaryCost.Text = "";
            txtFOHAddTaxCost.Text = "";
            txtFOHAddWaterCost.Text = "";
            txtFOHToataOHCost.Text = "";
            txtFOHAddOTCost.Text = "";
            txtFOHAddOther.Text = "";
            btnFOHAdd.Content = "Add";


            DateTime now = DateTime.Today;
            cmbFOHForMonthYear.SelectedItem = now.Year.ToString();
            cmbFOHmonthComboBox.SelectedIndex = -1;

            cmbFOHEditYear.SelectedIndex = -1;
            cmbFOHEditMonth.SelectedIndex = -1;
        }
        private void btnFOHReset_Click(object sender, RoutedEventArgs e)
        {
            resetAll();

        }

        private void btnFOHCal_Click(object sender, RoutedEventArgs e)
        {
            calOhTotal();
        }

       

        private void FixedOverHead1_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            System.Windows.Data.CollectionViewSource fixedOverheadViewSource =
                 ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixedOverheadViewSource")));

            // Load is an extension method on IQueryable,  
            // defined in the System.Data.Entity namespace. 
            // This method enumerates the results of the query,  
            // similar to ToList but without creating a list. 
            // When used with Linq to Entities this method  
            // creates entity objects and adds them to the context. 
            _context.FixedOverheads.Load();

            // After the data is loaded call the DbSet<T>.Local property  
            // to use the DbSet<T> as a binding source. 
            fixedOverheadViewSource.Source = _context.FixedOverheads.Local;
            fixDAO.populateYears(cmbFOHEditYear, cmbFOHEditMonth);

        }

        private void cmbFOHmonthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //hides the error icon
            lblFOHErrForMonth.Visibility = System.Windows.Visibility.Hidden;
        }

        
        private void cmbFOHForMonthYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            lblFOHErrForMonth.Visibility = System.Windows.Visibility.Hidden;
            string[] monthsToCombobox = DateTimeFormatInfo.CurrentInfo.MonthNames;
            DateTime now = DateTime.Today;
            if (cmbFOHForMonthYear.SelectedItem.ToString() == now.Year.ToString())
            {
                cmbFOHmonthComboBox.Items.Clear();
                //update the items of the cmbFOHmonthComboBox if the selected year is current year
                for (int i = 0; i < now.Month; i++)
                {

                    cmbFOHmonthComboBox.Items.Add(monthsToCombobox[i]);
                }
            }
            else
            {
                //update the items of the cmbFOHmonthComboBox if the selected year is a past year
                cmbFOHmonthComboBox.Items.Clear();
                for (int i = 0; i < 12; i++)
                {

                    cmbFOHmonthComboBox.Items.Add(monthsToCombobox[i]);
                }
            }
            
        }

        private void txtFOHAddOther_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void txtFOHAddOther_TextChanged(object sender, TextChangedEventArgs e)
        {
            //hide error icon
          //  valid.numberFormatVal(txtFOHAddOther, lblFOHErrOther);
        }

        private void cmbFOHEditYear_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //polpulate the two comboboexes
            populateMonths(cmbFOHEditMonth,cmbFOHEditYear);
        }

        //private void btnFOHEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (cmbFOHEditMonth.SelectedIndex >= 0)
        //    {
        //        fillvalsToTextfoh(cmbFOHEditMonth, cmbFOHEditYear);
        //    }
        //    else
        //        System.Windows.MessageBox.Show("Please select a year and a month to edit", "Please Select", MessageBoxButton.OK, MessageBoxImage.Warning);
        //}

        private void btnFOHDelete_Click(object sender, RoutedEventArgs e)
        {
            // If the user is authorized to perform the delete operation
            if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
            {
                //delete function
                FixedOverHeadDAO fixdao = new FixedOverHeadDAO();
                //get the confirmation with a message box with yes no cancel buttons
                if (System.Windows.MessageBox.Show("Do you want to delete " + cmbFOHEditYear.Text + " ," + cmbFOHEditMonth.Text + " months fixed overhead details?", "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    int mnthx = Convert.ToInt32(cmbFOHEditMonth.Text);
                    int yearx = Convert.ToInt32(cmbFOHEditYear.Text);

                    String fixid;
                    //dao method is called to delete the fix overhead
                    fixid = fixdao.getIdByMonthNYear(mnthx, yearx);
                    lbleditFOHID.Content = fixid;


                    if (fixdao.deleteFixOH(fixid))
                    {
                        this.fixedOverheadDataGrid.Items.Refresh();
                        _context.FixedOverheads.Load();
                        fixDAO.populateYears(cmbFOHEditYear, cmbFOHEditMonth);
                        System.Windows.MessageBox.Show("Succesfully Deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetAll();
                    }
                    else
                        System.Windows.MessageBox.Show("Faild to delete", "Faild", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);  
            }
            		
        }
    



        private void cmbFOHEditMonth_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbFOHEditMonth.SelectedIndex >= 0)
            {
                fillvalsToTextfoh(cmbFOHEditMonth, cmbFOHEditYear);
            }
            else
                System.Windows.MessageBox.Show("Please select a year and a month to edit", "Please Select", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void txtFOHAddElectricityCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrElectricityCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddElectricityCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddWaterCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrWaterCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddWaterCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddSalaryCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrSalatyCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddSalaryCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddFuleCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrFuleCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddFuleCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddPhoneInternetCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrPhoneInternetCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddPhoneInternetCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddOTCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrOTCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddOTCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddMiscellaneousCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrMiscellaneousCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddMiscellaneousCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddRentMortgageLeaseLoanCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrRentMortgageLeaseLoanCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddRentMortgageLeaseLoanCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddTaxCost_KeyDown(object sender, KeyEventArgs e)
        {
            lblFOHErrTaxCost.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddTaxCost.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

        private void txtFOHAddOther_KeyDown(object sender, KeyEventArgs e)
        {
            //lblFOHErrOther.Visibility = System.Windows.Visibility.Hidden;
            if (txtFOHAddOther.Text.IndexOf(".") == -1)
            {
                e.Handled = keyf.allowKeywithDot(e.Key);
            }
            else
            {
                e.Handled = keyf.allowKeywithOutDot(e.Key);
            }
        }

       

      

       
    }


   
}
