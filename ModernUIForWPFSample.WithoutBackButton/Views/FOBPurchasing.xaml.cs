using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Linq;
using FirstFloor.ModernUI.Windows.Controls;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using ModernUIForWPFSample.WithoutBackButton.Data;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for FOBPurchasing.xaml
    /// </summary>
    public partial class FOBPurchasing : UserControl
    {
        adoraDBContext _context = new adoraDBContext();
        LoginDetails _userType = new LoginDetails();
        FOBPurchasingDAO fobpdao = new FOBPurchasingDAO();
        KeyFunc keyf = new KeyFunc();
        public FOBPurchasing()
        {
            InitializeComponent();
            dtsFOBPAddFab.SelectedDate = DateTime.Today;
            dtsFOBPAddAccDate.SelectedDate = DateTime.Today;
            fobpdao.populateAccUnit(cmbFOBPAddAccUnit);
            fobpdao.populateFabCat(cmbFOBPAddFabType);
        }

        void resetFab()
        {
            txtFOBPAddFabPricePerYard.Text = "";
            txtFOBPAddFabYardage.Text = "";
            txtFOBPAddFabCourierTransport.Text = "";
            txtFOBPAddFabCost.Text = "";
            txtFOBPAddFabActualCostPerYard.Text = "";

            lblFOBPFabErrPricePerYard.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPFabErrYardage.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPFabErrCourierTransport.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPFabErrDate.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPFabErrType.Visibility = System.Windows.Visibility.Hidden;

            cmbFOBPAddFabType.Text = "";
            btnFOBPAddFab.Content = "Add";
            dtsFOBPAddFab.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resetFab();
        }
        private void calFab()
        {
            double pricePerYard = Convert.ToDouble(txtFOBPAddFabPricePerYard.Text);
            double yardage = Convert.ToDouble(txtFOBPAddFabYardage.Text);
            double courierTransport = Convert.ToDouble(txtFOBPAddFabCourierTransport.Text);
            double cost = (pricePerYard * yardage) + courierTransport;
            double actualCostPerYard = cost / yardage;

            txtFOBPAddFabCost.Text = Convert.ToDecimal(cost).ToString("0.00");
            txtFOBPAddFabActualCostPerYard.Text = Convert.ToDecimal(actualCostPerYard).ToString("0.00");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (getemptyValidation())
                System.Windows.MessageBox.Show("Need to fill all the fields", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                calFab();   
               
            }

        }
       
        private bool getemptyValidation()
        {
            bool emptyval1 = true;
            bool emptyval2 = true;
            bool emptyval3 = true;
            bool emptyval4 = true;

            Validations val1 = new Validations();

            if (val1.emptyFieldVal(txtFOBPAddFabPricePerYard, lblFOBPFabErrPricePerYard))
                emptyval1 = false;

            if (val1.emptyFieldVal(txtFOBPAddFabYardage, lblFOBPFabErrYardage))
                emptyval2 = false;

            if (val1.emptyFieldVal(txtFOBPAddFabCourierTransport, lblFOBPFabErrCourierTransport))
                emptyval3 = false;

            if (val1.emptyFieldVal(cmbFOBPAddFabType, lblFOBPFabErrType))
                emptyval4 = false;

            //MessageBox.Show((emptyval1 && emptyval2 && emptyval3 && emptyval4).ToString() + "|" + emptyval1.ToString()+"|"+emptyval2.ToString()+"|"+emptyval3.ToString()+"|"+emptyval4.ToString());

            return emptyval1 || emptyval2 || emptyval3 || emptyval4;
        }

        /// <summary>
        /// Accessories part is right bellow this comment
        /// </summary>
        
        private void btnFOBPAddAccAdd_Click(object sender, RoutedEventArgs e)
        {
            if (getEmptyValForacc())
                System.Windows.MessageBox.Show("Need to fill all the fields", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                calAss();
                string unitType = cmbFOBPAddAccUnit.Text;

                string cate = cmbFOBPAddAccType.Text;
                decimal priceperunit = Convert.ToDecimal(txtFOBPAddAccPricePerUnit.Text);
                float noofunits = (float)Convert.ToDouble(txtFOBPAddAccNoOfUnits.Text);
                decimal trasnport = Convert.ToDecimal(txtFOBPAddAccCourierTransport.Text);
                DateTime date = dtsFOBPAddAccDate.SelectedDate.Value;

                if (btnFOBPAddAccAdd.Content.ToString() == "Add")
                {
                    try
                    {
                        Accessory accAdd = new Accessory();
                        accAdd.Category = cate;
                        accAdd.UnitType = unitType;
                        accAdd.PricePerUnit = priceperunit;
                        accAdd.NoOfUnits = noofunits;
                        accAdd.TransportCost = trasnport;
                        accAdd.Date = date;

                        _context.Accessories.Add(accAdd);
                        _context.SaveChanges();

                        this.accessoryDataGrid.Items.Refresh();
                        _context.Accessories.Load();
                        System.Windows.MessageBox.Show("Succesfully Added", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString(), "Exception");
                    }


                }
                else // code to update Accessories
                {
                    try
                    {

                        string accId = lbleditAssID.Content.ToString();
                        Accessory accEdit = _context.Accessories.FirstOrDefault(i => i.AccID == accId);
                        accEdit.Category = cate;
                        accEdit.UnitType = unitType;
                        accEdit.PricePerUnit = priceperunit;
                        accEdit.NoOfUnits = noofunits;
                        accEdit.TransportCost = trasnport;
                        accEdit.Date = date;

                        _context.SaveChanges();
                        this.accessoryDataGrid.Items.Refresh();
                        _context.Accessories.Load();

                        System.Windows.MessageBox.Show("Succesfully Updated", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString(), "Exception");
                    }


                }
                fobpdao.populateAccUnit(cmbFOBPAddAccUnit);
                fobpdao.populateAccCat(cmbFOBPAccEditCatogery);
                fobpdao.populateAccCat(cmbFOBPAddAccType);
                resetAcc();



            }
        }

        private bool getEmptyValForacc()
        {
            bool emptyvalacc1 = true;
            bool emptyvalacc2 = true;
            bool emptyvalacc3 = true;
            bool emptyvalacc4= true;
            bool emptyvalacc5 = true;
            Validations valAcc = new Validations();

            if (valAcc.emptyFieldVal(txtFOBPAddAccPricePerUnit, lblFOBPErrAccPricePreUnit))
            {
                emptyvalacc1 = false;
            }

            if (valAcc.emptyFieldVal(txtFOBPAddAccNoOfUnits, lblFOBPErrAccNoOfUnits))
            {
                emptyvalacc2 = false;
            }

            if (valAcc.emptyFieldVal(txtFOBPAddAccCourierTransport, lblFOBPErrAccCourierTransport))
            {
                  emptyvalacc3 = false;
            }
           
            if (valAcc.emptyFieldVal(cmbFOBPAddAccType, lblFOBPErrAccType))
            {
                emptyvalacc4 = false;
            }
            if (valAcc.emptyFieldVal(cmbFOBPAddAccUnit, lblFOBPErrAccUnit))
            {
                emptyvalacc5 = false;
            }



            return emptyvalacc1 || emptyvalacc2 || emptyvalacc3 || emptyvalacc4 || emptyvalacc5 ;
        }

        

        private void txtFOBPAddAccPricePerUnit_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtFOBPAddAccNoOfUnits_KeyUp(object sender, KeyEventArgs e)
        {
           

        }
        private void calAss()
        {
            double pricePerUnit = Convert.ToDouble(txtFOBPAddAccPricePerUnit.Text);
            double noOfUnits = Convert.ToDouble(txtFOBPAddAccNoOfUnits.Text);
            double courierTransport = Convert.ToDouble(txtFOBPAddAccCourierTransport.Text);
            double cost = (pricePerUnit * noOfUnits) + courierTransport;
            double actualCostPerYard = cost / noOfUnits;

            txtFOBPAddAccCost.Text = Convert.ToDecimal(cost).ToString("0.00");
            txtFOBPAddAccActualCostPerUnit.Text = Convert.ToDecimal(actualCostPerYard).ToString("0.00");
        }
      
        private void btnFOBPAddAccCalc_Click_1(object sender, RoutedEventArgs e)
        {
            if (getEmptyValForacc())
                System.Windows.MessageBox.Show("Need to fill all the fields", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {

                calAss();
            }

        }

        private void txtFOBPAddAccCourierTransport_KeyUp_1(object sender, KeyEventArgs e)
        {
            lblFOBPErrAccCourierTransport.Visibility = System.Windows.Visibility.Hidden;
            Match match1 = Regex.Match(txtFOBPAddAccCourierTransport.Text, "^[0-9]*$");
            Match match2 = Regex.Match(txtFOBPAddAccCourierTransport.Text, "^[0-9]+\\.[0-9]+$");
            if (!match1.Success && !match2.Success)
            {
               lblFOBPErrAccCourierTransport.Visibility = System.Windows.Visibility.Visible;

            }
            else
                lblFOBPErrAccCourierTransport.Visibility = System.Windows.Visibility.Hidden;

        }

        private void resetAcc()
        {
            txtFOBPAddAccPricePerUnit.Text = "";
            txtFOBPAddAccNoOfUnits.Text = "";
            txtFOBPAddAccCourierTransport.Text = "";
            txtFOBPAddAccCost.Text = "";
            txtFOBPAddAccActualCostPerUnit.Text = "";

            lblFOBPErrAccCourierTransport.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPErrAccNoOfUnits.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPErrAccDate.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPErrAccPricePreUnit.Visibility = System.Windows.Visibility.Hidden;
            lblFOBPErrAccType.Visibility = System.Windows.Visibility.Hidden;

            cmbFOBPAddAccType.Text = "";
            cmbFOBPAddAccUnit.Text = "";

            dtsFOBPAddFab.SelectedDate = DateTime.Today;

            btnFOBPAddAccAdd.Content = "Add";
        }

        private void btnFOBPAddAccReset_Click(object sender, RoutedEventArgs e)
        {
            resetAcc();
        }

        private void cmbFOBPAddAccType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblFOBPErrAccType.Visibility = System.Windows.Visibility.Hidden;
        }

        private void FOBPurchasing1_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            System.Windows.Data.CollectionViewSource fabricViewSource =
                          ((System.Windows.Data.CollectionViewSource)(this.FindResource("fabricViewSource")));
            //creates entity objects and adds them to the context. 
            _context.Fabrics.Load();
            fabricViewSource.Source = _context.Fabrics.Local;

            // After the data is loaded call the DbSet<T>.Local property  
            // to use the DbSet<T> as a binding source. 
            System.Windows.Data.CollectionViewSource accessoryViewSource =
              ((System.Windows.Data.CollectionViewSource)(this.FindResource("accessoryViewSource")));
            //creates entity objects and adds them to the context. 
            _context.Accessories.Load();
            accessoryViewSource.Source = _context.Accessories.Local;
            
            fobpdao.populateFabCat(cmbFOBPFabEditCatogery);
            fobpdao.populateAccCat(cmbFOBPAccEditCatogery);
            fobpdao.populateAccCat(cmbFOBPAddAccType);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            if (getemptyValidation())
                System.Windows.MessageBox.Show("Need to fill all the fields", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                string fabtype = cmbFOBPAddFabType.Text;
                decimal priperyard = Convert.ToDecimal(txtFOBPAddFabPricePerYard.Text);
                float yardage = (float)Convert.ToDouble(txtFOBPAddFabYardage.Text);
                decimal transport = Convert.ToDecimal(txtFOBPAddFabCourierTransport.Text);
                DateTime date = dtsFOBPAddFab.SelectedDate.Value;

                calFab();
                if (btnFOBPAddFab.Content.ToString() == "Add")//code to add data to the fabric table is here
                {
                    try {                       
                            Fabric fab1 = new Fabric();
                            fab1.Category = fabtype;
                            fab1.PricePerYard = priperyard;
                            fab1.Yardage = yardage;
                            fab1.TransportCost = transport;
                            fab1.Date = date;

                            _context.Fabrics.Add(fab1);
                            _context.SaveChanges();

                            this.fabricDataGrid.Items.Refresh();
                            _context.Fabrics.Load();
                              System.Windows.MessageBox.Show("Succesfully Added", "Done", MessageBoxButton.OK, MessageBoxImage.Information);

                              fobpdao.populateFabCat(cmbFOBPFabEditCatogery);
                              fobpdao.populateFabCat(cmbFOBPAddFabType);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString());
                    }                   
                }
                else // code to edit data in fabric tbale is here
                {
                  
                    try
                    {
                        string fabid = lbleditFabID.Content.ToString();
                       
                        Fabric f = _context.Fabrics.First(i => i.FabID == fabid);
                        f.Category = fabtype;
                        f.PricePerYard = priperyard;
                        f.Yardage = yardage;
                        f.TransportCost = transport;
                        f.Date = date;

                        _context.SaveChanges();
                        this.fabricDataGrid.Items.Refresh();
                        _context.Fabrics.Load();

                        fobpdao.populateFabCat(cmbFOBPFabEditCatogery);
                        System.Windows.MessageBox.Show("Succesfully Updated", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString());
                    }
                }
                fobpdao.populateFabCat(cmbFOBPFabEditCatogery);
                fobpdao.populateFabCat(cmbFOBPAddFabType);

               
                resetFab();
               
               

            }
        }
      

          private void populateFabID(ComboBox fabID,ComboBox fabCat)
        {
            String category =null;

            if ((fabCat.SelectedItem) != null)
            {
                category = fabCat.SelectedValue.ToString();

                try
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        var fbID = (from e in a.Fabrics
                                     where e.Category == category
                                     select e.FabID
                       ).Distinct().ToList();

                        fabID.ItemsSource = fbID;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.InnerException.ToString());
                }
            }
                 
        }

       
          

          private void populateAccID(ComboBox accID, ComboBox accCat)
          {
              String category = null;

              if ((accCat.SelectedItem) != null)
              {
                  category = accCat.SelectedValue.ToString();

                  try
                  {
                      using (adoraDBContext a = new adoraDBContext())
                      {
                          var accId = (from e in a.Accessories
                                       where e.Category == category
                                       select e.AccID
                         ).Distinct().ToList();

                          accID.ItemsSource = accId;
                      }
                  }
                  catch (Exception e)
                  {
                      MessageBox.Show(e.InnerException.ToString());
                  }
              }

          }
          private void fillvalsToTextFab(ComboBox fabID)
          {
              if (fabID.SelectedItem != null)
              {
                  try
                  {
                      String fabricID = fabID.Text;
                      lbleditFabID.Content = fabricID;

                      using (adoraDBContext a = new adoraDBContext())
                      {
                         
                          var Category = (from e in a.Fabrics
                                            where (e.FabID == fabricID)
                                            select e.Category).SingleOrDefault();
                          var pricePerYard = (from e in a.Fabrics
                                             where (e.FabID == fabricID)
                                             select e.PricePerYard).SingleOrDefault();
                          var yardage = (from s in a.Fabrics
                                            where (s.FabID == fabricID)
                                         select s.Yardage).SingleOrDefault();
                          var transport = (from s in a.Fabrics
                                         where (s.FabID == fabricID)
                                           select s.TransportCost).SingleOrDefault();


                          cmbFOBPAddFabType.SelectedItem = Category.ToString();
                          txtFOBPAddFabPricePerYard.Text = Convert.ToDouble(pricePerYard).ToString("0.00"); 
                          txtFOBPAddFabYardage.Text = Convert.ToDouble(yardage).ToString("0.00"); 
                          txtFOBPAddFabCourierTransport.Text =Convert.ToDouble(transport).ToString("0.00"); 
                          calFab();
                          btnFOBPAddFab.Content = "Update";
                           
                      }
                  }
                  catch (Exception e)
                  {
                      MessageBox.Show(e.InnerException.ToString());
                  }
              }
              else
              {
                
              }
          }

          private void fillvalsToTextAcc(ComboBox accID)
          {
              if (accID.SelectedItem != null)
              {
                  try
                  {
                      String accesID = accID.Text;
                      lbleditAssID.Content = accesID;

                      using (adoraDBContext a = new adoraDBContext())
                      {
                          
                          var Category = (from e in a.Accessories
                                          where (e.AccID == accesID)
                                          select e.Category).SingleOrDefault();
                          var pricePerunit = (from e in a.Accessories
                                              where (e.AccID == accesID)
                                              select e.PricePerUnit).SingleOrDefault();
                          var noOfUnits = (from s in a.Accessories
                                           where (s.AccID == accesID)
                                         select s.NoOfUnits).SingleOrDefault();
                          var transport = (from s in a.Accessories
                                           where (s.AccID == accesID)
                                           select s.TransportCost).SingleOrDefault();
                          var unit = (from s in a.Accessories
                                           where (s.AccID == accesID)
                                           select s.UnitType).SingleOrDefault();


                          cmbFOBPAddAccUnit.SelectedItem = unit.ToString();
                          cmbFOBPAddAccType.SelectedItem = Category.ToString();
                          txtFOBPAddAccPricePerUnit.Text = pricePerunit.ToString();
                          txtFOBPAddAccNoOfUnits.Text = noOfUnits.ToString();
                          txtFOBPAddAccCourierTransport.Text = transport.ToString();
                          calAss();
                          btnFOBPAddAccAdd.Content = "Update";

                      }
                  }
                  catch (Exception e)
                  {
                      MessageBox.Show(e.InnerException.ToString());
                  }
              }
              else
              {

              }
          }

         

          private void cmbFOBPFabEditCatogery_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
          {
              populateFabID(cmbFOBPFabEditID, cmbFOBPFabEditCatogery);
          }

          private void btnFPBPFabEdit_Click(object sender, System.Windows.RoutedEventArgs e)
          {
              fillvalsToTextFab(cmbFOBPFabEditID);
          }

          private void btnFOBPFabDelete_Click(object sender, RoutedEventArgs e)
          {
               // If the user is authorized to perform the delete operation
              if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
              {
                  if (cmbFOBPFabEditID.SelectedIndex >= 0)
                  {
                      if (System.Windows.MessageBox.Show("Do you want to delete " + cmbFOBPFabEditID.Text, "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Information) == MessageBoxResult.Yes)
                      {
                          try
                          {
                              string fabid = cmbFOBPFabEditID.Text;
                              Fabric fabDel = _context.Fabrics.FirstOrDefault(i => i.FabID == fabid);
                              _context.Fabrics.Remove(fabDel); _context.SaveChanges();

                              this.fabricDataGrid.Items.Refresh();
                              _context.Fabrics.Load();
                              System.Windows.MessageBox.Show("Succesfully Deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.InnerException.ToString(), "Exception");
                          }


                      }
                  }
                  else
                      System.Windows.MessageBox.Show("Please Select A Fab ID from the Combo box", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                  fobpdao.populateFabCat(cmbFOBPFabEditCatogery);
                  fobpdao.populateFabCat(cmbFOBPAddFabType);
              }
              else
              {
                  ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);
              }
          }

          private void cmbFOBPAccEditCatogery_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              populateAccID(cmbFOBPAccEditID, cmbFOBPAccEditCatogery);
          }

          private void btnFPBPAccEdit_Click(object sender, RoutedEventArgs e)
          {
              fillvalsToTextAcc(cmbFOBPAccEditID);

          }

          private void btnFOBPAccDelete_Click(object sender, RoutedEventArgs e)
          {
              // If the user is authorized to perform the delete operation
              if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
              {
                  if (cmbFOBPAccEditID.SelectedIndex >= 0)// check whether a value from the AccID combo box is selcted
                  {
                      if (System.Windows.MessageBox.Show("Do you want to delete " + cmbFOBPAccEditID.Text, "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Information) == MessageBoxResult.Yes)// getting the confirmation
                      {
                          try
                          {
                              string accid = cmbFOBPAccEditID.Text;
                              Accessory accDel = _context.Accessories.FirstOrDefault(i => i.AccID == accid);
                              _context.Accessories.Remove(accDel);
                              System.Windows.MessageBox.Show("Succesfully Deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.InnerException.ToString(),"Exception");
                          }
                          fobpdao.populateAccCat(cmbFOBPAccEditCatogery);
                          fobpdao.populateAccCat(cmbFOBPAddAccType);
                      }
                  }
                  else
                      System.Windows.MessageBox.Show("Please Select A Fab ID from the Combo box", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
              }
              else
              {
                  ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);  
              }
       }

          private void cmbFOBPAddAccType_KeyUp(object sender, KeyEventArgs e)
          {
              lblFOBPErrAccType.Visibility = System.Windows.Visibility.Hidden;
              fobpdao.updateSearchComboBoxAcc(cmbFOBPAddAccType);
          }

          private void cmbFOBPAddFabType_KeyUp(object sender, KeyEventArgs e)
          {
              fobpdao.updateSearchComboBoxFab(cmbFOBPAddFabType);
          }

          private void cmbFOBPAddAccUnit_KeyUp(object sender, KeyEventArgs e)
          {
              lblFOBPErrAccUnit.Visibility = System.Windows.Visibility.Hidden;
              fobpdao.updateSearchComboBoxAccUni(cmbFOBPAddAccUnit);
          }

        
          private void cmbFOBPFabEditID_DropDownClosed(object sender, EventArgs e)
          {
              if (cmbFOBPFabEditCatogery.SelectedIndex >= 0)
              {
                  fillvalsToTextFab(cmbFOBPFabEditID);
              }
              else
                  System.Windows.MessageBox.Show("Please select a Catogery", "Please Select", MessageBoxButton.OK, MessageBoxImage.Warning);
          }

          private void cmbFOBPAccEditID_DropDownClosed(object sender, EventArgs e)
          {
              if (cmbFOBPAccEditCatogery.SelectedIndex >= 0)
              {
                  fillvalsToTextAcc(cmbFOBPAccEditID);
              }
              else
                  System.Windows.MessageBox.Show("Please select a Catogery", "Please Select", MessageBoxButton.OK, MessageBoxImage.Warning);
          }

          private void txtFOBPAddAccPricePerUnit_KeyDown(object sender, KeyEventArgs e)
          {
              if (txtFOBPAddAccPricePerUnit.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void txtFOBPAddAccNoOfUnits_KeyDown(object sender, KeyEventArgs e)
          {
              if (txtFOBPAddAccNoOfUnits.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void txtFOBPAddAccCourierTransport_KeyDown(object sender, KeyEventArgs e)
          {
              if (txtFOBPAddAccCourierTransport.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void txtFOBPAddAccNoOfUnits_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtFOBPAddFabPricePerYard_KeyDown(object sender, KeyEventArgs e)
          {
              lblFOBPFabErrPricePerYard.Visibility = System.Windows.Visibility.Hidden;
              if (txtFOBPAddFabPricePerYard.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void txtFOBPAddFabYardage_KeyDown(object sender, KeyEventArgs e)
          {
              lblFOBPFabErrYardage.Visibility = System.Windows.Visibility.Hidden;
              if (txtFOBPAddFabYardage.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void txtFOBPAddFabCourierTransport_KeyDown(object sender, KeyEventArgs e)
          {
              lblFOBPFabErrCourierTransport.Visibility = System.Windows.Visibility.Hidden;
              if (txtFOBPAddFabCourierTransport.Text.IndexOf(".") == -1)
              {
                  e.Handled = keyf.allowKeywithDot(e.Key);
              }
              else
              {
                  e.Handled = keyf.allowKeywithOutDot(e.Key);
              }
          }

          private void cmbFOBPAddAccUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              lblFOBPErrAccUnit.Visibility = System.Windows.Visibility.Hidden;
          }

          private void cmbFOBPAddFabType_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              lblFOBPFabErrType.Visibility = System.Windows.Visibility.Hidden;
          }

          private void cmbFOBPAddFabType_KeyDown(object sender, KeyEventArgs e)
          {
              lblFOBPFabErrType.Visibility = System.Windows.Visibility.Hidden;
          }

          private void txtFOBPAddFabYardage_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

         

    }
}
