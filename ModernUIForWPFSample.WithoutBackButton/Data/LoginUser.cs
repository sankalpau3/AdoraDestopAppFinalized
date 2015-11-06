using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    
    class LoginUser
    {
        adoraDBContext _context = new adoraDBContext(); //create a new DB CONTEXT
        MainWindow _main; //create an object from Main Window
        Login _login; //create an object from Login
        public bool LoginUserAdora(String usrname, String pass)
        {
            try
            {
                /*quary to get login*/
                string quary1 = (from user in _context.Users
                                 where user.UserName == usrname && user.password == pass
                                 select user.Name).FirstOrDefault();
                if (quary1 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(System.ArgumentNullException e1)
            {
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"","EXCEPTION");
            }

            return false;
        }

        /*method to get login name*/
        public string LoginName(String usrname, String pass)
        {
            string quary = null;
            try
            {
                /*linq query to get login name*/
                quary = (from user in _context.Users
                                 where user.UserName == usrname && user.password == pass
                                 select user.Name).FirstOrDefault();
            }
            catch (System.ArgumentNullException e1)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "", "EXCEPTION");
            }

            return quary;
        }

        /*method to get login user level*/
        public string LoginUserLevel(String usrname, String pass)
        {
            string quary = null;
            try
            {
                /*linq quary to get user level*/
                quary = (from user in _context.Users
                          where user.UserName == usrname && user.password == pass
                          select user.Type).FirstOrDefault();
            }
            catch (System.ArgumentNullException e1)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "", "EXCEPTION");
            }

            return quary;
        }

    }
}
