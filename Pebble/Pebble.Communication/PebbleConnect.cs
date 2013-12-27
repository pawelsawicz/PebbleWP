using Pebble.Communication.Enum;
using Pebble.Communication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;

namespace Pebble.Communication
{
    public class PebbleConnect : IPebbleConnect
    {
        public StreamSocket Socket { get; set; }

        public PebbleConnect()
        {
            Socket = new StreamSocket();
        }

        public async Task<ResultType> ConnectToDevice()
        {
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";

            var pairedDevices = await PeerFinder.FindAllPeersAsync();

            if (pairedDevices.Count == 0)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                return ResultType.Error;
            }
            else
            {
                PeerInformation selectedDevice = pairedDevices.First(x => x.DisplayName.Contains("Pebble"));

                if (selectedDevice == null)
                {
                    await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                    return ResultType.Error;
                }
                try
                {
                    await Socket.ConnectAsync(selectedDevice.HostName, "1");
                }
                catch (Exception ex)
                {
                    return ResultType.Error;
                } 

                return ResultType.Succeed;
            }
        }
    }
}
