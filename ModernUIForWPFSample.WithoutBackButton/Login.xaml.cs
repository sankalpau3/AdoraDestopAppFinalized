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
using System.Windows.Shapes;
using ModernUIForWPFSample.WithoutBackButton.Data;
using ModernUIForWPFSample.WithoutBackButton.Functions;

namespace ModernUIForWPFSample.WithoutBackButton
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginUser _login = new LoginUser(); //Login object
        MainWindow _main; //main window object
        LoginDetails _details = new LoginDetails(); //login details object
        Encryption _encrypt = new Encryption(); //encryption object
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*initialize strings*/
            string username = txtUsername.Text;
            string password = _encrypt.encryptPassword(txtPassword.Password);
            
            /*check for login*/
            bool val = _login.LoginUserAdora(username,password);

            if (val) /*login true*/
            {
                _details.fetchUser(username, password);
                _details.fetchUserLevel(username, password);

                _main = new MainWindow(); //open main window
                _main.Show();
                this.Close();
                
            }
            else /*login fail*/
            {
                MessageBox.Show("Please Enter correct username and password");
                pbStatus.Visibility = Visibility.Hidden;
            }
        }

        /*close button*/
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
