using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public interface IHistorical
    {

        bool SaveData(List<Data> data);
        List<Data> GetDataById(int dataId);
        List<Data> GetDataByAdresa(string adresa);

        List<Data> GetDataByMesec(string mesec);
        List<Data> GetAllData();
    }
}
