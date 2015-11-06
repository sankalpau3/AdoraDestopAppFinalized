
namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class FOBPurchasingFabricsData
    {
       private string _fabID;
       private string _Date;
       private  string _fabtype;
       private decimal _priperyard;
       private float _yardage;
       private decimal _transport;

        public string FabID
        {
            get { return _fabID; }
            set { _fabID = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string Fabtype
        {
            get { return _fabtype; }
            set { _fabtype = value; }
        }

        public decimal Priperyard
        {
            get { return _priperyard; }
            set { _priperyard = value; }
        }

        public float Yardage
        {
            get { return _yardage; }
            set { _yardage = value; }
        }

        public decimal Transport
        {
            get { return _transport; }
            set { _transport = value; }
        }
    }
}
