using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace TaskExecutor.Tests
{
    [TestFixture]
    public class IpAddressTests
    {
        [Test]
        public void GetIPAddress_GivenIPCommandIsSent_ShouldReturnIpAddress()
        {
            //Arrange
            var machineInformation = createIpAddressProcessor();
           
            var expected = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            //Act
            var result = machineInformation.GetIPAddress();

            //Assert
            Assert.AreEqual(expected, result);
        }

        private IpAddressProcessor createIpAddressProcessor()
        {
            return new IpAddressProcessor();
        }
    }
}
