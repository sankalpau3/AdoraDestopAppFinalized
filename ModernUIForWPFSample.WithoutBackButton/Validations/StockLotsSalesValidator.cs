using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Validations
{
    class StockLotsSalesValidator
    {
        public bool isShipmentNameValid(ComboBox shipment)
        {
            String shipmentName = null;

            if ((shipment.SelectedItem) != null)
            {
                shipmentName = shipment.SelectedValue.ToString();
            }
            if (shipmentName != null && shipmentName != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isInt(String no)
        {
            Match match = Regex.Match(no, "^[0-9]*$");

            if (match.Success && no != null && no != "0"  && no != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isDouble(String no)
        {
            Match match1 = Regex.Match(no, "^[0-9]*$");
            Match match2 = Regex.Match(no, "^[-+]?[0-9]+\\.[0-9]+$");

            if ((match1.Success || match2.Success) && no != null && no != "0" && no != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
