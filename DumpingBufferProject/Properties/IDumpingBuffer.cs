using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferProject
{
    public interface IDumpingBuffer
    {
        void SaveDataTemporary(int id, double potrosnja, string adresa, string mesec);

        void SendToHistorical();

        bool CheckState();
    }
}
