using System;
using xServer.Core.Networking;
using xServer.Core.Packets;

namespace xServer.Core.PortForward.Local.Packets
{
    [Serializable]
    public class LocalPortForwardConnectResponse : IPacket
    {
        public int ClientId { get; set; }

        public bool IsConnected { get; set; }

        public string SocketInfo { get; set; }

        public LocalPortForwardConnectResponse()
        {

        }

        public LocalPortForwardConnectResponse(int id, bool isConnected, string socketInfo)
        {
            this.ClientId = id;
            this.IsConnected = isConnected;
            this.SocketInfo = socketInfo;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}