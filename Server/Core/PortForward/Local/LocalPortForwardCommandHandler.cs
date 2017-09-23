

using xServer.Core.Networking;
using xServer.Core.Packets;
using xServer.Core.PortForward.Local.Packets;

namespace xServer.Core.PortForward.Local
{
    public class LocalPortForwardCommandHandler
    {
        public static void HandleCommand(Client client, IPacket packet)
        {
            var type = packet.GetType();
            if (type == typeof(LocalPortForwardConnectResponse))
            {
                LocalPortForwardConnectResponse response = (LocalPortForwardConnectResponse)packet;
                var forwardClient = client.Value.LocalPortForwardTracker.GetClientById(response.ClientId);
                if (forwardClient != null)
                {
                    forwardClient.HandleResponse(response);
                }
            }
            else if (type == typeof(LocalPortForwardData))
            {
                LocalPortForwardData data = (LocalPortForwardData)packet;
                var forwardClient = client.Value.LocalPortForwardTracker.GetClientById(data.ClientId);
                if (forwardClient != null)
                {
                    forwardClient.SendToHome(data.Data);
                }
            }
            else if (type == typeof(LocalPortForwardDisconnect))
            {
                LocalPortForwardDisconnect disconnectCommand = (LocalPortForwardDisconnect)packet;
                var forwardClient =
                    client.Value.LocalPortForwardTracker.GetClientById(disconnectCommand.ClientId);
                if (forwardClient != null)
                {
                    forwardClient.Disconnect();
                }
            }
        }

    }
}
