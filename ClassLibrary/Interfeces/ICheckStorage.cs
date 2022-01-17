using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfeces
{
    public interface ICheckStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns> 1 - больше вместиомсти, -1 - меньше 95%</returns>
        int CheckStorage(int m);
    }
}
