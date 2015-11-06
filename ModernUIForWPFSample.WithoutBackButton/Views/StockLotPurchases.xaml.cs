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
using System.Data.Entity;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using FirstFloor.ModernUI.Windows.Controls;


namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    
    

    public partial class StockLotPurchases : UserControl
    {
        private adoraDBContext _context = new adoraDBContext();
        LoginDetails _userType = new LoginDetails();
        Validations _val = new Validations();

        public StockLotPurchases()
        {
            InitializeComponent();
            txtAddDate.SelectedDate = DateTime.Today;
            populateCurrencyTypes(dropCurrency);
            dropCurrency.SelectedIndex = 2;
            
        }

        private void txtAddShipName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtAddNoPieces_KeyUp(object sender, KeyEventArgs e)
        {
            String s = txtAddNoPieces.Text;
            Match match = Regex.Match(s, "^[0-9]*$");
            if (!match.Success || s == null || s == "0")
            {
                lblAddNoPieces.Visibility = Visibility.Visible;
            }
            else
            {
                lblAddNoPieces.Visibility = Visibility.Hidden;
                
            }
        }

        private void txtAddPricePiece_KeyUp(object sender, KeyEventArgs e)
        {
            String s = txtAddPricePiece.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s,"^[-+]?[0-9]+\\.[0-9]+$");
            if ((!match1.Success && !match2.Success) || s == null || s == "0")
            {
                lblAddPPP.Visibility = Visibility.Visible;
            }
            else
            {
                lblAddPPP.Visibility = Visibility.Hidden;
                
            }
        }

        private void txtAddTrans_KeyUp(object sender, KeyEventArgs e)
        {
            String s = txtAddTrans.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s, "^[-+]?[0-9]+\\.[0-9]+$");
            if ((!match1.Success && !match2.Success) || s == null || s == "0")
            {
                lblAddTrans.Visibility = Visibility.Visible;
            }
            else
            {
                lblAddTrans.Visibility = Visibility.Hidden;
                
            }
        }

        private void txtAddSupComm_KeyUp(object sender, KeyEventArgs e)
        {
            String s = txtAddSupComm.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s, "^[-+]?[0-9]+\\.[0-9]+$");
            if ((!match1.Success && !match2.Success) || s == null || s == "0")
            {
                lblAddSupCom.Visibility = Visibility.Visible;
            }
            else
            {
                lblAddSupCom.Visibility = Visibility.Hidden;
                
            }
        }

        private void txtAddMisc_KeyUp(object sender, KeyEventArgs e)
        {
            String s = txtAddMisc.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s, "^[-+]?[0-9]+\\.[0-9]+$");
            if ((!match1.Success && !match2.Success) || s == null || s == "0")
            {
                lblAddMisc.Visibility = Visibility.Visible;
            }
            else
            {
                lblAddMisc.Visibility = Visibility.Hidden;
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            StockLotPurchaseHandle stl = new StockLotPurchaseHandle();

            ValidateNumbers();

            bool a = lblAddNoPieces.IsVisible;
            bool b = lblAddTrans.IsVisible;
            bool c = lblAddSupCom.IsVisible;
            bool d = lblAddMisc.IsVisible;
            bool f = lblAddPPP.IsVisible;

            if ( !a && !b && !c && !d && !f)
            {
                int No = Convert.ToInt32(txtAddNoPieces.Text);
                double PPP = Convert.ToDouble(txtAddPricePiece.Text);
                double Trans = Convert.ToDouble(txtAddTrans.Text);
                double SupCom = Convert.ToDouble(txtAddSupComm.Text);
                double Misc = Convert.ToDouble(txtAddMisc.Text);
                
                decimal value1 = Convert.ToDecimal(stl.CalcTotShipment(No,PPP, Trans, SupCom, Misc));
                txtAddTotalCost.Text = value1.ToString("0.00");

                decimal value2 = Convert.ToDecimal(stl.CalcCPP(No, PPP, Trans, SupCom, Misc));
                txtAddCPP.Text = value2.ToString("0.00");

                refresh();
            }
            else
            {
                txtAddTotalCost.Text = "";
                txtAddCPP.Text = "";
                MessageBox.Show("You need to fill all the values","Message");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ValidateValues();

            bool a = lblAddNoPieces.IsVisible;
            bool b = lblAddTrans.IsVisible;
            bool c = lblAddSupCom.IsVisible;
            bool d = lblAddMisc.IsVisible;
            bool f = lblAddPPP.IsVisible;
            bool g = lblAddDate.IsVisible;
            bool h = lblAddShipName.IsVisible;

            if (a || b || c || d || f || g || h)
            {
                MessageBox.Show("Check Values Again", "Message");
            }
            else
            {
                StockLotPurchaseHandle stl = new StockLotPurchaseHandle();

                int No = Convert.ToInt32(txtAddNoPieces.Text);
                double PPP = Convert.ToDouble(txtAddPricePiece.Text);
                double Trans = Convert.ToDouble(txtAddTrans.Text);
                double SupCom = Convert.ToDouble(txtAddSupComm.Text);
                double Misc = Convert.ToDouble(txtAddMisc.Text);

                double total = stl.CalcTotShipment(No, PPP, Trans, SupCom, Misc);
                double actualcostpp = stl.CalcCPP(No, PPP, Trans, SupCom, Misc);

                decimal pPPP = Convert.ToDecimal(PPP);
                decimal pTrans = Convert.ToDecimal(Trans);
                decimal pSupCom = Convert.ToDecimal(SupCom);
                decimal pMisc = Convert.ToDecimal(Misc);
                string pShipName = txtAddShipName.Text;
                DateTime pDate = Convert.ToDateTime(txtAddDate.Text);

                try
                {
                    PurchasingShipment ps = new PurchasingShipment();
                    ps.date = pDate;
                    ps.Title = pShipName;
                    ps.PricePerPiece = pPPP;
                    ps.NoOfPieces = No;
                    ps.SupplierCommission = pSupCom;
                    ps.TransportCost = pTrans;
                    ps.Micelleneous = pMisc;

                    _context.PurchasingShipments.Add(ps);
                    _context.SaveChanges();

                    this.purchasingShipmentDataGrid.Items.Refresh();
                    _context.PurchasingShipments.Load();
                    System.Windows.MessageBox.Show("Succesfully Added", "Done", MessageBoxButton.OK, MessageBoxImage.Information);

                    populateShipmentNames(txtDelShipName);
                    /*
                    string sql = "insert into PurchasingShipments(Title,Date,NoOfPieces,PricePerPiece,TransportCost,SupplierCommission,Micelleneous)" +
                                    "values(@P0,@P1,@P2,@P3,@P4,@P5,@P6)";

                    List<object> parameterList = new List<object>();
                    parameterList.Add(txtAddShipName.Text);
                    parameterList.Add(Convert.ToDateTime(txtAddDate.Text));
                    parameterList.Add(Convert.ToInt32(txtAddNoPieces.Text));
                    parameterList.Add(Convert.ToDecimal(txtAddPricePiece.Text));
                    parameterList.Add(Convert.ToDecimal(txtAddTrans.Text));
                    parameterList.Add(Convert.ToDecimal(txtAddSupComm.Text));
                    parameterList.Add(Convert.ToDecimal(txtAddMisc.Text));

                    

                    object[] parameters1 = parameterList.ToArray();
                    
                    int result = _context.Database.ExecuteSqlCommand(sql, parameters1);

                    _context.SaveChanges();
                    this.purchasingShipmentDataGrid.Items.Refresh();
                    _context.UserTypes.Load();
                    */

                    

                    refresh();
                    reset();
                    
                }
                catch(Exception)
                {
                }
                    
            }
        }



        public void ValidateNumbers()
        {
            if (String.IsNullOrEmpty(txtAddPricePiece.Text))
                lblAddPPP.Visibility = Visibility.Visible;
            if (String.IsNullOrEmpty(txtAddTrans.Text))
                lblAddTrans.Visibility = Visibility.Visible;
            if (String.IsNullOrEmpty(txtAddSupComm.Text))
                lblAddSupCom.Visibility = Visibility.Visible;
            if (String.IsNullOrEmpty(txtAddMisc.Text))
                lblAddMisc.Visibility = Visibility.Visible;
            if (String.IsNullOrEmpty(txtAddNoPieces.Text))
                lblAddNoPieces.Visibility = Visibility.Visible;
        }

        public void ValidateValues()
        {
            ValidateNumbers();
            if (String.IsNullOrEmpty(txtAddDate.Text))
                lblAddDate.Visibility = Visibility.Visible;
            if (String.IsNullOrEmpty(txtAddShipName.Text))
                lblAddShipName.Visibility = Visibility.Visible;
        }

        private void btnResetAdd_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void StockLotPurchases1_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
            populateShipmentNames(txtDelShipName);
        }

        public void refresh()
        {
            System.Windows.Data.CollectionViewSource purchasingShipmentViewSource =
                     ((System.Windows.Data.CollectionViewSource)(this.FindResource("purchasingShipmentViewSource")));

            // Load is an extension method on IQueryable,  
            // defined in the System.Data.Entity namespace. 
            // This method enumerates the results of the query,  
            // similar to ToList but without creating a list. 
            // When used with Linq to Entities this method  
            // creates entity objects and adds them to the context.
            adoraDBContext adb = new adoraDBContext();
            adb.PurchasingShipments.Load();

            // After the data is loaded call the DbSet<T>.Local property  
            // to use the DbSet<T> as a binding source. 

            purchasingShipmentViewSource.Source = adb.PurchasingShipments.Local;

            btnEdit.Visibility = Visibility.Hidden;
        
        }

        private void purchasingShipmentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void purchasingShipmentDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void populateShipmentNames(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var shipments = (from e in a.PurchasingShipments
                                     select e.Title
                   ).Distinct().ToList();

                    cmbBox.ItemsSource = shipments;
                }
                txtDelDate.SelectedIndex = -1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }


        private void populateShipmentDates(ComboBox date, ComboBox shipName)
        {
            String shipmentName = null;

            if ((shipName.SelectedItem) != null)
            {
                shipmentName = shipName.SelectedValue.ToString();

                try
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var dates = (from e in a.PurchasingShipments
                                     where e.Title == shipmentName
                                     select e.date
                       ).Distinct().ToList();

                        date.ItemsSource = dates;
                        //date.SelectedIndex = 0;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.InnerException.ToString());
                }
            }

        }

        private void populateShipmentID(ComboBox ID, ComboBox shipName)
        {
            String shipmentName = null;

            if ((shipName.SelectedItem) != null)
            {
                shipmentName = shipName.SelectedValue.ToString();

                try
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var ids = (from e in a.PurchasingShipments
                                     where e.Title == shipmentName
                                     select e.ShipmentID
                       ).Distinct().ToList();

                        ID.ItemsSource = ids;
                        //date.SelectedIndex = 0;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

        }

        private void txtDelShipName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateShipmentID(txtDelDate, txtDelShipName);
            reset();
        }

        void reset()
        {
            txtAddDate.SelectedDate = DateTime.Today;
            txtAddShipName.Text = "";
            txtAddNoPieces.Text = "";
            txtAddPricePiece.Text = "";
            txtAddTrans.Text = "";
            txtAddSupComm.Text = "";
            txtAddMisc.Text = "";
            txtAddTotalCost.Text = "";
            txtAddCPP.Text = "";

            lblAddDate.Visibility = Visibility.Hidden;
            lblAddMisc.Visibility = Visibility.Hidden;
            lblAddNoPieces.Visibility = Visibility.Hidden;
            lblAddPPP.Visibility = Visibility.Hidden;
            lblAddShipName.Visibility = Visibility.Hidden;
            lblAddSupCom.Visibility = Visibility.Hidden;
            lblAddTrans.Visibility = Visibility.Hidden;

            btnEdit.Visibility = Visibility.Hidden;
        
        }

        private void txtAddShipName_KeyUp(object sender, KeyEventArgs e)
        {
            string s = txtAddShipName.Text;

            if (s != "")
            {
                lblAddShipName.Visibility = Visibility.Hidden;
            }
            else 
            {
                lblAddShipName.Visibility = Visibility.Visible;
            }
        }

        private void txtDelDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillForEdit();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ValidateValues();

            bool a = lblAddNoPieces.IsVisible;
            bool b = lblAddTrans.IsVisible;
            bool c = lblAddSupCom.IsVisible;
            bool d = lblAddMisc.IsVisible;
            bool f = lblAddPPP.IsVisible;
            bool g = lblAddDate.IsVisible;
            bool h = lblAddShipName.IsVisible;

            if (a || b || c || d || f || g || h)
            {
                MessageBox.Show("Check Values Again", "Message");
            }
            else
            {
                StockLotPurchaseHandle stl = new StockLotPurchaseHandle();

                int No = Convert.ToInt32(txtAddNoPieces.Text);
                double PPP = Convert.ToDouble(txtAddPricePiece.Text);
                double Trans = Convert.ToDouble(txtAddTrans.Text);
                double SupCom = Convert.ToDouble(txtAddSupComm.Text);
                double Misc = Convert.ToDouble(txtAddMisc.Text);
                string ShipID = lblShipID.Content.ToString();

                double total = stl.CalcTotShipment(No, PPP, Trans, SupCom, Misc);
                double actualcostpp = stl.CalcCPP(No, PPP, Trans, SupCom, Misc);

                decimal pPPP = Convert.ToDecimal(PPP);
                decimal pTrans = Convert.ToDecimal(Trans);
                decimal pSupCom = Convert.ToDecimal(SupCom);
                decimal pMisc = Convert.ToDecimal(Misc);
                string pShipName = txtAddShipName.Text;
                DateTime pDate = Convert.ToDateTime(txtAddDate.Text);
                

                try
                {
                    adoraDBContext con = new adoraDBContext();
                    PurchasingShipment ps = _context.PurchasingShipments.First(i => i.ShipmentID == ShipID);
                    ps.PricePerPiece = pPPP;
                    ps.TransportCost = pTrans;
                    ps.SupplierCommission = pSupCom;
                    ps.Micelleneous = pMisc;
                    ps.Title = pShipName;
                    ps.date = pDate;

                    _context.SaveChanges();
                    populateShipmentNames(txtDelShipName);
                    this.purchasingShipmentDataGrid.Items.Refresh();
                    _context.PurchasingShipments.Load();
                    System.Windows.MessageBox.Show("Succesfully Updated", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    refresh();
                    reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void Rectangle_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
                        lblAddDate.Visibility = Visibility.Hidden;
        }

        private void fillForEdit()
        {

            btnEdit.Visibility = Visibility.Visible;
            string ShipmentID = null;
            lblShipID.Content = ShipmentID;
            string ShipName = txtDelShipName.Text;
            //System.DateTime ShipDate = Convert.ToDateTime(txtDelDate.SelectedValue);


            try
            {
                using (adoraDBContext ad = new adoraDBContext())
                {
                    lblShipID.Content = txtDelDate.SelectedValue.ToString();
                    ShipmentID = lblShipID.Content.ToString();
                   

                    var NoPieces = (from ab in ad.PurchasingShipments
                                    where (ab.ShipmentID == ShipmentID)
                                    select ab.NoOfPieces).SingleOrDefault();

                    var PPP = (from ab in ad.PurchasingShipments
                               where (ab.ShipmentID == ShipmentID)
                               select ab.PricePerPiece).SingleOrDefault();

                    var Trans = (from ab in ad.PurchasingShipments
                                 where (ab.ShipmentID == ShipmentID)
                                 select ab.TransportCost).SingleOrDefault();

                    var SupCom = (from ab in ad.PurchasingShipments
                                  where (ab.ShipmentID == ShipmentID)
                                  select ab.SupplierCommission).SingleOrDefault();

                    var Misc = (from ab in ad.PurchasingShipments
                                where (ab.ShipmentID == ShipmentID)
                                select ab.Micelleneous).SingleOrDefault();

                    var Date = (from ab in ad.PurchasingShipments
                                where (ab.ShipmentID == ShipmentID)
                                select ab.date).SingleOrDefault();

                    txtAddDate.SelectedDate = Convert.ToDateTime(Date.ToString());
                    txtAddShipName.Text = txtDelShipName.Text;
                    txtAddNoPieces.Text = NoPieces.ToString();
                    txtAddPricePiece.Text = PPP.ToString();
                    txtAddTrans.Text = Trans.ToString();
                    txtAddSupComm.Text = SupCom.ToString();
                    txtAddMisc.Text = Misc.ToString();

                }
            }
            catch (Exception e)
            {
               // MessageBox.Show(e.ToString());
            }
        
        }

        private void txtDelDate_DropDownClosed(object sender, EventArgs e)
        {
            fillForEdit();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // If the user is authorized to perform the delete operation
            if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
            {
                try
                {

                    string id = lblShipID.Content.ToString();
                    if (MessageBox.Show("Do you want to delete " + id, "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        adoraDBContext adb = new adoraDBContext();
                        PurchasingShipment psp = adb.PurchasingShipments.FirstOrDefault(i => i.ShipmentID == id);
                        adb.PurchasingShipments.Remove(psp);
                        adb.SaveChanges();

                        // this.purchasingShipmentDataGrid.Items.Refresh();
                        //context.PurchasingShipments.Load();
                        populateShipmentNames(txtDelShipName);
                        MessageBox.Show("Successfully Deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show("You cannot delete Shipments which are having associated frequencies! Please delete associated frequencies before deleting the shipment");

                }

                //adoraDBContext _con = new adoraDBContext();
                //_con.PurchasingShipments.Load();
                //this.purchasingShipmentDataGrid.Items.Refresh();
                refresh();
            }
                else
              {
                  ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);  
              }
            
        }

        private void txtDelShipName_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void dropCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((txtAddTotalCost.Text != null && txtAddTotalCost.Text != "") && (txtAddCPP.Text != null && txtAddCPP.Text != ""))
            {
                int No = Convert.ToInt32(txtAddNoPieces.Text);
                double PPP = Convert.ToDouble(txtAddPricePiece.Text);
                double Trans = Convert.ToDouble(txtAddTrans.Text);
                double SupCom = Convert.ToDouble(txtAddSupComm.Text);
                double Misc = Convert.ToDouble(txtAddMisc.Text);

                StockLotPurchaseHandle stl = new StockLotPurchaseHandle();

                double total = Convert.ToDouble(stl.CalcTotShipment(No, PPP, Trans, SupCom, Misc));
                //txtAddTotalCost.Text = value1.ToString("0.00");

                double actual = Convert.ToDouble(stl.CalcCPP(No, PPP, Trans, SupCom, Misc));
                //txtAddCPP.Text = value2.ToString("0.00");

                double trueTotal = 0;
                double trueActual = 0;
                if (dropCurrency.SelectedValue.ToString() != "LKR")
                {

                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var id = (from ee in a.CurCategories
                                  where (ee.Category == dropCurrency.SelectedValue.ToString())
                                  select ee.CurCatID).SingleOrDefault();
                        var val = (from s in a.Currencies
                                   where s.CurrencyCategory == id
                                   select s.Value).ToList();

                        double value = Convert.ToDouble(val.Last());
                        trueTotal = total / value;
                        trueActual = actual / value;
                    }
                }
                else
                {
                    trueTotal = total;
                    trueActual = actual;
                }

                //MessageBox.Show(dropCurrency.SelectedValue.ToString());

                txtAddTotalCost.Text = trueTotal.ToString("F");
                txtAddCPP.Text = trueActual.ToString("F");

                curlbl1.Content = dropCurrency.SelectedValue.ToString();
                curlbl2.Content = dropCurrency.SelectedValue.ToString();
            }
        }

        private void populateCurrencyTypes(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var types = (from e in a.CurCategories
                                 select e.Category
                   ).Distinct().ToList();

                    cmbBox.ItemsSource = types;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }

        private void txtAddNoPieces_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
        }

        private void txtAddPricePiece_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAddPricePiece.Text.IndexOf(".") == -1)
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key) && !_val.isDot(e.Key);
            }
            else
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
            }
        }

        private void txtAddTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAddTrans.Text.IndexOf(".") == -1)
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key) && !_val.isDot(e.Key);
            }
            else
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
            }
        }

        private void txtAddSupComm_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAddSupComm.Text.IndexOf(".") == -1)
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key) && !_val.isDot(e.Key);
            }
            else
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
            }
        }

        private void txtAddMisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAddMisc.Text.IndexOf(".") == -1)
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key) && !_val.isDot(e.Key);
            }
            else
            {
                e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
            }
        }

    }
}
