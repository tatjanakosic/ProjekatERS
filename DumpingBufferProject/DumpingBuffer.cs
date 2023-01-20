using HistoricalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DumpingBufferProject
{
    public class DumpingBuffer : IDumpingBuffer
    {
        public List<Data> TemporaryData { get; set; }

        public IHistorical Historical { get; set; }

        public bool On { get; set; }
        public DumpingBuffer() 
        {
            TemporaryData = new List<Data>();
            Historical = new Historical();
            On = true;
        }
        public void SaveDataTemporary(int id, double potrosnja,string adresa, string mesec)
        {
            Data data = new Data(id, potrosnja, adresa, mesec);
            TemporaryData.Add(data);
            Console.WriteLine("Dodato u red...\n");
        }

        public void SendToHistorical()
        {
            while (On) 
            {
                Thread.Sleep(2000);
                CheckState();
            }
        }

        public bool CheckState()
        {
            if (TemporaryData.Count < 7)
            {
                return false;
            }

            while (TemporaryData.Count >= 7)
            {
                List<Data> elements = TemporaryData.Take(7).ToList();
                TemporaryData.RemoveRange(0, 7);
                Historical.SaveData(elements);
            }
            return true;
        }
    }
}
