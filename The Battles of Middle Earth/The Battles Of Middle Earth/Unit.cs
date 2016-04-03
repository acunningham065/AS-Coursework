using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Battles_Of_Middle_Earth
{
    class Unit
    {
        //Define fields
        double _health = 0;
        double _minDamage = 0;
        double _maxDamage = 0;
        int _iconForUnit = 0;
        int _owner = 0;
        int _range = 1;

        //default constructor
        public Unit()
        { 
        }


        //Overload constructor
        public Unit(double health, double minDamage, double maxDamage, int iconForUnit, int owner)
        {
            _health = health;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            _iconForUnit = iconForUnit;
            _owner = owner;

        }//End overloaded constructor


        //Overload constructor
        public Unit(double health, double minDamage, double maxDamage, int iconForUnit, int owner, int range)
        {
            _health = health;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            _iconForUnit = iconForUnit;
            _owner = owner;
            _range = range;

        }//End overloaded constructor

        //Property declaration

        public double Health 
        {
            get { return _health; }

            set { _health = value; }

        }//End Health

        public double MinDamage
        {
            get { return _minDamage; }

            set { _minDamage = value; }

        }//End MinDamage

        public double MaxDamage
        {
            get { return _maxDamage; }

            set { _maxDamage = value; }

        }//End MaxDamage


        public int IconForUnit
        {
            get { return _iconForUnit; }

            set { _iconForUnit = value; }

        }//End IconForUnit

        public int Owner
        {
            get { return _owner; }

            set { _owner = value; }

        }//End Owner

        public int Range
        {
            get { return _range; }

            set { _range = value; }

        }//End PositionOnBoard

    }//End Unit Class
}
