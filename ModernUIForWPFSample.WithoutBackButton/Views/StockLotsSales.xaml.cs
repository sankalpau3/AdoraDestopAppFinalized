using ModernUIForWPFSample.WithoutBackButton.Functions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data.Entity;
using ModernUIForWPFSample.WithoutBackButton.DAO;
using ModernUIForWPFSample.WithoutBackButton.Validations;
using FirstFloor.ModernUI.Windows.Controls;


namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for StockLotsSales.xaml
    /// </summary>
    public partial class StockLotsSales : UserControl
    {
        adoraDBContext _context;                // Variable to hold DB Context
        StockLotSalesHandle _handler;           // Variable to hold handler for complex calculations..
        StockLotSalesDAO _dao;                  // Variable to hold data access object
        StockLotsSalesValidator _validator;     // Variable to hold validator object
        LoginDetails _userHandler;               // Variable to hold user validation object
        Validations _val;

        public StockLotsSales()
        {
            InitializeComponent();
            _context = new adoraDBContext();                 // Initialize DB Context
            _handler = new StockLotSalesHandle();            // Initialize Handler
            _dao = new StockLotSalesDAO();                   // Initialize Data access object
            _validator = new StockLotsSalesValidator();      // Initialize validator object
            _userHandler = new LoginDetails();               // Initialize user handler object
            _val = new Validations();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Create and iniialize CollectionViewSource Objects to display data in table view
            System.Windows.Data.CollectionViewSource bnSFrequencyViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("bnSFrequencyViewSource")));
            System.Windows.Data.CollectionViewSource showBnSDetailViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("showBnSDetailViewSource")));

           _context.BnSFrequencies.Load();      // Get the BnSFrequency data from the DataBase
           _context.showBnSDetails.Load();      // Get the showBnSDetails view data from the Database

            bnSFrequencyViewSource.Source = _context.BnSFrequencies.Local;      // Asign BnSFrequency view source with data retrieved from the DB
            showBnSDetailViewSource.Source = _context.showBnSDetails.Local;     // Asign showBnSDetails view source with data retrieved from the DB

            dateSellDate.SelectedDate = DateTime.Today;         // Set todays date in the calendar controller
            populateShipmentNames(dropShipmentName);            // Load shipment names combobox
            populateShipmentNames(dropRmShipmentName);          // Load shipment names combobox (remove functionality)
            populateCurrencyTypes(dropCurrency);                // Load currency types combobox
            dropCurrency.SelectedValue = "LKR";                 // Select the default currency type as LKR

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtAddNoPieces_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtAddShipName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtNumberOfPieces_KeyUp(object sender, KeyEventArgs e)
        {
            validateInt(txtNumberOfPieces,errNoOfPieces);           // Validate the number of pieces
            validateIssuable(txtAddNoPieces, txtNumberOfPieces, dropShipmentName, dropDate, dropFrequencyID, errNoOfPieces);    // Validate if the enterd amount is issuable
        }

        private void txtPricePerPiece_KeyUp(object sender, KeyEventArgs e)
        {
            validatePrice(txtPricePerPiece, errPricePerPiece);      // Validate price
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            txtAddTotalPrice.Text = "";                             // Set the total textBox empty

            validatePrice(txtPricePerPiece, errPricePerPiece);      // Validate Price
            validateInt(txtNumberOfPieces,errNoOfPieces);           // Validate number of pieces
            validateIssuable(txtAddNoPieces, txtNumberOfPieces, dropShipmentName, dropDate, dropFrequencyID, errNoOfPieces);    // Validate if the amount is issuable
            validateShipmentName(dropShipmentName,errShipmentName); // Validate the shipment name

            // If no error lables are visible
            if (!errShipmentName.IsVisible && !errPricePerPiece.IsVisible && !errNoOfPieces.IsVisible)
            {
                int noOfPieces = Convert.ToInt32(txtNumberOfPieces.Text);           // Convert and get number of pieces
                double pricePerPiece = Convert.ToDouble(txtPricePerPiece.Text);     // Convert and get price per piece

                // Calculate the total using StockLotsSales handler class
                double total = (_handler.calctotalPrice(pricePerPiece, noOfPieces, dropCurrency.SelectedValue.ToString()));

                txtAddTotalPrice.Text = total.ToString("F");                        // Format and display it in the relevent textBox
            }
            else
            {
                MessageBox.Show("Required fields are empty or Validation Faild! Please check the values again");
            }
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            validateInt(txtNumberOfPieces,errNoOfPieces);           // Validate number of pieces
            validateIssuable(txtAddNoPieces, txtNumberOfPieces, dropShipmentName, dropDate, dropFrequencyID, errNoOfPieces);    // Validate if the amount is issuable
            validatePrice(txtPricePerPiece, errPricePerPiece);      // Validate price per piece
            validateShipmentName(dropShipmentName,errShipmentName); // Validate shipment name
           
            // If no error lable is visible
            if (!errShipmentName.IsVisible && !errPricePerPiece.IsVisible && !errNoOfPieces.IsVisible)
            {
                String shipmentName = dropShipmentName.Text;                            // Convert and get shipment name
                int frequencyID = Convert.ToInt32(dropFrequencyID.Text);                // Convert and get frequency Id
                int noOfPieces = Convert.ToInt32(txtNumberOfPieces.Text);               // Convert and get number of pieces
                decimal pricePerPiece = Convert.ToDecimal(txtPricePerPiece.Text);       // Convert and get price per piece
                System.DateTime date = Convert.ToDateTime(dateSellDate.SelectedDate);   // Convert and get date of frequency
                System.DateTime dateShip = Convert.ToDateTime(dropDate.SelectedValue);  // Convert and get dateof Shipment

                String shipmentID = null;                               // Set shipment Id to null

                String Method = btnAdd.Content.ToString();              // Get the button text to detect the operation (add or update)

                // Get the shipment ID according to user selections usin DAO Class
                shipmentID = _dao.getShipmentID(shipmentName, dateShip);

                // If it is an add operation and shipmentID is found
                if (Method == "Add" && shipmentID != null)
                {
                    // Add new frequency using DAO Class and assign the status to a variable to perform further operation
                    bool isSuccess = _dao.addNewFrequency(shipmentID, frequencyID, noOfPieces, pricePerPiece, date);

                    // If the add operation is sucessfull
                    if (isSuccess)
                    {
                        MessageBox.Show("Frequency Details added sucessfully!");
                        resetForm();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured while adding to DB!");
                    }
                }
                
                // If it is an update operation and ShipmentId is found
                else if (Method == "Update" && shipmentID != null)
                {
                    // Update the frequency using DAO Class and assign the status to a variable to perform further operation
                    bool isSuccess = _dao.updateFrequency(shipmentID, frequencyID, noOfPieces, pricePerPiece, date);

                    // If the operation is sucessfull
                    if (isSuccess)
                    {
                        MessageBox.Show("Frequency Details Updated sucessfully!");
                        resetForm();
                    }
                    else
                    {
                        MessageBox.Show("Error occured while updating!");
                    }
                    refreshTable();
                }
            }
            else
            {
                MessageBox.Show("Required fields are empty or Validation Faild! Please check the values again");
            }
            refreshTable();
        }

        
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            resetForm();
        }

        private void txtAddShipName_KeyUp(object sender, KeyEventArgs e)
        {
            validateShipmentName(dropShipmentName,errShipmentName);
        }

        private void btnRmReset_Click(object sender, RoutedEventArgs e)
        {
            dropRmShipmentName.Text = "";
            dropRmDate.Text = "";
            dropRmFrequencyID.Text = "";
            
        }

        private void btnRmRemove_Click(object sender, RoutedEventArgs e)
        {
            // If the user is authorized to perform the delete operation
            if(_userHandler.getUserLevel() == 1 || _userHandler.getUserLevel() == 2) 
            {
                // If a shipment is selected in remove Shipment Combobox
                if (!String.IsNullOrEmpty(dropRmShipmentName.Text) && dropRmFrequencyID.SelectedIndex>-1)
                {
                    // Confirming the deletion
                    String sen = "Are you sure you want to delete Shipment :" + dropRmShipmentName.Text + "'s selling frequency number :" + dropRmFrequencyID.Text + " ?";
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(sen, "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                
                    // If user confirms the deletion
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        String ship = dropRmShipmentName.SelectedValue.ToString();          // Convert and get the remove Shipment Name
                        System.DateTime d = Convert.ToDateTime(dropRmDate.SelectedValue);   // Convert and get the date
                        int fre = Convert.ToInt32(dropRmFrequencyID.Text);                  // Convert and get the frequency number

                        var shipmentIDn = _dao.getShipmentID(ship, d);                      // Get the shipment ID using DAO object
                        var freq = _dao.getFrequency(shipmentIDn, fre, _context);           // Get the selected frequency object from the DB
                        _context.BnSFrequencies.Remove(freq);                                //Delete frequency from memory
                        int done = _context.SaveChanges();                                   //Save to database

                        // If the operation is successful
                        if (done > 0)
                        {
                            MessageBoxResult var = MessageBox.Show("Sucessfully Deleted frequency details");
                            dropRmFrequencyID.Text = "";
                            dropRmDate.Text = "";
                            dropRmShipmentName.Text = "";
                        }
                    }     
                }
                else
                {
                    MessageBox.Show("Please specify the shipment number and select the frequency number to be deleted");
                }
                refreshTable();
            }
            else 
            {
                ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);  
            }
        }

        private void dropShipmentName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateShipmentName(dropShipmentName, errShipmentName);
            populateShipmentDates(dropDate, dropShipmentName);
            dropDate.SelectedIndex = 0;
            fillNoOfPiecesAvailable(dropShipmentName, dropDate,errShipmentName, txtAddNoPieces);
            fillCostPerPiece(dropShipmentName, dropDate, errShipmentName, txtAddCostPiece);
            populateFrequencyNumbers(dropFrequencyID, dropShipmentName, dropDate, errShipmentName);
            dropFrequencyID.SelectedIndex = dropFrequencyID.Items.Count - 1;
            changeNextFreLabel(dropFrequencyID,lblNextFrequencyID);
            fillDate(dropShipmentName,dropDate,dropFrequencyID,dateSellDate);
            fillNoOfPieces(dropShipmentName, dropDate, dropFrequencyID, txtNumberOfPieces);
            fillPricePerPiece(dropShipmentName, dropDate, dropFrequencyID, txtPricePerPiece);
            validatePrice(txtPricePerPiece, errPricePerPiece);
            validateInt(txtNumberOfPieces,errNoOfPieces);
            validateIssuable(txtAddNoPieces, txtNumberOfPieces, dropShipmentName, dropDate, dropFrequencyID, errNoOfPieces);
            errPricePerPiece.Visibility = Visibility.Hidden;
            errNoOfPieces.Visibility = Visibility.Hidden;
        }

        private void dropShipmentName_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void dropDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillNoOfPiecesAvailable(dropShipmentName, dropDate,errShipmentName,txtAddNoPieces);
            fillCostPerPiece(dropShipmentName,dropDate,errShipmentName,txtAddCostPiece);
            populateFrequencyNumbers(dropFrequencyID, dropShipmentName, dropDate, errShipmentName);
            dropFrequencyID.SelectedIndex = dropFrequencyID.Items.Count - 1;
            changeNextFreLabel(dropFrequencyID,lblNextFrequencyID);
            fillDate(dropShipmentName, dropDate, dropFrequencyID, dateSellDate);
            fillNoOfPieces(dropShipmentName, dropDate, dropFrequencyID, txtNumberOfPieces);
            fillPricePerPiece(dropShipmentName, dropDate, dropFrequencyID, txtPricePerPiece);
            detectAddOrUpdate(dropFrequencyID,lblNextFrequencyID,btnAdd);
            errPricePerPiece.Visibility = Visibility.Hidden;
            errNoOfPieces.Visibility = Visibility.Hidden;
        }

        private void dropFrequencyID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            detectAddOrUpdate(dropFrequencyID, lblNextFrequencyID,btnAdd);
            fillDate(dropShipmentName, dropDate, dropFrequencyID, dateSellDate);
            fillNoOfPieces(dropShipmentName, dropDate, dropFrequencyID, txtNumberOfPieces);
            fillPricePerPiece(dropShipmentName, dropDate, dropFrequencyID, txtPricePerPiece);
            validatePrice(txtPricePerPiece,errPricePerPiece);
            validateInt(txtNumberOfPieces,errNoOfPieces);
            validateIssuable(txtAddNoPieces, txtNumberOfPieces, dropShipmentName, dropDate, dropFrequencyID, errNoOfPieces);
            errPricePerPiece.Visibility = Visibility.Hidden;
            errNoOfPieces.Visibility = Visibility.Hidden;
        }

        private void bnSFrequencyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dropRmShipmentName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateShipmentDates(dropRmDate, dropRmShipmentName);
            dropRmDate.SelectedIndex = 0;
            dropRmFrequencyID.SelectedIndex = 0;
        }

        private void dropRmDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateRmFrequencyNumbers(dropRmFrequencyID, dropRmShipmentName, dropRmDate, errShipmentName);
        }

        private void dropShipmentName_KeyUp(object sender, KeyEventArgs e)
        {
            validateShipmentName(dropShipmentName, errShipmentName);
        }

        //******************************** DB Access and Validation Methods *******************************************//

        /* This method validates doubles  using Validator class
         @param pricePerPiece : TextBox instance representing price per piece
         @param errPrice : Label instance representing error in the price per piece
         @returns nothing */
        private void validatePrice(TextBox pricePerPiece, Label errPrice)
        {
            String no = pricePerPiece.Text;
            errPrice.Visibility = Visibility.Visible;       // Make the error lable visible
            
            // If the number is a double
            if (_validator.isDouble(no))
            {
                errPrice.Visibility = Visibility.Hidden;
            }
            else
            {
                errPrice.Visibility = Visibility.Visible;

            }
        }

        /* This method validates integers  using Validator class
         @param selling : TextBox instance representing no Of Items 
         @param errNoPieces : Label instance representing error in the number of pieces
         @returns nothing */
        private void validateInt(TextBox selling, Label errNoPieces)
        {
            errNoPieces.Visibility = Visibility.Visible;        // Make the error lable visible

            // If the number is an integer
            if (_validator.isInt(selling.Text))
            {
                errNoPieces.Visibility = Visibility.Hidden;
                
            }
            else 
            {
                errNoPieces.Visibility = Visibility.Visible;
            }
        }

        /* This method checks the entered no of items can be issued or not
         @param available : TextBox instance representing available no of items
         @param selling : TextBox instance representing no Of Items 
         @param shipment : Combobox instance representing shipment names
         @param date : Combobox instane representing shipment dates
         @param frqId : ComboBox instance representing frequency ids
         @param errNo : Label instance representing error in the number of pieces
         @returns nothing */
        private void validateIssuable(TextBox available, TextBox selling, ComboBox shipment, ComboBox date, ComboBox frqId, Label errNo)
        {
           // errNo.Visibility = Visibility.Hidden;       // Hide the error lable

            // If the available textbox and the selling textboxes are not empty
            if (errNo.Visibility != Visibility.Visible && available.Text != "" && available.Text != null && selling.Text != null && selling.Text != "")
            {
                int avail = Convert.ToInt32(available.Text);    // Convert and get the available no of Pieces
                int sell = Convert.ToInt32(selling.Text);       // Convert and get the selling no of pieces

                // If the operation is adding new record
                if (btnAdd.Content.ToString() == "Add")
                {
                    // If the amount of pieces entered is greater than available pieces
                    if (sell > avail)
                    {
                        errNo.Visibility = Visibility.Visible;      // Display error label
                    }
                    else
                    {
                        errNo.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    String shipmentName = shipment.SelectedValue.ToString();
                    System.DateTime dateOfShipment = Convert.ToDateTime(date.SelectedValue);
                    int frId = Convert.ToInt32(frqId.SelectedValue);

                    // Get the number of pieces of the selected shipment using DAO Object
                    int thisFreq = _dao.getNoOfPieces(shipmentName, dateOfShipment, frId);

                    // As this is an update operation, No of items which can be issued is the addition of thisFreq + available items
                    int actualAvailable = thisFreq + avail;

                    // If the entered value is greter than actual available
                    if (sell > actualAvailable)
                    {
                        errNo.Visibility = Visibility.Visible;      // Display the error label
                    }
                    else
                    {
                        errNo.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        /* This method validates shipment names using Validator class
         @param shipment : ComboBox instance representing shipment Names
         @param errShip : Label instance representing error in the shipment nane
         @returns nothing */
        private void validateShipmentName(ComboBox shipment, Label errShip)
        {
            // If the shipment name is valid
            if (_validator.isShipmentNameValid(shipment))
            {
                errShip.Visibility = Visibility.Hidden; // Hide the error lable
            }
            else
            {
                errShip.Visibility = Visibility.Visible;    // Display the error lable
            }
        }

        /* This method populates shipment names combobox
           @param shipment : ComboBox instance representing shipment names
           @returns nothing */
        private void populateShipmentNames(ComboBox cmbBox)
        {
            // Fill the shipmentName combobox using DAO class
            cmbBox.ItemsSource = _dao.getShipmentNames();
        }

        /* This method populates shipment Dates combobox
           @param shipment : ComboBox instance representing shipment names
           @param date : ComboBox instance representing shipment Dates 
           @returns nothing */
        private void populateShipmentDates(ComboBox date,ComboBox shipName)
        {
            String shipmentName =null;

            // If a shipment name is selected
            if ((shipName.SelectedItem) != null)
            {
                shipmentName = shipName.SelectedValue.ToString();   // Convert and get the selected shipment name

                // Fill the date combobox according to the selected shipment name using DAO class
                date.ItemsSource = _dao.getShipmentDates(shipmentName);
     
            }
                 
        }

        /* This method fills number of piece available from a given shipment
         @param shipment : ComboBox instance representing shipment names
         @param date : ComboBox instance representing shipment Dates
         @param errShip : Label instance representing a error in shipment name
         @param noOfPieces : Textbox instance holding the number of pieces
         @returns nothing */
        private void fillNoOfPiecesAvailable(ComboBox shipment, ComboBox date,Label errShip,TextBox noOfPieces)
        {
            // If a shipment is selected and the error lable is not visible
            if (shipment.SelectedItem != null && !errShip.IsVisible)
            {
                    String shipmentName = shipment.SelectedValue.ToString();    // Convert and get shipmentname
                    System.DateTime dateOfShipment = Convert.ToDateTime(date.SelectedValue);  // Convert and get shipment date


                    int totalPieces = _dao.getTotalPieces(shipmentName, dateOfShipment);    // Get the total number of pieces for the shipment using DAO object
                    int totalSold = _dao.getTotalSoldPieces(shipmentName, dateOfShipment);  // Get the total pieces sold from the shipment using DAO object

                    int totalRemaining = totalPieces - totalSold ;      // Calculate total pieces remaining
                    noOfPieces.Text = totalRemaining.ToString();    // Set it in the textbox
            }
            else
            {
                txtAddNoPieces.Text = "";
            }
        }

        /* This method fills cost per piece for a given shipment
         @param shipName : ComboBox instance representing shipment names
         @param date : ComboBox instance representing shipment Dates
         @param errShip : Label instance representing a error in shipment name
         @param costPerPiece : Textbox instance holding the cost per piece
         @returns nothing */
        private void fillCostPerPiece(ComboBox shipName,ComboBox date,Label errShip,TextBox costPerPiece)
        {
            // If a shipment is selected and the error label is not visible
            if (shipName.SelectedItem != null && !errShip.IsVisible)
            {
                    String shipmentName = shipName.SelectedValue.ToString();        // Convert and get shipment Name
                    System.DateTime dateOfShipment = Convert.ToDateTime(date.SelectedValue);    // Convert and get dateof shipment

                    // Get cost per piece for given shipment using DAO object and set it in the relevent textbox (Formatted to 2 decimal places)
                    costPerPiece.Text = _dao.getCostPerPiece(shipmentName,dateOfShipment).ToString("F");
               
            }
            else
            {
                txtAddNoPieces.Text = "";
            }
        }

        /* This method populates frequency numbers of frequency combobox
         @param freq : ComboBox instance representing frequency ids
         @param shipment : ComboBox instance representing shipment names
         @param dateC : ComboBox instance representing shipment Dates
         @param errShip : Label instance representing a error in shipment name
         @returns nothing */
        private void populateFrequencyNumbers(ComboBox freq,ComboBox shipment, ComboBox dateC, Label errShip)
        {
            // Create a new empty list and assign it to the frequency number combobox
            ObservableCollection<Group> emptyList = new ObservableCollection<Group>();
            freq.ItemsSource = emptyList;
            String shipmentName = null;
            
            // If a shipment is selected and error lable is not visible
            if ((shipment.SelectedItem) != null && !errShip.IsVisible)
            {
                shipmentName = shipment.SelectedValue.ToString();   // Convert and get shipment name
                System.DateTime date = Convert.ToDateTime(dateC.SelectedValue);   // Convert and get shipment date

                // Get frequency number list from database using DAO Object
                System.Collections.Generic.List<int> freNoList = _dao.getFrequencyNumbers(shipmentName, date);

                // If the list is not empty
                if (freNoList.Any())
                {
                    int nextID = freNoList.Last() + 1;  // Get the number next to the last element of the list
                    freNoList.Add(nextID);          // Add it to the list because it will be the next frequency number (It is needed for add operations)
                           
                    // Assign combo box with the items in the list
                    freq.ItemsSource = freNoList;
                 }

                    // If the list is empty add number 1 to the list as it will be the next frequency number
                 else
                 {
                     freNoList.Add(1);
                     freq.ItemsSource = freNoList;
                 }               
            }

        }

         /* This method populates frequency numbers of remove frequency combobox
         @param freq : ComboBox instance representing frequency ids
         @param shipment : ComboBox instance representing shipment names
         @param dateC : ComboBox instance representing shipment Dates
         @param errShip : Label instance representing a error in shipment name
         @returns nothing */
        private void populateRmFrequencyNumbers(ComboBox freq, ComboBox shipment, ComboBox dateC, Label errShip)
        {
            // Create a new empty list and assign it as the source of the frequency combobox
            ObservableCollection<Group> emptyList = new ObservableCollection<Group>();
            freq.ItemsSource = emptyList;
            String shipmentName = null;

            // If an item is selected and there are no errors in shipment name
            if ((shipment.SelectedItem) != null && !errShip.IsVisible)
            {
                shipmentName = shipment.SelectedValue.ToString();   // Convert and geth the shipment name
                System.DateTime date = Convert.ToDateTime(dateC.SelectedValue); // Convert and get the date of the shipment

                // Get frequency number list from database using DAO Object
                System.Collections.Generic.List<int> freNoList = _dao.getFrequencyNumbers(shipmentName, date);

                // If the list is not empty
                if (freNoList != null)
                {
                    // Assign combo box with the items in the list
                    freq.ItemsSource = freNoList;
                }
            }

        }

         /* This method dispalys the next frequency number in a label
         @param freqId : ComboBox instance representing frequency numbers
         @param nextFreId : Label instance representing next frequency number
         @reurns nothing */
        private void changeNextFreLabel(ComboBox freqId, Label nextFreId)
        {
            String NextID = (freqId.Items.Count).ToString();   // Count and get the number of items in the frequency combobox
            nextFreId.Content = NextID;
        }

         /* This method detects whether the user operation is update or delete and changes the button text accordingly
         @param dropFreId : Combobox instance representing frequency numbers
         @param nextFreqId : Label instance representing the next frequency number to be issued for a particulat shipment
         @param btn : Button instance representing the add/update button
         @returns nothing */
        private void detectAddOrUpdate(ComboBox dropFreId, Label nextFreqId, Button btn)
        {
            // If a frequency is selected
            if (dropFreId.SelectedValue != null)
            {
                String freqSelected = dropFreId.SelectedValue.ToString(); // Convert and get selected frequency number
                String nextFreq = nextFreqId.Content.ToString();        // Convert and get next frequency number

                // If the selected frequency is next frequency
                if (freqSelected == nextFreq)
                {
                    // It is a add operation
                    btn.Content = "Add";
                }
                else
                {
                    // It is an update operation
                    btn.Content = "Update";
                }
            }
            //If a frequency is not selected
            else
            {
                //It is an add operation
                btn.Content = "Add";
            }
            
        }

         /* This method fills the shipmentDate combobox according to the user selections
         @param shipmentName : ComboBox instance representing the shipment names 
         @param date  : ComboBox instance representing dates
         @param freId : ComboBox instance representing frequency ids
         @param shipmentDate : DatePicker instance representing selling date of a frequency */
        private void fillDate(ComboBox shipmentName, ComboBox date, ComboBox freId, DatePicker shipmentDate)
        {
            // If the button text is "Update" and a shipment is selected
            if (btnAdd.Content.ToString() == "Update" && shipmentName.SelectedValue != null)
            {
                String shipName = shipmentName.SelectedValue.ToString();            // Get and convert shipmentNmae
                System.DateTime shipDate = Convert.ToDateTime(date.SelectedValue);  // Get and convert date
                int frequencyId = Convert.ToInt32(freId.SelectedValue);             // Get and convert frequencyId

                // Get the date through DAO Object and set it in the calendar
                shipmentDate.SelectedDate = _dao.getDate(shipName, shipDate, frequencyId);
            }
            else
            {
                shipmentDate.SelectedDate = DateTime.Now;
            }
        }

         /* This method fills the price per piece textbox according to the user selections
         @param shipmentName : ComboBox instance representing the shipment names 
         @param date  : ComboBox instance representing dates
         @param freId : ComboBox instance representing frequency ids
         @param txtPricePerPiece : TextBox instance representing price per piece of a frequency */
        private void fillPricePerPiece(ComboBox shipmentName, ComboBox date, ComboBox freId, TextBox txtPricePerPiece)
        {
            // If the button text is "Update" and a shipment is selected
            if (btnAdd.Content.ToString() == "Update" && shipmentName.SelectedValue != null)
            {
                String shipName = shipmentName.SelectedValue.ToString();            // Get and convert shipmentNmae
                System.DateTime shipDate = Convert.ToDateTime(date.SelectedValue);  // Get and convert date
                int frequencyId = Convert.ToInt32(freId.SelectedValue);             // Get and convert frequencyId

                // Get price per pieces through DAO object and assign it to the relevent textbox
                txtPricePerPiece.Text = (_dao.getPrice(shipName, shipDate, frequencyId)).ToString();
            }
            else
            {
                txtPricePerPiece.Text = "";
            }
        }

        /* This method Fills the Number of pieces textbox according to the user selections
           @param shipmentName : ComboBox instance representing the shipment names 
           @param date  : ComboBox instance representing dates
           @param freId : ComboBox instance representing frequency ids
           @param txtNoOfPieces : TextBox instance representing number of pieces of a frequency */
        private void fillNoOfPieces(ComboBox shipmentName, ComboBox date, ComboBox freId, TextBox txtNoOfPieces)
        {
            // If the button text is "Update" and a shipment is selected
            if (btnAdd.Content.ToString() == "Update" && shipmentName.SelectedValue != null)
            {
                String shipName = shipmentName.SelectedValue.ToString();            // Get and convert shipmentNmae
                System.DateTime shipDate = Convert.ToDateTime(date.SelectedValue);  // Get and convert date
                int frequencyId = Convert.ToInt32(freId.SelectedValue);             // Get and convert frequencyId

                // Get number of pieces through DAO object and assign it to the relevent textbox
                txtNoOfPieces.Text = (_dao.getNoOfPieces(shipName, shipDate, frequencyId)).ToString();
            }
            else
            {
                txtNoOfPieces.Text = "";
            }
        }

        // This method resets all the form controlls
        // @returns nothing
        private void resetForm()
        {
            txtAddCostPiece.Text = "";
            txtAddNoPieces.Text = "";
            dropShipmentName.Text = "";
            dropDate.Text = "";
            txtPricePerPiece.Text = "";
            txtAddCostPiece.Text = "";
            txtNumberOfPieces.Text = "";
            txtPricePerPiece.Text = "";
            txtAddTotalPrice.Text = "";

            // Hide all error lables
            errNoOfPieces.Visibility = Visibility.Hidden;
            errPricePerPiece.Visibility = Visibility.Hidden;
            errShipmentName.Visibility = Visibility.Hidden;
        }

        // This method populates currency types combo box
        // @param cmbBox : ComboBox instance representing the currency types combobox
        // @returns nothing
        private void populateCurrencyTypes(ComboBox curTypes)
        {
            // Get the currency types through DAO object and fill the combobox using it
            curTypes.ItemsSource = _dao.getCurrencyTypes();  
        }

        // This method reloads the table displaying data
        // @returns nothing
        private void refreshTable()
        {
            // Create new viewsource and set the current viewsource to it
            System.Windows.Data.CollectionViewSource showBnSDetailViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("showBnSDetailViewSource")));

            // Create new db Context
            adoraDBContext adbc = new adoraDBContext();
            adbc.BnSFrequencies.Load(); // Reload BnSFrequency table
            adbc.showBnSDetails.Load(); // Reload showBnSDetails table

            // Reassign the viewsource with reloaded BnSDetails view
            showBnSDetailViewSource.Source = adbc.showBnSDetails.Local; 
        }

        // This method calculates total price according to the selected currency type
        private void dropCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check whether the required fields are empty
            if ((txtAddNoPieces.Text != null && txtAddNoPieces.Text != "") && (txtPricePerPiece.Text != null && txtPricePerPiece.Text != ""))
            {
                int noOfPieces = Convert.ToInt32(txtNumberOfPieces.Text);           // get and convert no Of Pieces
                double pricePerPiece = Convert.ToDouble(txtPricePerPiece.Text);     // get and convert price Per Piece           
                String currencyType = dropCurrency.SelectedValue.ToString();        // get and convert Currency Type

                // Calculate total price using handler
                txtAddTotalPrice.Text = (_handler.calctotalPrice(pricePerPiece, noOfPieces, currencyType)).ToString("F");
                lblCurrency3.Content = dropCurrency.SelectedValue.ToString();       // Change lable text to display currency type
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected search date
            DateTime? picker = calSearchDate.SelectedDate;
            String date = picker.ToString();

            // If only a date is specified
            if (date != "" && (txtSearchShipName.Text == null || txtSearchShipName.Text == ""))
            {
                StockLotsSalesSearch search = new StockLotsSalesSearch(calSearchDate.SelectedDate.Value);
                search.Show();
            }
                // If only a name is specified
            else if (date == "" && (txtSearchShipName.Text != null && txtSearchShipName.Text != ""))
            {
                StockLotsSalesSearch search = new StockLotsSalesSearch(txtSearchShipName.Text);
                search.Show();
            }
                // If both name and a date is specified
            else if (date != "" && (txtSearchShipName.Text != null && txtSearchShipName.Text != ""))
            {
                StockLotsSalesSearch search = new StockLotsSalesSearch(calSearchDate.SelectedDate.Value,txtSearchShipName.Text);
                search.Show();
            }
                // If nothing is specified
            else
                MessageBox.Show("Please provide Date and/or shipment name to search");
        }

        private void txtNumberOfPieces_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !_val.IsNumberKey(e.Key) && !_val.IsActionKey(e.Key);
        }

        private void txtPricePerPiece_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPricePerPiece.Text.IndexOf(".") == -1)
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
