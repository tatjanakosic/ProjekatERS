using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public class MyStreamWritter : IMyStreamWritter
    {
        public StreamWriter Writter { get; set; }

        public MyStreamWritter() 
        {
            
        }


        public virtual void WriteLine(string line)
        {
            Writter.WriteLine(line);
        }

        public virtual void Open(string fileName)
        {
            if (!File.Exists(fileName)) 
            {
                File.Create(fileName).Dispose();
            }

            Writter = new StreamWriter(fileName, true);
        }

        public virtual void Close()
        {
            Writter.Close();
        }
    }
}
