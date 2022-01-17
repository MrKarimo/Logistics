using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Truck
    {
        public double Tonnage { get; private set; }

        public Truck(double tonnage)
        {
            Tonnage = tonnage;
        }
    }
}
