using HistoricalProject;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemoryTest
{
    public class HistoricalTest
    {

        [Test]
        public void HistoricalConstructorTest() 
        {
            Historical historical = new Historical();

            Assert.IsNotNull(historical.MyWritter);
            Assert.IsNotNull(historical.MyReader);

        }

        [Test]
        public void SaveData_ReturnsTrue()
        {
            //Arrange
            Historical historical = new Historical();

            List<Data> data = new List<Data>();

            var mock = new Mock<MyStreamWritter>();
            mock.Setup(x => x.Open(It.IsAny<string>())).Verifiable();
            mock.Setup(x => x.Close()).Verifiable();
            mock.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();

            historical.MyWritter = (MyStreamWritter)mock.Object;



            //Act
            bool resutl = historical.SaveData(data);

            //Assert

            Assert.IsTrue(resutl);
        }

        [Test]
        public void SaveData_ReturnsFalse()
        {
            //Arrange
            Historical historical = new Historical();

            List<Data> data = new List<Data>();

            var mock = new Mock<MyStreamWritter>();
            mock.Setup(x => x.Open(It.IsAny<string>())).Throws(new Exception());
            mock.Setup(x => x.Close()).Throws(new Exception());
            mock.Setup(x => x.WriteLine(It.IsAny<string>())).Throws(new Exception());

            historical.MyWritter = mock.Object;



            //Act
            bool resutl = historical.SaveData(data);

            //Assert

            Assert.IsFalse(resutl);
        }

        [Test]
        public void GetDataById_ReturnsNull() 
        {
            //Arrange
            Historical historical = new Historical();

            var mock = new Mock<MyStreamReader>();

            mock.Setup(x => x.Open(It.IsAny<string>())).Throws(new Exception());
            mock.Setup(x => x.Close()).Throws(new Exception());
            mock.Setup(x => x.ReadLine()).Throws(new Exception());

            historical.MyReader = mock.Object;
            //Act

            List<Data> result = historical.GetDataById(1);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetDataByAdresa_ReturnsNull()
        {
            //Arrange
            Historical historical = new Historical();

            var mock = new Mock<MyStreamReader>();

            mock.Setup(x => x.Open(It.IsAny<string>())).Throws(new Exception());
            mock.Setup(x => x.Close()).Throws(new Exception());
            mock.Setup(x => x.ReadLine()).Throws(new Exception());

            historical.MyReader = mock.Object;
            //Act

            List<Data> result = historical.GetDataByAdresa("test");

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetDataByMesec_ReturnsNull()
        {
            //Arrange
            Historical historical = new Historical();

            var mock = new Mock<MyStreamReader>();

            mock.Setup(x => x.Open(It.IsAny<string>())).Throws(new Exception());
            mock.Setup(x => x.Close()).Throws(new Exception());
            mock.Setup(x => x.ReadLine()).Throws(new Exception());

            historical.MyReader = mock.Object;
            //Act

            List<Data> result = historical.GetDataByMesec("test");

            //Assert
            Assert.IsNull(result);
        }


        [Test]
        public void GetAllData_ReturnsNull()
        {
            //Arrange
            Historical historical = new Historical();

            var mock = new Mock<MyStreamReader>();

            mock.Setup(x => x.Open(It.IsAny<string>())).Throws(new Exception());
            mock.Setup(x => x.Close()).Throws(new Exception());
            mock.Setup(x => x.ReadLine()).Throws(new Exception());

            historical.MyReader = mock.Object;
            //Act

            List<Data> result = historical.GetAllData();

            //Assert
            Assert.IsNull(result);
        }
    }
}
