using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    public partial class StockLotsSalesSearch : Form
    {
        // Variables to keep Date and shipment name
        DateTime Date;
        String ShipmentName = null;

        public StockLotsSalesSearch(DateTime date)
        {
            InitializeComponent();
            this.CenterToScreen();

            Date = date;

            // Filter search results according to the date entered by the user using table adapter
            this.showBnSDetailsTableAdapter.FillByDate(this.adoraDBSetDataSet.showBnSDetails, Date.ToString());
        }

        public StockLotsSalesSearch(String shipmentTitle)
        {
            InitializeComponent();
            this.CenterToScreen();

            ShipmentName = shipmentTitle;

            // Filter search results according to the name entered by the user using table adapter
            this.showBnSDetailsTableAdapter.FillByName(this.adoraDBSetDataSet.showBnSDetails, ShipmentName);
        }

        public StockLotsSalesSearch(DateTime date, String shipmentTitle)
        {
            InitializeComponent();
            this.CenterToScreen();

            Date = date;
            ShipmentName = shipmentTitle;

            // Filter search results according to the date and name entered by the user using table adapter
            this.showBnSDetailsTableAdapter.FillByBoth(this.adoraDBSetDataSet.showBnSDetails, Date.ToString(), ShipmentName);
        }

        private void StockLotsSalesSearch_Load(object sender, EventArgs e)
        {
           
        }
    }
}
