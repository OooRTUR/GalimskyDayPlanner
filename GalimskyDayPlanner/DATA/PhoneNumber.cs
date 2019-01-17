using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalimskyDayPlanner
{
    public class PhoneNumber//: //IComparable<PhoneNumber>
    {
        public string Number { get; set; } //сам номер
        public string Name { get; set; } //обладатель номера

        public override string ToString()
        {
            return Name + " | " + Number;
        }

       

        public PhoneNumber(string number, string name)
        {
            Number = number;
            Name = name;
        }


        /*
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PhoneNumber objAsNum = obj as PhoneNumber;
            if (objAsNum == null) return false;
            else return Equals(objAsNum);
        }

        public int CompareTo(PhoneNumber other)
        {
            if (other == null)
                return 1;
            else
                return Name.CompareTo(other.Name);
        }
        */
    }
}
