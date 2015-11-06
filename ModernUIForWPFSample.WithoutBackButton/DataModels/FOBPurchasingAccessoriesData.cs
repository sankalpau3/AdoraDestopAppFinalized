using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class FOBPurchasingAccessoriesData
    {
        string _category;
        decimal _pricePerUnit;
        string _unitType;
        float _noOfUnits;
        decimal _transport;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string UnitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }
        public decimal PricePerUnit
        {
            get { return _pricePerUnit; }
            set { _pricePerUnit = value; }
        }
        public float NoOfUnits
        {
            get { return _noOfUnits; }
            set { _noOfUnits = value; }
        }
        public decimal Transport
        {
            get { return _transport; }
            set { _transport = value; }
        }
    }
}
