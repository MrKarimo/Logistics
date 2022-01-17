using ClassLibrary.Const;
using ClassLibrary.Interfeces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
