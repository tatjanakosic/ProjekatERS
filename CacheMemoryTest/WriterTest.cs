using DumpingBufferProject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterProject;

namespace CacheMemoryTest
{
    public class WriterTest
    {

        [Test]
        public void WriterEmptyConstructorTest() 
        {
            Writer writer = new Writer();

            Assert.IsNotNull(writer.DumpingBuffer);
        }

        [Test]
        public void WriterConstructorwithParametersTest()
        {
            DumpingBuffer db = new DumpingBuffer();
            Writer writer = new Writer(db);

            Assert.IsNotNull(writer.DumpingBuffer);
        }
    }
}
