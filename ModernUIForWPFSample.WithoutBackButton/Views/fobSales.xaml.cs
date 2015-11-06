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
using ModernUIForWPFSample.WithoutBackButton.DAO;
using System.Data.Entity;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using FirstFloor.ModernUI.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for fobSales.xaml
    /// </summary>
    public partial class fobSales : UserControl
    {
        // data access object for database
        adoraDBContext abc = new adoraDBContext();

        // fobSales Data access object class
        fobSalesDAO sales = new fobSalesDAO();

        // object for the validation class
        Validations val = new Validations();

        // Global access dictionary for hold current record data
        Dictionary<String, String> currentRecord = new Dictionary<string, string>();

        // Global list for hold Current record frequency Number list
        List<int> currentFrequencyNumberList = new List<int>();

        // Global variable for hold current record ShipmentID/StockOD
        String currentShipmentID;

        // Global varibale for next frequency ID
        int nextFreqID;

        LoginDetails _userType = new LoginDetails();

        public fobSales()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            searchCombo.ItemsSource = sales.populateSearchBarWithAllData();
            
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            System.Windows.Data.CollectionViewSource fOBSalesFrequencyViewSource =
                  ((System.Windows.Data.CollectionViewSource)(this.FindResource("fOBSalesFrequencyViewSource")));
            abc.FOBSalesFrequencies.Load();
            fOBSalesFrequencyViewSource.Source = abc.FOBSalesFrequencies.Local;
           
        }

        // This section use to update search combo box
        private void searchCombo_KeyUp(object sender, KeyEventArgs e)
        {
            String searchString = searchCombo.Text;

            // Updating the searchbox from the database using the current typed string in the search combo box
            searchCombo.ItemsSource = sales.updateSearchComboBox(searchString);
            searchCombo.IsDropDownOpen = true;
         
        }



        // This section use to fill the remaining textboxes according to the selection done in the search combo box
        private void searchCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedString = null;

            if (searchCombo.SelectedIndex > -1)
            {
                selectedString = searchCombo.SelectedValue.ToString();

                // updating the global dictionary ( currentRecord )
                currentRecord = sales.populateAllOtherTextbox(selectedString);

                // retriving data from the global dictionary and setting it to the textbox 
                factoryNameFobSalesText.Text = currentRecord["factoryName"];
                textItemNameFobSales.Text = currentRecord["itemName"];
                textDescriptionFobSales.Text = currentRecord["descriptionDetails"];
                textNoOfPiecesFobSales.Text = currentRecord["noOfPiecesDetails"];
                textCostPerPieceFobSales.Text = currentRecord["CostPerPieceDetails"];

                // updating the global current shipment ID
                currentShipmentID = sales.getShipmentID(currentRecord["factoryName"], currentRecord["itemName"], currentRecord["descriptionDetails"]);

                // update the current frequency number list
                currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);

                // setting the current frequency number list to the frequency id combo box
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
            }

            // if the frequency number list is empty set next frequency as 1 and add 1 it to the frequency list
            if (currentFrequencyNumberList.Count == 0)
            {
                nextFreqID = 1;
                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;

            }
            else
            {
                // If there are any elements in the  frequency number list add them to the list and add next frequency number to the list
                nextFreqID = currentFrequencyNumberList.Count + 1;

                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;
                
            }

        }

        private void frequencyAddButton_Click(object sender, RoutedEventArgs e)
        {
            String buttonString = frequencyAddButton.Content.ToString();
            
            // This section is use to add frequency
            if (buttonString.Equals("Add Frequency"))
            {
                if (val.allFrequencyFieldsFilled(frequencyIDComboBox, noOfPiecesFrequncyText, sellingPricePerPieceFrequencyText, sellingDatePicker) && compareAvailabeAndSellingPieceCount(Convert.ToInt32(noOfPiecesFrequncyText.Text)))
                {
                    String stockID = sales.getShipmentID(factoryNameFobSalesText.Text, textItemNameFobSales.Text, textDescriptionFobSales.Text);
                    int frequencyID = Convert.ToInt32(frequencyIDComboBox.Text);
                    int noOfPieces = Convert.ToInt32(noOfPiecesFrequncyText.Text);
                    Decimal pricePerPiece = Convert.ToDecimal(sellingPricePerPieceFrequencyText.Text);
                    System.DateTime sellingDateX = Convert.ToDateTime(sellingDatePicker.SelectedDate);

                    bool isSuccess = sales.addNewFrequency(stockID, frequencyID, noOfPieces, pricePerPiece, sellingDateX);

                    int amountOfItemsAvailable = Convert.ToInt32(sales.getNoOfPiecesAvailable(currentShipmentID));

                    int amountLeftAfterSelling = amountOfItemsAvailable - noOfPieces;


                    bool updateStatus = sales.updateStockInHandAmountOfItems(currentShipmentID, amountLeftAfterSelling);

                    if (isSuccess)
                    {
                        // If adding is success update the frequency number list and update the table
                        int newNumber = currentFrequencyNumberList.Count;
                        newNumber++;
                        currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);
                        currentFrequencyNumberList.Add(newNumber);
                        frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                        reloadWhenAddingNewRecord();
                        MessageBox.Show("Successfully Added","Success");
                        refreshTable();
                       
                    }
                    else
                    {
                        MessageBox.Show("Error Occured While Adding","Error");
                    }
                }
                else
                {
                    MessageBox.Show("Fill All Fields");
                }
            }

            // This section is use to update the frequency and update the stock in hand items according to the updated frequency value
            if (buttonString.Equals("Update Frequency"))
            {
                if (val.allFrequencyFieldsFilled(frequencyIDComboBox, noOfPiecesFrequncyText, sellingPricePerPieceFrequencyText, sellingDatePicker))
                {

                    if (compareFrequencyUpdateCurrentValueAndUpdatingValue(currentShipmentID, Convert.ToInt32(frequencyIDComboBox.SelectedValue.ToString()), Convert.ToInt32(noOfPiecesFrequncyText.Text)))
                    {
                        int frequencyID = Convert.ToInt32(frequencyIDComboBox.Text);
                        int noOfPieces = Convert.ToInt32(noOfPiecesFrequncyText.Text);
                        Decimal pricePerPiece = Convert.ToDecimal(sellingPricePerPieceFrequencyText.Text);
                        System.DateTime sellingDateX = Convert.ToDateTime(sellingDatePicker.SelectedDate);

                        int oldFreqNoOfItems = Convert.ToInt32(sales.getNoOfPiecesCurrentlyInThatFreqency(currentShipmentID, Convert.ToInt32(frequencyIDComboBox.SelectedValue.ToString())));
                       
                        bool isSuccess = sales.updateFrequency(currentShipmentID, frequencyID, noOfPieces, pricePerPiece, sellingDateX);
                        
                        int differeceBetweenOldAndNewFreqNoOfItems = oldFreqNoOfItems - noOfPieces;

                        int noOfItemsInTheStockInHand = Convert.ToInt32(sales.getNoOfItemsInFobStockInHand(currentShipmentID));

                        int updatedFobStockInHandNoOfItems = noOfItemsInTheStockInHand + differeceBetweenOldAndNewFreqNoOfItems;

                        bool isUpdateSuccess = sales.updateStockInHandAmountOfItems(currentShipmentID, updatedFobStockInHandNoOfItems);

                        if (isSuccess && isUpdateSuccess)
                        {
                            // if updating us successfull refresh the table
                            MessageBox.Show("Successfully Updated");
                            refreshTable();
                        }
                        else
                        {
                            MessageBox.Show("Error Occured While Updating");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough Items");
                    }
                }
                else
                {
                    MessageBox.Show("Fill All Fields");
                }
            }

        }

        // This section is use to compare the frequency current value and updating value
        public bool compareFrequencyUpdateCurrentValueAndUpdatingValue(String shipmentID,int freqNo, int newFreqValue)
        {
            int currentNoOfItemsFreqValueInTheDB = Convert.ToInt32(sales.getNoOfPiecesCurrentlyInThatFreqency(shipmentID, freqNo));

            int numberOfPiecesAvailableInTheStockInHand = Convert.ToInt32(sales.getNoOfPiecesAvailable(shipmentID));

            int totalNoOfItems = currentNoOfItemsFreqValueInTheDB + numberOfPiecesAvailableInTheStockInHand;

            // return true if the total No of items < = newly entered value
            if(newFreqValue <= totalNoOfItems)
            {
                return true;
            }else
            {   
                // Return false if new frquency amount > total no of items
                return false;
            }
        }

        // This section is use to compare available and selling pieces count
        public bool compareAvailabeAndSellingPieceCount(int sellingCount)
        {
            int amountOfItemsAvailable = Convert.ToInt32(sales.getNoOfPiecesAvailable(currentShipmentID));

            // If there are enough items to sell it returns true
            if(sellingCount <= amountOfItemsAvailable)
            {
                return true;
            }
            else
            {
                //If there are not enough items shows error message and return false
                MessageBox.Show("Available items are less than selling items");
                return false;
            }
        }


        private void noOfPiecesFrequncyText_KeyUp(object sender, KeyEventArgs e)
        {
            bool isNumeric = val.numberFormatVal(noOfPiecesFrequncyText, errorLabelNoOfPieces);
        }

        private void sellingPricePerPieceFrequencyText_KeyUp(object sender, KeyEventArgs e)
        {
            val.numberFormatVal(sellingPricePerPieceFrequencyText, errorLabelSellingPrice);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            reloadTheCurrentRecordForTheReset();
        }

        // This section is use to reload the currently selected record in the search combo box
        public void reloadTheCurrentRecordForTheReset()
        {
            String selectedString = null;

            if (searchCombo.SelectedIndex > -1)
            {
                selectedString = searchCombo.SelectedValue.ToString();

                // updating the global dictionary ( currentRecord )
                currentRecord = sales.populateAllOtherTextbox(selectedString);

                // retriving data from the global dictionary and setting it to the textbox 
                factoryNameFobSalesText.Text = currentRecord["factoryName"];
                textItemNameFobSales.Text = currentRecord["itemName"];
                textDescriptionFobSales.Text = currentRecord["descriptionDetails"];
                textNoOfPiecesFobSales.Text = currentRecord["noOfPiecesDetails"];
                textCostPerPieceFobSales.Text = currentRecord["CostPerPieceDetails"];

                // updating the global current shipment ID
                currentShipmentID = sales.getShipmentID(currentRecord["factoryName"], currentRecord["itemName"], currentRecord["descriptionDetails"]);

                // update the current frequency number list
                currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);

                // setting the current frequency number list to the frequency id combo box
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
            }
            // if the frequency number list is empty set next frequency as 1 and add 1 it to the frequency list
            if (currentFrequencyNumberList.Count == 0)
            {
                nextFreqID = 1;
                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;

            }
            else
            {
                // If there are any elements in the  frequency number list add them to the list and add next frequency number to the list
                nextFreqID = currentFrequencyNumberList.Count + 1;

                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;

            }
        }

        private void frequencyIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int freqIdSelectedValue = 0;

                // update the current frequency number list
                currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);

                if (frequencyIDComboBox.SelectedIndex > -1)
                {
                     freqIdSelectedValue = Int32.Parse(frequencyIDComboBox.SelectedValue.ToString());
                }

                // Checking the selected frequency ID is in the currentFrequencyNumber global list
                // If selected frequency is in the currentFrequencyNumber list changing the add button to update frequency
                if (currentFrequencyNumberList.Count != 0 && freqIdSelectedValue <= currentFrequencyNumberList.Count)
                {

                    Dictionary<String, String> currentFrequencyData = new Dictionary<string, string>();
                    String selectedFreqID = null;

                    if (frequencyIDComboBox.SelectedIndex > -1)
                    {
                        selectedFreqID = frequencyIDComboBox.SelectedValue.ToString();

                        currentFrequencyData = sales.populateFrequencyData(currentShipmentID, selectedFreqID);

                        noOfPiecesFrequncyText.Text = currentFrequencyData["NoOfPiecesDetails"];
                        sellingPricePerPieceFrequencyText.Text = currentFrequencyData["pricePerPieceDetails"];
                        sellingDatePicker.Text = currentFrequencyData["date"];

                        //This method is use to calculate the total price list
                        calculateTotalPrice();

                        frequencyAddButton.Content = "Update Frequency";
                    }
                }
                // If selected frequency number is next frequency number changes the button content to Add frequency
                if (currentFrequencyNumberList.Count != 0 && freqIdSelectedValue > currentFrequencyNumberList.Count)
                {
                    frequencyAddButton.Content = "Add Frequency";
                    noOfPiecesFrequncyText.Text = null;
                    sellingPricePerPieceFrequencyText.Text = null;
                    sellingDatePicker.Text = null;
                    totalPriceFrequencyText.Text = null;
                }
            }catch(Exception ea)
            {
                MessageBox.Show(ea.ToString());
            }

        }

        // This section is use to calculate the total price
        // Total price = price per piece * no of pieces
        public void calculateTotalPrice()
        {
            if(sellingPricePerPieceFrequencyText.Text != null && noOfPiecesFrequncyText.Text != null)
            {
                decimal pricePerPiece = Decimal.Parse(sellingPricePerPieceFrequencyText.Text);
                int noOfPieces = Int32.Parse(noOfPiecesFrequncyText.Text.ToString());

                decimal total = pricePerPiece * noOfPieces;

                // Setting the total price frequency textbox text as total price
                totalPriceFrequencyText.Text = total.ToString();
            }
        }

        //This section is use to reload the all section when adding a record
        public void reloadWhenAddingNewRecord()
        {
            String selectedString = null;

            if (searchCombo.SelectedIndex > -1)
            {
                selectedString = searchCombo.SelectedValue.ToString();

                // updating the global dictionary ( currentRecord )
                currentRecord = sales.populateAllOtherTextbox(selectedString);

                // retriving data from the global dictionary and setting it to the textbox 
                factoryNameFobSalesText.Text = currentRecord["factoryName"];
                textItemNameFobSales.Text = currentRecord["itemName"];
                textDescriptionFobSales.Text = currentRecord["descriptionDetails"];
                textNoOfPiecesFobSales.Text = currentRecord["noOfPiecesDetails"];
                textCostPerPieceFobSales.Text = currentRecord["CostPerPieceDetails"];

                // updating the global current shipment ID
                currentShipmentID = sales.getShipmentID(currentRecord["factoryName"], currentRecord["itemName"], currentRecord["descriptionDetails"]);

                // update the current frequency number list
                currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);

                // setting the current frequency number list to the frequency id combo box
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
            }
            // if the frequency number list is empty set next frequency as 1 and add 1 it to the frequency list
            if (currentFrequencyNumberList.Count == 0)
            {
                nextFreqID = 1;
                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;

            }
            else
            {
                // If there are any elements in the  frequency number list add them to the list and add next frequency number to the list
                nextFreqID = currentFrequencyNumberList.Count + 1;

                currentFrequencyNumberList.Add(nextFreqID);
                frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                nextIDLabel.Content = nextFreqID;
                frequencyIDComboBox.SelectedItem = nextFreqID;

            }
        }

        // This section is use to delete the frequency
        private void frequencyDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // If the user is authorized to perform the delete operation
              if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
              {
            // Deletion confirmation box
                  if (MessageBox.Show("Do you want to delete current frequency record?", "Frequency Record Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                  {

                  }
                  else
                  {
                      int selectedFrequencyId = Convert.ToInt32(frequencyIDComboBox.SelectedValue.ToString());

                      int deletingFrequencyNoOfItems = Convert.ToInt32(sales.getNoOfPiecesCurrentlyInThatFreqency(currentShipmentID, selectedFrequencyId));

                      int currentItemsInTheStockInHand = Convert.ToInt32(sales.getNoOfItemsInFobStockInHand(currentShipmentID));

                      int totalItems = currentItemsInTheStockInHand + deletingFrequencyNoOfItems;

                      // delete the current selected frequency
                      bool status = sales.deleteCurrentFrequency(currentShipmentID, selectedFrequencyId);

                      // update the stock in hand table total amount of items with deleted frequency no of items
                      // deleted frequency no of items will be added to the stock in hand total items
                      bool statusOfStockInHandUpdate = sales.updateStockInHandAmountOfItems(currentShipmentID, totalItems);

                      // If successfully updated
                      if (status && statusOfStockInHandUpdate)
                      {
                          // Updating the global frquency number list
                          currentFrequencyNumberList = sales.getFrequencyNumbers(currentShipmentID);

                          frequencyIDComboBox.ItemsSource = currentFrequencyNumberList;
                          MessageBox.Show("Delete Successfull");

                          // reload the current record
                          reloadTheCurrentRecordForTheReset();

                          // refresh the table
                          refreshTable();

                      }
                      
                  }
                
            }
              else
              {
                  ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);  
              }
        }


        // this section is use to refresh the table
        private void refreshTable()
        {

            System.Windows.Data.CollectionViewSource showFobSalesDataSource =

                ((System.Windows.Data.CollectionViewSource)(this.FindResource("fOBSalesFrequencyViewSource")));

            // creating the new databse context object
            adoraDBContext adbc = new adoraDBContext();

            // loading the FOBSalesFrequencies table
            adbc.FOBSalesFrequencies.Load();

            showFobSalesDataSource.Source = adbc.FOBSalesFrequencies.Local;

        }

        private void noOfPiecesFrequncyText_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !val.IsNumberKey(e.Key) && !val.IsActionKey(e.Key);
        }

        private void sellingPricePerPieceFrequencyText_KeyDown(object sender, KeyEventArgs e)
        {
            if (sellingPricePerPieceFrequencyText.Text.IndexOf(".") == -1)
            {
                e.Handled = !val.IsNumberKey(e.Key) && !val.IsActionKey(e.Key) && !val.isDot(e.Key);
            }
            else
            {
                e.Handled = !val.IsNumberKey(e.Key) && !val.IsActionKey(e.Key);
            }
        }

    }
}
