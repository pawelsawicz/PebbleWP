using Pebble.Communication.Enum;
using Pebble.Communication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Pebble.Communication
{
    public class PebbleDevice : IPebbleDevice
    {
        private StreamSocket _socket = null;
        private DataWriter _writer = null;
        private DataReader _reader = null;


        public PebbleDevice(StreamSocket stream)
        {
            _socket = stream;
        }        

        public bool IsConnected()
        {
            if (_socket != null && _writer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
