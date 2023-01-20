using DumpingBufferProject;
using HistoricalProject;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CacheMemoryTest
{
    public class DumpingBufferTest
    {
       
        [Test]
        public void SaveDataTemporary()
        {
            //Arrange
            DumpingBuffer dupingBuffer = new DumpingBuffer();
            int id = 1;
            double potrosnja = 10;
            string adresa = "test";
            string mesec = "test";

            dupingBuffer.SaveDataTemporary(id, potrosnja, adresa, mesec);

            //Act

            CollectionAssert.IsNotEmpty(dupingBuffer.TemporaryData);
        }

        [Test]
        public void DumpingBufferConstructorTest()
        {
            //Arrange
            DumpingBuffer dupingBuffer = new DumpingBuffer();


            Assert.IsNotNull(dupingBuffer.TemporaryData);
            Assert.IsNotNull(dupingBuffer.Historical);
            Assert.IsTrue(dupingBuffer.On);
        }

        [Test]
        public void CheckState_RetursFalse()
        {
            //Arrange
            DumpingBuffer dupingBuffer = new DumpingBuffer();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.SaveData(It.IsAny<List<Data>>())).Verifiable();
            dupingBuffer.Historical = mock.Object;
            //Act

            bool result = dupingBuffer.CheckState();
            //Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void CheckState_RetursTrue()
        {
            //Arrange
            DumpingBuffer dupingBuffer = new DumpingBuffer();
            for(int i=0; i<8; i++)
            {
                dupingBuffer.TemporaryData.Add(new Data(1, 1, "test", "test"));
            }

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.SaveData(It.IsAny<List<Data>>())).Verifiable();
            dupingBuffer.Historical = mock.Object;
            //Act

            bool result = dupingBuffer.CheckState();
            //Assert
            Assert.IsTrue(result);
        }
    }
}