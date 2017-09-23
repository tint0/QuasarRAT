using System;
using xClient.Core.Networking;
using xClient.Core.Packets;

namespace xClient.Core.PortForward.Local.Packets
{
    [Serializable]
    public class LocalPortForwardConnect : IPacket
    {
        public int ClientId { get; set; }

        public string RemoteHost { get; set; }

        public int RemotePort { get; set; }

        public LocalPortForwardConnect()
        {

        }

        public LocalPortForwardConnect(int id, string remoteHost, int remotePort)
        {
            this.ClientId = id;
            this.RemoteHost = remoteHost;
            this.RemotePort = remotePort;
        }
        
        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}