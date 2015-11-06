using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class StockLotPurchaseHandle
    {

        public double CalcTotShipment(int No, double PPP, double Trans, double SupCom, double Misc)
        {
            return (No*PPP + Trans + SupCom + Misc);
        }

        public double CalcCPP(int No, double PPP, double Trans, double SupCom, double Misc)
        {
            return ((No*PPP + Trans + SupCom + Misc)/No);
        }


    }
}
