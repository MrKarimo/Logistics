using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfeces
{
    //По идеии хранить данные нужно в каком то хранилище (файл, БД),
    //но на данный момент интерфейс будет брать данные из динамической памяти,
    //где условным огрничением будет 100 записей
    public interface IReport
    {
        string GenerateReport();
    }
}
