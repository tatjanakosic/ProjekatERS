using HistoricalProject;
using Moq;
using NUnit.Framework;
using ReaderProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemoryTest
{
    public class ReaderTest
    {

        [Test]
        public void ReaderEmptyConstructorTest() 
        {
            Reader reader = new Reader();

            Assert.IsNotNull(reader.Historical);
        }


        [Test]
        public void ReaderConstructorWithParametersTest()
        {

            Historical historical = new Historical();
            Reader reader = new Reader(historical);

            Assert.IsNotNull(reader.Historical);

        }

        [Test]
        public void WriteAllData_ReturnsFalse() 
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetAllData()).Returns((List<Data>)null);
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteAllData();

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteAllData_ReturnsTrue()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetAllData()).Returns(new List<Data>());
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteAllData();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WriteDataById_ReturnsFalse()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataById(It.IsAny<int>())).Returns((List<Data>)null);
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataById(1);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteDataById_ReturnsTrue()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataById(It.IsAny<int>())).Returns(new List<Data>());
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataById(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WriteDataByAdresa_ReturnsFalse()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataByAdresa(It.IsAny<string>())).Returns((List<Data>)null);
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataByAdresa("adresa");

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteDataByAdresa_ReturnsTrue()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataByAdresa(It.IsAny<string>())).Returns(new List<Data>());
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataByAdresa("adresa");

            //Assert
            Assert.IsTrue(result);
        }


        [Test]
        public void WriteDataByMesec_ReturnsFalse()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataByMesec(It.IsAny<string>())).Returns((List<Data>)null);
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataByMesec("mesec");

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteDataByMesec_ReturnsTrue()
        {
            //Arrange
            Reader reader = new Reader();

            var mock = new Mock<IHistorical>();
            mock.Setup(x => x.GetDataByMesec(It.IsAny<string>())).Returns(new List<Data>());
            reader.Historical = mock.Object;

            //Act
            bool result = reader.WriteDataByMesec("mesec");

            //Assert
            Assert.IsTrue(result);
        }

        // test stream readera za nepostojeci fajl
        [Test]
        public void GetSetTest()
        {
            Assert.Throws<System.IO.FileNotFoundException>(
                () => {
                    MyStreamReader myStreamReader = new MyStreamReader();
                    myStreamReader.Open("DataBase.txt");
                    myStreamReader.ReadLine();
                    myStreamReader.Close();
                    myStreamReader.Reader = null;

                }
            );
           
        }

    }
}
