

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class Validations
    {
        /// <summary>
        /// emptyFieldVal checks whether the given textbox is empry 
        /// if so return true and mark the perticular text fieds border with red else return false
        /// </summary>
        /// <param name="txtb"></param>
        /// <returns></returns>

        public bool emptyFieldVal(TextBox txtb, Label err)
        {
            if (String.IsNullOrEmpty(txtb.Text) || String.IsNullOrWhiteSpace(txtb.Text))
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }       
        }

        public bool emptyFieldVal(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text))
            {

                return false;
            }
            else
            {

                return true;
            }
        }

        public bool numberFormatVal(TextBox txtb, Label err)
        {
            String s = txtb.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            Match match2 = Regex.Match(s, "^[-+]?[0-9]+\\.[0-9]+$");
            if (!match1.Success && !match2.Success)
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
               
        }

        public bool intnumberFormatVal(TextBox txtb, Label err)
        {
            String s = txtb.Text;
            Match match1 = Regex.Match(s, "^[0-9]*$");
            if (!match1.Success && s != "0")
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }

        }

        public bool emailVal(TextBox txtb, Label err)
        {
            String s = txtb.Text;
            Match match1 = Regex.Match(s, "^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$");
            if (!match1.Success)
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }

        }

        public bool NIClVal(TextBox txtb, Label err)
        {
            String s = txtb.Text;
            Match match1 = Regex.Match(s, "^[0-9]{9}[vVxX]$");
            if (!match1.Success)
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }

        }

        public bool emptyPassword(PasswordBox pswd, Label err)
        {
            if (String.IsNullOrEmpty(pswd.Password) || String.IsNullOrWhiteSpace(pswd.Password))
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
        }

        public bool confPassword(PasswordBox box1, PasswordBox box2, Label err)
        {
            if (box1.Password.Equals(box2.Password))
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }

        }


        public bool allFieldsFilled(TextBox factoryName, TextBox itemSelect, DatePicker dateSelect, TextBox descriptionText, TextBox noOfPiecesText)
        {
            if (String.IsNullOrEmpty(factoryName.Text) || String.IsNullOrEmpty(itemSelect.Text) || String.IsNullOrEmpty(dateSelect.Text) || String.IsNullOrEmpty(descriptionText.Text) || String.IsNullOrEmpty(noOfPiecesText.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void resetForm(TextBox factoryName, TextBox itemSelect, DatePicker dateSelect, TextBox descriptionText, TextBox noOfPiecesText, Label err)
        {
            factoryName.Text = "";
            itemSelect.Text = "";
            descriptionText.Text = "";
            noOfPiecesText.Text = "";
            dateSelect.Text = "";


            err.Visibility = Visibility.Hidden;

        }

        public bool allFrequencyFieldsFilled(ComboBox feqId, TextBox noOfPieces, TextBox sellingPricePerPiece, DatePicker date)
        {
            if (String.IsNullOrEmpty(feqId.Text) || String.IsNullOrEmpty(noOfPieces.Text) || String.IsNullOrEmpty(sellingPricePerPiece.Text) || String.IsNullOrEmpty(date.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if ((inKey < Key.NumPad0 || inKey > Key.NumPad9) || inKey != Key.Decimal || inKey != Key.OemPeriod)
                {
                    return false;
                }
            }
            return true;
        }
        public bool isDot(Key inkey)
        {
            return inkey == Key.OemPeriod || inkey == Key.Decimal;
        }


        public bool IsActionKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
        }

        public bool emptyFieldVal(ComboBox txtb, Label err)
        {
            if (String.IsNullOrEmpty(txtb.Text) || String.IsNullOrWhiteSpace(txtb.Text))
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
        }

        public bool emptyFieldValbyId(ComboBox txtb, Label err)
        {
            if (txtb.SelectedIndex == -1)
            {
                err.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else
            {
                err.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
        }

       }
}
