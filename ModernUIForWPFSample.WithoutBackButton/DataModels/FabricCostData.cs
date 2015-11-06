using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class FabricCostData
    {
        int _id;
        string _fabCostId;
        string _type;
        double _amount;
        double _cost;
        string _aCostID;
        double _costPyard;

        public double CostPyard
        {
            get { return _costPyard; }
            set { _costPyard = value; }
        }
       
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public string FabCostId
        {
            get { return _fabCostId; }
            set { _fabCostId = value; }
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
        

        public string ACostID
        {
            get { return _aCostID; }
            set { _aCostID = value; }
        }



    }
}
