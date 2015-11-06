using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class ActualCostData
    {
        double _totalCost;
        string _cm;
        string _acostID;
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public string AcostID
        {
            get { return _acostID; }
            set { _acostID = value; }
        }
        

        public string Cm
        {
            get { return _cm; }
            set { _cm = value; }
        }
        

        public double TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }
    }
}
