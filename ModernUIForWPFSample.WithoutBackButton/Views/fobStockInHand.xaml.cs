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
using System.Text.RegularExpressions;
using System.IO;
using ModernUIForWPFSample.WithoutBackButton.DAO;
using ModernUIForWPFSample.WithoutBackButton.Functions;
using FirstFloor.ModernUI.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    /// <summary>
    /// Interaction logic for fobStockInHand.xaml
    /// </summary>
    public partial class fobStockInHand : UserControl
    {

        Validations validate = new Validations();

        fobStockInHandDAO dao = new fobStockInHandDAO();
        LoginDetails _userType = new LoginDetails();


        public fobStockInHand()
        {
            InitializeComponent();
        }


        private void textNoOfPieces_KeyUp(object sender, KeyEventArgs e)
        {

            validate.numberFormatVal(textNoOfPieces, errorLabelNoOfPieces);

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dao.populateSearchBarWithAllData(searchCombo);
        }

        public void resetForm()
        {
            textFactoryName.Text = "";
            textItemName.Text = "";
            textCostPerPiece.Text = "";
            textDescription.Text = "";
            textNoOfPieces.Text = "";
            datePick.Text = "";


            errorLabelNoOfPieces.Visibility = Visibility.Hidden;
            imageViewer.Source = null;

        }

        public void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            resetForm();
        }



        private void updateRButton_Checked(object sender, RoutedEventArgs e)
        {
            updateButton.Content = "Update Details";
        }

        private void addNewRButton_Checked(object sender, RoutedEventArgs e)
        {
            updateButton.Content = "Add New Record";
        }



        private void searchCombo_KeyUp(object sender, KeyEventArgs e)
        {
            dao.updateSearchComboBox(searchCombo);
        }

        private void searchCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dao.populateAllOtherTextbox(searchCombo, textFactoryName, textItemName, datePick, textDescription, textNoOfPieces, textCostPerPiece, imageViewer);
        }

        private void searchCombo_DropDownOpened(object sender, EventArgs e)
        {
            dao.populateSearchBarWithAllData(searchCombo);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            dao.addUpdateRecord(updateRButton, addNewRButton, textFactoryName, textItemName, datePick, textDescription, textNoOfPieces, errorLabelNoOfPieces);
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            dao.imageUpload();
        }


        private void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            dao.changeToNextImage(imageViewer);
        }

        private void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            dao.changeToPreviousImage(imageViewer);
        }

        private void deleteCurrentImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this image?", "Current Image Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                dao.deleteCurrentImage(imageViewer);
            }

        }

        private void deleteCurrentRecordButton_Click(object sender, RoutedEventArgs e)
        {
            // If the user is authorized to perform the delete operation
            if (_userType.getUserLevel() == 1 || _userType.getUserLevel() == 2)
            {
                if (MessageBox.Show("Do you want to delete this record ? This action will permenently delete all the images associated with this record !", "Current Record Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    dao.deleteCurrentRecordWithItsImages();
                    resetForm();
                    imageViewer.Source = null;
                    dao.updateSearchComboBox(searchCombo);
                }
            }
            else
            {
                ModernDialog.ShowMessage("You are not privilaged to perform this action", "Access Denied!", MessageBoxButton.OK);
            }

        }

        private void textNoOfPieces_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !validate.IsNumberKey(e.Key) && !validate.IsActionKey(e.Key);
        }
    }
}
