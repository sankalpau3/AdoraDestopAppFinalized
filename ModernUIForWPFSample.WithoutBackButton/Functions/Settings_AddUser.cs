using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUIForWPFSample.WithoutBackButton.Data;
using System.Windows.Controls;
using ModernUIForWPFSample.WithoutBackButton.DataModels;
using System.Text.RegularExpressions;
using System.Windows;
using ModernUIForWPFSample.WithoutBackButton.Functions;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class Settings_AddUser
    {
        Settings_AddUserDAO _userDAO = new Settings_AddUserDAO();   //Create an object from Settings_AddUserDAO
        Encryption _encrypt = new Encryption();     //encryption object made

        /*Method To Populate User Types*/
        public void populateUserTypes(ComboBox cmbbox)
        {
            cmbbox.ItemsSource = _userDAO.getUserLevels();
        }

        /*Method to popilate user names*/
        public void populateUserNames(ComboBox cmbbox)
        {
            cmbbox.ItemsSource = _userDAO.getUserNames();
        }

        /*Method to add user*/
        public bool AddUserFunc(TextBox pName, TextBox pUsername, PasswordBox ppassword, ComboBox puserlvl,TextBox pNIC, TextBox pemail)
        {
            string Name = pName.Text;
            string Username = pUsername.Text;
            string Password = _encrypt.encryptPassword(ppassword.Password);
            string UserLvl = puserlvl.SelectedItem.ToString();
            string NIC = pNIC.Text;
            string Email = pemail.Text;

            bool success = _userDAO.addUser(Name,Username,Password,UserLvl,NIC,Email);

            if (success)
            {
                return true; 
            }
            else
                return false;
        }

        /*Methos to Edit User*/
        public bool EditUserFunc(ComboBox cmbUsrName, TextBox pName, TextBox pUsername, PasswordBox ppassword, ComboBox puserlvl, TextBox pNIC, TextBox pemail)
        {
            string cmbusername = cmbUsrName.SelectedItem.ToString();
            string Name = pName.Text;
            string Username = pUsername.Text;
            string Password = _encrypt.encryptPassword(ppassword.Password);
            string UserLvl = puserlvl.SelectedItem.ToString();
            string NIC = pNIC.Text;
            string Email = pemail.Text;


            bool success = _userDAO.editUser(cmbusername,Name, Username, Password, UserLvl, NIC, Email);

            if (success)
            {
                return true;
            }
            else
                return false;
        }

        /*Method to Remove User*/
        public bool RemoveUser(ComboBox username)
        {
            string UsrName = null;

            if (username.SelectedIndex > -1)
            {
                UsrName = username.SelectedItem.ToString();


                bool ok = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes;

                if (ok)
                {
                    if (_userDAO.DeleteUser(UsrName))
                        return true;
                    else
                        return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /*Method to clear entries*/
        public void clear(TextBox pName, TextBox pUsername, PasswordBox ppassword, PasswordBox pconfpass, ComboBox puserlvl, TextBox pNIC, TextBox pemail)
        {
            pName.Text = null;
            pUsername.Text = null; ;
            ppassword.Password = null; ;
            pconfpass.Password = null;
            puserlvl.SelectedIndex = 0;
            pNIC.Text = null;
            pemail.Text = null;

            
        }

        /*Method to Refresh Table*/
        public void RefreshTable(DataGrid dgr)
        {
            _userDAO.RefreshUserTable(dgr);
        }

        /*Method to fill the entries when combo box value is selected*/
        public bool fillBoxes(ComboBox Username, TextBox Name, TextBox Usernamet, ComboBox UserLevel, TextBox NIC, TextBox Email)
        { 
            
            bool value = _userDAO.FillFieldsDAO(Username,Name,Usernamet,UserLevel,NIC,Email);

            if (value)
                return true;
            else
                return false;
        
        }

        /*Validate*/
        public bool validateFields(TextBox Name, TextBox Usernamet,PasswordBox pass, PasswordBox confpass, TextBox NIC, TextBox Email)
        {
            bool value = true;
            
            String s1 = Email.Text;
            Match match1 = Regex.Match(s1, "^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$");

            String s2 = NIC.Text;
            Match match2 = Regex.Match(s2, "^[0-9]{9}[vVxX]$");

            if (String.IsNullOrEmpty(Name.Text) || String.IsNullOrWhiteSpace(Name.Text))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The Name");
            }
            else if (String.IsNullOrEmpty(Usernamet.Text) || String.IsNullOrWhiteSpace(Usernamet.Text))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The Username");
            }
            else if (String.IsNullOrEmpty(pass.Password) || String.IsNullOrWhiteSpace(pass.Password))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The Password");
            }
            else if (String.IsNullOrEmpty(confpass.Password) || String.IsNullOrWhiteSpace(confpass.Password))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The Confirm Password");
            }
            else if (String.IsNullOrEmpty(NIC.Text) || String.IsNullOrWhiteSpace(NIC.Text))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The NIC");
            }
            else if (String.IsNullOrEmpty(Email.Text) || String.IsNullOrWhiteSpace(Email.Text))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Please Fill The Email");
            }
            else if (!(pass.Password.Equals(confpass.Password)))
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("Password and Confirm password don't match");
            }
            else if (!match1.Success)
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("E Mail Format Error");
            }
            else if(!match2.Success)
            {
                value = false;
                System.Windows.Forms.MessageBox.Show("NIC Format Error");
            }

            return value;
        }
    }
}
