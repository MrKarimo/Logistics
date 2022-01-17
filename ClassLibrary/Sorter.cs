using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfeces
{
    public static class Sorter
    {
        public static List<Storage> Storages { get; private set; }
        public static List<Truck> Trucks { get; private set; }

        public static void InitSorter(List<Storage> storages, List<Truck> trucks )
        {
            Storages = storages;
            Trucks = trucks;
        }

        public static void Transfer(List<Product> products)
        {
            //поиск скалада в который поместится продукция
            foreach(var storage in Storages)
            {
                if(storage.CheckStorage(products.Count()) != 1)
                {
                    storage.TakeProduct(products);
                    while(storage.CheckStorage(0) != -1)
                    {
                        storage.CallTruck(Trucks[new Random().Next(Trucks.Count)]);
                    }
                    return;
                }
            }
            //если не было найдено, то чистим первый склад и отправляем туда
            while (Storages[0].CheckStorage(products.Count()) != -1)
            {
                Storages[0].CallTruck(Trucks[new Random().Next(Trucks.Count)]);
            }
            Storages[0].TakeProduct(products);
            while (Storages[0].CheckStorage(0) != -1)
            {
                Storages[0].CallTruck(Trucks[new Random().Next(Trucks.Count)]);
            }
        }
    }
}
