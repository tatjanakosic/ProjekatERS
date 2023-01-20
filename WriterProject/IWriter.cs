using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterProject
{
    public interface IWriter
    {

        void SendData(int id, double potrosnja, string adresa, string mesec);
    }
}
