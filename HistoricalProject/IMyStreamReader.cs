using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public interface IMyStreamReader
    {
        string ReadLine();
        void Open(string fileName);
        void Close();
    }
}
