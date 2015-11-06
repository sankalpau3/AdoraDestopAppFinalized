using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUIForWPFSample.WithoutBackButton.Data;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class LoginDetails
    {
        LoginUser _user = new LoginUser(); /*create object from LoginUser*/

        private static string Name_Of_User; /*Variable to store name of logged user*/
        private static int User_Level; /*Variable to store user level*/

        /*method to get user and store in Name_Of_User variable*/
        public void fetchUser(string username,string password)
        {
            Name_Of_User = _user.LoginName(username, password);
        }

        /*method to get user level as an integer*/
        public void fetchUserLevel(string username, string password)
        {
            string level = _user.LoginUserLevel(username, password);
            
            if (level.Equals("Administrator")) /*returns 1 if Admin*/
            {
                User_Level= 1;
            }
            else if (level.Equals("Manager")) /*returns 2 if Manager*/
            {
                User_Level= 2;    
            }
            else if (level.Equals("Data Entry Operator")) /*returns 3 if DEO*/
            {
                User_Level = 3;
            }
            else
            {
                User_Level = -1;
            }
        }

        /*Description for each user type*/
        public string showUserText()
        {
            string text = null;
            if (User_Level == 1)
            {
                text = "> You have Administrator privileges in the system \n" +
                        "> You have access rights of the whole system.";
                return text;
            }
            else if (User_Level == 2)
            {
                text = "> You have Management privileges in the system\n" +
                        "> You have intermediate access rights of the system";
                return text;
            }
            else if (User_Level == 3)
            {
                text = "> You have Data Entry Operator privileges in the system\n" +
                        "> You have minimal access rights in the system\n" +
                        "> In case of an error, please contact a manager";
                return text;
            }
            else
            {
                return null;
            }
        }
        /*Access method of User's Name*/
        public string getUser()
        {
            return Name_Of_User;
        }

        /*Access method of user's level as an integer */
        public int getUserLevel()
        {
            return User_Level;
        }

    }
}
