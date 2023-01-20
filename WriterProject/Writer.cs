using DumpingBufferProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterProject
{
    public class Writer : IWriter
    {
        public IDumpingBuffer DumpingBuffer { get; set; }


        public Writer(IDumpingBuffer dumpingBuffer) 
        {
            DumpingBuffer = dumpingBuffer;
        }

        public Writer() 
        {
            DumpingBuffer = new DumpingBuffer();
        }

        public void SendData(int id, double potrosnja,string adresa, string mesec)
        {
            DumpingBuffer.SaveDataTemporary(id, potrosnja,adresa,mesec);
        }
    }
}
