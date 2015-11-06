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
using ModernUIForWPFSample.WithoutBackButton.Functions;
using ModernUIForWPFSample.WithoutBackButton.DataModels;
using System.Collections.ObjectModel;
using FirstFloor.ModernUI.Windows.Controls;


namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for FOBActualCost.xaml
    /// </summary>
    public partial class FOBActualCost : UserControl
    {
        adoraDBContext _context = new adoraDBContext();
        FOBActualCostDAO actCostdao = new FOBActualCostDAO();
        private List<string> fabIDtoRem = new List<string>();
        private List<string> accIDtoRem = new List<string>();
        LoginDetails _userType = new LoginDetails();

        public FOBActualCost()
        {
            InitializeComponent();
            populateItemCombo();
            populateTypeCombo();
            actCostdao.updateSearchComboBox(cmbEditAcost);
            actCostdao.currency(cmbCurrency);
            hideComb();
             
        }
        private void hideComb()
        {
            lstBoxAccCostID.Visibility = System.Windows.Visibility.Hidden;
            lstBoxFabCostID.Visibility = System.Windows.Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            System.Windows.Data.CollectionViewSource actualCostViewSource =
                 ((System.Windows.Data.CollectionViewSource)(this.FindResource("actualCostViewSource")));
            _context.ActualCosts.Load();
            actualCostViewSource.Source = _context.ActualCosts.Local;
        }

        private void removeItem(ListBox lb, int index)
        {
            List<string> lst = new List<string>();

            for (int i = 0; i < lb.Items.Count; i++)
            {
                lst.Add(lb.Items[i].ToString());
            }
            lst.RemoveAt(index);
            lb.ItemsSource = lst;
        }
        private void addItems(ListBox lb, string val)
        {
            List<string> lst = new List<string>();
            lst.Add(val);
            for (int i = 0; i < lb.Items.Count; i++)
            {
                lst.Add(lb.Items[i].ToString());
            }
           
            lb.ItemsSource = lst;
        }
        private void clear(ComboBox cmb, TextBox txt1, TextBox txt2, Button btn, TextBox txt3)
        {
            cmb.SelectedIndex = -1;
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";

            txt1.IsEnabled = false;
            txt2.IsEnabled = false;
            txt3.IsEnabled = false;
            btn.IsEnabled = false;
        }
        private void clear(ComboBox cmb, TextBox txt1, TextBox txt2, Button btn)
        {
            cmb.SelectedIndex = -1;
            txt1.Text = "";
            txt2.Text = "";
           

            txt1.IsEnabled = false;
            txt2.IsEnabled = false;
            btn.IsEnabled = false;
        }

        private void clearfab()
        {
            lstBoxFabCPY.ItemsSource = null;
            lstBoxFabCost.ItemsSource = null;
            lstBoxFabComsup.ItemsSource = null;
            lstBoxFabType.ItemsSource = null;
            lstBoxFabCostID.ItemsSource = null;

            lstBoxFabCPY.Items.Refresh();
            lstBoxFabCost.Items.Refresh();
            lstBoxFabComsup.Items.Refresh();
            lstBoxFabType.Items.Refresh();
            lstBoxFabCostID.Items.Refresh();

            lstBoxFabCPY.Items.Clear();
            lstBoxFabCost.Items.Clear();
            lstBoxFabComsup.Items.Clear();
            lstBoxFabType.Items.Clear();
            lstBoxFabCostID.Items.Clear();
        }

        private void clearAcc()
        {
            lstBoxAccCostID.ItemsSource = null;
            lstBoxAccType.ItemsSource = null;
            lstBoxAccWPI.ItemsSource = null;
            lstBoxAccCostForH.ItemsSource = null;
            lstBoxAccAmt.ItemsSource = null;
            lstBoxAccCostPI.ItemsSource = null;

            lstBoxAccCostID.Items.Refresh();
            lstBoxAccType.Items.Refresh();
            lstBoxAccWPI.Items.Refresh();
            lstBoxAccCostForH.Items.Refresh();
            lstBoxAccAmt.Items.Refresh();
            lstBoxAccCostPI.Items.Refresh();

            lstBoxAccCostID.Items.Clear();
            lstBoxAccType.Items.Clear();
            lstBoxAccWPI.Items.Clear();
            lstBoxAccCostForH.Items.Clear();
            lstBoxAccAmt.Items.Clear();
            lstBoxAccCostPI.Items.Clear();
        }
        private void clearAll()
        {
            clear(cmbFabTypes, txtCostPYard, txtConsump, btnAddFabToList);
            clear(cmbAccTypes, txtWeightPItem, txtCostOfHgrams, btnAddAccList, txtAccAmt);
            clearAcc();
            clearfab();
            cmbEditAcost.SelectedIndex = -1;
            cmbSelectItem.SelectedIndex = -1;
            lblStylishDisplay.Content = "";
            btnCal.Content = "Add";
            lblActCost_Display.Content = "";
            lblCmDisplay.Content = "";
        }
        private void addActDetails()
        {
            if (lstBoxFabCost.Items.Count != 0 && lstBoxAccCostPI.Items.Count != 0 && cmbCurrency.SelectedIndex != -1)
            {
                ActualCostHandle actCostHandle = new ActualCostHandle();
                FOBActualCostDAO daoObject = new FOBActualCostDAO();
                string cmx = cmbCurrency.Text;
                
                double total = actCostHandle.calTotalCost(lstBoxFabCost, lstBoxAccCostPI);

                if (daoObject.addActualCost(total, cmx))
                {
                    string ActCostId = daoObject.getLastActualCostId();
                    bool getverificatio1 = false, getverificatio2 = false;
                    AccessoryCostData accCostData = new AccessoryCostData();
                    FabricCostData fabCostData = new FabricCostData();

                    int size = lstBoxAccCostPI.Items.Count;

                    for (int i = 0; i < size; i++)
                    {
                        accCostData.Unit = actCostdao.getuntype(lstBoxAccType.Items[i].ToString());
                        //accCostData.Unit = actCostHandle.getUnitType(lstBoxAccType.Items[i].ToString());
                        accCostData.Amount = Convert.ToDouble(lstBoxAccAmt.Items[i].ToString());
                        accCostData.Type = lstBoxAccType.Items[i].ToString();
                        accCostData.Cost = Convert.ToDouble(lstBoxAccCostPI.Items[i].ToString());
                        accCostData.WeightPItem = Convert.ToDouble(lstBoxAccWPI.Items[i].ToString());
                        accCostData.AcostID = ActCostId;
                        accCostData.Chg = Convert.ToDouble(lstBoxAccCostForH.Items[i].ToString());

                        getverificatio1 = daoObject.addAccessoryCost(accCostData);

                    }
                    size = lstBoxFabCost.Items.Count;
                    for (int i = 0; i < size; i++)
                    {
                        fabCostData.Type = lstBoxFabType.Items[i].ToString();
                        fabCostData.Amount = Convert.ToDouble(lstBoxFabComsup.Items[i].ToString());
                        fabCostData.Cost = Convert.ToDouble(lstBoxFabCost.Items[i].ToString());
                        fabCostData.CostPyard = Convert.ToDouble(lstBoxFabCPY.Items[i].ToString());
                        fabCostData.ACostID = ActCostId;

                        getverificatio2 = daoObject.addFabricCost(fabCostData);
                    }

                    if (getverificatio1 && getverificatio2 && daoObject.updateStock(cmbSelectItem.Text.ToString().Split('|')[1], ActCostId))
                    {
                        _context.SaveChanges();
                        _context.ActualCosts.Load();

                        this.actualCostDataGrid.Items.Refresh();
                        actCostdao.updateSearchComboBox(cmbEditAcost);
                        actCostdao.getTotal(ActCostId, lblCmDisplay, lblActCost_Display, true);
                        populateItemCombo();
                        clearAcc();
                        MessageBox.Show("Successfully Added", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else
                { }
            }
            else if (cmbCurrency.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select CM", "Select", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please Add values to the Fabrics and Accessories", "Empty fileds available", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loadData(bool add)
        {
            actCostdao.getTotal(cmbEditAcost.Text, lblCmDisplay, lblActCost_Display, add);
            actCostdao.setCm(cmbCurrency, cmbEditAcost.Text);
            actCostdao.fillListFabs(lstBoxFabCostID, lstBoxFabType, lstBoxFabComsup, lstBoxFabCost, lstBoxFabCPY, cmbEditAcost.Text);
            btnCal.Content = "Edit";
            actCostdao.fillListAccs(lstBoxAccCostID, lstBoxAccType, lstBoxAccWPI, lstBoxAccCostForH, lstBoxAccAmt, lstBoxAccCostPI, cmbEditAcost.Text);
            lblStylishDisplay.Content = actCostdao.getItemName(cmbEditAcost.Text);
            cmbAccTypes.IsEnabled = true;
            cmbFabTypes.IsEnabled = true;
            fabIDtoRem.Clear();
            accIDtoRem.Clear();
        }


        private void editActAccCost()
        {
            FabricCostData fabdata = new FabricCostData();
            AccessoryCostData accdata = new AccessoryCostData();
            ActualCostHandle actCostHandle = new ActualCostHandle();
            bool chk1 = true;
            bool chk2 = true;
            bool chk3 = true;
            bool chk4 = true;
            foreach (string w in fabIDtoRem)
            {
                if (!actCostdao.deleteFromFab(w))
                    chk1 = false;
            }
            foreach (string w in accIDtoRem)
            {
                if (!actCostdao.deleteFromAcc(w))
                    chk2 = false;
            }



            for (int i = 0; i < lstBoxFabCostID.Items.Count; i++)
            {
                if (lstBoxFabCostID.Items[i].ToString() == "XXXX")
                {


                    fabdata.Type = lstBoxFabType.Items[i].ToString();
                    fabdata.Amount = Convert.ToDouble(lstBoxFabComsup.Items[i].ToString());
                    fabdata.Cost = Convert.ToDouble(lstBoxFabCost.Items[i].ToString());
                    fabdata.CostPyard = Convert.ToDouble(lstBoxFabCPY.Items[i].ToString());
                    fabdata.ACostID = cmbEditAcost.Text;

                    if (!actCostdao.addFabricCost(fabdata))
                        chk3 = false;
                }
            }//for loop for addign fabrics in the edit part ends

            for (int i = 0; i < lstBoxAccCostID.Items.Count; i++)
            {
                if (lstBoxAccCostID.Items[i].ToString() == "XXXX")
                {
                    accdata.Unit = actCostdao.getuntype(lstBoxAccType.Items[i].ToString());
                    //accdata.Unit = actCostHandle.getUnitType(lstBoxAccType.Items[i].ToString());
                    accdata.Amount = Convert.ToDouble(lstBoxAccAmt.Items[i].ToString());
                    accdata.Type = lstBoxAccType.Items[i].ToString();
                    accdata.Cost = Convert.ToDouble(lstBoxAccCostPI.Items[i].ToString());
                    accdata.WeightPItem = Convert.ToDouble(lstBoxAccWPI.Items[i].ToString());
                    accdata.AcostID = cmbEditAcost.Text;
                    accdata.Chg = Convert.ToDouble(lstBoxAccCostForH.Items[i].ToString());

                    if (!actCostdao.addAccessoryCost(accdata))
                        chk4 = false;

                }
            }//for loop for adding acc in the edit part ends

            double totalx = actCostHandle.calTotalCost(lstBoxFabCost, lstBoxAccCostPI);
            //MessageBox.Show(actCostdao.editActCost(cmbEditAcost.Text.ToString(), totalx, cmbCurrency.Text).ToString()+"|"+ chk1.ToString()+"|"+chk2.ToString()+"|"+chk3.ToString()+"|"+chk4.ToString());
            if (actCostdao.editActCost(cmbEditAcost.Text.ToString(), totalx, cmbCurrency.Text) && chk1 && chk2 && chk3 && chk4)
            {
                MessageBox.Show("Successfully Edited", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                _context.ActualCosts.Load();

                this.actualCostDataGrid.Items.Refresh();
                string actcostid = cmbEditAcost.Text;
                clearAll();
                cmbEditAcost.SelectedItem = actcostid;
                loadData(false);
                actCostdao.getTotal(cmbEditAcost.Text, lblCmDisplay, lblActCost_Display, false);

            }
            else
                MessageBox.Show("Faild to Edit", "Faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void populateItemCombo()
        {
            FOBActualCostDAO actualcostOject = new FOBActualCostDAO();
            cmbSelectItem.ItemsSource =  actualcostOject.getItems();
        }

        private void populateTypeCombo()
        {
            FOBActualCostDAO actualcostOject = new FOBActualCostDAO();
            cmbAccTypes.ItemsSource = actualcostOject.getAccTypes();
            cmbFabTypes.ItemsSource = actualcostOject.getFabTypes();
        }

        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if ((inKey < Key.NumPad0 || inKey > Key.NumPad9) || inKey != Key.Decimal || inKey != Key.OemPeriod)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isDot(Key inkey)
        {
            return inkey == Key.OemPeriod || inkey == Key.Decimal;            
        }


        private bool IsActionKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
        }
       

        private void cmbSelectItem_DropDownClosed(object sender, EventArgs e)
        {
           // lblStylishDisplay.Content =  cmbSelectItem.SelectedValue.ToString();
        }

       

        private void cmbSelectItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] arr =cmbSelectItem.SelectedValue.ToString().Split('|');
                lblStylishDisplay.Content = arr[0];
                if (cmbSelectItem.SelectedIndex >= 0)
                {
                    cmbAccTypes.IsEnabled = true;
                    cmbFabTypes.IsEnabled = true;
                }
            }
            catch (NullReferenceException)
            {
            }
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnCal.Content.ToString() == "Add")
            {
                addActDetails();
                clearAll();
 
            }//if for button content check ends
            else if (btnCal.Content.ToString() == "Edit")
            {
                editActAccCost();
            }
        }

        private void cmbFabTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFabTypes.SelectedIndex >= 0)
            {
                txtConsump.IsEnabled = true;
                txtCostPYard.IsEnabled = true;
                btnAddFabToList.IsEnabled = true;
            }
        }

        private void cmbAccTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAccTypes.SelectedIndex >= 0)
            {
                txtWeightPItem.IsEnabled = true;
                txtCostOfHgrams.IsEnabled = true;
                btnAddAccList.IsEnabled = true;
                txtAccAmt.IsEnabled = true;
            }
        }

        private void txtCostPYard_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (txtCostPYard.Text.IndexOf(".") == -1)
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key) && !isDot(e.Key);
            }
            else
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key);
            }
           

            
        }

        private void txtConsump_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtConsump.Text.IndexOf(".") == -1)
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key) && !isDot(e.Key);
            }
            else
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key);
            }
        }

        private void txtWeightPItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtWeightPItem.Text.IndexOf(".") == -1)
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key) && !isDot(e.Key);
            }
            else
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key);
            }
        }

        private void txtCostOfHgrams_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCostOfHgrams.Text.IndexOf(".") == -1)
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key) && !isDot(e.Key);
            }
            else
            {
                e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key);
            }
        }

        private void btnAddFabToList_Click(object sender, RoutedEventArgs e)
        {
            Validations val = new Validations();

            if ((val.emptyFieldVal(txtCostPYard.Text) || val.emptyFieldVal(txtConsump.Text)))
            {
                
                try
                {
                    double fabCPY = Convert.ToDouble(txtCostPYard.Text);
                    double fabComsup = Convert.ToDouble(txtConsump.Text);

                    addItems(lstBoxFabType, cmbFabTypes.SelectedValue.ToString());
                    addItems(lstBoxFabCPY, txtCostPYard.Text);
                    addItems(lstBoxFabComsup, txtConsump.Text);
                    addItems(lstBoxFabCost, (fabCPY * fabComsup).ToString("0.00"));
                    addItems(lstBoxFabCostID, "XXXX");


                    clear(cmbFabTypes, txtCostPYard, txtConsump, btnAddFabToList);
                }
                catch (Exception)
                {
                }

            }
            else
            {
                MessageBox.Show("Cost per Yard and Consumtion can not be empty !", "Empty Fields in Fabrics", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnAddAccList_Click(object sender, RoutedEventArgs e)
        {
            Validations val = new Validations();

            if ((val.emptyFieldVal(txtWeightPItem.Text) || val.emptyFieldVal(txtCostOfHgrams.Text)))
            {
                
                double wPI = Convert.ToDouble(txtWeightPItem.Text);
                double costForH = Convert.ToDouble(txtCostOfHgrams.Text);
                double amt = Convert.ToDouble(txtAccAmt.Text);

                addItems(lstBoxAccType, cmbAccTypes.SelectedValue.ToString());
                addItems(lstBoxAccWPI, txtWeightPItem.Text);
                addItems(lstBoxAccCostForH, txtCostOfHgrams.Text);
                addItems(lstBoxAccAmt, txtAccAmt.Text);
                addItems(lstBoxAccCostPI, ((costForH / 100.0) * wPI * amt).ToString("0.00"));
                addItems(lstBoxAccCostID, "XXXX");


                clear(cmbAccTypes, txtWeightPItem, txtCostOfHgrams, btnAddAccList, txtAccAmt);
            }
            else
            {
                MessageBox.Show("Weight per item and Cost of 100 grams can not be empty !", "Empty Fields in Accessories", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void lstBoxFabType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxFabCPY.SelectedIndex = lstBoxFabType.SelectedIndex;
            lstBoxFabComsup.SelectedIndex = lstBoxFabType.SelectedIndex;
            lstBoxFabCost.SelectedIndex = lstBoxFabType.SelectedIndex;
            lstBoxFabCostID.SelectedIndex = lstBoxFabType.SelectedIndex;
        }

        private void lstBoxFabCPY_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxFabType.SelectedIndex = lstBoxFabCPY.SelectedIndex;
            lstBoxFabComsup.SelectedIndex = lstBoxFabCPY.SelectedIndex;
            lstBoxFabCost.SelectedIndex = lstBoxFabCPY.SelectedIndex;
            lstBoxFabCostID.SelectedIndex = lstBoxFabCPY.SelectedIndex;
        }

        private void lstBoxFabComsup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxFabType.SelectedIndex = lstBoxFabComsup.SelectedIndex;
            lstBoxFabCPY.SelectedIndex = lstBoxFabComsup.SelectedIndex;
            lstBoxFabCost.SelectedIndex = lstBoxFabComsup.SelectedIndex;
            lstBoxFabCostID.SelectedIndex = lstBoxFabComsup.SelectedIndex;
        }

        private void lstBoxFabCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxFabType.SelectedIndex = lstBoxFabCost.SelectedIndex;
            lstBoxFabCPY.SelectedIndex = lstBoxFabCost.SelectedIndex;
            lstBoxFabComsup.SelectedIndex = lstBoxFabCost.SelectedIndex;
            lstBoxFabCostID.SelectedIndex = lstBoxFabCost.SelectedIndex;


        }

        private void cmbSelectItem_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            
           
        }

        private void cmbSelectItem_TextInput(object sender, TextCompositionEventArgs e)
        {
            
    
        }

        private void cmbSelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbSelectItem.Text.ToString().Length > 2)
            {
                lblStylishDisplay.Content = cmbSelectItem.Text.ToString();
                cmbAccTypes.IsEnabled = true;
                cmbFabTypes.IsEnabled = true;
            }
            
        }

        private void lstBoxAccType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxAccWPI.SelectedIndex = lstBoxAccType.SelectedIndex;
            lstBoxAccCostForH.SelectedIndex = lstBoxAccType.SelectedIndex;
            lstBoxAccCostPI.SelectedIndex = lstBoxAccType.SelectedIndex;
            lstBoxAccCostID.SelectedIndex = lstBoxAccType.SelectedIndex;
            lstBoxAccAmt.SelectedIndex = lstBoxAccType.SelectedIndex;
        }

        private void lstBoxAccWPI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxAccType.SelectedIndex = lstBoxAccWPI.SelectedIndex;
            lstBoxAccCostForH.SelectedIndex = lstBoxAccWPI.SelectedIndex;
            lstBoxAccCostPI.SelectedIndex = lstBoxAccWPI.SelectedIndex;
            lstBoxAccCostID.SelectedIndex = lstBoxAccWPI.SelectedIndex;
            lstBoxAccAmt.SelectedIndex = lstBoxAccWPI.SelectedIndex;

        }

        private void lstBoxAccCostForH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxAccType.SelectedIndex = lstBoxAccCostForH.SelectedIndex;
            lstBoxAccWPI.SelectedIndex = lstBoxAccCostForH.SelectedIndex;
            lstBoxAccCostPI.SelectedIndex = lstBoxAccCostForH.SelectedIndex;
            lstBoxAccCostID.SelectedIndex = lstBoxAccCostForH.SelectedIndex;
            lstBoxAccAmt.SelectedIndex = lstBoxAccCostForH.SelectedIndex;


        }

        private void lstBoxAccCostPI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxAccType.SelectedIndex = lstBoxAccCostPI.SelectedIndex;
            lstBoxAccWPI.SelectedIndex = lstBoxAccCostPI.SelectedIndex;
            lstBoxAccCostForH.SelectedIndex = lstBoxAccCostPI.SelectedIndex;
            lstBoxAccCostID.SelectedIndex = lstBoxAccCostPI.SelectedIndex;
            lstBoxAccAmt.SelectedIndex = lstBoxAccCostPI.SelectedIndex;


        }

        private void cmbEditAcost_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void cmbEditAcost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //fillListFabs(ListBox id, ListBox type, ListBox consum, ListBox cost, ListBox costpy, string idString)
           // actCostdao.fillListFabs(lstBoxFabCostID, lstBoxFabType, lstBoxFabComsup, lstBoxFabCost, lstBoxFabCPY, cmbEditAcost.Text);
        }

        private void txtAccAmt_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key);
        }

        private void cmbEditAcost_DropDownClosed(object sender, EventArgs e)
        {
            loadData(false);
        }

        private void btnResetAll_Click(object sender, RoutedEventArgs e)
        {

            clearAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (lstBoxFabCostID.ItemsSource != null)
            {
                for (int i = 0; i < lstBoxFabCostID.Items.Count; i++)
                    fabIDtoRem.Add(lstBoxFabCostID.Items[i].ToString());
            }
           
            clearfab();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (lstBoxAccCostID.ItemsSource != null)
            {
                for (int i = 0; i < lstBoxAccCostID.Items.Count; i++)
                    accIDtoRem.Add(lstBoxAccCostID.Items[i].ToString());
            }
            clearAcc();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lstBoxFabCPY.SelectedIndex;
               
                if (lstBoxFabCostID.ItemsSource != null)
                {
                    fabIDtoRem.Add(lstBoxFabCostID.SelectedValue.ToString());
                    ListBox[] lstArray = new ListBox[5];
                    lstArray[0] = lstBoxFabCPY;
                    lstArray[1] = lstBoxFabCost;
                    lstArray[2] = lstBoxFabComsup;
                    lstArray[3] = lstBoxFabType;
                    lstArray[4] = lstBoxFabCostID;

                    
                    foreach (ListBox a in lstArray)
                    {
                        removeItem(a, index);
                    }


                    lstBoxFabCPY.Items.Refresh();
                    lstBoxFabCost.Items.Refresh();
                    lstBoxFabComsup.Items.Refresh();
                    lstBoxFabType.Items.Refresh();
                    lstBoxFabCostID.Items.Refresh();
                }
                else 
                {
                    ListBox[] lstArray = new ListBox[5];
                    lstBoxFabCPY.Items.RemoveAt(index);
                    lstBoxFabCost.Items.RemoveAt(index);
                    lstBoxFabComsup.Items.RemoveAt(index);
                    lstBoxFabType.Items.RemoveAt(index);
                    
                }
               
                
            }
            catch (Exception)
            {
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            /*
             lstBoxAccCostID.ItemsSource = null;
            lstBoxAccType.ItemsSource = null;
            lstBoxAccWPI.ItemsSource = null;
            lstBoxAccCostForH.ItemsSource = null;
            lstBoxAccAmt.ItemsSource = null;
            lstBoxAccCostPI.ItemsSource = null;
             */
            try
            {
                int index = lstBoxAccType.SelectedIndex;
                if (lstBoxAccCostID.ItemsSource != null)
                {
                    accIDtoRem.Add(lstBoxAccCostID.SelectedValue.ToString());
                    ListBox[] lstArray = new ListBox[6];
                    lstArray[0] = lstBoxAccCostID;
                    lstArray[1] = lstBoxAccType;
                    lstArray[2] = lstBoxAccWPI;
                    lstArray[3] = lstBoxAccCostForH;
                    lstArray[4] = lstBoxAccAmt;
                    lstArray[5] = lstBoxAccCostPI;


                    foreach (ListBox a in lstArray)
                    {
                        removeItem(a, index);
                    }


                    
                }
                else
                {

                    lstBoxAccType.Items.RemoveAt(index);
                    lstBoxAccWPI.Items.RemoveAt(index);
                    lstBoxAccCostForH.Items.RemoveAt(index);
                    lstBoxAccAmt.Items.RemoveAt(index);
                    lstBoxAccCostPI.Items.RemoveAt(index);

                }
                lstBoxAccType.Items.Refresh();
                lstBoxAccWPI.Items.Refresh();
                lstBoxAccCostForH.Items.Refresh();
                lstBoxAccAmt.Items.Refresh();
                lstBoxAccCostPI.Items.Refresh();
                lstBoxAccCostID.Items.Refresh();


            }
            catch (Exception exx)
            {
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
             // If the user is authorized to perform the delete operation
            if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
            {
                // DeleteAllActCost(string id)
                MessageBoxResult result = MessageBox.Show("This wii delete all the Fabric cost vales and Accessory cost values. Also this will update the Actual value in the FOB Stock in Hand", "Confirm Delete", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (actCostdao.DeleteAllActCost(cmbEditAcost.Text))
                    {
                        clearAll();
                        populateItemCombo();
                        MessageBox.Show("Successfully Deleted", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Faild to Delete", "Faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    clearAll();
                }
            }
            else
            {
                ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);
            }
        }

        private void lstBoxAccAmt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBoxAccType.SelectedIndex = lstBoxAccAmt.SelectedIndex;
            lstBoxAccWPI.SelectedIndex = lstBoxAccAmt.SelectedIndex;
            lstBoxAccCostPI.SelectedIndex = lstBoxAccAmt.SelectedIndex;
            lstBoxAccCostID.SelectedIndex = lstBoxAccAmt.SelectedIndex;
            lstBoxAccCostForH.SelectedIndex = lstBoxAccAmt.SelectedIndex;
        }
    }
}
