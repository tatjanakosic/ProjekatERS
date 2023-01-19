using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public class MyStreamReader : IMyStreamReader
    {
        public StreamReader Reader { get; set; }

        public MyStreamReader() 
        {
        
        }
        public virtual void Close()
        {
            Reader.Close();
        }

        public virtual void Open(string fileName)
        {
            Reader = new StreamReader(fileName);
        }

        public virtual string ReadLine()
        {
            return Reader.ReadLine();
        }
    }
}
