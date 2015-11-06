using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class AccessoryCostData
    {
        string _type;
        double _amount;
        double _cost;
        string _unit;
        string _AcostID;
        int _id;
        string _accID;
        double _weightPItem;
        double _chg;

        public double Chg
        {
            get { return _chg; }
            set { _chg = value; }
        }


        public double WeightPItem
        {
            get { return _weightPItem; }
            set { _weightPItem = value; }
        }

        public string AccID
        {
            get { return _accID; }
            set { _accID = value; }
        }


        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }


        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }


        public string AcostID
        {
            get { return _AcostID; }
            set { _AcostID = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
