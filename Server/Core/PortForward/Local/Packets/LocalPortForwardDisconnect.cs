using System;
using xServer.Core.Networking;
using xServer.Core.Packets;

namespace xServer.Core.PortForward.Local.Packets
{
    [Serializable]
    public class LocalPortForwardDisconnect : IPacket
    {
        public int ClientId { get; set; }

        public LocalPortForwardDisconnect()
        {
        }

        public LocalPortForwardDisconnect(int id)
        {
            this.ClientId = id;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}