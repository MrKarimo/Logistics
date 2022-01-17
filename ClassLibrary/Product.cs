using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string PackageType { get; set; }

        public Product(string name, double weigth, string packageType)
        {
            Name = name;
            Weight = weigth;
            PackageType = packageType;
        }
    }
}
