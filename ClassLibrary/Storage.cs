using ClassLibrary.Interfeces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Storage: ICallTruck, ICheckStorage, IReport, ITakeProduct
    {
        private int M { get; set; }

        static ReaderWriterLockSlim Productslock = new ReaderWriterLockSlim();
        static ReaderWriterLockSlim Shipmentlock = new ReaderWriterLockSlim();

        private List<Product> products;
        private List<Product> Products { 
            get 
            {
                Productslock.EnterReadLock();
                try
                {
                    return products;
                }
                finally
                {
                    Productslock.ExitReadLock();
                }
            } 
            set 
            {
                Productslock.EnterWriteLock();
                try
                {
                    products = value;
                }
                finally
                {
                    Productslock.ExitWriteLock();
                }
            } 
        }

        private List<List<Product>> shipmentList;
        public List<List<Product>> ShipmentList 
        { get 
            {
                Shipmentlock.EnterReadLock();
                try
                {
                    return shipmentList;
                }
                finally
                {
                    Shipmentlock.ExitReadLock();
                }
            }
            private set
            {
                Shipmentlock.EnterWriteLock();
                try
                {
                    shipmentList = value;
                }
                finally
                {
                    Shipmentlock.ExitWriteLock();
                }
            }
        }

        public Storage(int m)
        {
            M = m;

            Products = new List<Product>();
            ShipmentList = new List<List<Product>>();
        }

        public void CallTruck(Truck truck)
        {
            var tonnage = truck.Tonnage;

            ShipmentList.Add(Shipment(tonnage));
        }

        private List<Product> Shipment(double tonnage)
        {
            int start;
            int finsh;

            List<Product> shipped = new List<Product>();

            do
            {
                FindRange(out start, out finsh, tonnage);
                if(start != finsh)
                {
                    for(;start<finsh;++start)
                    {
                        shipped.Add(Products[start]);
                        Products.RemoveAt(start);
                    }
                }
            }
            while (start != 0 && finsh != 0);

            return shipped;
        }

        private void FindRange(out int start, out int finnish, double tonnage)
        {
            double eps = tonnage;
            double sum = 0;
            start = 0;
            finnish = 0;
            int l = 0;
            for(int r = 0; r<Products.Count; ++r)
            {
                sum += Products[r].Weight;
                while(sum > tonnage && r > l)
                {
                    sum -= Products[l].Weight;
                    ++l;
                }
                var dif = tonnage - sum;
                if(dif < eps)
                {
                    eps = dif;
                    start = l;
                    finnish = r;
                }
            }
        }

        public int CheckStorage(int m)
        {
            var sum = Products.Count + m;

            if (sum < (int)(M * 0.95))
            {
                return -1;
            }
            else if (sum >= (int)(M * 0.95) && sum <= M)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void TakeProduct(List<Product> products)
        {
            Products.AddRange(products);
        }
    }
}
