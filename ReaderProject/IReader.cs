using HistoricalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderProject
{
    public interface IReader
    {
        void WriteData(List<Data> data);

        bool WriteAllData();

        bool WriteDataById(int id);

        bool WriteDataByAdresa(string adresa);

        bool WriteDataByMesec(string mesec);
    }
}
