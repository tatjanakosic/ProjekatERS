using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public interface IMyStreamWritter
    {
        void WriteLine(string line);
        void Open(string fileName);
        void Close();
    }
}
