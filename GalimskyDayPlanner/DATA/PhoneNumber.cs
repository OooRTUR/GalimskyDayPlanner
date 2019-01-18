using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalimskyDayPlanner
{

    public class PhoneNumber : IComparable<PhoneNumber>
    {
        public string Number { get; set; } //сам номер
        public string Name { get; set; } //обладатель номера

        public override string ToString()
        {
            return Name + " | " + Number;
        }

        public int CompareTo(PhoneNumber other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public PhoneNumber(string number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
