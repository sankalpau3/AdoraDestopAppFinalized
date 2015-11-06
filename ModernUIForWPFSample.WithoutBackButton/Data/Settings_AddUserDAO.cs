using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class Settings_AddUserDAO
    {

        adoraDBContext _context = new adoraDBContext(); //create a new DB CONTEXT

        // This method returns User Levels
        public List<String> getUserLevels()
        {
            try
            {
                //LINQ query to retrieve UserLevels from DB
                var types = (from e in _context.UserTypes
                                 select e.UserTypeName
                  ).Distinct().ToList();

                return types;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return null;
            }
        }

        /*Get User Names*/
        public List<String> getUserNames()
        {
            try
            {
                //LINQ query to retrieve UserNames from DB
                var types = (from e in _context.Users
                             select e.UserName
                  ).Distinct().ToList();

                return types;

            }
            catch (System.ArgumentNullException e)
            {
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return null;
            }
        }

        /*Add User*/
        public bool addUser(string pName, string pUsername, string ppassword, string puserlvl,string pNIC, string pemail)
        {
            try {
                //create a User object  
                User usr = new User();
                
                usr.Name = pName;
                usr.UserName = pUsername;
                usr.Type = puserlvl;
                usr.password = ppassword;
                usr.NIC = pNIC;
                usr.Email = pemail;

                _context.Users.Add(usr);
                _context.SaveChanges();

                MessageBox.Show("SUCCESSFULLY ADDED","SUCCESS");
                return true;
            }
            catch (System.ArgumentNullException e)
            {
                return false;
            }
            catch (System.InvalidOperationException e)
            {
                return false;
            }
            catch (System.NotSupportedException e)
            {
                return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e+"","EXCEPTION");
                return false;
            }
        }

        /*Edit User*/
        public bool editUser(string combouser,string pName, string pUsername, string ppassword, string puserlvl, string pNIC, string pemail)
        {
            try
            {
                User usr = _context.Users.First(i => i.UserName == combouser); //select row with username
                /*add values to User variable*/
                usr.Name = pName; 
                usr.Type = puserlvl;
                usr.password = ppassword;
                usr.NIC = pNIC;
                usr.Email = pemail;

                _context.SaveChanges(); //sace changes to AdoraDBContext

                MessageBox.Show("SUCCESSFULLY UPDATED", "SUCCESS");
                return true;
            }
            catch (System.ArgumentNullException e)
            {
                return false;
            }
            catch (System.InvalidOperationException e)
            {
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "", "EXCEPTION");
                return false;
            }
        }


        /*Delete User*/
        public bool DeleteUser(string combouser)
        {
            try
            {
                User usr = _context.Users.FirstOrDefault(i => i.UserName == combouser); //select row with username

                _context.Users.Remove(usr); //remove row
                _context.SaveChanges(); //save changes to Adora DB Context

                MessageBox.Show("SUCCESSFULLY REMOVED", "SUCCESS"); //show success message
                return true;
            }
            catch (System.ArgumentNullException e)
            {
                return false;
            }
            catch (System.InvalidOperationException e)
            {
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "", "EXCEPTION");
                return false;
            }
        }

        /*Refresh User Table*/
        public void RefreshUserTable(DataGrid dg)
        {
            dg.Items.Refresh();
        
        }

        /*Fill Fields in the View when a selection is made*/
        public bool FillFieldsDAO(ComboBox EditUsername, TextBox pName, TextBox ppUsername, ComboBox puserlvl, TextBox pNIC, TextBox pemail)
        {
            string pUsername = null;
            if (EditUsername.SelectedIndex > -1)
            {
                pUsername = EditUsername.SelectedItem.ToString(); //get username

                try
                {
                    /*select Name from DB*/
                    var Name = (from e in _context.Users
                                where (e.UserName == pUsername)
                                select e.Name
                                    ).SingleOrDefault();

                    /*select UserLevel from DB*/
                    var UserLevel = (from e in _context.Users
                                     where (e.UserName == pUsername)
                                     select e.Type
                                    ).SingleOrDefault();

                    /*select NIC from DB*/
                    var NIC = (from e in _context.Users
                               where (e.UserName == pUsername)
                               select e.NIC
                                    ).SingleOrDefault();

                    /*select Email from DB*/
                    var Email = (from e in _context.Users
                                 where (e.UserName == pUsername)
                                 select e.Email
                                    ).SingleOrDefault();

                    /*Assign values to the text boxes and combo boxes*/
                    pName.Text = Name.ToString();
                    ppUsername.Text = EditUsername.SelectedItem.ToString();
                    puserlvl.SelectedItem = UserLevel.ToString();
                    pNIC.Text = NIC.ToString();
                    pemail.Text = Email.ToString();

                    return true;



                }
                catch (System.ArgumentNullException e)
                {
                    return false;
                }
                catch (System.InvalidOperationException e)
                {
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
