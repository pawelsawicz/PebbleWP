using Pebble.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace Pebble.Communication.Interface
{
    public interface IPebbleConnect
    {
        Task<ResultType> ConnectToDevice();
        StreamSocket Socket { get; set; }
    }
}
