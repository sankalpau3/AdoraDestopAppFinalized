using System.Diagnostics;
using System.Windows.Navigation;
using System.Data.Entity;
using System.Windows.Controls;
using System.Linq;
using System;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using ModernUIForWPFSample.WithoutBackButton.Data;
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Media;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    
    public partial class ResourcesControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesControl"/> class.
        /// </summary>
        private adoraDBContext _context = new adoraDBContext();
        Validations _validatetxt = new Validations();
        Settings_AddUser _addUser = new Settings_AddUser();
        CurrencySettingsDAO _dao;                  // Variable to hold data access object
        LoginDetails _userType = new LoginDetails();
        
        public ResourcesControl()
        {
            InitializeComponent();
            _addUser.populateUserTypes(txtUsrLvl);
            _addUser.populateUserNames(txtEditUsername);

            // Initialize the data access object class
            _dao = new CurrencySettingsDAO();

            
        }
        
        /// <summary>
        /// Handles the RequestNavigate event of the Hyperlink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RequestNavigateEventArgs"/> instance containing the event data.</param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
       // adoraDBContext _context = new adoraDBContext();
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource showCurDetailViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("showCurDetailViewSource")));

           
            _context.showCurDetails.Load();
            showCurDetailViewSource.Source = _context.showCurDetails.Local;

            System.Windows.Data.CollectionViewSource userViewSource =
                     ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));

            _context.Users.Load();
            userViewSource.Source = _context.Users.Local;
            // After the data is loaded call the DbSet<T>.Local property  
            // to use the DbSet<T> as a binding source. 
            //showCurDetailViewSource.Source = _context.showCurDetails.Local;
            populateCurrencyTypes(dropCurType);
            btnEditUser.Visibility = Visibility.Hidden;

            if (_userType.getUserLevel() != 1)
            {
                BBCodeBlock bs = new BBCodeBlock();
                try
                {
                    bs.LinkNavigator.Navigate(new Uri("/Views/firstOpen.xaml", UriKind.Relative), this);
                    ModernDialog.ShowMessage("You are not privilaged to access this page", "Access Denied!", MessageBoxButton.OK);
                }
                catch (Exception error)
                {
                    ModernDialog.ShowMessage(error.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
                }
            }

        }

        private void populateCurrencyTypes(ComboBox cmbBox)
        {
            // Get the currency types through DAO object and fill the combobox using it
            cmbBox.ItemsSource = _dao.getCurrencyTypes();
        }

        private void validateValue()
        {
            String s = txtValue.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s, "^[-+]?[0-9]+\\.[0-9]+$");
            if ((!match1.Success && !match2.Success) || s == null || s == "0" || s == "")
            {
                errValue.Visibility = Visibility.Visible;
            }
            else
            {
                errValue.Visibility = Visibility.Hidden;

            }
        }

        private void fillValue()
        {
            // If a currency type is selected and no errors are shown
            if (dropCurType.SelectedItem != null && !errValue.IsVisible)
            {
                // Get the user selected type
                String type = dropCurType.SelectedValue.ToString();

                // Get the id of selected currency type using data access object
                String id = _dao.getCurrencyID(type);

                // Get the value of selected currency type using data access object
                double value = _dao.getValue(id);

                txtValue.Text = value.ToString("F");
            }
            else
            {
                txtValue.Text = "";
            }
        }

        private void detectAddOrUpdate()
        {

            if (dropCurType.SelectedIndex != -1)
            {
                btnAdd.Content = "Update";
            }
            else
            {
                btnAdd.Content = "Add";
            }

        }

        private void refreshTable()
        {
            System.Windows.Data.CollectionViewSource showCurDetailViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("showCurDetailViewSource")));

            adoraDBContext adbc = new adoraDBContext();
            adbc.showCurDetails.Load();

            showCurDetailViewSource.Source = adbc.showCurDetails.Local;

            System.Windows.Data.CollectionViewSource userViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));

            adbc.Users.Load();

            userViewSource.Source = adbc.Users.Local;
        }

        private void txtValue_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateValue();
        }

        private void dropCurType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillValue();
            detectAddOrUpdate();
        }

        private void dropCurType_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            detectAddOrUpdate();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            dropCurType.Text = "";
            txtValue.Text = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            validateValue();

            if (!errValue.IsVisible)
            {
                String curType = dropCurType.Text;
                decimal value = Convert.ToDecimal(txtValue.Text.ToString());

                String Method = btnAdd.Content.ToString();

                // If the operation is 'Add'
                if (Method == "Add")
                {
                    int done = _dao.addNewType(curType);

                    if (done > 0)
                    {
                        int done2 = _dao.addNewCurrencyValue(curType, value);

                        if (done2 > 0)
                        {
                            MessageBox.Show("Successfully added new currency details");
                            dropCurType.Text = "";
                            txtValue.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error occured while adding!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error Occured while adding to DB!");
                    }
                }

                // If the operation is update
                else if (Method == "Update")
                {
                    _context.Currencies.Load();
                    int done = _dao.updateCurrency(curType, value);

                    if (done > 0)
                    {
                        MessageBox.Show("Currency Details updated sucessfully!");
                        dropCurType.Text = "";
                        txtValue.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("You have not modified any value!");
                    }

                }

            }

            else
            {
                MessageBox.Show("Validation Failed! Check the inputs again");
            }
            refreshTable();
            populateCurrencyTypes(dropCurType);
        }


        private void txtAddShipName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAddUName_TextChanged(object sender, KeyEventArgs e)
        {

        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            DataBackup dbck = new DataBackup();


            if (!String.IsNullOrEmpty(txtBackupLoc.Text) && !String.IsNullOrWhiteSpace(txtBackupLoc.Text))
            {
                string path = txtBackupLoc.Text.ToString().Replace("\\", "\\\\");

                if (dbck.backup(path))
                {
                    txtBackupLoc.Text = "";
                    MessageBox.Show("Backup created successfully ", "Successfucl", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Faild to create backup", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Please browse a location to save the database", "Brows Location", MessageBoxButton.OK, MessageBoxImage.Error);
            
            
        }

        private void btnrestore_Click(object sender, RoutedEventArgs e)
        {
            DataBackup dbca = new DataBackup();

            if (!String.IsNullOrEmpty(txtRestore.Text) && !String.IsNullOrWhiteSpace(txtRestore.Text))
            {
                string path = txtRestore.Text.ToString().Replace("\\", "\\\\");

                if (dbca.restoreDatabase(path))
                {
                    txtRestore.Text = "";
                    MessageBox.Show("Restored successfully ", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Faild to Restore", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Please browse a backup file to restore database", "Brows file", MessageBoxButton.OK, MessageBoxImage.Error);
           
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.emptyFieldVal(txtName,lblName);
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.emptyFieldVal(txtUsername, lblUname);
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.emptyPassword(txtPass, lblPass);
        }

        private void txtConfPass_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.confPassword(txtPass,txtConfPass,lblconfPW);
        }

        private void txtNIC_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.NIClVal(txtNIC,lblNIC);
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            _validatetxt.emailVal(txtEmail,lblEMail);
        }

        /*Add User Button Click Event*/
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {

            if (_addUser.validateFields(txtName, txtUsername, txtPass, txtConfPass, txtNIC, txtEmail))
            {
                bool result = _addUser.AddUserFunc(txtName, txtUsername, txtPass, txtUsrLvl, txtNIC, txtEmail);
                /*Add user function called*/
                if (result)
                {
                    _addUser.clear(txtName, txtUsername, txtPass, txtConfPass, txtUsrLvl, txtNIC, txtEmail); //clear values
                    _addUser.RefreshTable(userDataGrid); //refresh table
                    _context.Users.Load(); //load Users from entity
                    refreshTable(); //refresh table
                    _addUser.populateUserNames(txtEditUsername); //Add newly added user to the combo box
                }
            }
        }

        /*selection changed event of Edit Username Combo Box*/
        private void txtEditUsername_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _addUser.clear(txtName, txtUsername, txtPass, txtConfPass, txtUsrLvl, txtNIC, txtEmail);

            if (_addUser.fillBoxes(txtEditUsername, txtName, txtUsername, txtUsrLvl, txtNIC, txtEmail))
                btnEditUser.Visibility = Visibility.Visible;
        }

        /*Reset Button CLick Event*/
        private void btnReset1_Click(object sender, RoutedEventArgs e)
        {
            _addUser.clear(txtName, txtUsername, txtPass, txtConfPass, txtUsrLvl, txtNIC, txtEmail);
            btnEditUser.Visibility = Visibility.Hidden;
        }

        /*Edit User Button Press Event*/
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (_addUser.validateFields(txtName, txtUsername, txtPass, txtConfPass, txtNIC, txtEmail))
            {

                bool result = _addUser.EditUserFunc(txtEditUsername, txtName, txtUsername, txtPass, txtUsrLvl, txtNIC, txtEmail);
                /*Calling Edit User Function*/

                if (result)
                {
                    _addUser.clear(txtName, txtUsername, txtPass, txtConfPass, txtUsrLvl, txtNIC, txtEmail); //clear the boxes
                    _addUser.RefreshTable(userDataGrid); //refresh table
                    _context.Users.Load(); //load user values
                  
                    _addUser.populateUserNames(txtEditUsername); //populate usernames
                    btnEditUser.Visibility = Visibility.Hidden; //hide update button

                    refreshTable(); //refresh table
                }
            }
        }

        /*Delete User Button Press Event*/
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            /*deleting user*/
            if (_addUser.RemoveUser(txtEditUsername)) //if removing success
            {
                _addUser.clear(txtName, txtUsername, txtPass, txtConfPass, txtUsrLvl, txtNIC, txtEmail); //clear boxes
                _addUser.RefreshTable(userDataGrid);
                _context.Users.Load(); //load table values
                refreshTable(); //refresh table
                _addUser.populateUserNames(txtEditUsername);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "AdoraSystemBackup" + DateTime.Now.ToString().Replace(':', '_').Replace(' ', '_').Replace('/', '_'); // Default file name
            dlg.DefaultExt = ".bak"; // Default file extension
            dlg.Filter = "SQL server backup (.bak)|*.bak"; // Filter files by extension


            // Show save file dialog boxS
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Set document path to text box
                txtBackupLoc.Text = dlg.FileName;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBackup dbck = new DataBackup();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "AdoraSystemBackup" + DateTime.Now.ToString().Replace(':', '_').Replace(' ', '_').Replace('/', '_'); // Default file name
            dlg.DefaultExt = ".bak"; // Default file extension
            dlg.Filter = "SQL server backup (.bak)|*.bak"; // Filter files by extension


            // Show save file dialog boxS
            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                txtRestore.Text = dlg.FileName;
            }
        }

    }


}
