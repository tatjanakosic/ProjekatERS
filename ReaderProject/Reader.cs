using HistoricalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderProject
{
    public class Reader : IReader
    {
        public IHistorical Historical { get; set; }

        public Reader() 
        {
            Historical = new Historical();
        }

        public Reader(IHistorical historical) 
        {
            Historical = historical;
        }


        public void WriteData(List<Data> data) 
        {
            foreach (Data d in data)
            {
                Console.WriteLine(d.ToString());
            }
        }

        public bool WriteAllData() 
        {
            List<Data> allData = Historical.GetAllData();
            if(allData == null) 
            {
                return false;
            }
            WriteData(allData);
            return true;
        }

        public bool WriteDataById(int id) 
        {
            List<Data> data = Historical.GetDataById(id);
            if(data == null)
            {
                return false;
            }

            WriteData(data);
            return true;
        }

        public bool WriteDataByAdresa(string adresa)
        {
            List<Data> data = Historical.GetDataByAdresa(adresa);
            if (data == null)
            {
                return false;
            }

            WriteData(data);
            return true;
        }


        public bool WriteDataByMesec(string mesec)
        {
            List<Data> data = Historical.GetDataByMesec(mesec);
            if (data == null)
            {
                return false;
            }

            WriteData(data);
            return true;
        }
    }
}
