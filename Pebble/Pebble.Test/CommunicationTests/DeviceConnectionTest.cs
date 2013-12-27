using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pebble.Communication.Interface;
using Pebble.Communication;
using FluentAssertions;
using Pebble.Communication.Enum;
namespace Pebble.Test.CommunicationTests
{
    [TestClass]
    public class DeviceConnectionTest
    {
        private IPebbleConnect _pebbleConnect;

        [TestInitialize]
        public void SetUp()
        {
            _pebbleConnect = new PebbleConnect();
        }

        [TestMethod]
        public async Task connect_to_device()
        {
            var result = await _pebbleConnect.ConnectToDevice();
            result.Should().Be(ResultType.Succeed);
        }
    }
}
