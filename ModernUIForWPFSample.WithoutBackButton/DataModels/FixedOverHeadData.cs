using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.DataModels
{
    class FixedOverHeadData
    {
        double _elect;
        double _water;
        double _salary;
        double _fule;
        double _phInt;
        double _ot;
        double _mess;
        double _rent;
        double _tax;
        double _other;
        string _date;
        int _month;
        int _year;
        string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public double Other
        {
            get { return _other; }
            set { _other = value; }
        }
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public double Rent
        {
            get { return _rent; }
            set { _rent = value; }
        }
        public double Mess
        {
            get { return _mess; }
            set { _mess = value; }
        }
        public double Ot
        {
            get { return _ot; }
            set { _ot = value; }
        }
        public double PhInt
        {
            get { return _phInt; }
            set { _phInt = value; }
        }
        public double Fule
        {
            get { return _fule; }
            set { _fule = value; }
        }
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public double Water
        {
            get { return _water; }
            set { _water = value; }
        }
        public double Elect
        {
            get { return _elect; }
            set { _elect = value; }
        }
    }
}
