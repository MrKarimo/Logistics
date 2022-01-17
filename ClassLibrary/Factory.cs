using ClassLibrary.Const;
using ClassLibrary.Interfeces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassLibrary
{
    public class Factory: IStart, IStop
    {
        public int Speed { get; set; }
        private string NameProduct { get; set; }
        private string PackageType { get; set; }
        private bool State { get; set; }

        public Factory(string nameFactory, string packageType)
        {
            NameProduct = nameFactory + "_product";
            PackageType = packageType;
        }

        private Product CreateProduct()
        {
            Random random = new Random();
            var wiegth = Math.Round(random.NextDouble(), 2) * 10;

            return new Product(NameProduct, wiegth, PackageType);
        }

        public void Start()
        {
            State = true;
        }

        public void Stop()
        {
            State = false;
        }

        private void Work()
        {
            List<Product> products;
            while (State)
            {
                products = new List<Product>();
                for(int i = 0; i < Speed; ++i)
                {
                    products.Add(CreateProduct());
                }

                Sorter.Transfer(products);

                Thread.Sleep(Global.SecToHour);
            }
        }
    }
}
