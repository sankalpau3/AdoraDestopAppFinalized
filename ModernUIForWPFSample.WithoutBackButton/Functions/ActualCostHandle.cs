using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class ActualCostHandle
    {
        public double calTotalCost(ListBox bx1, ListBox bx2)
        {
            int bx1Count = bx1.Items.Count;
            int bx2Count = bx2.Items.Count;
            double subtot1 = 0, subtot2 = 0;

            for (int i = 0; i < bx1Count; i++)
            {
                subtot1 += Convert.ToDouble(bx1.Items[i].ToString());
            }
            for (int i = 0; i < bx2Count; i++)
            {
                subtot1 += Convert.ToDouble(bx2.Items[i].ToString());
            }

                return (subtot1+subtot2);
        }
        public string getUnitType(string allx)
        {
            string unitx = "";
            for(int i= (allx.IndexOf("(")); i <= (allx.IndexOf(")")); i++)
            {
                unitx = unitx + allx[i];
            }
            
            return "";
        }
    }
}
